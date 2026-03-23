Program działa jako aplikacja konsolowa pozwalająca użytkownikom na wyporzyczanie sprzętu. Zawiera możliwość
zarejestrowania użytkownika, generowania raportu, porzyczanie jak i zwracania sprzętu i wyświetlanie kilku informacji.
Obsługiwanie klienta dzieje się poprzez Front, który tworzy obiekt Service i przesyła do niego instrukcje z konsoli.
Oparte to jest na switch case, zrobiłam tak ponieważ takie podejście jest dla mnie znane i niezbyt skomplikowane,
ale również pozwala na łatwe dodawanie kolejnych poleceń do systemu. Starałam się rozbić wiele operacji na metody pomocnicze,
i dodać kilkukrotnie zmienne, w miejscach gdzie normalnie bym poprostu wywołała kilka metod naraz, aby ulepszyć czytelność kodu. 
Patrząc na fakt że wszystkie sprzęty mają bardzo wiele wspólnego, wybrałam zrobienie klasy abstrakcyjnej
po której dziedziczy każdy następny rodzaj sprzętu. Tym samym nie powinnien wystąpić przypadek gdzie
wprowadzimy do systemu "Sprzęt" o którym nic nie wiemy. Nazwy sprzętów są w nazwie klas, ale też
przechowywane są wewnątrz, zapomocom wywołania 'GetType().ToString().Split('.').Last();' w Equipment

Użytkownicy też mają wiele wspólnego, więc też są klasą abstrakcyjną po której dziedziczą 
konkretni użytkownicy. W mojej implementacji nie wiele się różnią, ale pozwala to na
łatwe dodawanie kolejnych rodzaji użytkowników lub wprowadzenie konkretnych możliwości dla
danego rodzaju użytkownika. 

Logika aplikacji jest zawarta w obiektach których używa, przechowywując ważne informacje 
w każdej instancji, zamaiast otwarcie w głównej pętli, zachowując hermatyzacje i 
korzystanie z konwencji obiektowego programowania. 

Ponieważ moja aplikacja działa w pełni poprzez konsole, nie jestem w stanie przygotować scenariuszu w metodzie main,
więc zamiast tego załącze transkrypt scenariuszu jako dodatkowy plik tekstowy w projekcie.

