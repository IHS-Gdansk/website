# Property Based Testing with F#
## Property Based Testing with F#

W ramach regularnych spotkań pod nazwą "Akademia Messera", 7 października 2015 pracownicy IHS Global mieli okazję posłuchać o alternatywnym podejściu do popularnych Unit Testów. Tomasz Heimowski opowiedział o Property Based Testing z wykorzystaniem języka F#.

W ramach regularnych spotkań pod nazwą "Akademia Messera", 7 października 2015 pracownicy IHS Global mieli okazję posłuchać o alternatywnym podejściu do popularnych Unit Testów. Tomasz Heimowski opowiedział o Property Based Testing z wykorzystaniem języka F#.

<p class="text-center">
    <img src="images/articles/2015.10/property_based_testing/2015-10-07 0010.jpg" class="img img-responsive img-thumbnail" alt="PBT w/ F# image 0" />
</p>

Property Based Testing jest bardzo ciekawym zagadnieniem, dzięki któremu można automatycznie wykryć skrajne przypadki powodujące nieprawidłowe działanie naszego programu. Dzieje się tak poprzez zastąpienie standardowej (dla Unit Testów) fazy "Assert" generatorem danych wejściowych.

Podczas prezentacji zostały podkreślone 2 problemy Unit Testów: brak gwarancji poprawności oraz ilość kodu przygotowującego dane testowe. Problemy te adresuje Property Based Testing, dzięki któremu zyskujemy znacznie większe pokrycie testowe przy mniejszej ilości kodu.

<p class="text-center">
    <img src="images/articles/2015.10/property_based_testing/fsharp256.PNG" class="img img-responsive img-thumbnail" alt="fsharp logo" />
</p>

Język [F#](http://fsharp.org), w którym były zaprezentowane przykłady, jest na codzień używany w IHS w projekcie Phoenix właśnie na potrzeby testów transformaty XSLT jak i pomocnicznych skryptów projektowych.
Sama idea Property Based Testing nie jest jednak ściśle związana z żadną specyficzną technologią. Biblioteki i narzędzia do testowania w ten sposób można znaleźć dla przeróżnych języków programowania i platform.

Prezentację można obejrzeć pod [tym adresem](https://theimowski.github.io/PropertyBasedTestsWithFSharp/).