-- T00 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-1, 'Cilj "hinta" je da ti usmeri razmišljanje bez da direktno ponudi odgovor na zadatak. Spram toga "rešenje" nudi kod ili video koji direktno prikazuju kako izgleda konačno rešenje. Da bi završio ovaj izazov neophodno je da preimenuješ polje "Challenge" u "_completed". Vidimo da je ovaj hint izuzetak zato što nudi konačno rešenje.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-1, /*-1000*/);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-1, '{"Challenge"}', -1);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-2, /*-1000*/);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-2, '{"_completed"}', -1);

-- =================================
-- N01 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-31, 'Izbegavaj redundantne reči koje ponavljaju informacije koje već stoje u tipu (npr. List, Num).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-31, /*-994*/);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-31, '{"List","string"}', -31);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-32, 'Izbegavaj misteriozne nazive koji ne objašnjavaju šta dati identifikator predstavlja (npr. nazive sa jednim slovom, a da nisu iteratori petlje).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-32, /*-994*/);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-32, '{"s","e"}', -32);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-33, 'Razmisli kako da integrišeš domenski značajne reči poput "Syntagms", "pascalCase", "capital" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-33, /*-994*/);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-33, '{"syntagms","pascalCase","capital"}', -33);

-- N03 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-11, 'Izbegavaj generične reči koje se mogu koristiti da opišu bilo kakav kod (npr. Manager, Data), kao i one koje ponavljaju informacije koje već stoje u nazivu tipa (npr. List, Num).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-11, /*-988*/);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-11, '{"Data","Info","Str","Set","The"}', -11);
	

-- N05 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-21, 'Razmisli kako da integrišeš domenski značajne reči poput "Enroll", "newCourse", "Maximum" i "Active" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-21, /*-981*/);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-21, '{"Enroll","newCourse","Maximum","Active"}', -21);

-- =================================
-- F02 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-71, 'Identifikuj regione povezanog koda (obrati pažnju na komentare) i izdvoj ih u funkciju kojoj možeš dati jasan naziv.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-71, /*-967*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-71, 'MELOC', 1, 18, -71);

	
-- F03 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-41, 'Razmisli kako bi pojednostavio datu metodu tako da smanjiš ugnježdavanje koda.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-42, 'Ne zaboravi da vodiš računa o linijama koda.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-41, /*-963*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-41, 'CYCLO', 1, 5, -41);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-42, /*-963*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-42, 'MELOC', 1, 12, -42);

-- F05 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-61, 'Da li možeš dodatno da redukuješ ugnježdavanje, tako što ćeš izdvojiti metodu ili invertovati uslov u grananju?');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-62, 'Ne zaboravi da vodiš računa o linijama koda.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-61, /*-957*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-61, 'CYCLO', 1, 4, -61);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-62, /*-957*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-62, 'MMNB', 1, 2, -61); -- TODO: Check if 3 is suitable; Check these rules in general
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-63, /*-957*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-63, 'MELOC', 1, 16, -62);
	
-- F07 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-51, 'Funkcija ima previše parametra. Razmisli koja strategija za redukciju parametra najviše odgovara skupu parametra u datoj funkciji, pa je primeni.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-52, 'Vredna strategija za redukciju parametra podrazumeva premeštanje metoda i polja klase tako da se ukloni potreba za parametrom. Razmisli da li ima smisla premestiti neku metodu iz ove klase u drugu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-51, /*-951*/, 'Methods.Params.CourseService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-51, 'NOP', 0, 1, -51);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-52, /*-951*/, 'Methods.Params.Course');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-52, 'NOP', 0, 1, -51);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-53, /*-951*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-53, 'NMD', 0, 2, -52);

-- =================================
-- C31 (srp) challenge strategies & hints
-- Books
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-141, 'Book klasa rešava više odgovornosti i potrebno je razložiti u nekoliko klasa koje će podeliti teret i odgovoriti na dodatne zahteve istaknute u zadatku.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-142, 'Book klasa ima previše metoda u sebi, gde neke pripadaju "BookReading" konceptu, odnosno klasi koja će da predstavlja čitanje neke konkretne knjige od strane jednog korisnika.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-141, /*-945*/, 'Classes.SRP.Books.Book');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-141, 'CELOC', 3, 8, -141);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-142, /*-945*/, 'Classes.SRP.Books.Book');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-142, 'NMD', 1, 1, -142);
	
-- Achievements
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-131, 'AchievementService poseduje mnogo odgovornosti, od koordinacije raznih operacija do poznavanje detalja implementacije svake operacije. Potrebno je pojednostaviti logiku klase tako da se samo bavi koordinacijom, odnosno pozivima metoda drugih objekata.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-132, 'Kao koordinator u ovom problemu, AchievementService bi trebao da radi sa 2-3 klase, gde bi svaka imala sopstvenu odgovornost, poput perzistencije i poslovne logike rada sa postignućima.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-131, /*-943*/, 'Classes.SRP.Achievements.AchievementService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-131, 'CELOC', 3, 15, -131);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-132, /*-943*/, 'Classes.SRP.Achievements.AchievementService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-132, 'CBO', 2, 3, -132);
	
-- C33 (struct coh) challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-101, 'CourseService klasa poseduje mnogo metoda koje nisu vezane samo za kurseve. Analiziraj nazive svih metoda i vidi da li ima smisla da se neke metode premeste ili da se formira nova klasa koja će ih skladištiti.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-102, 'CourseService klasa ima nisku strukturalnu koheziju. Ovo se dešava kada metode koriste manji deo atributa. Iako ne moramo da imamo idealnu koheziju, treba težiti da većina metoda koristi većinu atributa i spram toga organizovati metode u klase.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-101, /*-938*/, 'Classes.Structural.CourseService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-101, 'CELOC', 8, 17, -101);

INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-102, /*-938*/, 'Classes.Structural.CourseService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-102, 'LCOM', -1, 0.25, -102);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-103, /*-938*/, 'Classes.Structural.CourseService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-103, 'TCC', 0.75, 1, -102);

-- C35 (coupling) challenge strategies & hints
-- Employees
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-111, 'EmployeeService kopa podatke iz Employee objekta da bi uradio neku pamet nad njima, poput izmene njihove vrednosti. Idealno bi bilo ako bi Employee klasa ovo radila, posebno zato što je izmena navedenih atributa usko-povezana operacija kojoj možemo smisliti dobar naziv.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-111, /*-931*/, 'Classes.Coupling.Employees.EmployeeService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-111, 'ATFD', 0, 1, -111);
	
-- Rental
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-121, 'Česta rasporedimo logiku i kompletne metode u pogrešnu klasu. Da li možeš da izdvojiš komad logike iz RentalSchedule klase u zasebnu metodu, koju bi potom mogao smisleno da premestiš u DateRange klasu?');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-121, /*-929*/, 'Classes.Coupling.Rental.DateRange');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-121, 'CELOC', 5, 15, -121);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-122, /*-929*/, 'Classes.Coupling.Rental.RentalSchedule');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-122, 'CYCLO', 0, 4, -121);
	





-- Currently unused
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (60, 60);
INSERT INTO public."Videos"(
	"Id", "Url")
	VALUES (60, 'https://youtu.be/2goLaolzEV0');
	
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (61, 61);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (61, 'https://i.ibb.co/ydsGxjM/a-RS-Methods-LINQ.png', 'Razmisli na koji način nam IsActive funkcija apstrahuje logiku, a na koji način je enkapsulira.');
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (64, 63);
INSERT INTO public."Videos"(
	"Id", "Url")
	VALUES (64, 'https://youtu.be/JQPIh0VcLK4');
	
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (65, 64);
INSERT INTO public."Texts"(
	"Id", "Content")
	VALUES (65, 'Zamisli aplikaciju koja se razvija duže vreme. Sadrži mnogo klasa, gde se većina sastoji od više čistih metoda koje su fokusirane na jedan zadatak. Kompletan sistem podržava razne slučajeve korišćenja kroz koordinaciju ovih mnogobrojnih funkcija.
Stiže novi zahtev koji zahteva izmenu kako se neki zadatak izvršava. Programer kreće od korisničke kontrole (forme, tastera) koja će pružiti drugačije ponašanje/podatke kada se ispuni zahtev i ispituje telo povezane metode/endpoint-a. Potom rekurzivno primenjuje sledeći algoritam:

1. Ispitaj telo metode u potrazi za logikom koju treba menjati.
2. Za svako ime metode koja se poziva, analiziraj njegovo značenje. Ako ime određuje logiku relevantnu za novi zahtev skoči na telo date funkcije i primeni korak 1. U suprotnom ignoriši.

Ovako programer izbegava analizu stotina linija koda i svede posao na analizu nekoliko imena. Programer leti kroz kod uz pomoć prečica svog integrisanog razvojnog okruženja i ne zamara se sa detaljima funkcija koje nisu relevantne za dati zahtev.
Kada konačno pronađu funkciju čije ponašanje treba promeniti, izmena je sitna i fokusirana, što smanjuje šansu da se uvede *bug*. Programer ispunjuje novi zahtev bez da je potrošio mnogo mentalne energije.

Sada zamisli sličnu aplikaciju koja je sastavljena od golemih funkcija koje broje stotine linija koda i poseduju misteriozna imena. Nova izmena zahteva od programera da istražuje kod. Potreban je veliki mentalni napor kako bi se očuvao visok fokus dok se identifikuje koje deo kompleksne logike treba izmeniti, a koji ignorisati. Sama izmena je rizična aktivnost i u ovakvom kodu se *bug* lako potkrade. Zbog toga je potrebno pažljivo raditi ovaj mukotrpan proces, koji može trajati više sati (na dovoljno složenom problemu i više dana). Na kraju, programer je istrošen i opterećen mislima da je nešto prevideo i da će njegova izmena srušiti sistem u produkciji.

Pisanje čistih funkcija je teže nego kucanje koda dok ne proradi. Za čiste funkcije svakako treba napraviti nešto što radi, a onda još treba organizovati tu logiku u smislene celine ispred kojih stavljamo jasno ime. Sa druge strane, čitanje aljkavo napisanih funkcija je teže od čistanja čistih funkcija. Postavlja se pitanje - u koji aspekt vredi uložiti više truda i energije? Za softver koji je dovoljno dugo u razvoju (npr. više od mesec dana, razvijan od strane pet ili više ljudi) većina programerovog vremena odlazi na čitanje koda.');
-- Cohesion - PK Node 2
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (120, 120);
INSERT INTO public."Videos"(
	"Id", "Url")
	VALUES (120, 'https://www.youtube.com/watch?v=qE-Gmu_YuQE'); -- TODO: RS
-- SRP možda
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (131, 131);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (131, 'https://i.ibb.co/6wH5NrY/RS-dung.png', 'Lepljivi moduli su "utility" i "misc" paketi, kao i "Manager" i "Service" klase. Zbog svog generičnog imena, lako je opravdati bilo koji dodatak u ovakav modul - što postavlja pitanje da li se neko parče logike nalazi na smislenom mestu ili u kontejneru koji zovemo "ostalo"?');
	
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (132, 132);
INSERT INTO public."Texts"(
	"Id", "Content")
	VALUES (132, 'Kroz ovu lekciju smo se u značajnoj meri fokusirali na koheziju klase i veza između njenih elemenata. Možemo ukratko sagledati jednostavnije i složenije module i kako se kohezija odnosi na njih.
	
- Funkcije kao najjednostavniji autonomni modul ima visoku koheziju ako njene instrukcije kolektivno izvršavaju jedan zadatak. Funkcija sa niskom kohezijom često poseduje "regione" instrukcija (odvojene komentarom ili praznim redom), gde se svaki region bavi posebnim zadatkom. U goroj varijanti, ovi regioni su isprepletani i teško je odrediti koje sve zadatke vrši funkcija. Kod funkcija je semantička kohezija značajnija metrika jer je teško definisati strukturalnu metriku za veze između instrukcija.
- Visoko-kohezivni paketi podrazumevaju kolekciju klasa koje rade zajedno kako bi ostvarili neki cilj višeg nivoa apstrakcije. Ovakav paket izvršava značajan deo poslovne ili aplikativne logike uz minimalnu podršku drugih paketa. Pored semantičke kohezije, moguće je uposliti strukturalne metrike koje određuju spregnutost između klasa (engl. *Coupling between objects*; *CBO*). Dobro formiran paket će imati dosta više sprega između objekata koji su deo tog paketa nego između unutrašnjih i spoljašnjih objekata. Ovakve pakete je jednostavno promovisati u zasebne aplikacije ili mikroservise ukoliko postoji potreba za time.');

