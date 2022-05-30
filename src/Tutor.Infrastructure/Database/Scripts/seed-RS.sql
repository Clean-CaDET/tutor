
DELETE FROM public."AssessmentItemMasteries";
DELETE FROM public."KcMasteries";
DELETE FROM public."UnitEnrollments";
DELETE FROM public."GroupMemberships";
DELETE FROM public."LearnerGroups";
DELETE FROM public."Learners";
DELETE FROM public."Events";
DELETE FROM public."Users";

DELETE FROM public."Texts";
DELETE FROM public."Images";
DELETE FROM public."Videos";
DELETE FROM public."BasicMetricCheckers";
DELETE FROM public."BannedWordsCheckers";
DELETE FROM public."RequiredWordsCheckers";
DELETE FROM public."ChallengeHints";
DELETE FROM public."ChallengeFulfillmentStrategies";
DELETE FROM public."Challenges";
DELETE FROM public."MrqItems";
DELETE FROM public."MultiResponseQuestions";
DELETE FROM public."ArrangeTaskElements";
DELETE FROM public."ArrangeTaskContainers";
DELETE FROM public."ArrangeTasks";
DELETE FROM public."ShortAnswerQuestions";
DELETE FROM public."AssessmentItems";
DELETE FROM public."InstructionalItems";
DELETE FROM public."KnowledgeComponents";
DELETE FROM public."KnowledgeUnits";
INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description") VALUES
	(-100, 'TT00', 'Interakcija sa tutorom', 'U sklopu ove kratke *lekcije* ćeš upoznati funkcionalnosti koje nudi Tutor i kako da tumačiš gradivo, zadatke i povratnu informaciju koju ti nudi. Za početak analiziraj *veštine* koje su izlistane ispod i način kako su prezentovane.

Veština "Formiraj odgovor na izazov refaktorisanja" je višeg stepena i njoj je moguće pristupiti tek kada se otključaju sve podveštine. Otključane veštine počinju sa 0% *vičnosti*, gde se ovaj procenat povećava kako daješ odgovore na zadatke i pokazuješ Tutoru da si stekao određenu ekspertizu. Odaberi jednu od otključanih veština i pristupi njenom *gradivu*. Kada dostigneš traženu vičnost otvori sledeću veštinu dok ne savladaš sve veštine koje su deo ove lekcije.');

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description") VALUES
	(-99, 'CC01', 'Značajni nazivi', 'Nazive pronalazimo u svim segmentima razvoja softvera - kod identifikatora promenljive, funkcije, klase, ali i biblioteke i aplikacije. Jasan naziv funkcije nas oslobađa od čitanja njenog tela, dok će misteriozni naziv zahtevati dodatan mentalni napor da razumemo svrhu koncepta koji opisuje. U najgorem slučaju, loš naziv će nas naterati da formiramo pogrešnu pretpostavku, što će nam drastično produžiti vreme razvoja. Kroz ovaj modul ispitujemo dobre i loše prakse za formiranja naziva identifikatora u kodu.');

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-100, 'T01', 'Formiraj odgovor na izazov refaktorisanja', '', -100, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-99, 'T02', 'Analiziraj različite načine serviranja gradiva', '', NULL, -100);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-98, 'T03', 'Formiraj odgovor na proste tipove zadataka', '', NULL, -100);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-97, 'N01', 'Konstruiši značajne nazive za identifikatore u kodu', '', -99, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-96, 'N02', 'Prati timske konvencije prilikom formiranja naziva', '', NULL, -97);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-95, 'N03', 'Izbegavaj beznačajne reči', '', NULL, -97);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-94, 'N04', 'Primeni prikladne tipove reči', '', NULL, -97);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-93, 'N05', 'Koristi terminologiju domena problema', '', NULL, -97);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-92, 'N06', 'Analiziraj širi kontekst prilikom formiranja naziva', '', NULL, -97);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "KnowledgeUnitId", "ParentId") VALUES
	(-91, 'N07', 'Formiraj naziv na dobrom nivou apstrakcije', '', NULL, -97);

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-1000, -100, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-1000, 'Do sada smo prošli generične kontrole za prikaz gradiva i zadataka koji su primenjivi za razvoj bilo kakvih veština, bez obzira na domen. Sada ćemo videti tip zadatka koji je specijalizovan za domen softverskog inženjerstva i koji se integriše u Visual Studio Code razvojno okruženje. U videu ispod se pokazuje šta je potrebno da se instalira plagin za VS Code i kako se koristi plagin da se pošalju rešenja za izazove.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-999, -100, 2);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-999, 'https://www.youtube.com/watch?v=GEUTc-q2juw');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-998, -99, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-998, 'Prvi korak u razvoju veštine je ispitivanje gradiva koje opisuje aspekte date veštine. U sklopu Tutora se gradivo izlaže kroz tekst, poput ovog, kroz sliku, kao i kroz video, što se vidi u nastavku. Potrebno je ispitati gradivo i analizirati njegov sadržaj pre nego što se pređe na rešavanje zadataka. Svakako je dozvoljeno vratiti se na gradivo u sred rada na zadacima i postoji taster upravo za te potrebe pri dnu panela koji prikazuje zadatak.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-997, -99, 2);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-997, 'https://i.ibb.co/8BNsVDp/themes.png', 'Tutor podržava svetlu i tamnu temu, pa podesi svoje učenje spram preferenci i doba dana.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-996, -99, 3);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-996, 'https://youtu.be/3DZDotjzL5o');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-995, -98, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-995, 'Tutor nudi nekoliko tipova zadataka koji na različite načine ispituju stepen razvoja povezane veštine. Svaki tip zadatka nudi povratnu informaciju da li je odgovor tačan i često dodatno pojašnjenje zašto je nešto tačno ili netačno. Ilustracije koje slede ističu različite tipove zadataka i elemente na koje treba obratiti pažnju.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-994, -98, 2);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-994, 'https://i.ibb.co/q5F09Qq/mrq.png', 'Bitni segmenti tipa zadatka "pitanje sa više odgovora", gde možemo imati 0, 1 ili više tačnih odgovora.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-993, -98, 3);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-993, 'https://i.ibb.co/0GqJZrN/saq.png', 'Bitni segmenti tipa zadatka "pitanje sa kratkim odgovorom", gde možemo imati 0, 1 ili više reči (razdvojene zarezom).');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-992, -98, 4);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-992, 'https://i.ibb.co/ngGFtVd/at.png', 'Bitni segmenti tipa zadatka "raspored elemenata u kategorije", gde je moguće da kategorija ima 0, 1 ili više elementa koji joj pripadaju.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-991, -98, 5);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-991, 'Kada se pošalje odgovor na zadatak Tutor računa stepen tačnosti odgovora i potencijalno ažurira vičnost. Učenik prelazi na sledeći zadatak i daje dalje odgovore sve dok ne postigne zadovoljavajuć stepen vičnosti. Kada Tutor ostane bez novih zadataka nudi učeniku već viđene zadatke koje je najslabije savladao.

Možeš preći na zadatke da ispitaš prethodno opisane kontrole.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-990, -97, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-990, 'Van jednostavnih slučajeva, izbor pravog naziva je proces koji podrazumeva sledeće korake:

1. Opisivanje koncepta koji želimo da imenujemo kroz rečenicu ili dve, koristeći prikladnu terminologiju iz domena problema ili rešenja. Često ćemo ovaj opis pronaći ili ostaviti u tekstu komentara koji stoji uz koncept, sa ciljem da dodatno pojasni šta koncept predstavlja. Ovaj tekst je lakše formirati na maternjem jeziku, a kada smo zadovoljni sa opisom možemo prevesti na engleski (uz moguću pomoć onlajn prevodioca).
2. Uklanjanje svih *noise* reči, odnosno redundantnih imenica, veznika i priloga koji nisu ključni za prenošenje svrhe koncepta koji imenujemo.
3. Uklanjanje svih preostalih reči koje se jednostavno izvlače iz šireg konteksta, poput naziva **tipa** (npr. povratne vrednosti, parametra ili promenljive), **modula** kom dati element pripada (npr. klase ili paketa) i dodatnih elemenata (npr. nazivi parametra i njihovih tipova kod funkcije koju imenujemo).
4. Razmatranje da li preostale reči opisuju koncept na dobrom nivou apstrakcije i da li predstavljaju glagol za metodu ili funkciju, odnosno imenicu u preostalim slučajevima.
5. Postavljanje novog imena.

Navedeni algoritam nije jednokratna aktivnost. Često je potrebno nekoliko iteracija i preimenovanja da bismo stigli do imena koje je dovoljno jasno i značajno. Na sreću, savremeni IDE alati pružaju podršku za lako preimenovanje elemenata koda. Ako kod prolazi *build* posle preimenovanja, možemo biti uvereni da nismo uveli nove greške u kod.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-989, -97, 2);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-989, 'https://i.ibb.co/vqjMTyJ/simple-names-sr.png', 'U većini slučajeva kada hoćemo da stavimo komentar, pravo rešenje je smišljanje jasnijeg imena.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-988, -96, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-988, 'Idealan naziv treba jasno da odredi neku operaciju ili pojam. Zbog ovoga je neophodno izbegavati sinonime i pratiti timske konvencije.

Kao primer možemo zamisliti skup klasa čiji zadatak je da učitaju različite entitete iz skladišta. Jedna klasa učitava jedan entitet i sadrži logiku za serijalizaciju i deserijalizaciju datog entiteta (takozvane *Repository* klase). Ako većina ovakvih klasa poseduje metodu čiji naziv počinje sa *Get*, programer će morati da zastane ako naleti na metodu koja učitava određeni entitet i ime joj počinje sa *Load*. Postaviće se pitanje da li je *Load* drugačije od *Get* i da li treba nešto drugačije uraditi sa *Load* metodama. Da bi bio siguran, programer mora da otvori kod metode *Load* i da proveri da ne postoji neka bitna razlika, čime troši vreme.

Prethodni problem neće izazvati velik trošak vremena, no gomila ovakvih prekršaja će svakako opteretiti programera. Dalje, postoji mogućnost da će programer u nedostatku *Get* funkcije implementirati takvu metodu, iako nespretno nazvan *Load* već radi traženi posao.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-987, -96, 2);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-987, 'Određene konvencije potiču iz programskog jezika ili tehnologija koje koristimo. One mogu i često jesu usvojene kao timske konvencije. Primeri ovakvih konvencija uključuju:

- *i* i *j* koji se koriste za nazive promenljiva koje prate broj iteracije za *for* petlje.
- *Controller*, *Service*, *Repository* i *Dto* reči koje se koriste kao sufiksi u nazivima određenih klasa, gde date reči jasno označavaju deo odgovornosti date klase.
- Upotreba *PascalCase* notacije za nazivanje klasa i metoda u C# programskom jeziku, kao i upotreba *pascalCase* notacije za formiranje naziva ostalih identifikatora.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-986, -95, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-986, 'Prilikom formiranja naziva treba da izbegnemo dodavanje beznačajnih prefiksa i sufiksa. Tipičan primer nepotrebnog sufiksa nastaje kada se radi *copy & paste* izraza koji definiše promenljivu, gde se na kraj kopirane promenljive doda *1*. Ovaj potez rezultuje brzom pisanju nove instrukcije, ali usporava svako naknadno čitanje.

Treba da izbegavamo redundantne reči koje ponovo ističu tip elementa (npr. *str, string, obj, list, set*). Takođe treba da izbegavamo previše generične reči, poput *Manager, Coordinator, Data, Info*, jer ovakve reči važe za mnoge elemente koda.

U opštem slučaju, prefiksi i sufiksi su prihvatljivi samo kada se prati konvencija tima (čest primer za ovo su *Controller* i *Service* sufiksi koji nose jasno značenje), no i tada se moramo postarati da imamo značajno ime pre nego što uvedemo ovakve dodatke.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-985, -95, 2);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-985, 'https://youtu.be/IusayOJt79E');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-984, -94, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-984, 'Česta konvencija je da reči koje formiraju naziv metode rezultuju glagolom, označavajući da se *nešto radi*, odnosno operacija izvršava kada se metoda pozove. Primeri za ovo uključuju:

- *Buy(Product product)*
- *Open(File file)*
- *LoadSyntaxTrees(List<string> sourceCode)*

Ova konvencija se ponekad narušava kod funkcija koje predstavljaju pitanje čiji odgovor je da (tj. *true*) ili ne (tj. *false*). Primer za ovo je naziv *IsPublished()*.

Nazivi ostalih vrsta identifikatora (npr. za promenljive, polja, klase i pakete) formiramo kao imenice.  Primeri za ovo uključuju:

- *FileParser*
- *User*
- *retiredEmployees*
- *ConfigurationUtilities*');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-983, -93, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-983, '*Domen problema* predstavlja oblast za koju pravimo softver, koji rešava problem u tom domenu. Primeri domena problema su zdravstvo, obrazovanje, ekonomija i ekologija. Softver retko pokriva toliko širok domen kao što je "zdravstvo", već je specijalizovan za neki manji poddomen. Primer poddomena je "radiologija", gde bi softver koji rešava problem u ovom domenu mogao da bude alat za automatsku analizu radioloških slika.

Domen problema obuhvata organizacije, ljude, podatke, poslovne procese i znanje koje postoji van našeg softvera. Ovo znači da će poslovne operacije poput "podizanja novca sa računa" moći da se izvrše i bez softvera (npr. uz pomoć šalter radnika i odgovarajućih dokumenata). Kada dizajniramo softver, bitan cilj je da razdvojimo kod koji modeluje domen problema i poslovnu logiku (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za nazive, gde klase i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Tako za operaciju arhiviranja dokumenta ima smisla da definišemo funkciju sa nazivom *Archive*, dok bi *ArchiveToCloud* sadržalo previše tehničkih detalja.

Ako pravimo aplikaciju za bolnicu, domen problema uključuje titule i odgovornosti zdravstvenih radnika, strukture dokumenata i stanja u kojim se oni mogu naći, kao i procedure i operacije u kojim učestvuju različiti zdravstveni radnici. Naš posao će biti da razvijemo funkcionalnosti za podršku ovih korisnika, dokumenata i procedura i tom prilikom treba da ugradimo što više terminologije iz domena problema u naš kod.

Za prethodni primer ova terminologija može da uključi *Doctor* i *Nurse*, zatim *Medical Record* i *Prescription Drug*, kao i *Schedule Operation* i *Cancel Appointment*. Dobra praksa je da konzistentno koristimo ove nazive u delu koda koji modeluje domen problema, kako bismo sav naš razgovor sa korisnicima i stručnjacima iz ovog domena jednostavno mapirali na naš kod.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-982, -93, 2);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-982, 'https://youtu.be/wcIJOmP0R7I');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-981, -93, 3);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-981, 'https://i.ibb.co/Tw9qktR/domain-names-sr.png', 'Kada razvijamo poslovnu logiku za koju nemamo dobar naziv, možemo sastaviti komentar koji opisuje šta kod radi tako da koristimo što više reči iz domena problema. Iz ovog teksta možemo izdvojiti ključne reči da definišu naziv.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-980, -93, 4);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-980, 'Zamislimo promenljivu tipa *List<Doctor>*. Šta očekujemo da sadrži ova lista ako je ime promenljive *doctors*, a šta ako je *availableDoctors*, *capableDoctors* ili *suitableDoctor*?

Možemo zamisliti da će se za određenu operaciju razlikovati spisak svih lekara bolnice od onih koji su sposobni ili dostupni da urade datu operaciju. U ovom primeru vidimo kako upotreba odgovarajućeg atributa (slobodan, sposoban ili prikladan) u nazivu ograničava i jasnije određuje očekivani skup vrednosti u promenljivi.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-979, -93, 5);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-979, 'https://i.ibb.co/f144vCk/names-example.png', 'Ovako objektno orijentisani programer imenuje stvari kada izbegava reči iz poslovnog domena.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-978, -92, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-978, 'Svaki element koda pripada nekom širem kontekstu. Promenljive i parametri pripadaju metodi. Atributi i metode pripadaju klasi i dodatno su opisani svojim tipom, odnosno tipom svoje povratne vrednosti. Klasa ima svoj paket, odnosno *namespace*. *Namespace* je deo neke aplikacije.

Prilikom formiranja naziva za neki identifikator treba da uvažimo širi kontekst kom dati identifikator pripada. Naziv mora da bude jasan kada posmatramo njega i nazive iz njegovog šireg konteksta i to tako da izbegnemo redundantne informacije.

Kao primer možemo sagledati metodu sa nazivom *IsCapable*. Bez šireg konteksta nije jasno na šta se odnosi niti šta znači njen rezultat. Međutim, ako znamo da ova metoda pripada klasi *Doctor* i u kodu vidimo liniju poput *if(doctor.IsCapable(operation))* jasno je da je u pitanju provera sposobnosti određenog lekara za prosleđenu operaciju. Naziv *CheckDoctorCapabilityForOperation* jasno govori o čemu je reč bez šireg konteksta, no ovo dovodi do dvostruke redundantnosti u kodu poput *if(doctor.CheckDoctorCapabilityForOperation(operation))*.

Za drugi primer možemo zamisliti promenljivu sa nazivom *state* koja je definisana u okviru metode *FindAvailableRooms*. Posmatrajući samo naziv teško je odrediti kakav podatak je smešten u ovu promenljivu, da li je neko stanje sobe (poput zauzeta, spremna za čišćenja ili slobodna) ili je informacija o opštini u kojoj se traži soba. Naziv tipa promenljive bi mogao da pomogne, no savremeni programski jezici favorizuju upotrebu generične reči za definisanje promenljive, poput *var* ili *let*. Moguće rešenje bi bilo da se naziv preimenuje u *roomState* ili *addressState*.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-977, -91, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-977, 'Jasan naziv objašnjava **šta** povezano parče koda predstavlja, a ne **kako** radi ili od kojih podelemenata se sastoji. Tako jedna funkcija može imati sledeća imena:

 - *List<KeyValuePair<EmployeeId, decimal>> SumBonusesAndSickDaysForSalaryCalculation()*, gde naziv odaje previše detalja i možemo pretpostaviti kako izgleda kod;
 - *List<KeyValuePair<EmployeeId, decimal>> ComputeEmployeeSalaries()* gde je istaknuta suština operacije bez nepotrebnih dodatnih detalja.

Poslednji naziv je na višem nivou apstrakcije od opisa skupa koraka i tipa povratne vrednosti funkcije. Iz perspektive programera koji prvi put gleda ovaj kod, razumemo nameru funkcije bez da ulazimo u detalje njene implementacije i strukture njene povratne vrednosti. Ako nam je zadatak da modifikujemo algoritam za računanje plate, ova funkcija će nam biti interesantna i dublje ćemo je ispitati. Ako nam zadatak nema veze sa ovom funkcionalnošću biće nam dovoljno da pogledamo ime funkcije da znamo da ne moramo da gledamo kod njene implementacije.');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-976, -91, 2);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-976, '*Repository* je ključna reč koja se koristi u nazivima klasa čiji zadatak je da interaguju sa skladištem nekakvih podataka. Tako će *EmployeeRepository* imati zadatak da pročita sadržaj nekog skladišta (npr. baze podataka ili datoteke) i formira instance *Employee* klase.

U kontekstu različitih nivoa apstrakcije postavlja se pitanje kako razlikujemo naziv klase *EmployeeRepository* od *EmployeeFileRepository* i *EmployeeSqlRepository* i šta možemo očekivati da je kod svake od ovih klasa. Za naveden primer, razumno očekivanje je sledeće:

- *EmployeeFileRepository* - klasa koja zna da otvori datoteku, serijalizuje i deserijalizuje zaposlenog u format koji datoteka očekuje i zatvori datoteku.
- *EmployeeSQLRepository* - klasa koja zna da se zakači na bazu podataka (direktno ili uz pomoć objektno-relacionog mapera) i postavi joj upit koji će učitati ili sačuvati zaposlenog.
- *EmployeeRepository* - apstrakcija koja ili samo definiše interfejs koji dele prethodne dve klase ili sadrži neku zajedničku logiku koja nije vezana za detalje rada sa datotekom ili SQL bazom podataka.

Kada pišemo kod koji radi sa EmployeeRepository apstrakcijom, ne moramo da se opterećujemo da li se ispod haube dešava interakcija sa bazom ili datotekom. U ovom primeru je koncept "skladišta" apstraktniji od koncepta "datoteke" ili "SQL baze" i naziv ovo oslikava.');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-1000, -100, 1);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-1000, 'Cilj ovog zadatka je da instaliraš VS Code plagin, preuzmeš kolekciju izazova, napraviš sitnu izmenu nad početnim kodom i pošalješ rešenje na evaluaciju. Ispod se nalazi taster za preuzimanje koda izazova. U sklopu direktorijuma "Basics/01. Simple Challenge" isprati zadatak u zaglavlju klase i aktiviraj Submit komandu nad datom .cs datotekom.', 'https://github.com/Clean-CaDET/challenge-repository', 'Basics.Simple', 'https://gist.github.com/Luburic/2ad6db4c02c11ed221d1d2b6d82d1aed#file-start-cs');
--TODO: STRATEGIES AND HINTS

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-999, -99, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-999, 'Iz sledećeg spiska štikliraj sve istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9990, 'Tutor organizuje sadržaj u lekcije, koje su podeljene u module. Svaki modul ima gradivo i veštine.', false, 'Izjava nije tačna.', -999);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9991, 'Tutor organizuje sadržaj u lekcije, koje su podeljene u veštine. Svaka veština prezentuje povezano gradivo i zadatke.', true, 'Izjava je tačna.', -999);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9992, 'Tutor podržava tri vrste tema: svetlu, tamnu i sivu.', false, 'Izjava nije tačna.', -999);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9993, 'Tutor podržava funkcionalnost za hvatanje beleški.', true, 'Izjava je tačna i data funkcionalnost je opisana u videu.', -999);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-998, -98, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-998, 'Iz sledećeg spiska štikliraj sve istinite tvrdnje. Ne brini ako ne znaš neku od navedenih informacija. Donekle je i cilj da pogrešno odgovoriš na ovo pitanje da vidiš kako ćeš se na kraju vratiti na ovaj zadatak. Ne zaboravi da analiziraš povratnu informaciju.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9980, 'Tutor je dizajniran da optimizuje vreme učenja.', true, 'Izjava je istinita. Prvo, cilj ove aplikacije je da što preciznije odredi stepen razvoja veština svakog pojedinca. Sa tim znanjem, Tutor ne treba da zadržava učenika na veštini koju je već savladao, a treba da ga zadrži na onim koje tek treba da savlada.', -998);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9981, 'Tutor organizuje edukativan sadržaj oko veština koje treba savladati.', true, 'Izjava je istinita. Cilj ove aplikacije je da razvije kompetenciju iz nekog konkretnog domena. Za to je potrebno da se izgradi znanje koje Tutor izlaže kroz gradivo, kao i da se razvije veština, koju Tutor proverava kroz zadatke.', -998);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9982, 'Tutor je specijalizovan za domen veštačke inteligencije.', false, 'Izjava nije istinita. Tutor predstavlja ekspertski sistem i primenjuje određene algoritme veštačke inteligencije, ali je specijalizovan za domen softverskog inženjerstva, primarno kroz podsistem za izazove.', -998);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9983, 'Tutor beleži i analizira tvoju interakciju sa njim.', true, 'Izjava je istinita. Tutor koristi događaje koje generišeš, odgovore na zadatke i povratnu informaciju koju nudiš da bolje razume tvoje iskustvo i problematične veštine i informiše nastavnika gde ima prostora za unapređenje.', -998);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-997, -98, 2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-997, 'Šta je pretposlednja reč prvog paragrafa gradiva koje je vezano za ovu veštinu? Slobodno se vrati na gradivo da proveriš odgovor na pitanje.', '{"obratiti"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-996, -98, 3);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-996, 'Rasporedi sledeće opise spram tipa zadatka na koji se odnose.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9960, -996, 'Pitanje sa više odgovora');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99600,-9960, 'Niz izjava gde je potrebno obeležiti istinite izjave.', 'Zapamti da ovakvo pitanje može da ima 0, 1 ili više tačnih izjava.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9961, -996, 'Pitanje sa kratkim odgovorom');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99610,-9961, 'Potrebno je upisati 0, 1 ili više reči razdvojene zarezom.', 'Zapamti da povratna informacija uključuje spisak prihvatljivih odgovora koji su razdvojeni sa tačkom-zarez.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9962, -996, 'Raspored elemenata u kategorije');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99620,-9962, 'Potrebno je prevlačiti elemente između različitih kontejnera, kako bi se smestili u željene kategorije.', 'Zapamti da će pogrešno smešten element sadržati "X" tamo gde je postavljen, a da će drugom bojom biti označen u ispravnoj kategoriji.');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-995, -97, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-995, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9950, 'Uvek je bolje dodeliti identifikatoru duži naziv.', false, 'Izjava nije tačna. Iako je često bolje ime koje se sastoji od nekoliko reči umesto od par karaktera, treba da izbegavamo suvišne, redundantne i generične reči i da budemo koncizni. U određenim okolnostima, čak i ime od par karaktera je dopustivo (npr. kada je scope identifikatora ograničen na par linija koda).', -995);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9951, 'Formiranje jasnog imena ubrzava čitanje i pisanje koda.', false, 'Izjava nije tačna. Dobro ime značajno olakšava čitanje koda, no formulisanje jasnog imena je često zahtevan posao i može uzeti više minuta, dok je postavljanje besmislenog imena instant operacija.', -995);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9952, 'Kada formiramo ime za neki element, treba da uzmemo u obzir njegov kontekst (tip, modul kom pripada, itd.)', true, 'Izjava je tačna. Kada zadajemo ime treba da izbegnemo ponavljanje informacije koja je jasno vidljiva iz npr. tipa povratne vrednosti funkcije ili objekta nad kojim se poziva metoda.', -995);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-994, -97, 2);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-994, 'Sabrali smo sve smernice i prakse za davanje značajnog naziva u jednostavan algoritam. U sklopu direktorijuma "Naming/03. Meaningful Names" isprati zadatke u zaglavlju klase i primeni dati algoritam kako bi unapredio nazive koji se koriste u kodu.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Meaning', 'https://youtu.be/kna0fx6TglA');
--TODO: STRATEGIES AND HINTS

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-993, -97, 3);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-993, 'Analiziraj sledeći kod i rasporedi nazive u odgovarajuće kategorije u zavisnosti od toga da li krše neki princip dobrog imenovanja.
```csharp
public class MultipleResponseQuestion
{
    public string Text { get; private set; }
    public List<MrqItem> Items { get; private set; }

    public MrqEvaluation EvaluateMrqSubmission(MrqSubmission mrqSubmission)
    {
        var itemEvaluations = CheckAnswers(mrqSubmission.SubmittedItemsIds);
        var correctness = (double)itemEvaluations.Count(a => a.SubmissionWasCorrect) / answerEvaluations.Count;
        
        return new MrqEvaluation(Id, correctness, answerEvaluations);
    }

    private List<MrqItemEvaluation> CheckAnswers(List<int> submittedItemsIds)
    {
        var itemEvaluations = new List<MrqItemEvaluation>();
        foreach (var item in Items)
        {
            bool itemMarkedFlag = submittedItemsIds.Contains(answer.Id);
            itemEvaluations.Add(new MrqItemEvaluation(item, item.IsCorrect ? itemMarkedFlag : !itemMarkedFlag));
        }

        return itemEvaluations;
    }
}
```');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9930, -993, 'Naziv je ispravan');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99300,-9930, 'itemEvaluations', 'Ovaj naziv kratko i jasno označava kakvi podaci se nalaze u promenljivoj.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9931, -993, 'Naziv nije na odgovarajućem nivou apstrakcije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9932, -993, 'Naziv ne prati timske konvencije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9933, -993, 'Naziv sadrži beznačajne reči');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99330,-9933, 'itemMarkedFlag', '"Flag" je redundantna reč, gde je iz naziva i tipa jasno da je u pitanju flag podatak.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9934, -993, 'Naziv ne koristi ispravnu terminologiju domena problema');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99340,-9934, 'CheckAnswers', '"Answers" se nigde ne pominje van ovog naziva, te bi ovu reč trebalo zameniti sa "Items".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9935, -993, 'Naziv ne uzima u obzir širi kontekst');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99350,-9935, 'EvaluateMrqSubmission', '"MrqSubmission" se jednostavno može izvući iz parametra.');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-992, -97, 4);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-992, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9920, 'Treba da izbegavamo tehnološke reči u našim imenima.', false, 'Izjava nije tačna. U redu je da imamo reči poput "File", "HTTP" i "Queue" u našim nazivima, ali ciljamo da ove koncepte izdvojimo od poslovne logike.', -992);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9921, 'Kod koji opisuje poslovnu logiku treba u većoj meri da bude čitljiv od strane našeg klijenta.', true, 'Izjava je tačna. Kada koristimo imenice iz domena da opišemo klase i promenljive i glagole da opišemo metode, naš kod je čitljiv od strane osobe koja poznaje domen - naš klijent.', -992);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9922, 'Potrebno je dobro ime izabrati u startu, zato što je naknadna promena skupa.', false, 'Izjava nije tačna. Promena imena za gotovo svaki element koda je trivijalna operacija uz pomoć savremenih editora koda.', -992);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-991, -97, 5);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-991, '
Analiziraj sledeći kod i rasporedi nazive u odgovarajuće kategorije u zavisnosti od toga da li krše neki princip dobrog imenovanja.
```csharp
public class Cart {
    public Cart(UUID cartId, String customerId, List<CartItem> cartItems) {
        this.cartId = cartId;
        this.customerId = customerId;
        this.cartItems = cartItems;
    }

    private UUID cartId;
    private String customerId;
    private List<CartItem> cartItems = new ArrayList<>();
    private int maxItemsLimit = 10;

    public boolean IsBasketEmpty() {
        return cartItems.size() <= 0;
    }

    public int NumberOfItems() {
        return cartItems.size();
    }

    public void AddItemToCart(CartItem cartItem) {
        if (NumberOfItems() + 1 < maxItemsLimit) {
            this.cartItems.add(cartItem);
        } else {
            // Throw Exception for violating limit.
        }
    }

    public decimal GetSumOfAllItemPrices() {
        decimal sum = 0;
        foreach(var item in this.cartItems)
        {
            sum += item.Price;
        }
        return sum;
    }
}
```');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9910, -991, 'Naziv je ispravan');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99100,-9910, 'maxItemsLimit', 'Ovaj naziv kratko i jasno označava kakvi podaci se nalaze u atributu.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9911, -991, 'Naziv nije na odgovarajućem nivou apstrakcije');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99110,-9911, 'GetSumOfAllItemPrices', '"GetTotalPrice" ili sličan naziv bi bolje opisao šta metoda radi, bez da ulazi u detalje kako to radi.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9912, -991, 'Naziv ne koristi ispravne tipove reči');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99120,-9912, 'NumberOfItems', 'Ovakav naziv je ispravan kao ime atributa ili property-a. Za metodu bi bolji naziv bio u obliku glagola, poput "CountItems" ili "GetNumberOfItems".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9913, -991, 'Naziv ne prati timske konvencije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9914, -991, 'Naziv ne koristi ispravnu terminologiju domena problema');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99140,-9914, 'IsBasketEmpty', '"Basket" se nigde ne pominje van ovog naziva, te bi ovu reč trebalo zameniti sa "Cart".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9915, -991, 'Naziv ne uzima u obzir širi kontekst');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99150,-9915, 'AddItemToCart', 'Pošto se poziva nad instancom klase Cart, "ToCart" je suvišno. Pošto prihvata kao jedini parametar CartItem, i "Item" može biti suvišno, posebno ako je ovo jedina metoda koja dodaje nešto.');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-990, -96, 1);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-990, 'Posmatrajući sledeću strukturu paketa, navedi nazive klasa (razdvojene zarezom i bez .cs) koji krše konvenciju.

- Hospital
  - Core
    - Patients
      - Model
        - Patient.cs
        - PatientRecord.cs
      - Repository
        - PatientRepository.cs
      - MedicalRecordService.cs
    - Physicians
      - Model
        - Physician.cs
        - Specialization.cs
      - Repository
        - PhysicianStorage.cs
      - PhysicianService.cs
    - Schedule
       - Model
         - PhysicianSchedule.cs
         - Appointment.cs
      - Repository
        - PhysicianScheduleRepository.cs
       - ScheduleService.cs
  - Controllers
    - PatientRecordController.cs
    - ScheduleController.cs', '{"MedicalRecordService, PhysicianStorage"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-989, -96, 2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-989, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji krše česte konvencije u pisanju programa.
```csharp
public List<string> GetCamelCaseWords(List<string> Words)
{
    List<string> camelCaseWords = new List<string>();
    foreach (string word in Words)
    {
        var word_parts = Regex.Split(word, "[A-Z]");
        var matches = Regex.Matches(word, "[A-Z]");
        for (int idx = 0; idx < word_parts.Length - 1; idx++)
        {
            word_parts[idx + 1] = matches[idx] + word_parts[idx + 1];
        }
        camelCaseWords.AddRange(word_parts);
    }

    return camelCaseWords;
}
```', '{"Words, word_parts, idx"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-988, -95, 1);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-988, 'Često definišemo naše nazive koristeći generične ili beznačajne reči koje ponavljaju očiglednu informaciju ili ništa posebno ne kažu. U sklopu direktorijuma "Naming/01. Noise Words" isprati zadatke u zaglavlju klase i ukloni suvišne reči iz imena u kodu.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Noise', 'https://youtu.be/sR8hjHldAfI');
--TODO: STRATEGIES AND HINTS

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-987, -95, 2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-987, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji sadrža beznačajne reči.
```csharp
public int GetEffectiveLinesOfCode(string codeAsString)
{
    string code = RemoveCodeComments(codeAsString);
        
    var allLines = code.Split(new[] { "\r\n", "\r", "\n" });
    int ignoreLineCount = CountBlankLines(allLines);
    int ignoreLineCount2 = CountHeaderLines(allLines);
        
    return Math.Max(allLines.Length - (ignoreLineCount + ignoreLineCount2 + 2), 1);
}
```', '{"codeAsString, ignoreLineCount2"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-986, -95, 3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-986, 'Analiziraj sledeći kod i označi sve nazive koje smatraš da sadrže beznačajne reči.
```csharp
public string GetSignature()
{
    StringBuilder signatureBuilder = new StringBuilder();
    signatureBuilder.Append(Name);
    if (Params != null)
    {
        signatureBuilder.Append("(");
        for (var i = 0; i < Params.Count; i++)
        {
            signatureBuilder.Append(Params[i].Type.FullName);
            if (i < Params.Count - 1) signatureBuilder.Append(", ");
        }

        signatureBuilder.Append(")");
    }

    return signatureBuilder.ToString();
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9860, 'GetSignature', false, 'Uklanjanje bilo koje reči bi učinilo naziv nevalidnim, gde "Get" samo po sebi ne daje dovoljno informacija šta se dobavlja, a "Signature" predstavlja imenicu što nije pogodan tip reči za metodu.', -986);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9861, 'signatureBuilder', false, 'Obe reči su bitne. Iako nezgodan primer, "Builder" je bitna reč. Ukazuje na to da se u promenljivi ne nalazi potpis funkcije, već mehanizam za njegovu izgradnju.', -986);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9862, 'FullName', false, 'Obe reči su bitne. Ovaj primer zahteva dublje razumevanje koncepta punog imena klase, koji podrazumeva uz naziv klase i naziv namespace-a kom pripada.', -986);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-985, -94, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-985, 'Označi nazive koji ne poštuju pravilo za upotrebu prikladnog tipa reči.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9850, 'public bool IsValid(User user)', false, '"IsValid" predstavlja pitanje i prihvatljivo je da ovako formulišemo naziv.', -985);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9851, 'public void Validate(User user)', false, 'Ovo je ispravan naziv.', -985);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9852, 'public bool Valid(User user)', true, 'Ovo nije ispravan naziv, jer "Valid" ne predstavlja glagol, a koristi se kao naziv funkcije.', -985);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9853, 'public class UserValidator', false, 'Ovo je ispravan naziv, gde se imenica koristi da označi naziv klase.', -985);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9854, 'public class ValidateUser', true, 'Ovo nije ispravan naziv, jer se glagol koristi da označi naziv klase.', -985);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-984, -94, 2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-984, 'Posmatrajući sledeći kod, unesi naziv identifikatora koji ne koristi ispravan tip reči.
```csharp
public void AddToCart(int carId)
{
    var cartItem = CartItem(carId);
    if (cartItem == null)
    {
        cartItem = new CartItem
        {
            CarId = recordingId,
            Quantity = 1
        };

        items.Add(cartItem);
    }
    else
    {
        cartItem.Quantity++;
    }
}
```', '{"CartItem"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-983, -94, 3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-983, 'Označi nazive koji predstavljaju ispravan tip reči.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9830, 'public void Put(List<Employee> employees)', true, 'Nazivi ove funkcije i njenih parametra su ispravni.', -983);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9831, 'public class GeneratedReport', true, 'Naziv ove klase je ispravan što se tiče tipa reči, no svakako je upitno šta predstavlja koncept "generisanog" izveštaja.', -983);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9832, 'public void Register(User createUser)', false, 'Naziv funkcije koristi ispravan tip reči, dok naziv parametra predstavlja glagol, gde je očekivano da bude imenica.', -983);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9833, 'public class Registry', true, 'Naziv klase je ispravno imenica.', -983);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-982, -93, 1);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-982, '*Order* klasa predstavlja porudžbinu koju korisnik može da formira (npr. u kontekstu poručivanja hrane preko Wolt/Glovo aplikacija). Instance ove klase sadrže podatke poput stavki porudžbine i njenog statusa (npr. kreirana, prihvaćena, otkazana).
Koristeći terminologiju domena problema, kako bismo nazvali (na engleskom, *PascalCase*) metodu koja treba da se pozove nad instancom *Order* klase kada korisnik želi da otkaže svoje porudžbinu?', '{"Cancel", "CancelOrder"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-981, -93, 2);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-981, 'U svojoj brzopletosti, često nabacamo kratke nazive kako bismo što pre formirali kod koji radi. U sklopu direktorijuma "Naming/02. Domain Words" izmeni nazive tako da ukloniš potrebu za komentarima i isprati zadatke u zaglavlju klase.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Domain', 'https://youtu.be/8OYsu0dza0k');
--TODO: STRATEGIES AND HINTS

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-980, -93, 3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-980, 'Označi kod iz naredne liste koji smatraš da potiče iz klasa koje opisuju domen problema, odnosno poslovne logike.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9800, 'string.join(":", patientRecord)', false, 'Ovo nije naziv iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -980);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9801, 'Close(Account account)', true, 'Ovaj naziv je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -980);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9802, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovaj naziv ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je naziv metode bio samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -980);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9803, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj, a ne deo domena problema.', -980);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9804, 'Register(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. sportskog kluba ili biblioteke).', -980);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-979, -93, 4);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-979, '*Schedule* klasa sabira sastanke i obaveze koje korisnik ima u toku dana (npr. u kontekstu *Google Calendar* aplikacije). Instance ove klase sadrže spisak događaja (engl. *Appointment*), gde je svaki definisan sa nazivom, vremenom početka i završetka.
Koristeći terminologiju domena problema, kako bismo nazvali (na engleskom, *PascalCase*) metodu koja se poziva nad *Schedule* objektom, prihvata dužinu trajanja događaja u minutima i pronalazi prvi slobodan termin (engl. Timeslot) kada se događaj može zakazati.', '{"FindFirstAvailableTimeslot", "GetFirstAvailableTimeslot"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-978, -92, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-978, 'Razmotri sledeći kod.
```csharp
namespace DSE.Core.DataSets
{
    public class DataSetProject : DSEObject
    {
        public int Id { get; private set; }
        public string DataSetProjectName { get; private set; }
        public string Url { get; private set; }
        private HashSet<CandidateInstances> candidateInstances;
        public ProjectState ProjectState { get; private set; }

        internal DataSetProject(string name, string url)
        {
            DataSetProjectName = name;
            Url = url;
            candidateInstances = new HashSet<SmellCandidateInstances>();
            ProjectState = ProjectState.Processing;
        }

        internal void AddCandidateInstance(CandidateInstances newCandidate)
        {
            CandidateInstances.Add(newCandidate);
        }
    }
}
```
Posmatrajući nazive iz prethodnog koda, označi one koji nepotrebno ponavljaju reči iz šireg konteksta i koje bi trebalo refaktorisati.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9780, 'DataSetProject', false, 'Naziv je korektan i označava projekat u okviru nekog skupa podataka.', -978);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9781, 'DSEObject', false, 'Naziv je korektan, no primer je nezgodan. DSE je korenski namespace, što znači da akronim DSE predstavlja ime aplikacije. Po logici ovog naziva bismo mogli svaku klasu da nazovemo sa prefiksom DSE, što bi bilo izuzetno redundantno. Međutim, u ovom slučaju ima smisla jer bez prefiksa ostaje ključna reč Object koja ima posebno značenje u objektno-orijentisanim jezicima. Možemo pretpostaviti da je DSEObject nekakva korenska klasa koja sadrži podatke i logiku zajedničku za značajan deo ove aplikacije.', -978);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9782, 'DataSetProjectName', true, 'Naziv polja redundantno ponavlja ime svoje klase. "Name" bi bilo dovoljno da se razume da podatak predstavlja ime projekta.', -978);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9783, 'ProjectState (naziv enumeracije)', false, 'Naziv je korektan. "State" bi bilo previše opšte, dok bi "DatasetProjectState" bilo donekle redundantno, pod pretpostavkom da DSE aplikacija nema više različitih projekata, posebno u Datasets namespace-u.', -978);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9784, 'ProjectState (naziv atributa)', true, 'Naziv sadrži redundantnu reč "Project". Pošto su ostali atributi izuzetno jasni u svom značenju, neće doći do konfuzije ako bismo ostavili samo reč "State" za naziv ovog polja.', -978);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9785, 'AddCandidateInstance', true, 'Naziv je redundantan, uzimajući u obzir naziv parametra i njegovog tipa. "Add" bi bio dovoljan pod pretpostavkom da nema drugih metoda koje nešto dodaju. U suprotnom bi "AddInstances" mogao da bude dovoljan.', -978);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-977, -92, 2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-977, 'Analiziraj sledeći kod koji je deo `CCMethod` klase i navedi sve nazive (odvojene zarezom) koje smatraš da se mogu pojednostaviti analizom šireg konteksta.
```csharp
public string GetMethodSignature()
{
    StringBuilder signatureBuilder = new StringBuilder();
    signatureBuilder.Append(Name);
    if (Params != null)
    {
        signatureBuilder.Append("(");
        for (var i = 0; i < Params.Count; i++)
        {
            signatureBuilder.Append(Params[i].Type.FullNameOfType);
            if (i < Params.Count - 1) signatureBuilder.Append(", ");
        }

        signatureBuilder.Append(")");
    }

    return signatureBuilder.ToString();
}
```', '{"GetMethodSignature, FullNameOfType"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-976, -92, 3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-976, 'Ako treba da analiziramo širi kontekst prilikom formiranja naziva, označi nazive funkcija koje sadrže dobar naziv.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9760, 'void RegisterTemporaryUser(User user)', true, 'Ovo je dobar naziv iako je težak primer. Reč "User" jeste redundantna, no njeno uklanjanje bi ostavilo reč "Temporary" da visi bez imenice na koju se odnosi. Ključno je da je operacija registracije privremenog korisnika drugačija od registracije redovnog korisnika zbog čega nam znači diferencijacija u nazivu.', -976);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9761, 'ChallengeEvaluation Evaluate(ChallengeSubmission submission)', true, 'Ovo je ispravan naziv. Iako se "Evaluate" ponavlja u delu naziva tipa povratne vrednosti, dati naziv jasno i koncizno opisuje da se ovde vrši provera submisije za izazov.', -976);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9762, 'List<Doctor> GetDoctorsForOperation(Operation operation)', false, 'Ovo nije dobar naziv jer redundantno opisuje parametar.', -976);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9763, 'Dictionary<MetricId, double>> GetMetricValueMap()', false, 'Ovo nije dobar naziv, jer redundantno opisuje tip povratne vrednosti. Reč Map je sinonim za Dictionary, te je treba izbaciti iz naziva.', -976);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9764, 'void RegisterUser(User user)', false, 'Ovo nije dobar naziv, gde je reč "User" redundantna.', -976);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-975, -91, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-975, 'Ako tvrdimo da jasan naziv objašnjava šta parče koda radi, a ne kako to radi, označi funkcije koje imaju naziv na dobrom nivou apstrakcije.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9750, 'Employee Get(int employeeId)', true, 'Ovo je dobar naziv, pod pretpostavkom da se glagol "Get" po konvenciji koristi za svako čuvanje entiteta.', -975);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9751, 'List<DatasetInstance> FindInstancesRequiringAdditionalAnnotation(Dataset dataset)', true, 'Ovo je dobar naziv, jer apstrahuje detalje koji određuju šta znači da instanca nije dovoljno anotirana, a opet dodatno opisuje šta će ta povratna vrednost da predstavlja, odnosno da nije bilo kakva lista instanci.', -975);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9752, 'decimal ApplyDiscountToOrder(Order order, Discount discount)', false, 'Ovo nije dobar naziv jer opisuje kako se cena računa. Bolje ime bi bilo "CalculatePrice(Order order, Discount discount)" koje ističe nameru funkcije, a iz parametra se vidi da se popust uvažava.', -975);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9753, 'void SaveIfValid(Employee employee)', false, 'Ovo nije dobar naziv jer otkriva detalje implementacije u vidu provere validnosti prosleđenog objekta. "Save" je naziv na boljem nivou apstrakcije.', -975);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-974, -91, 2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-974, 'Razmotri sledeći zahtev i definiši ime funkcije na prikladnom nivou apstrakcije (samo ime, bez zagrada i parametra), prateći *PascalCase* konvenciju i koristeći engleski jezik.

Pored osnovnih podataka, entitet zaposlenog sadrži listu odsustva koje uključuju godišnje odmore i bolovanja (engl. *sick leave*). Potrebno je definisati funkciju koja će da pronađe sve zaposlene koji nisu uzeli bolovanje u određenoj godini, gde se godina prosleđuje kao parametar. Šta je prikladno ime za ovu funkciju?', '{"GetEmployeesWithoutSickLeave", "FindEmployeesWithoutSickLeave", "GetEmployeesWithNoSickLeave", "FindEmployeesWithNoSickLeave"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-973, -91, 3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-973, 'Ako tvrdimo da jasan naziv objašnjava šta parče koda radi, a ne kako to radi, označi funkcije koje imaju naziv na dobrom nivou apstrakcije.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9730, 'List<Doctor> GetAvailableAndCapableDoctors(Operation operation)', false, 'Ovo nije dobar naziv jer opisuje sadržaj tela funkcije.', -973);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9731, 'List<Doctor> GetDoctors(Operation operation)', false, 'Ovaj naziv je na granici, no verovatno je previše apstraktan. Naime, iz naziva nije jasno kakav skup lekara se dobija. Uzimajući u obzir i parametar se može naslutiti, no zahteva mentalno mapiranje.', -973);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9732, 'List<Doctor> GetSuitableDoctors(Operation operation)', true, 'Ovaj naziv se nalazi na optimalnom nivou apstrakcije.', -973);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9733, 'List<Doctor> Get(Operation operation)', false, 'Ovaj naziv je previše apstraktan. Uz ozbiljno mentalno mapiranje je moguće razumeti nameru ove funkcije ako se posmatra povratna vrednost i parametar. Ovakav napor želimo da izbegnemo u našem kodu.', -973);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-972, -91, 4);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-972, 'Razmotri sledeći zahtev i definiši ime funkcije na prikladnom nivou apstrakcije (samo ime, bez zagrada i parametra), prateći *PascalCase* konvenciju i koristeći engleski jezik.

Postoji klasa koja predstavlja duž (*Line*). Ona sadrži dva atributa tipa *Point* gde svaki predstavlja jednu tačku duži i sastoji se od koordinata X i Y. *Line* klasa nudi metodu koja računa rastojanje između dve tačke koristeći formulu *√((p2.x-p1.x)²+(p2.y-p1.y)²)*, čime se dobija dužina duži. Šta je prikladno ime za ovu funkciju?', '{"GetLength", "CalculateLength"}');





INSERT INTO public."LearnerGroups"("Id", "Name") VALUES
	(-996, 'Test Group');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-1000, 'TT-1-2022', 'vcweKQcmg9cUXTyZpGkbtYQaLTaEs576LTv+AEU/h54=', 'GW4e6yYZDe5fmGH4Whicdg==', 2); -- Password: tutor1

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-1000, -1000, 'TT-1-2022', 'Pero', 'Perić');

INSERT INTO public."GroupMemberships"("Id", "LearnerId", "LearnerGroupId") VALUES
	(-1000, -1000, -996);

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-999, 'TT-2-2022', 'ql1gkQ4uFMV/0JfGFpd5N5Qn/aAo9Na+bm6/yCc71uk=', 'AoVeUEx37NKGu9f5vp1LOg==', 2); -- Password: tutor2

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-999, -999, 'TT-2-2022', 'Miko', 'Mikić');

INSERT INTO public."GroupMemberships"("Id", "LearnerId", "LearnerGroupId") VALUES
	(-999, -999, -996);

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-998, 'TT-3-2022', 'wdt/cifXc55zpc2qLZpPcHBgENNfGtANsRivVHmK6xU=', 'Hg40JK10S0d/jy1SeyHsvw==', 2); -- Password: tutor3

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-998, -998, 'TT-3-2022', 'Stevo', 'Stević');

INSERT INTO public."GroupMemberships"("Id", "LearnerId", "LearnerGroupId") VALUES
	(-998, -998, -996);

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-997, 'TT-4-2022', 'con+oYVwHZYEpzmXHmPcZIydGyq3Zz9WF0o6nG6Yikg=', '2fbvbSJNFG+sRCL4xw6ZSA==', 1); -- Password: tutor4

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-997, -997, 'TT-4-2022', 'Admin', 'Adminić');

INSERT INTO public."GroupMemberships"("Id", "LearnerId", "LearnerGroupId") VALUES
	(-997, -997, -996);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9999, -1000, -100, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9998, -1000, -99, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9999, 0.00, -100, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-100000, -1000, 0.00, 0, NULL, -9999);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9998, 0.00, -99, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99999, -999, 0.00, 0, NULL, -9998);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9997, 0.00, -98, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99998, -998, 0.00, 0, NULL, -9997);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99997, -997, 0.00, 0, NULL, -9997);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99996, -996, 0.00, 0, NULL, -9997);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9996, 0.00, -97, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99995, -995, 0.00, 0, NULL, -9996);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99994, -994, 0.00, 0, NULL, -9996);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99993, -993, 0.00, 0, NULL, -9996);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99992, -992, 0.00, 0, NULL, -9996);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99991, -991, 0.00, 0, NULL, -9996);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9995, 0.00, -96, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99990, -990, 0.00, 0, NULL, -9995);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99989, -989, 0.00, 0, NULL, -9995);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9994, 0.00, -95, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99988, -988, 0.00, 0, NULL, -9994);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99987, -987, 0.00, 0, NULL, -9994);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99986, -986, 0.00, 0, NULL, -9994);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9993, 0.00, -94, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99985, -985, 0.00, 0, NULL, -9993);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99984, -984, 0.00, 0, NULL, -9993);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99983, -983, 0.00, 0, NULL, -9993);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9992, 0.00, -93, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99982, -982, 0.00, 0, NULL, -9992);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99981, -981, 0.00, 0, NULL, -9992);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99980, -980, 0.00, 0, NULL, -9992);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99979, -979, 0.00, 0, NULL, -9992);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9991, 0.00, -92, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99978, -978, 0.00, 0, NULL, -9991);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99977, -977, 0.00, 0, NULL, -9991);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99976, -976, 0.00, 0, NULL, -9991);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9990, 0.00, -91, -1000, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99975, -975, 0.00, 0, NULL, -9990);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99974, -974, 0.00, 0, NULL, -9990);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99973, -973, 0.00, 0, NULL, -9990);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99972, -972, 0.00, 0, NULL, -9990);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9997, -999, -100, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9996, -999, -99, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9989, 0.00, -100, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99971, -1000, 0.00, 0, NULL, -9989);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9988, 0.00, -99, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99970, -999, 0.00, 0, NULL, -9988);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9987, 0.00, -98, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99969, -998, 0.00, 0, NULL, -9987);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99968, -997, 0.00, 0, NULL, -9987);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99967, -996, 0.00, 0, NULL, -9987);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9986, 0.00, -97, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99966, -995, 0.00, 0, NULL, -9986);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99965, -994, 0.00, 0, NULL, -9986);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99964, -993, 0.00, 0, NULL, -9986);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99963, -992, 0.00, 0, NULL, -9986);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99962, -991, 0.00, 0, NULL, -9986);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9985, 0.00, -96, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99961, -990, 0.00, 0, NULL, -9985);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99960, -989, 0.00, 0, NULL, -9985);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9984, 0.00, -95, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99959, -988, 0.00, 0, NULL, -9984);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99958, -987, 0.00, 0, NULL, -9984);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99957, -986, 0.00, 0, NULL, -9984);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9983, 0.00, -94, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99956, -985, 0.00, 0, NULL, -9983);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99955, -984, 0.00, 0, NULL, -9983);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99954, -983, 0.00, 0, NULL, -9983);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9982, 0.00, -93, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99953, -982, 0.00, 0, NULL, -9982);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99952, -981, 0.00, 0, NULL, -9982);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99951, -980, 0.00, 0, NULL, -9982);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99950, -979, 0.00, 0, NULL, -9982);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9981, 0.00, -92, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99949, -978, 0.00, 0, NULL, -9981);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99948, -977, 0.00, 0, NULL, -9981);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99947, -976, 0.00, 0, NULL, -9981);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9980, 0.00, -91, -999, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99946, -975, 0.00, 0, NULL, -9980);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99945, -974, 0.00, 0, NULL, -9980);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99944, -973, 0.00, 0, NULL, -9980);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99943, -972, 0.00, 0, NULL, -9980);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9995, -998, -100, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9994, -998, -99, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9979, 0.00, -100, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99942, -1000, 0.00, 0, NULL, -9979);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9978, 0.00, -99, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99941, -999, 0.00, 0, NULL, -9978);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9977, 0.00, -98, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99940, -998, 0.00, 0, NULL, -9977);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99939, -997, 0.00, 0, NULL, -9977);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99938, -996, 0.00, 0, NULL, -9977);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9976, 0.00, -97, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99937, -995, 0.00, 0, NULL, -9976);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99936, -994, 0.00, 0, NULL, -9976);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99935, -993, 0.00, 0, NULL, -9976);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99934, -992, 0.00, 0, NULL, -9976);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99933, -991, 0.00, 0, NULL, -9976);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9975, 0.00, -96, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99932, -990, 0.00, 0, NULL, -9975);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99931, -989, 0.00, 0, NULL, -9975);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9974, 0.00, -95, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99930, -988, 0.00, 0, NULL, -9974);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99929, -987, 0.00, 0, NULL, -9974);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99928, -986, 0.00, 0, NULL, -9974);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9973, 0.00, -94, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99927, -985, 0.00, 0, NULL, -9973);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99926, -984, 0.00, 0, NULL, -9973);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99925, -983, 0.00, 0, NULL, -9973);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9972, 0.00, -93, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99924, -982, 0.00, 0, NULL, -9972);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99923, -981, 0.00, 0, NULL, -9972);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99922, -980, 0.00, 0, NULL, -9972);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99921, -979, 0.00, 0, NULL, -9972);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9971, 0.00, -92, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99920, -978, 0.00, 0, NULL, -9971);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99919, -977, 0.00, 0, NULL, -9971);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99918, -976, 0.00, 0, NULL, -9971);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9970, 0.00, -91, -998, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99917, -975, 0.00, 0, NULL, -9970);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99916, -974, 0.00, 0, NULL, -9970);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99915, -973, 0.00, 0, NULL, -9970);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99914, -972, 0.00, 0, NULL, -9970);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9993, -997, -100, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9992, -997, -99, '5/30/2022 3:06:27 PM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9969, 0.00, -100, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99913, -1000, 0.00, 0, NULL, -9969);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9968, 0.00, -99, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99912, -999, 0.00, 0, NULL, -9968);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9967, 0.00, -98, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99911, -998, 0.00, 0, NULL, -9967);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99910, -997, 0.00, 0, NULL, -9967);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99909, -996, 0.00, 0, NULL, -9967);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9966, 0.00, -97, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99908, -995, 0.00, 0, NULL, -9966);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99907, -994, 0.00, 0, NULL, -9966);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99906, -993, 0.00, 0, NULL, -9966);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99905, -992, 0.00, 0, NULL, -9966);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99904, -991, 0.00, 0, NULL, -9966);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9965, 0.00, -96, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99903, -990, 0.00, 0, NULL, -9965);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99902, -989, 0.00, 0, NULL, -9965);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9964, 0.00, -95, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99901, -988, 0.00, 0, NULL, -9964);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99900, -987, 0.00, 0, NULL, -9964);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99899, -986, 0.00, 0, NULL, -9964);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9963, 0.00, -94, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99898, -985, 0.00, 0, NULL, -9963);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99897, -984, 0.00, 0, NULL, -9963);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99896, -983, 0.00, 0, NULL, -9963);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9962, 0.00, -93, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99895, -982, 0.00, 0, NULL, -9962);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99894, -981, 0.00, 0, NULL, -9962);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99893, -980, 0.00, 0, NULL, -9962);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99892, -979, 0.00, 0, NULL, -9962);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9961, 0.00, -92, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99891, -978, 0.00, 0, NULL, -9961);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99890, -977, 0.00, 0, NULL, -9961);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99889, -976, 0.00, 0, NULL, -9961);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession") VALUES
	(-9960, 0.00, -91, -997, false, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99888, -975, 0.00, 0, NULL, -9960);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99887, -974, 0.00, 0, NULL, -9960);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99886, -973, 0.00, 0, NULL, -9960);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99885, -972, 0.00, 0, NULL, -9960);

-- T00 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-1, 'Cilj "hinta" je da ti usmeri razmišljanje bez da direktno ponudi odgovor na zadatak. Spram toga "rešenje" nudi kod ili video koji direktno prikazuju kako izgleda konačno rešenje. Da bi završio ovaj izazov neophodno je da preimenuješ polje "Challenge" u "_completed". Vidimo da je ovaj hint izuzetak zato što nudi konačno rešenje.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-1, -1000);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-1, '{"Challenge"}', -1);
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-2, -1000);
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
	VALUES (-31, -994);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-31, '{"List","string"}', -31);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-32, 'Izbegavaj misteriozne nazive koji ne objašnjavaju šta dati identifikator predstavlja (npr. nazive sa jednim slovom, a da nisu iteratori petlje).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-32, -994);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-32, '{"s","e"}', -32);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-33, 'Razmisli kako da integrišeš domenski značajne reči poput "Syntagms", "pascalCase", "capital" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-33, -994);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-33, '{"syntagms","pascalCase","capital"}', -33);

-- N03 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-11, 'Izbegavaj generične reči koje se mogu koristiti da opišu bilo kakav kod (npr. Manager, Data), kao i one koje ponavljaju informacije koje već stoje u nazivu tipa (npr. List, Num).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-11, -988);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-11, '{"Data","Info","Str","Set","The"}', -11);
	

-- N05 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-21, 'Razmisli kako da integrišeš domenski značajne reči poput "Enroll", "newCourse", "Maximum" i "Active" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-21, -981);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-21, '{"Enroll","newCourse","Maximum","Active"}', -21);