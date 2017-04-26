# Rozwijanie strony IHS Gdańsk

Celem istnienia strony jest budowanie "twarzy" naszego gdańskiego biura.

## Wspólnie

Zmiany może zaproponować ktokolwiek. Jeśli jesteś naszym kolegą / koleżanką możesz mieć wpływ na wygląd [ihsgdansk.com](http://ihsgdansk.com/) i prezentowaną treść. Wyślij prośbę o dostęp do projektu do {?}.

Inicjatywa nie jest tez osadzona w prózni i bedzie sie zapewne przeplatac z innymi inicjatywami w naszym biurze takimi jak np. "Ajejczes Magazin".

### Jak uruchomić stronę lokalnie

Wystarczy otworzyć plik `index.html` w przeglądarce ;)

Jeśli ~~jesteś zepsutym frontendowcem~~ lubisz pragmatyczne nowoczesne rozwijanie stron z automatycznym przeładowywaniem, `live-server` jest przygotowany dla Ciebie:

```shell
npm i
npm run live
```

## Iteracyjnie

Tworzenie strony IHS Gdańsk to proces i nie chcieliśmy "przestrzelic". Zaczęliśmy od czegoś prostego aby potem to rozwijać. Przykladowo jezeli ktos chcialby opisac któras z grup pracowników w naszym biurze mozna zaczac od krótkiego opisu co dana grupa robi, ile osób, od kiedy istnieje. W kolejnych wersjach strony można to rozwijać, zamieszczać zdjęcia, historie grupy, opisy projektów, wywiady dla prasy ;-)

## Zagadnienia do opracowania

> TODO: Usuwanie/odhaczanie zrobionych - zależy czy to lista "pozostałych", czy wizualizacja postępów

> TODO: Przegląd pomysłów, bo część wydaje się bez sensu. Im więcej treści, tym więcej pracy nad utrzymaniem.

> TODO: Przegląd pomysłów/treści pod kątem zorientowania na odbiorcę. Jeśli odbiorcą jest potencjalny pracownik, to część treści trzeba przeredagować, a pomysły zoptymalizować (np. Akademia im. Messera, "skad dojezdzamy i czym"), niektóre hasła brzmią dobrze tylko od "wewnątrz firmy". Wolelibyśmy nie wzbudzać uśmiechu z politowaniem.

> TODO: Analiza dlaczego strona jest porzucona. Co zrobić, aby ludzie chcieli ją rozwijać? Może 1970+ linii kodu HTML działa odstraszająco?

> TODO: Lista aspektów technicznych (podział na partiale, Pug zamiast HTML-a?, szablony i treść osobno? Static Site generator? CMS?) Pomysłów jak stracić czas jest multum. Trzeba je przefiltrować po dyskusji o przyszłości i celu strony.

### Treści statyczne

- Informacje ogólne o IHS Inc.
    - [x] co to za firma,
    - [x] czym sie zajmuje - klienci
    - [ ] accolades, nagrody, cytowania itp
    - [ ] ile ludzi total <- **13000 czy 9000? Mamy niespójność**
    - [ ] jakie dzialy ile ludzi w róznych dzialach
    - [ ] rozproszenie geograficzne, gdzie biura itp
    - [ ] przetlumaczyc IHS Elevator Pitch na polski

- Biuro w Gdansku
    - [ ] Krótka historia (timeline rozwoju)
    - [ ] wladze, zarzad itp.
    - [ ] Dzialy - Product Development, SQA, Dzial operacji ekonomicznych, Dzial analityczny
        - czym sie zajmuje dany dział
        - krótka historia
        - ile ludzi
        - zdjecia ludzi jesli chetni pokazac
        - moze dla chetnych którzy chca sie na stronie znalezc zdjecie + krótka notka o tym co robie i skad sie wzialem(wzielam)

    - lokalizacja
        - [x] mapa
        - [ ] zdjecia wewn. zewn. (preferowane nastrojowe zdjecia makro na których jest cos ladnego ale nie za bardzo wiadomo co ;-)

    - sprzet
        - [x] z jakiego sprzetu korzystamy 
        - [x] mobile, sprzet Apple
        - [x] serwerownia, infrastruktura
        - [ ] zdjecia

    - technologia
        - [ ] timeline uzywanych technologii
        - [ ] opisy co uzywamy w jakim projekcie i dlaczego i jak jest fajnie (lub niefajnie)


    - jak pracujemy
        - [ ] dlaczego to jest fajne ze nie jestesmy Outsourcingiem                                   - 
        - [ ] podejscie do projektów, kontakty z pracownikami zza granicy, BA's, wizyty, wyjazdy (jak ktos gdzies byl w fajnym miejscu firmowo to moze chce napisac co gdzie i jak plus zdjecia)
        - [x] imprezy firmowe, opis, zdjecia
        - [ ] jak pracujemy bardziej szczególowo:
            - projekty, metodologia, podejscia (agile, testowanie automatyczne, analizy)

    - szkolenia
        - wewnetrzne – „Nothing But .NET.”, „Akademia im. Messera”, „F# lab”, inne nie tylko IT
        - zewnetrzne
            - kto byl na szkoleniu to moze napisze co gdzie i kiedy i jak bylo i o czym
            - kto byl na konferencji to moze napisze co gdzie i kiedy i jak bylo i o czym
    - kontakt z uczelnia
        - [ ] informacja o stażach
        - [ ] liczba pracujacych studentow
        - pracownicy uczelni - czym sie zajmuja, jacy sa fajni, zdjecia

    - aktywnosc, trójmiejskie kola .NET, inne organizacje, kto sie udziela to moze cos napisze

    - Projekty i produkty - co wytworzylismy w Gdansku
        - [ ] materialy reklamowe z centrali
        - [ ] cos z IHS.COM
        - [ ] mobilne aplikacje iOS
        - [ ] Android
        - [ ] ciekawe R&D

    - Sustainability
        - [ ] jakie inicjatywy, co gdzie kiedy, zdjecia
        - [ ] skad dojezdzamy i czym!

### Treści dynamiczne

- [ ] wydarzenia
- [ ] speaker corner
- [ ] more TBD
