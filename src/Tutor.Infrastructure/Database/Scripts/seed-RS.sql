DELETE FROM public."Submissions";
DELETE FROM public."ArrangeTaskContainerSubmissions";
DELETE FROM public."Texts";
DELETE FROM public."Images";
DELETE FROM public."Videos";
DELETE FROM public."MetricRangeRules";
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
DELETE FROM public."AssessmentEvents";
DELETE FROM public."InstructionalEvents";
DELETE FROM public."KnowledgeComponents";
DELETE FROM public."Units";
DELETE FROM public."Learners";

INSERT INTO public."Units"("Id", "Code", "Name", "Description") VALUES
	(-1, 'CC01', 'Značajni nazivi', 'Nazive pronalazimo u svim segmentima razvoja softvera - kod identifikatora promenljive, funkcije, klase, ali i biblioteke i aplikacije. Jasan naziv funkcije nas oslobađa od čitanja njenog tela, dok će misteriozni naziv zahtevati dodatan mentalni napor da razumemo svrhu koncepta koji opisuje. U najgorem slučaju, loš naziv će nas naterati da formiramo pogrešnu pretpostavku, što će nam drastično produžiti vreme razvoja. Kroz ovaj modul ispitujemo dobre i loše prakse za formiranja naziva identifikatora u kodu.');

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-1, 'N01', 'Konstruiši značajne nazive za identifikatore u kodu', '', -1, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-2, 'N02', 'Prati timske konvencije prilikom formiranja naziva', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-3, 'N03', 'Izbegavaj beznačajne reči', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-4, 'N04', 'Primeni prikladne tipove reči', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-5, 'N05', 'Koristi terminologiju domena problema', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-6, 'N06', 'Analiziraj širi kontekst prilikom formiranja naziva', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-7, 'N07', 'Formiraj naziv na dobrom nivou apstrakcije', '', NULL, -1);

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-1, -1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-1, 'Van jednostavnih slučajeva, izbor pravog naziva je proces koji podrazumeva sledeće korake:

1. Opisivanje koncepta koji želimo da imenujemo kroz rečenicu ili dve, koristeći prikladnu terminologiju iz domena problema ili rešenja. Često ćemo ovaj opis pronaći ili ostaviti u tekstu komentara koji stoji uz koncept, sa ciljem da dodatno pojasni šta koncept predstavlja. Ovaj tekst je lakše formirati na maternjem jeziku, a kada smo zadovoljni sa opisom možemo prevesti na engleski (uz moguću pomoć onlajn prevodioca).
2. Uklanjanje svih *noise* reči, odnosno redundantnih imenica, veznika i priloga koji nisu ključni za prenošenje svrhe koncepta koji imenujemo.
3. Uklanjanje svih preostalih reči koje se jednostavno izvlače iz šireg konteksta, poput naziva **tipa** (npr. povratne vrednosti, parametra ili promenljive), **modula** kom dati element pripada (npr. klase ili paketa) i dodatnih elemenata (npr. nazivi parametra i njihovih tipova kod funkcije koju imenujemo).
4. Razmatranje da li preostale reči opisuju koncept na dobrom nivou apstrakcije i da li predstavljaju glagol za metodu ili funkciju, odnosno imenicu u preostalim slučajevima.
5. Postavljanje novog imena.

Navedeni algoritam nije jednokratna aktivnost. Često je potrebno nekoliko iteracija i preimenovanja da bismo stigli do imena koje je dovoljno jasno i značajno. Na sreću, savremeni IDE alati pružaju podršku za lako preimenovanje elemenata koda. Ako kod prolazi *build* posle preimenovanja, možemo biti uvereni da nismo uveli nove greške u kod.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-2, -1);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-2, 'https://i.ibb.co/vqjMTyJ/simple-names-sr.png', 'U većini slučajeva kada hoćemo da stavimo komentar, pravo rešenje je smišljanje jasnijeg imena.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-3, -1);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-3, '');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-4, -2);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-4, 'Idealan naziv treba jasno da odredi neku operaciju ili pojam. Zbog ovoga je neophodno izbegavati sinonime i pratiti timske konvencije.

Kao primer možemo zamisliti skup klasa čiji zadatak je da učitaju različite entitete iz skladišta. Jedna klasa učitava jedan entitet i sadrži logiku za serijalizaciju i deserijalizaciju datog entiteta (takozvane *Repository* klase). Ako većina ovakvih klasa poseduje metodu čiji naziv počinje sa `Get`, programer će morati da zastane ako naleti na metodu koja učitava određeni entitet i ime joj počinje sa `Load`. Postaviće se pitanje da li je `Load` drugačije od `Get` i da li treba nešto drugačije uraditi sa `Load` metodama. Da bi bio siguran, programer mora da otvori kod metode `Load` i da proveri da ne postoji neka bitna razlika, čime troši vreme.

Prethodni problem neće izazvati velik trošak vremena, no gomila ovakvih prekršaja će svakako opteretiti programera. Dalje, postoji mogućnost da će programer u nedostatku `Get` funkcije implementirati takvu metodu, iako nespretno nazvan `Load` već radi traženi posao.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-5, -2);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-5, 'Određene konvencije potiču iz programskog jezika ili tehnologija koje koristimo. One mogu i često jesu usvojene kao timske konvencije. Primeri ovakvih konvencija uključuju:

- `i` i `j` koji se koriste za nazive promenljiva koje prate broj iteracije za `for` petlje.
- `Controller`, `Service`, `Repository` i `Dto` reči koje se koriste kao sufiksi u nazivima određenih klasa, gde date reči jasno označavaju deo odgovornosti date klase.
- Upotreba *PascalCase* notacije za nazivanje klasa i metoda u C# programskom jeziku, kao i upotreba *pascalCase* notacije za formiranje naziva ostalih identifikatora.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-6, -3);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-6, 'Prilikom formiranja naziva treba da izbegnemo dodavanje beznačajnih prefiksa i sufiksa. Tipičan primer nepotrebnog sufiksa nastaje kada se radi *copy & paste* izraza koji definiše promenljivu, gde se na kraj kopirane promenljive doda `1`. Ovaj potez rezultuje brzom pisanju nove instrukcije, ali usporava svako naknadno čitanje.

Treba da izbegavamo redundantne reči koje ponovo ističu tip elementa (npr. `str, string, obj, list, set`). Takođe treba da izbegavamo previše generične reči, poput `Manager, Coordinator, Data, Info`, jer ovakve reči važe za mnoge elemente koda.

U opštem slučaju, prefiksi i sufiksi su prihvatljivi samo kada se prati konvencija tima (čest primer za ovo su `Controller` i `Service` sufiksi koji nose jasno značenje), no i tada se moramo postarati da imamo značajno ime pre nego što uvedemo ovakve dodatke.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-7, -3);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-7, 'https://youtu.be/IusayOJt79E');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-8, -4);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-8, 'Česta konvencija je da reči koje formiraju naziv metode rezultuju glagolom, označavajući da se *nešto radi*, odnosno operacija izvršava kada se metoda pozove. Primeri za ovo uključuju:

- `Buy(Product product)`
- `Open(File file)`
- `LoadSyntaxTrees(List<string> sourceCode)`

Ova konvencija se ponekad narušava kod funkcija koje predstavljaju pitanje čiji odgovor je da (tj. *true*) ili ne (tj. *false*). Primer za ovo je naziv `IsPublished()`.

Nazivi ostalih vrsta identifikatora (npr. za promenljive, polja, klase i pakete) formiramo kao imenice.  Primeri za ovo uključuju:

- `FileParser`
- `User`
- `retiredEmployees`
- `ConfigurationUtilities`');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-9, -5);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-9, 'Domen problema predstavlja oblast za koju pravimo softver. Obuhvata organizacije, ljude, podatke, poslovne procese i znanje koje postoji i bez našeg softvera, sa kojim naš softver treba da interaguje. Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za nazive, gde klase i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata.

Ako pravimo aplikaciju za bolnicu, domen problema uključuje titule i odgovornosti zdravstvenih radnika, strukture dokumenata i stanja u kojim se oni mogu naći, kao i procedure i operacije u kojim učestvuju različiti korisnici. Naš posao će biti da razvijemo funkcionalnosti za podršku ovih korisnika, dokumenata i procedura i tom prilikom treba da ugradimo što više terminologije iz domena problema u naš kod.

Za prethodni primer ova terminologija može da uključi *Doctor* i *Nurse*, zatim *Medical Record* i *Prescription Drug*, kao i *Schedule Operation* i *Cancel Appointment*. Dobra praksa je da konzistentno koristimo ove nazive u delu koda koji modeluje domen problema, kako bismo sav naš razgovor sa korisnicima i stručnjacima iz ovog domena jednostavno mapirali na naš kod.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-10, -5);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-10, 'https://youtu.be/wcIJOmP0R7I');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-11, -5);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-11, 'Zamislimo promenljivu tipa `List<Doctor>`. Šta očekujemo da sadrži ova lista ako je ime promenljive `doctors`, a šta ako je `availableDoctors`, `capableDoctors` ili `suitableDoctor`?

Možemo zamisliti da će se za određenu operaciju razlikovati spisak svih lekara bolnice od onih koji su sposobni ili dostupni da urade datu operaciju. U ovom primeru vidimo kako upotreba odgovarajućeg atributa (slobodan, sposoban ili prikladan) u nazivu ograničava i jasnije određuje očekivani skup vrednosti u promenljivi.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-12, -5);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-12, 'https://i.ibb.co/f144vCk/names-example.png', 'Ovako objektno orijentisani programer imenuje stvari kada izbegava reči iz poslovnog domena.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-13, -6);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-13, 'Svaki element koda pripada nekom širem kontekstu. Promenljive i parametri pripadaju metodi. Atributi i metode pripadaju klasi i dodatno su opisani svojim tipom, odnosno tipom svoje povratne vrednosti. Klasa ima svoj paket, odnosno *namespace*. *Namespace* je deo neke aplikacije.

Prilikom formiranja naziva za neki identifikator treba da uvažimo širi kontekst kom dati identifikator pripada. Naziv mora da bude jasan kada posmatramo njega i nazive iz njegovog šireg konteksta i to tako da izbegnemo redundantne informacije.

Kao primer možemo sagledati metodu sa nazivom `IsCapable`. Bez šireg konteksta nije jasno na šta se odnosi niti šta znači njen rezultat. Međutim, ako znamo da ova metoda pripada klasi `Doctor` i u kodu vidimo liniju poput `if(doctor.IsCapable(operation))` jasno je da je u pitanju provera sposobnosti određenog lekara za prosleđenu operaciju. Naziv `CheckDoctorCapabilityForOperation` jasno govori o čemu je reč bez šireg konteksta, no ovo dovodi do dvostruke redundantnosti u kodu poput `if(doctor.CheckDoctorCapabilityForOperation(operation))`.

Za drugi primer možemo zamisliti promenljivu sa nazivom `state` koja je definisana u okviru metode `FindAvailableRooms`. Posmatrajući samo naziv teško je odrediti kakav podatak je smešten u ovu promenljivu, da li je neko stanje sobe (poput zauzeta, spremna za čišćenja ili slobodna) ili je informacija o opštini u kojoj se traži soba. Naziv tipa promenljive bi mogao da pomogne, no savremeni programski jezici favorizuju upotrebu generične reči za definisanje promenljive, poput `var` ili `let`. Moguće rešenje bi bilo da se naziv preimenuje u `roomState` ili `addressState`.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-14, -7);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-14, 'Jasan naziv objašnjava **šta** povezano parče koda predstavlja, a ne **kako** radi ili od kojih podelemenata se sastoji. Tako jedna funkcija može imati sledeća imena:

 - `List<KeyValuePair<EmployeeId, decimal>> SumBonusesAndSickDaysForSalaryCalculation()`, gde naziv odaje previše detalja i možemo pretpostaviti kako izgleda kod;
 - `List<KeyValuePair<EmployeeId, decimal>> ComputeEmployeeSalaries()` gde je istaknuta suština operacije bez nepotrebnih dodatnih detalja.

Poslednji naziv je na višem nivou apstrakcije od opisa skupa koraka i tipa povratne vrednosti funkcije. Iz perspektive programera koji prvi put gleda ovaj kod, razumemo nameru funkcije bez da ulazimo u detalje njene implementacije i strukture njene povratne vrednosti. Ako nam je zadatak da modifikujemo algoritam za računanje plate, ova funkcija će nam biti interesantna i dublje ćemo je ispitati. Ako nam zadatak nema veze sa ovom funkcionalnošću biće nam dovoljno da pogledamo ime funkcije da znamo da ne moramo da gledamo kod njene implementacije.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-15, -7);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-15, '`Repository` je ključna reč koja se koristi u nazivima klasa čiji zadatak je da interaguju sa skladištem nekakvih podataka. Tako će `EmployeeRepository` imati zadatak da pročita sadržaj nekog skladišta (npr. baze podataka ili datoteke) i formira instance `Employee` klase.

U kontekstu različitih nivoa apstrakcije postavlja se pitanje kako razlikujemo naziv klase `EmployeeRepository` od `EmployeeFileRepository` i `EmployeeSqlRepository` i šta možemo očekivati da je kod svake od ovih klasa. Za naveden primer, razumno očekivanje je sledeće:

- `EmployeeFileRepository` - klasa koja zna da otvori datoteku, serijalizuje i deserijalizuje zaposlenog u format koji datoteka očekuje i zatvori datoteku.
- `EmployeeSQLRepository` - klasa koja zna da se zakači na bazu podataka (direktno ili uz pomoć objektno-relacionog mapera) i postavi joj upit koji će učitati ili sačuvati zaposlenog.
- `EmployeeRepository` - apstrakcija koja ili samo definiše interfejs koji dele prethodne dve klase ili sadrži neku zajedničku logiku koja nije vezana za detalje rada sa datotekom ili SQL bazom podataka.

Kada pišemo kod koji radi sa EmployeeRepository apstrakcijom, ne moramo da se opterećujemo da li se ispod haube dešava interakcija sa bazom ili datotekom. U ovom primeru je koncept "skladišta" apstraktniji od koncepta "datoteke" ili "SQL baze" i naziv ovo oslikava.');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-1, -1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-1, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-10, 'Uvek je bolje dodeliti identifikatoru duži naziv.', false, 'Izjava nije tačna. Iako je često bolje ime koje se sastoji od nekoliko reči umesto od par karaktera, treba da izbegavamo suvišne, redundantne i generične reči i da budemo koncizni. U određenim okolnostima, čak i ime od par karaktera je dopustivo (npr. kada je scope identifikatora ograničen na par linija koda).', -1);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-11, 'Formiranje jasnog imena ubrzava čitanje i pisanje koda.', false, 'Izjava nije tačna. Dobro ime značajno olakšava čitanje koda, no formulisanje jasnog imena je često zahtevan posao i može uzeti više minuta, dok je postavljanje besmislenog imena instant operacija.', -1);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-12, 'Kada formiramo ime za neki element, treba da uzmemo u obzir njegov kontekst (tip, modul kom pripada, itd.)', true, 'Izjava je tačna. Kada zadajemo ime treba da izbegnemo ponavljanje informacije koja je jasno vidljiva iz npr. tipa povratne vrednosti funkcije ili objekta nad kojim se poziva metoda.', -1);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-3, -1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-3, 'Analiziraj sledeći kod i rasporedi nazive u odgovarajuće kategorije u zavisnosti od toga da li krše neki princip dobrog imenovanja.

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
    }');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-30, -3, 'Naziv je ispravan');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-300,-30, 'itemEvaluations', 'Ovaj naziv kratko i jasno označava kakvi podaci se nalaze u promenljivoj.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-31, -3, 'Naziv nije na odgovarajućem nivou apstrakcije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-32, -3, 'Naziv ne prati timske konvencije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-33, -3, 'Naziv sadrži beznačajne reči');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-330,-33, 'itemMarkedFlag', '"Flag" je redundantna reč, gde je iz naziva i tipa jasno da je u pitanju flag podatak.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-34, -3, 'Naziv ne koristi ispravnu terminologiju domena problema');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-340,-34, 'CheckAnswers', '"Answers" se nigde ne pominje van ovog naziva, te bi ovu reč trebalo zameniti sa "Items".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-35, -3, 'Naziv ne uzima u obzir širi kontekst');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-350,-35, 'EvaluateMrqSubmission', '"MrqSubmission" se jednostavno može izvući iz parametra.');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-4, -1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-4, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-40, 'Treba da izbegavamo tehnološke reči u našim imenima.', false, 'Izjava nije tačna. U redu je da imamo reči poput "File", "HTTP" i "Queue" u našim nazivima, ali ciljamo da ove koncepte izdvojimo od poslovne logike.', -4);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-41, 'Kod koji opisuje poslovnu logiku treba u većoj meri da bude čitljiv od strane našeg klijenta.', true, 'Izjava je tačna. Kada koristimo imenice iz domena da opišemo klase i promenljive i glagole da opišemo metode, naš kod je čitljiv od strane osobe koja poznaje domen - naš klijent.', -4);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-42, 'Potrebno je dobro ime izabrati u startu, zato što je naknadna promena skupa.', false, 'Izjava nije tačna. Promena imena za gotovo svaki element koda je trivijalna operacija uz pomoć savremenih editora koda.', -4);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-5, -1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-5, 'Analiziraj sledeći kod i rasporedi nazive u odgovarajuće kategorije u zavisnosti od toga da li krše neki princip dobrog imenovanja.

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
    }');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-50, -5, 'Naziv je ispravan');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-500,-50, 'maxItemsLimit', 'Ovaj naziv kratko i jasno označava kakvi podaci se nalaze u atributu.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-51, -5, 'Naziv nije na odgovarajućem nivou apstrakcije');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-510,-51, 'GetSumOfAllItemPrices', '"GetTotalPrice" ili sličan naziv bi bolje opisao šta metoda radi, bez da ulazi u detalje kako to radi.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-52, -5, 'Naziv ne koristi ispravne tipove reči');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-520,-52, 'NumberOfItems', 'Ovakav naziv je ispravan kao ime atributa ili property-a. Za metodu bi bolji naziv bio u obliku glagola, poput "CountItems" ili "GetNumberOfItems".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-53, -5, 'Naziv ne prati timske konvencije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-54, -5, 'Naziv ne koristi ispravnu terminologiju domena problema');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-540,-54, 'IsBasketEmpty', '"Basket" se nigde ne pominje van ovog naziva, te bi ovu reč trebalo zameniti sa "Cart".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-55, -5, 'Naziv ne uzima u obzir širi kontekst');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-550,-55, 'AddItemToCart', 'Pošto se poziva nad instancom klase Cart, "ToCart" je suvišno. Pošto prihvata kao jedini parametar CartItem, i "Item" može biti suvišno, posebno ako je ovo jedina metoda koja dodaje nešto.');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-7, -2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-7, 'Posmatrajući sledeću strukturu paketa, navedi nazive klasa (razdvojene zarezom i bez .cs) koji krše konvenciju.

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
    - EmployeeController.cs
    - ScheduleController.cs', '{"MedicalRecordService, PhysicianStorage"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-8, -2);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-8, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji krše česte konvencije u pisanju programa.

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
    }', '{"Words, word_parts, idx"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-10, -3);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-10, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji sadrža beznačajne reči.

    public int GetEffectiveLinesOfCode(string codeAsString)
    {
        string code = RemoveCommentsFromCode(codeAsString);
            
        var allLines = code.Split(new[] { "\r\n", "\r", "\n" });
        int ignoreLineCount = CountBlankLines(allLines);
        int ignoreLineCount2 = CountHeaderLines(allLines);
            
        return Math.Max(allLines.Length - (ignoreLineCount + ignoreLineCount2 + 2), 1);
    }', '{"codeAsString, ignoreLineCount2"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-11, -3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-11, 'Analiziraj sledeći kod i označi sve nazive koje smatraš da sadrže beznačajne reči.

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
    }');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-110, 'GetSignature', false, 'Uklanjanje bilo koje reči bi učinilo naziv nevalidnim, gde "Get" samo po sebi ne daje dovoljno informacija šta se dobavlja, a "Signature" predstavlja imenicu što nije pogodan tip reči za metodu.', -11);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-111, 'signatureBuilder', false, 'Obe reči su bitne. Iako nezgodan primer, "Builder" je bitna reč. Ukazuje na to da se u promenljivi ne nalazi potpis funkcije, već mehanizam za njegovu izgradnju.', -11);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-112, 'FullName', false, 'Obe reči su bitne. Ovaj primer zahteva dublje razumevanje koncepta punog imena klase, koji podrazumeva uz naziv klase i naziv namespace-a kom pripada.', -11);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-12, -4);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-12, 'Označi nazive koji ne poštuju pravilo za upotrebu prikladnog tipa reči.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-120, 'public bool IsValid(User user)', false, '"IsValid" predstavlja pitanje i prihvatljivo je da ovako formulišemo naziv.', -12);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-121, 'public void Validate(User user)', false, 'Ovo je ispravan naziv.', -12);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-122, 'public bool Valid(User user)', true, 'Ovo nije ispravan naziv, jer "Valid" ne predstavlja glagol, a koristi se kao naziv funkcije.', -12);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-123, 'public class UserValidator', false, 'Ovo je ispravan naziv, gde se imenica koristi da označi naziv klase.', -12);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-124, 'public class ValidateUser', true, 'Ovo nije ispravan naziv, jer se glagol koristi da označi naziv klase.', -12);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-13, -4);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-13, 'Posmatrajući sledeći kod, unesi naziv identifikatora koji ne koristi ispravan tip reči.

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
    }', '{"CartItem"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-14, -4);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-14, 'Označi nazive koji predstavljaju ispravan tip reči.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-140, 'public void Put(List<Employee> employees)', true, 'Nazivi ove funkcije i njenih parametra su ispravni.', -14);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-141, 'public class GeneratedReport', true, 'Naziv ove klase je ispravan što se tiče tipa reči, no svakako je upitno šta predstavlja koncept "generisanog" izveštaja.', -14);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-142, 'public void Register(User createUser)', false, 'Naziv funkcije koristi ispravan tip reči, dok naziv parametra predstavlja glagol, gde je očekivano da bude imenica.', -14);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-143, 'public class Registry', true, 'Naziv klase je ispravno imenica.', -14);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-15, -5);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-15, '`Order` klasa predstavlja porudžbinu koju korisnik može da formira (npr. u kontekstu poručivanja hrane preko Wolt/Glovo aplikacija). Instance ove klase sadrže podatke poput stavki porudžbine i njenog statusa (npr. kreirana, prihvaćena, otkazana).
Koristeći terminologiju domena problema, kako bismo nazvali (na engleskom, *PascalCase*) metodu koja treba da se pozove nad instancom `Order` klase kada korisnik želi da otkaže svoje porudžbinu?', '{"Cancel", "CancelOrder"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-17, -5);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-17, 'Označi kod iz naredne liste koji smatraš da potiče iz klasa koje opisuju domen problema, odnosno poslovne logike.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-170, 'string.join(":", patientRecord)', false, 'Ovo nije naziv iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -17);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-171, 'Close(Account account)', true, 'Ovaj naziv je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -17);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-172, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovaj naziv ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je naziv metode bio samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -17);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-173, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj, a ne deo domena problema.', -17);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-174, 'Register(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. sportskog kluba ili biblioteke).', -17);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-18, -5);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-18, '`Schedule` klasa sabira sastanke i obaveze koje korisnik ima u toku dana (npr. u kontekstu *Google Calendar* aplikacije). Instance ove klase sadrže spisak događaja (engl. *Appointment*), gde je svaki definisan sa nazivom, vremenom početka i završetka.
Koristeći terminologiju domena problema, kako bismo nazvali (na engleskom, *PascalCase*) metodu koja se poziva nad `Schedule` objektom, prihvata dužinu trajanja događaja u minutima i pronalazi prvi slobodan termin (engl. Timeslot) kada se događaj može zakazati.', '{"FindFirstAvailableTimeslot", "GetFirstAvailableTimeslot"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-19, -6);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-19, 'Razmotri sledeći kod.

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

Posmatrajući nazive iz prethodnog koda, označi one koji nepotrebno ponavljaju reči iz šireg konteksta i koje bi trebalo refaktorisati.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-190, 'DataSetProject', false, 'Naziv je korektan i označava projekat u okviru nekog skupa podataka.', -19);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-191, 'DSEObject', false, 'Naziv je korektan, no primer je nezgodan. DSE je korenski namespace, što znači da akronim DSE predstavlja ime aplikacije. Po logici ovog naziva bismo mogli svaku klasu da nazovemo sa prefiksom DSE, što bi bilo izuzetno redundantno. Međutim, u ovom slučaju ima smisla jer bez prefiksa ostaje ključna reč Object koja ima posebno značenje u objektno-orijentisanim jezicima. Možemo pretpostaviti da je DSEObject nekakva korenska klasa koja sadrži podatke i logiku zajedničku za značajan deo ove aplikacije.', -19);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-192, 'DataSetProjectName', true, 'Naziv polja redundantno ponavlja ime svoje klase. "Name" bi bilo dovoljno da se razume da podatak predstavlja ime projekta.', -19);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-193, 'ProjectState (naziv enumeracije)', false, 'Naziv je korektan. "State" bi bilo previše opšte, dok bi "DatasetProjectState" bilo donekle redundantno, pod pretpostavkom da DSE aplikacija nema više različitih projekata, posebno u Datasets namespace-u.', -19);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-194, 'ProjectState (naziv atributa)', true, 'Naziv sadrži redundantnu reč "Project". Pošto su ostali atributi izuzetno jasni u svom značenju, neće doći do konfuzije ako bismo ostavili samo reč "State" za naziv ovog polja.', -19);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-195, 'AddCandidateInstance', true, 'Naziv je redundantan, uzimajući u obzir naziv parametra i njegovog tipa. "Add" bi bio dovoljan pod pretpostavkom da nema drugih metoda koje nešto dodaju. U suprotnom bi "AddInstances" mogao da bude dovoljan.', -19);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-21, -6);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-21, 'Analiziraj sledeći kod koji je deo `CCMethod` klase i navedi sve nazive (odvojene zarezom) koje smatraš da se mogu pojednostaviti analizom šireg konteksta.

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
    }', '{"GetMethodSignature, FullNameOfType"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-22, -6);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-22, 'Ako treba da analiziramo širi kontekst prilikom formiranja naziva, označi nazive funkcija koje sadrže dobar naziv.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-220, 'void RegisterTemporaryUser(User user)', true, 'Ovo je dobar naziv iako je težak primer. Reč "User" jeste redundantna, no njeno uklanjanje bi ostavilo reč "Temporary" da visi bez imenice na koju se odnosi. Ključno je da je operacija registracije privremenog korisnika drugačija od registracije redovnog korisnika zbog čega nam znači diferencijacija u nazivu.', -22);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-221, 'ChallengeEvaluation Evaluate(ChallengeSubmission submission)', true, 'Ovo je ispravan naziv. Iako se "Evaluate" ponavlja u delu naziva tipa povratne vrednosti, dati naziv jasno i koncizno opisuje da se ovde vrši provera submisije za izazov.', -22);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-222, 'List<Doctor> GetDoctorsForOperation(Operation operation)', false, 'Ovo nije dobar naziv jer redundantno opisuje parametar.', -22);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-223, 'Dictionary<MetricId, double>> GetMetricValueMap()', false, 'Ovo nije dobar naziv, jer redundantno opisuje tip povratne vrednosti. Reč Map je sinonim za Dictionary, te je treba izbaciti iz naziva.', -22);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-224, 'void RegisterUser(User user)', false, 'Ovo nije dobar naziv, gde je reč "User" redundantna.', -22);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-23, -7);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-23, 'Ako tvrdimo da jasan naziv objašnjava šta parče koda radi, a ne kako to radi, označi funkcije koje imaju naziv na dobrom nivou apstrakcije.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-230, 'Employee Get(int employeeId)', true, 'Ovo je dobar naziv, pod pretpostavkom da se glagol "Get" po konvenciji koristi za svako čuvanje entiteta.', -23);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-231, 'List<DatasetInstance> FindInstancesRequiringAdditionalAnnotation(Dataset dataset)', true, 'Ovo je dobar naziv, jer apstrahuje detalje koji određuju šta znači da instanca nije dovoljno anotirana, a opet dodatno opisuje šta će ta povratna vrednost da predstavlja, odnosno da nije bilo kakva lista instanci.', -23);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-232, 'decimal ApplyDiscountToOrder(Order order, Discount discount)', false, 'Ovo nije dobar naziv jer opisuje kako se cena računa. Bolje ime bi bilo "CalculatePrice(Order order, Discount discount)" koje ističe nameru funkcije, a iz parametra se vidi da se popust uvažava.', -23);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-233, 'void SaveIfValid(Employee employee)', false, 'Ovo nije dobar naziv jer otkriva detalje implementacije u vidu provere validnosti prosleđenog objekta. "Save" je naziv na boljem nivou apstrakcije.', -23);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-24, -7);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-24, 'Razmotri sledeći zahtev i definiši ime funkcije na prikladnom nivou apstrakcije (samo ime, bez zagrada i parametra), prateći *PascalCase* konvenciju i koristeći engleski jezik.

Pored osnovnih podataka, entitet zaposlenog sadrži listu odsustva koje uključuju godišnje odmore i bolovanja (engl. *sick leave*). Potrebno je definisati funkciju koja će da pronađe sve zaposlene koji nisu uzeli bolovanje u određenoj godini, gde se godina prosleđuje kao parametar. Šta je prikladno ime za ovu funkciju?', '{"GetEmployeesWithoutSickLeave", "FindEmployeesWithoutSickLeave", "GetEmployeesWithNoSickLeave", "FindEmployeesWithNoSickLeave"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-25, -7);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-25, 'Ako tvrdimo da jasan naziv objašnjava šta parče koda radi, a ne kako to radi, označi funkcije koje imaju naziv na dobrom nivou apstrakcije.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-250, 'List<Doctor> GetAvailableAndCapableDoctors(Operation operation)', false, 'Ovo nije dobar naziv jer opisuje sadržaj tela funkcije.', -25);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-251, 'List<Doctor> GetDoctors(Operation operation)', false, 'Ovaj naziv je na granici, no verovatno je previše apstraktan. Naime, iz naziva nije jasno kakav skup lekara se dobija. Uzimajući u obzir i parametar se može naslutiti, no zahteva mentalno mapiranje.', -25);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-252, 'List<Doctor> GetSuitableDoctors(Operation operation)', true, 'Ovaj naziv se nalazi na optimalnom nivou apstrakcije.', -25);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-253, 'List<Doctor> Get(Operation operation)', false, 'Ovaj naziv je previše apstraktan. Uz ozbiljno mentalno mapiranje je moguće razumeti nameru ove funkcije ako se posmatra povratna vrednost i parametar. Ovakav napor želimo da izbegnemo u našem kodu.', -25);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-26, -7);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-26, 'Razmotri sledeći zahtev i definiši ime funkcije na prikladnom nivou apstrakcije (samo ime, bez zagrada i parametra), prateći *PascalCase* konvenciju i koristeći engleski jezik.

Postoji klasa koja predstavlja duž (`Line`). Ona sadrži dva atributa tipa `Point` gde svaki predstavlja jednu tačku duži i sastoji se od koordinata X i Y. `Line` klasa nudi metodu koja računa rastojanje između dve tačke koristeći formulu `√((p2.x-p1.x)²+(p2.y-p1.y)²)`, čime se dobija dužina duži. Šta je prikladno ime za ovu funkciju?', '{"GetLength", "CalculateLength"}');



