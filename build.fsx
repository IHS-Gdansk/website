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
    { Id = "2017_InfoShare"
      ShortTitle = "InfoShare 2017"
      Thumbnail = "images/aktualnosci/2017_InfoShare/DSCF4698-1500x1000.jpeg"
      Title = "InfoShare, 16-18 maja 2017 r."
      Abstract = "<p>W dniach 16&ndash;18 maja 2017 r. w AmberExpo odbyła się konferencja InfoShare 2017, której jednym ze sponsorów była firma IHS Markit.</p>"
      Content = """<p>Jedenasta edycja technologicznej konferencji Infoshare za nami! Cieszymy się, że największe tego typu wydarzenie organizowane w Europie Środkowo-Wschodniej odbyło się w Gdańsku. Tematyka konferencji dotykała takich zagadnień jak: #FrontEnd, #Java, #DevOps i wiele innych.</p>
      <p class="text-center">
          <img src="images/aktualnosci/2017_InfoShare/DSCF4698-1500x1000.jpeg" class="img-responsive" alt="2017 InfoShare">
      </p>
      <p>Jak co roku organizatorzy zaprosili wielu interesujących prelegentów. W gronie tym znaleźli się developerzy i architekci z takich firm jak: Google, Netflix czy Niebezpiecznik.pl. Ze względu na dogodną lokalizację wydarzenia wielu naszych pracowników miało możliwość przybyć na wybrane prelekcje.</p>
      <p class="text-center">
          <img src="images/aktualnosci/2017_InfoShare/DSCF4682-1500x1000.jpeg" class="img-responsive" alt="2017 InfoShare">
      </p>
      <p>Podczas pierwszego dnia konferencji wykład Stephena Rivasa zgromadził dużą widownię. Drugi dzień przyniósł wiele ciekawych tematów takich jak: &#8222;Asynchronous by default, synchronous when necessary&#8221;, czy &#8222;From 0 to DevOps in 80 Days&#8221;. Organizatorzy zapewnili uczestnikom wiele atrakcji, wieczorem po pierwszym dniu konferencji można było udać się na koncert Fisz Emade organizowany w Starym Maneżu lub w piątkowy poranek wybrać się na rejs po Motławie. Wydarzenie zgromadziło na terenie AmberExpo kilka tysięcy zainteresowanych, więc zapewne możecie sobie wyobrazić jak wyglądały kolejki w kierunku foodtruck'ów w porze lunchu.&#9786;</p>
      <p class="text-center">
          <img src="images/aktualnosci/2017_InfoShare/DSCF4710-1500x1000.jpeg" class="img-responsive" alt="2017 InfoShare">
      </p>
      <p>Doceniamy przygotowanie organizatorów oraz pomysłowość pozostałych wystawców. Była to dla nas świetna okazja do rozmów, dyskusji, zaczerpnięcia inspiracji oraz poznania konkurencji.</p>
      <p class="text-center">
          <img src="images/aktualnosci/2017_InfoShare/InfoShare-04.jpeg" class="img-responsive" style="width: 400px; display: inline-block;" alt="2017 InfoShare">
          <img src="images/aktualnosci/2017_InfoShare/InfoShare-05.jpeg" class="img-responsive" style="width: 410px; padding-left: 10px; display: inline-block;" alt="2017 InfoShare">
      </p>
      <p>Do zobaczenia w przyszłym roku!</p>"""}
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