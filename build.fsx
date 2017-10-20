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

type Event =
  { Id : string
    ShortTitle : string
    Thumbnail : string
    Title : string
    Abstract : string
    Content : string }

type Website = 
  { Title : string
    Events : Event list }

let generate () =
  let events = [
    { Id = "2017_kolorowy_piornik"
      ShortTitle = "Kolorowy piórnik"
      Thumbnail = "images/aktualnosci/2017_kolorowy_piornik/Kolorowy_piornik_1500x1000.jpg"
      Title = "Kolorowy piórnik, 19 sierpnia 2017 r."
      Abstract = "<p>Koniec wakacji zbliża się wielkimi krokami, a wraz z nim początek roku szkolnego. Dla nas to świetna okazja do tego, żeby wspólnie zrobić coś dobrego.</p>"
      Content = """<p>Koniec wakacji zbliża się wielkimi krokami, a wraz z nim początek roku szkolnego. Dla nas to świetna okazja do tego, żeby wspólnie zrobić coś dobrego. Przez ostatnie dwa tygodnie w naszym biurze zrobiło się jeszcze bardziej kolorowo, a to wszystko dzięki akcji  &#8222;Kolorowy piórnik&#8221; i wszystkim kolorowym przyborom szkolnym, które gromadziły się w naszych pokojach. Wspólnymi siłami udało nam się zebrać dość sporą wyprawkę szkolną, która trafiła w ręce Fundacji Hospicyjnej, wspierającej dzieci z osieroconych rodzin. </p> 
      <img src="images/aktualnosci/2017_kolorowy_piornik/Kolorowy_piornik_01.jpg" class="img-responsive" style="width: 410px; padding-left: 10px; display: inline-block;"> 
      <img src="images/aktualnosci/2017_kolorowy_piornik/Kolorowy_piornik_02.jpg" class="img-responsive" style="width: 410px; padding-left: 10px; display: inline-block;">"""}
  ]
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