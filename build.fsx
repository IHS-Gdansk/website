#load "packages/FSharp.Formatting/FSharp.Formatting.fsx"
#r @"packages/FAKE/tools/FakeLib.dll"

open Fake

let content = __SOURCE_DIRECTORY__
let output  = __SOURCE_DIRECTORY__ </> "output"

let copyFiles () =
  for dir in [ "css" ] do
    ensureDirectory (output </> dir)
    CopyRecursive (content </> dir) (output </> dir) true
    |> Log "Copying: "

let generate () =
  ()

Target "Generate" (fun _ ->
  copyFiles()
  generate()
)

Target "Preview" (fun _ -> ())

"Generate"
  ==> "Preview"

RunTargetOrDefault "Preview"