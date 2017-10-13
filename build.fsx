#load "packages/FSharp.Formatting/FSharp.Formatting.fsx"
#r @"packages/FAKE/tools/FakeLib.dll"
#r @"packages/RazorEngine/lib/net45/RazorEngine.dll"

open System
open System.IO

open Fake

open RazorEngine
open RazorEngine.Templating

let content = __SOURCE_DIRECTORY__
let output  = __SOURCE_DIRECTORY__ </> "output"

let copyFiles () =
  for dir in [ "css"; "js"; "images"; "fonts" ] do
    ensureDirectory (output </> dir)
    CopyRecursive (content </> dir) (output </> dir) true
    |> Log "Copying: "

type Website = 
  { Title : string }

let generate () =
  let template = File.ReadAllText (content </> "index.cshtml")
  let website = { Title = "IHS Markit" }
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