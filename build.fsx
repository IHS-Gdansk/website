#load "packages/FSharp.Formatting/FSharp.Formatting.fsx"
#r @"packages/FAKE/tools/FakeLib.dll"
#r @"packages/RazorEngine/lib/net45/RazorEngine.dll"

open System
open System.IO
open System.Text.RegularExpressions

open Fake

open FSharp.Markdown

open RazorEngine
open RazorEngine.Templating

let content = __SOURCE_DIRECTORY__
let output  = __SOURCE_DIRECTORY__ </> "output"

let copyFiles () =
  for dir in [ "css"; "js"; "images"; "fonts" ] do
    ensureDirectory (output </> dir)
    CopyRecursive (content </> dir) (output </> dir) true
    |> Log "Copying: "

type Event =
  { Id : string
    ShortTitle : string
    LongTitle : string
    Thumbnail : string
    Abstract : string
    Content : string }

type Website = 
  { Title : string
    Events : Event list }

let emptyDict = Collections.Generic.Dictionary<_,_>()

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

let writeSpansHtml spans =
  MarkdownDocument([Span spans], emptyDict)
  |> Markdown.WriteHtml

let writeParasHtml paras =
  MarkdownDocument(paras,emptyDict)
  |> Markdown.WriteHtml

let event (id, markdown : MarkdownDocument) =
  let short,long,abst,content =
    match markdown.Paragraphs with
    | Heading (1, short) ::
      Heading (2, long)  ::
      Paragraph abst     ::
      content ->
      writeSpansHtml short,
      writeSpansHtml long,
      writeSpansHtml abst,
      writeParasHtml content
    | _ -> failwithf "invalid markdown structure in '%s'" id

  let thumbnail = 
    match content with
    | Regex """<img src="(.*?)" """ [src] -> src
    | _ -> failwithf "cannot find any image in '%s'" id

  {
    Id = id
    ShortTitle = short
    Thumbnail = thumbnail
    LongTitle = long
    Abstract = abst
    Content = content
  }

let generate () =
  let events =
    DirectoryInfo(content </> "content" </> "events").EnumerateFiles()
    |> Seq.filter (fun fi -> fi.Name.EndsWith ".md")
    |> Seq.map (fun fi -> 
      Path.GetFileNameWithoutExtension fi.Name,
      Markdown.Parse (File.ReadAllText fi.FullName))
    |> Seq.map event
    |> Seq.toList
    |> List.rev
  
  let template = File.ReadAllText (content </> "index.cshtml")
  let website = { Title = "IHS Markit"; Events = events }
  let html = Engine.Razor.RunCompile(template, "key", null, website)
  File.WriteAllText (output </> "index.html", html)

Target "Generate" (fun _ ->
  copyFiles()
  generate()
)

Target "Preview" (fun _ -> ())

"Generate"
  ==> "Preview"

RunTargetOrDefault "Preview"