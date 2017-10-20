#load "packages/FSharp.Formatting/FSharp.Formatting.fsx"
#r @"packages/FAKE/tools/FakeLib.dll"
#r @"packages/RazorEngine/lib/net45/RazorEngine.dll"

open System
open System.IO

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

let writeSpansHtml spans =
  MarkdownDocument([Span spans], emptyDict)
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
      content
    | _ -> failwithf "invalid markdown structure in '%s'" id

  {
    Id = id
    ShortTitle = short
    Thumbnail = "images/aktualnosci/2017_kolorowy_piornik/Kolorowy_piornik_1500x1000.jpg"
    LongTitle = long
    Abstract = abst
    Content = """<p>Koniec wakacji zbliża się wielkimi krokami, a wraz z nim początek roku szkolnego. Dla nas to świetna okazja do tego, żeby wspólnie zrobić coś dobrego. Przez ostatnie dwa tygodnie w naszym biurze zrobiło się jeszcze bardziej kolorowo, a to wszystko dzięki akcji  &#8222;Kolorowy piórnik&#8221; i wszystkim kolorowym przyborom szkolnym, które gromadziły się w naszych pokojach. Wspólnymi siłami udało nam się zebrać dość sporą wyprawkę szkolną, która trafiła w ręce Fundacji Hospicyjnej, wspierającej dzieci z osieroconych rodzin. </p> 
    <img src="images/aktualnosci/2017_kolorowy_piornik/Kolorowy_piornik_01.jpg" class="img-responsive" style="width: 410px; padding-left: 10px; display: inline-block;"> 
    <img src="images/aktualnosci/2017_kolorowy_piornik/Kolorowy_piornik_02.jpg" class="img-responsive" style="width: 410px; padding-left: 10px; display: inline-block;">"""
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