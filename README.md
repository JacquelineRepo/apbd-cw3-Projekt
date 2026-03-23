Program działa jako aplikacja konsolowa pozwalająca użytkownikom na wyporzyczanie sprzętu. Zawiera możliwość
zarejestrowania użytkownika, generowania raportu, porzyczanie jak i zwracania sprzętu i wyświetlanie kilku informacji.
Obsługiwanie klienta dzieje się poprzez Front, który tworzy obiekt Service i przesyła do niego instrukcje z konsoli.
Oparte to jest na switch case, zrobiłam tak ponieważ takie podejście jest dla mnie znane i niezbyt skomplikowane,
ale również pozwala na łatwe dodawanie kolejnych poleceń do systemu. Starałam się rozbić wiele operacji na metody pomocnicze,
i dodać kilkukrotnie zmienne, w miejscach gdzie normalnie bym poprostu wywołała kilka metod naraz, aby ulepszyć czytelność kodu. 
