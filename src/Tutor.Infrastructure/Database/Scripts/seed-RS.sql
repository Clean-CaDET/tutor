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
DELETE FROM public."KcMastery";
DELETE FROM public."KnowledgeComponents";
DELETE FROM public."Units";
DELETE FROM public."Learners";

INSERT INTO public."Units"("Id", "Code", "Name", "Description") VALUES
	(-1, 'CC02', 'Čiste funkcije', 'Tradicionalna funkcija predstavlja *imenovani* blok koda koji obuhvata smislen zadatak. U objektno-orijentisanom programiranju funkcije su često *metode* koje definišu ponašanje objekta nad kojim se pozivaju. Principi koje poštujemo za formiranje čistih funkcija su jednako primenjivi na metode. Čista funkcija je *fokusirana na jedan zadatak*. Ovaj zadatak je jasno opisan kroz nazive u zaglavlju funkcije, što uključuje naziv funkcije i nazive njenih parametra. Čista funkcija ima jednostavno telo i sastoji se od koda koji zahteva malo mentalnog napora da se razume. Kao posledica, ovakve funkcije često sadrže mali broj linija koda. Kroz ovaj modul ispitujemo dobre i loše prakse za pisanje funkcija.');

INSERT INTO public."Units"("Id", "Code", "Name", "Description") VALUES
	(-2, 'CC01', 'Značajni nazivi', 'Nazive pronalazimo u svim segmentima razvoja softvera - kod identifikatora promenljive, funkcije, klase, ali i biblioteke i aplikacije. Jasan naziv funkcije nas oslobađa od čitanja njenog tela, dok će misteriozni naziv zahtevati dodatan mentalni napor da razumemo svrhu koncepta koji opisuje. U najgorem slučaju, loš naziv će nas naterati da formiramo pogrešnu pretpostavku, što će nam drastično produžiti vreme razvoja. Kroz ovaj modul ispitujemo dobre i loše prakse za formiranja naziva identifikatora u kodu.');

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-1, 'F01', 'Konstruiši čiste funkcije', '', -1, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-2, 'F02', 'Segmentiraj dugačku funkciju spram regiona kohezivne logike', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-3, 'F03', 'Umanji složenost funkcije', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-4, 'F04', 'Reorganizuj logiku funkcije radi smanjenja njene složenosti', '', NULL, -3);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-5, 'F05', 'Izdvoj složenu logiku u posebnu funkciju', '', NULL, -3);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-6, 'F06', 'Imenuj rezultat složene logike', '', NULL, -3);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-7, 'F07', 'Smanji broj parametra funkcije upotrebom prikladne strategije', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-8, 'F08', 'Odredi semantičku svrhu funkcije', '', NULL, -1);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-9, 'N01', 'Konstruiši značajne nazive za identifikatore u kodu', '', -2, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-10, 'N02', 'Prati timske konvencije prilikom formiranja naziva', '', NULL, -9);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-11, 'N03', 'Izbegavaj beznačajne reči', '', NULL, -9);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-12, 'N04', 'Primeni prikladne tipove reči', '', NULL, -9);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-13, 'N05', 'Koristi terminologiju domena problema', '', NULL, -9);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-14, 'N06', 'Analiziraj širi kontekst prilikom formiranja naziva', '', NULL, -9);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "UnitId", "ParentId") VALUES
	(-15, 'N07', 'Formiraj naziv na dobrom nivou apstrakcije', '', NULL, -9);

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-1, -1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-1, 'Kada saberemo sve do sada, vidimo da čista funkcija ima sledeće karakteristike:

- Jasno definisan zadatak koji rešava i koji je rezimiran nazivom funkcije.
- Ograničenu količinu složene logike, bez mnogo ugnježdavanja i složenih izraza.
- Kohezivan skup instrukcija koje staju u mali broj linija koda.
- Mali broj parametra, izuzev funkcija čiji zadatak je da kreira složeni objekat (npr. konstruktor).

Kod koji prati prethodne smernice će posedovati visok broj jednostavnih funkcija. Takav kod donosi nekoliko prednosti:

- Razumevanje pojedinačne funkcije je trivijalno.
- Ispunjavanje novog zahteva je jednostavno, gde se brzo može identifikovati funkcija koju treba izmeniti ili proširiti.
- Pojava *bug*a postaje retka, a i kada se desi je jednostavno pronaći logiku koja je kriva za neočekivano ponašanje.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-2, -2);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-2, 'Prosta smernica za ispitivanje čistoće funkcije predstavlja provera broja linija koda. Funkcija koja ima ispod 5 linija koda *verovatno* nije problematična. Funkcija koja ima preko 50 linija koda *verovatno* jeste problematična. Ključna reč je "verovatno" i izuzeci svakako postoje. Postavlja se pitanje da li je funkcija sa 20 linija koda problematična i videćemo da puno faktora utiče na to da li jeste ili nije, uključujući i subjektivnu percepciju programera i njegovu familijarnost sa kodom koji se razmatra. Drugim rečima, postoji siva zona između 5 i 50 linija koda u koju upadaju funkcije koje i jesu i nisu problematične.

Zbog date sive zone, kao i izuzetaka na pravila da manje od 5 nije problem i veće od 50 jeste, posmatranje broja linija koda nije dovoljno da otkrijemo problematičan kod. Umesto toga, vredi identifikovati regione logički povezanog koda koji se mogu smisleno izdvojiti u zasebne funkcije, posebno kada uspemo dobar naziv da smislimo za dati kod. Ovi regioni često prirodno nastanu u kodu tako što programer ostavi par **praznih redova** da razdvoji regione ili **komentar** koji opisuje šta naredni kod radi. Ovo ne znači da ćemo za svaki komentar praviti funkciju. Tek kada se komentar odnosi na više linija koda ili na par veoma složenih linija imamo kandidata za ekstrakciju.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-3, -2);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-3, 'https://youtu.be/D5Ubdm2fccQ');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-4, -3);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-4, 'Složena logika je često posledica nepažljivog programiranja. Lako je upasti u klopku gde proizvodimo složen i nerazumljiv kod kada smo fokusirani na novu funkcionalnost i programiramo "u zoni". Pošto je sve sveže u umu, nije problem izboriti se sa zamršenom logikom i složenim nizovima instrukcija i operacija. Problem nastaje kada drugi programer treba da razume i modifikuje naš kod ili kada smo sami prisiljeni to da radimo šest meseci kasnije.

Kada uočimo da funkcija poseduje netrivijalnu logiku, treba da postavimo sledeća pitanja:

- Da li postoji linija koda ili region funkcije koji sadrži značajno složeniju logiku od ostatka? Da li se takva logika može izdvojiti u posebnu metodu ili rezultate logike smestiti u promenljivu sa jasnim nazivom?
- Da li postoji visok stepen ugnježdavanja (promena indentacija)? Da li se ugnježdena logika može premestiti ili reorganizovati da postane trivijalna?
- Ako postoji promena indentacije, da li uvek ide u dubinu ili skače između "dubljih" i "plićih" blokova koda? Čak i visok stepen ugnježdavanja može biti razumljiv kada se uvek ide u dubinu.

Što bolje poznajemo programski jezik to više možemo da redukujemo složenost koda. Ovo uključuje poznavanje osnovnih stvari poput tipova podataka i funkcija standardne biblioteke jezika, do naprednijih koncepata poput delegata i LINQ izraza u C# programskom jeziku.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-5, -4);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-5, '
Složenost funkcije raste kada ne vodimo računa o organizaciji instrukcija unutar tela funkcije. Kada mehanički proizvodimo kod, bez razmišljanja, skloni smo dupliranju koda, zamršavanju logike i pisanju redundantnih instrukcija. Razmotri sledeći primer:
```csharp
public bool IsTeenager(Person p)
{
    bool isTeenager = false;
    if(p.Age > 13 && p.Age < 19)
    {
        isTeenager = true;
    }
    else
    {
        isTeenager = false;
    }
    return isTeenager;
}
```
Funkcija je relativno jednostavna za razumevanje, no verovatno imaš ideju kako bismo je pojednostavili boljom organizacijom logike. Jedan korak može da bude uklanjanje promenljive i direktan povratak vrednosti, tako da dobijemo sledeći kod:
```csharp
public bool IsTeenager(Person p)
{
    if(p.Age > 13 && p.Age < 19)
    {
        return true;
    }
    else
    {
        return false;
    }
}
```
Drugi korak može da bude uklanjanje else ključne reči, pošto se ništa van njega ne nalazi. Tako dobijamo:
```csharp
public bool IsTeenager(Person p)
{
    if(p.Age > 13 && p.Age < 19)
    {
        return true;
    }
    return false;
}
```
Treći korak može da bude kompletno izbacivanje grananja. Ova funkcija ima jednu proveru, gde spram rezultata relacione operacije (koja je tipa *bool*) vraća vrednost tipa *bool*. Ovo je moguće direktno iskoristiti, tako da dobijamo kod:
```csharp
public bool IsTeenager(Person p)
{
    return p.Age > 13 && p.Age < 19;
}
```
Prvobitna funkcija je brojala 10 linija koda u svom telu, dok poslednja ima jednu liniju koda. Sve što je potrebno za ovu uštedu je poznavanje *bool* tipa podataka i razmišljanje koje se ne završava na nivou jedne linije koda već razmatra širu sliku tela funkcije.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-6, -5);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-6, 'Ponekad imamo funkciju koja se sastoji od više trivijalnih linija koda i nekoliko linija zbog kojih se drastično poveća složenost cele funkcije. Složene linije koda dolaze u nekoliko varijanti. Jedan primer je lanac poziva metoda, poput `CalculatePrice(items.SelectMany(i => i.Components).Where(c => !c.Discount).ToList().AddRange(cart.Items))`. Drugi primer je kombinacija više aritmetičkih, logičkih ili relacionih operacija, poput `!(IsInside(index + 1) && Get(index + 1) == Tile.WallA) && !(IsInside(index + width) && Get(index + width) == Tile.WallA)`. Treći primer predstavlja duboko ugnježdavanje (npr. FOR u IF u FOR u TRY).

Kod ovakvog koda treba da se zapitamo da li bi se jasnoća povećala sa ekstrakcijom nekog segmenta u zasebnu metodu, gde ćemo tu složenost sakriti iza dobrog naziva. Ekstrakcija složenih izraza u posebnu funkciju je posebno pogodna opcija ako dati izraz pozivamo na više mesta u našem kodu.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-7, -6);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-7, 'Složene linije koda dolaze u nekoliko varijanti. Jedan primer je dugačak lanac poziva metoda, poput `CalculatePrice(items.SelectMany(i => i.Components).Where(c => !c.Discount).ToList().AddRange(cart.Items))`. Drugi primer je kombinacija više aritmetičkih, logičkih ili relacionih operacija, poput `!(IsInside(index + 1) && Get(index + 1) == Tile.WallA) && !(IsInside(index + width) && Get(index + width) == Tile.WallA)`.

Kod ovakvog koda treba da se zapitamo da li bi se jasnoća povećala ako bismo rezultat složenog niza instrukcija sačuvali u promenljivu koja će nositi deskriptivan i jasan naziv iza kog "sakrivamo" složenost instrukcije. Ovakve promenljive nazivamo *explanatory variables* i njihova svrha je da ponude dobar naziv za rezultat složenog niza operacija.

Tako možemo da definišemo promenljivu `var totalPriceWithoutDiscounts = CalculatePrice(items.SelectMany(i => i.Components).Where(c => !c.Discount).ToList().AddRange(cart.Items))` da izbegnemo opterećivanje programera koji sada može tumačenje lanaca poruka da zameni sa razumevanjem naziva promenljive.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-8, -7);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-8, 'Čiste funkcije treba da teže ka što manjem broju parametara. Ovaj broj je idealno nula, no svakako su funkcije sa jednim ili dva parametra prihvatljive i česte. Tako imamo funkcije koje prihvataju parametar da bi ga transformisali u novi objekat (npr. deserijalizacija stringa u objekat), funkcije koje ispituju neko svojstvo parametra, kao i funkcije koje izvršavaju komandu spram ulaznog podatka ili obrađuju prosleđeni događaj. Sve preko dva parametra je ozbiljan kandidat za refaktorisanje. Takve funkcije obično rešavaju više zadataka i sadrže opterećujuću kompleksnost. Izuzetak na ovo pravilo su konstruktori koji često prihvataju više podataka kako bi formirali složeni objekat.

Potrebno je odrediti pogodnu strategiju za redukciju broja parametra. Treba da ispitamo da li određeni parametar smisleno može da postoji kao atribut klase, pa da se kroz konstruktor definiše. Treba da sagledamo da li su parametri usko povezani, u kom slučaju ćemo ih spojiti u klasu. Najzad, vredi razmotriti da li je metoda previše složena, gde bismo segmentacijom poslova u više metoda mogli da izdvojimo deo parametra koji su potreban za jedan posao u jednu metodu, a ostatak u drugu.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-9, -7);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-9, 'https://i.ibb.co/nm4mh3m/RS-params.png', 'Navedene strategije možemo redom razmotriti kada pronađemo funkciju koja ima 3 ili više parametra.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-10, -7);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-10, 'U određenim situacijama parametar metode vredi pretvoriti u atribut klase. Parametar je kandidat za promociju u atribut kada važi nešto od sledećeg:

- Često sadrži istu vrednost, koja se smisleno može dodeliti prilikom konstrukcije objekta.
- Predstavlja koncept koji smisleno pripada klasi.
- Predstavlja parametar koji se ponavlja u mnogim metodama date klase.

Razmotri `UserFileRepository` koja nudi metode poput `Get`, `Save`, `Update` i `Delete`. Ako pretpostavimo da se datoteke sa korisnicima čitaju iz istog iz istog direktorijuma, prva opcija nam je da zakucamo u kodu svake metode `baseFolder` putanju. Ako bismo želeli da učinimo klasu konfigurabilnom, jedna opcija bi bila da svaka metoda ima `baseFolder` parametar. Međutim, ovaj podatak se retko menja, a verovatno nikad između poziva metoda. Dalje, ovaj atribut predstavlja koncept koji svakako ima semantičkog smisla da stoji u datoj klasi. Najzad, ako ostane kao atribut pojaviće se u zaglavlju svake od navedenih metoda. Zbog svega navedenog ima smisla da postane atribut.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-11, -7);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-11, 'Svaki parametar predstavlja nekakav podatak koji u praksi ima određenu semantiku i ograničen skup mogućih vrednosti. `string name` može da sadrži bilo kakav tekst, no u praksi će verovatno sadržati nečije ime ili specijalnu vrednost poput praznog teksta. Ponekad će više parametra metode predstavljati skup podataka koji često "ide zajedno". Ovo "zajedništvo" se može tumačiti na nivou semantike (npr. `name`, `surname`, `index` su podaci koji se odnose na nekakvog `Student`a. Ono se takođe može posmatrati u kodu, gde više metoda koje radi neke analize vremenskog rasporeda mogu posedovati parametre poput `DateTime from` i `DateTime to`.

Kada pronađemo funkciju koja ima više parametra, vredi razmotriti da li oni "idu zajedno". Kada to jeste slučaj, možemo kreirati novu klasu koja će imati atribute koji se mapiraju na date parametre.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-12, -8);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-12, 'Kažemo da dobro-formirana funkcija treba da rešava jedan zadatak. Kako definišemo zadatak? Idealno, funkcija koja radi jedan zadatak zna koji su koraci potrebni da se uradi taj zadatak, bez da poznaje detalje svakog od navedenih koraka (npr. bez da zna koji su koraci potrebni da bi se rešio njen prvi korak).

`GetSuitableDoctors` zna da je za operaciju potrebno pronaći lekare koji su sposobni da urade operaciju i dostupni u predloženom terminu. Ova funkcija neće znati šta znači da je "lekar sposoban", niti kako da interaguje sa skladištem podataka kako bi dobavila lekare. Dalje, `IsAvailable` će znati šta sve treba proveriti da se odredi da li je lekar dostupan, što podrazumeva pregled njegovog radnog vremena i razmatranje da li već ima bitne obaveze u datom vremenskom opsegu. Ova funkcija neće poznavati detalje ovih koraka, poput logike koja određuje da li neki `DateTime` upada u određeni vremenski opseg.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-13, -8);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-13, 'https://i.ibb.co/x1KBmTk/RS-method-semantic.png', '"Zadatak" može da opiše logiku na raznim nivoima apstrakcije - od "GetSuitableDoctors(operation)" do "Sum(a,b)".');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-14, -8);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-14, 'Zadatak koji funkcija rešava definiše *semantičku svrhu* funkcije. Kada opišemo ovu svrhu u nekoliko dobro-odabranih reči dobijamo prikladan naziv za funkciju.

Razmotrimo primer prodavnice koja poseduje aplikaciju za upravljanje magacinom. Magacioneri su dužni da vrše periodičan popis zaliha (engl. *stocktaking*). Tom prilikom porede stvarno stanje zaliha u magacinu sa očekivanim koji je zabeležen u informacionom sistemu. Rezultat aktivnosti predstavlja spisak razlika i sadrži dodatne podatke poput vremena i izvršioca popisa. Magacioner kroz softver treba da zaključi popis sa ovim podacima. Prethodni tekst nam definiše semantičku svrhu metode koju bismo mogli da nazovemo `ConcludeStocktaking`.

Naspram primera iz domena problema možemo razmotriti funkcije koje rade sa tehnološkim detaljima. U mnogim programskim jezicima `String` klasa sadrži metodu `ToUpper()` čija semantička svrha se može izvući iz dokumentacije "*Returns a copy of this string converted to uppercase*". U C# jeziku, `String` klasa sadrži metodu `Parse(String)` čija svrha je definisana u dokumentaciji kao "*Converts the string representation of a date and time to its DateTime equivalent*".

Funkcije za koje je teško definisati semantičku svrhu su često funkcije koje rešavaju previše zadataka. Kod složenijih funkcija treba uložiti trud u identifikaciju ovih zadataka i njihovo izdvajanje u zasebne metode.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-15, -8);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-15, 'https://i.ibb.co/rFJK6Z8/RS-Methods-Hierarchy.png', 'Uzmi po jednu metodu svake boje i opiši u rečenici šta rade, odnosno koje korake rešavaju. Razmisli koliko je apstraktan opis ljubičaste metode, a koliko konkretan opis plave metode.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-16, -9);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-16, 'Van jednostavnih slučajeva, izbor pravog naziva je proces koji podrazumeva sledeće korake:

1. Opisivanje koncepta koji želimo da imenujemo kroz rečenicu ili dve, koristeći prikladnu terminologiju iz domena problema ili rešenja. Često ćemo ovaj opis pronaći ili ostaviti u tekstu komentara koji stoji uz koncept, sa ciljem da dodatno pojasni šta koncept predstavlja. Ovaj tekst je lakše formirati na maternjem jeziku, a kada smo zadovoljni sa opisom možemo prevesti na engleski (uz moguću pomoć onlajn prevodioca).
2. Uklanjanje svih *noise* reči, odnosno redundantnih imenica, veznika i priloga koji nisu ključni za prenošenje svrhe koncepta koji imenujemo.
3. Uklanjanje svih preostalih reči koje se jednostavno izvlače iz šireg konteksta, poput naziva **tipa** (npr. povratne vrednosti, parametra ili promenljive), **modula** kom dati element pripada (npr. klase ili paketa) i dodatnih elemenata (npr. nazivi parametra i njihovih tipova kod funkcije koju imenujemo).
4. Razmatranje da li preostale reči opisuju koncept na dobrom nivou apstrakcije i da li predstavljaju glagol za metodu ili funkciju, odnosno imenicu u preostalim slučajevima.
5. Postavljanje novog imena.

Navedeni algoritam nije jednokratna aktivnost. Često je potrebno nekoliko iteracija i preimenovanja da bismo stigli do imena koje je dovoljno jasno i značajno. Na sreću, savremeni IDE alati pružaju podršku za lako preimenovanje elemenata koda. Ako kod prolazi *build* posle preimenovanja, možemo biti uvereni da nismo uveli nove greške u kod.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-17, -9);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-17, 'https://i.ibb.co/vqjMTyJ/simple-names-sr.png', 'U većini slučajeva kada hoćemo da stavimo komentar, pravo rešenje je smišljanje jasnijeg imena.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-18, -10);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-18, 'Idealan naziv treba jasno da odredi neku operaciju ili pojam. Zbog ovoga je neophodno izbegavati sinonime i pratiti timske konvencije.

Kao primer možemo zamisliti skup klasa čiji zadatak je da učitaju različite entitete iz skladišta. Jedna klasa učitava jedan entitet i sadrži logiku za serijalizaciju i deserijalizaciju datog entiteta (takozvane *Repository* klase). Ako većina ovakvih klasa poseduje metodu čiji naziv počinje sa `Get`, programer će morati da zastane ako naleti na metodu koja učitava određeni entitet i ime joj počinje sa `Load`. Postaviće se pitanje da li je `Load` drugačije od `Get` i da li treba nešto drugačije uraditi sa `Load` metodama. Da bi bio siguran, programer mora da otvori kod metode `Load` i da proveri da ne postoji neka bitna razlika, čime troši vreme.

Prethodni problem neće izazvati velik trošak vremena, no gomila ovakvih prekršaja će svakako opteretiti programera. Dalje, postoji mogućnost da će programer u nedostatku `Get` funkcije implementirati takvu metodu, iako nespretno nazvan `Load` već radi traženi posao.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-19, -10);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-19, 'Određene konvencije potiču iz programskog jezika ili tehnologija koje koristimo. One mogu i često jesu usvojene kao timske konvencije. Primeri ovakvih konvencija uključuju:

- `i` i `j` koji se koriste za nazive promenljiva koje prate broj iteracije za `for` petlje.
- `Controller`, `Service`, `Repository` i `Dto` reči koje se koriste kao sufiksi u nazivima određenih klasa, gde date reči jasno označavaju deo odgovornosti date klase.
- Upotreba *PascalCase* notacije za nazivanje klasa i metoda u C# programskom jeziku, kao i upotreba *pascalCase* notacije za formiranje naziva ostalih identifikatora.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-20, -11);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-20, 'Prilikom formiranja naziva treba da izbegnemo dodavanje beznačajnih prefiksa i sufiksa. Tipičan primer nepotrebnog sufiksa nastaje kada se radi *copy & paste* izraza koji definiše promenljivu, gde se na kraj kopirane promenljive doda `1`. Ovaj potez rezultuje brzom pisanju nove instrukcije, ali usporava svako naknadno čitanje.

Treba da izbegavamo redundantne reči koje ponovo ističu tip elementa (npr. `str, string, obj, list, set`). Takođe treba da izbegavamo previše generične reči, poput `Manager, Coordinator, Data, Info`, jer ovakve reči važe za mnoge elemente koda.

U opštem slučaju, prefiksi i sufiksi su prihvatljivi samo kada se prati konvencija tima (čest primer za ovo su `Controller` i `Service` sufiksi koji nose jasno značenje), no i tada se moramo postarati da imamo značajno ime pre nego što uvedemo ovakve dodatke.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-21, -11);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-21, 'https://youtu.be/IusayOJt79E');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-22, -12);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-22, 'Česta konvencija je da reči koje formiraju naziv metode rezultuju glagolom, označavajući da se *nešto radi*, odnosno operacija izvršava kada se metoda pozove. Primeri za ovo uključuju:

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
	(-23, -13);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-23, 'Domen problema predstavlja oblast za koju pravimo softver. Obuhvata organizacije, ljude, podatke, poslovne procese i znanje koje postoji i bez našeg softvera, sa kojim naš softver treba da interaguje. Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za nazive, gde klase i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata.

Ako pravimo aplikaciju za bolnicu, domen problema uključuje titule i odgovornosti zdravstvenih radnika, strukture dokumenata i stanja u kojim se oni mogu naći, kao i procedure i operacije u kojim učestvuju različiti korisnici. Naš posao će biti da razvijemo funkcionalnosti za podršku ovih korisnika, dokumenata i procedura i tom prilikom treba da ugradimo što više terminologije iz domena problema u naš kod.

Za prethodni primer ova terminologija može da uključi *Doctor* i *Nurse*, zatim *Medical Record* i *Prescription Drug*, kao i *Schedule Operation* i *Cancel Appointment*. Dobra praksa je da konzistentno koristimo ove nazive u delu koda koji modeluje domen problema, kako bismo sav naš razgovor sa korisnicima i stručnjacima iz ovog domena jednostavno mapirali na naš kod.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-24, -13);
INSERT INTO public."Videos"("Id", "Url") VALUES
	(-24, 'https://youtu.be/wcIJOmP0R7I');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-25, -13);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-25, 'https://i.ibb.co/Tw9qktR/domain-names-sr.png', 'Kada razvijamo poslovnu logiku za koju nemamo dobar naziv, možemo sastaviti komentar koji opisuje šta kod radi tako da koristimo što više reči iz domena problema. Iz ovog teksta možemo izdvojiti ključne reči da definišu naziv.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-26, -13);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-26, 'Zamislimo promenljivu tipa `List<Doctor>`. Šta očekujemo da sadrži ova lista ako je ime promenljive `doctors`, a šta ako je `availableDoctors`, `capableDoctors` ili `suitableDoctor`?

Možemo zamisliti da će se za određenu operaciju razlikovati spisak svih lekara bolnice od onih koji su sposobni ili dostupni da urade datu operaciju. U ovom primeru vidimo kako upotreba odgovarajućeg atributa (slobodan, sposoban ili prikladan) u nazivu ograničava i jasnije određuje očekivani skup vrednosti u promenljivi.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-27, -13);
INSERT INTO public."Images"("Id", "Url", "Caption") VALUES
	(-27, 'https://i.ibb.co/f144vCk/names-example.png', 'Ovako objektno orijentisani programer imenuje stvari kada izbegava reči iz poslovnog domena.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-28, -14);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-28, 'Svaki element koda pripada nekom širem kontekstu. Promenljive i parametri pripadaju metodi. Atributi i metode pripadaju klasi i dodatno su opisani svojim tipom, odnosno tipom svoje povratne vrednosti. Klasa ima svoj paket, odnosno *namespace*. *Namespace* je deo neke aplikacije.

Prilikom formiranja naziva za neki identifikator treba da uvažimo širi kontekst kom dati identifikator pripada. Naziv mora da bude jasan kada posmatramo njega i nazive iz njegovog šireg konteksta i to tako da izbegnemo redundantne informacije.

Kao primer možemo sagledati metodu sa nazivom `IsCapable`. Bez šireg konteksta nije jasno na šta se odnosi niti šta znači njen rezultat. Međutim, ako znamo da ova metoda pripada klasi `Doctor` i u kodu vidimo liniju poput `if(doctor.IsCapable(operation))` jasno je da je u pitanju provera sposobnosti određenog lekara za prosleđenu operaciju. Naziv `CheckDoctorCapabilityForOperation` jasno govori o čemu je reč bez šireg konteksta, no ovo dovodi do dvostruke redundantnosti u kodu poput `if(doctor.CheckDoctorCapabilityForOperation(operation))`.

Za drugi primer možemo zamisliti promenljivu sa nazivom `state` koja je definisana u okviru metode `FindAvailableRooms`. Posmatrajući samo naziv teško je odrediti kakav podatak je smešten u ovu promenljivu, da li je neko stanje sobe (poput zauzeta, spremna za čišćenja ili slobodna) ili je informacija o opštini u kojoj se traži soba. Naziv tipa promenljive bi mogao da pomogne, no savremeni programski jezici favorizuju upotrebu generične reči za definisanje promenljive, poput `var` ili `let`. Moguće rešenje bi bilo da se naziv preimenuje u `roomState` ili `addressState`.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-29, -15);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-29, 'Jasan naziv objašnjava **šta** povezano parče koda predstavlja, a ne **kako** radi ili od kojih podelemenata se sastoji. Tako jedna funkcija može imati sledeća imena:

 - `List<KeyValuePair<EmployeeId, decimal>> SumBonusesAndSickDaysForSalaryCalculation()`, gde naziv odaje previše detalja i možemo pretpostaviti kako izgleda kod;
 - `List<KeyValuePair<EmployeeId, decimal>> ComputeEmployeeSalaries()` gde je istaknuta suština operacije bez nepotrebnih dodatnih detalja.

Poslednji naziv je na višem nivou apstrakcije od opisa skupa koraka i tipa povratne vrednosti funkcije. Iz perspektive programera koji prvi put gleda ovaj kod, razumemo nameru funkcije bez da ulazimo u detalje njene implementacije i strukture njene povratne vrednosti. Ako nam je zadatak da modifikujemo algoritam za računanje plate, ova funkcija će nam biti interesantna i dublje ćemo je ispitati. Ako nam zadatak nema veze sa ovom funkcionalnošću biće nam dovoljno da pogledamo ime funkcije da znamo da ne moramo da gledamo kod njene implementacije.');

INSERT INTO public."InstructionalEvents"("Id", "KnowledgeComponentId") VALUES
	(-30, -15);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-30, '`Repository` je ključna reč koja se koristi u nazivima klasa čiji zadatak je da interaguju sa skladištem nekakvih podataka. Tako će `EmployeeRepository` imati zadatak da pročita sadržaj nekog skladišta (npr. baze podataka ili datoteke) i formira instance `Employee` klase.

U kontekstu različitih nivoa apstrakcije postavlja se pitanje kako razlikujemo naziv klase `EmployeeRepository` od `EmployeeFileRepository` i `EmployeeSqlRepository` i šta možemo očekivati da je kod svake od ovih klasa. Za naveden primer, razumno očekivanje je sledeće:

- `EmployeeFileRepository` - klasa koja zna da otvori datoteku, serijalizuje i deserijalizuje zaposlenog u format koji datoteka očekuje i zatvori datoteku.
- `EmployeeSQLRepository` - klasa koja zna da se zakači na bazu podataka (direktno ili uz pomoć objektno-relacionog mapera) i postavi joj upit koji će učitati ili sačuvati zaposlenog.
- `EmployeeRepository` - apstrakcija koja ili samo definiše interfejs koji dele prethodne dve klase ili sadrži neku zajedničku logiku koja nije vezana za detalje rada sa datotekom ili SQL bazom podataka.

Kada pišemo kod koji radi sa EmployeeRepository apstrakcijom, ne moramo da se opterećujemo da li se ispod haube dešava interakcija sa bazom ili datotekom. U ovom primeru je koncept "skladišta" apstraktniji od koncepta "datoteke" ili "SQL baze" i naziv ovo oslikava.');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-1, -1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-1, 'Prateći kod predstavlja primer čiste funkcije.
```csharp
public List<Doctor> GetSuitableDoctors(Operation operation){
	List<Doctor> doctors = doctorRepository.FindAll();

	List<Doctor> suitableDoctors = new ArrayList<>();
	foreach(Doctor doctor in doctors) {
		if(IsCapable(doctor, operation.GetRequiredCapabilities())
		    && IsAvailable(doctor, operation.GetTimeSlot())) {
			suitableDoctors.Add(doctor);
		}
	}

	return suitableDoctors;
}
```
Rasporedi zahteve za izmenu softvera tako da su vezani za funkcije čije telo bismo verovatno menjali da bismo ih ispoštovali.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-10, -1, 'Nijedna od navedenih');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-100,-10, 'Dopuni format data transfer objekta da prikaže podatke novoj klijentskoj aplikaciji.', 'Metoda nema dodira sa Dto klasom u kojoj je potrebno napraviti izmenu.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-11, -1, 'FindAll');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-110,-11, 'Potrebno je dobaviti podatke o lekarima iz NoSQL bazi umesto u SQL bazi.', 'doctorRepository se bavi  interakcijom sa skladištem, a FindAll dobava lekare iz skladišta.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-12, -1, 'GetSuitableDoctors');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-120,-12, 'Od mogućih, uvek odabrati lekara koji ima najveći stepen uspeha za dati tip operacije, a prvog kada je nerešeno.', 'Ova metoda jedina raspolaže sa spiskom mogućih lekara (dostupnih i sposobnih) te bi nju trebalo izmeniti da se ispuni novi zahtev.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-13, -1, 'IsCapable');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-130,-13, 'Za izazovnu operaciju je potreban hirurg koji je bar jednom izveo dati tip operacije.', 'Proširujemo definiciju šta znači da je lekar sposoban, a IsCapable metoda baš tu proveru pravi.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-14, -1, 'IsAvailable');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-140,-14, 'Uzima u obzir da li je lekar na bitnom sastanku u traženo vreme.', 'Proširujemo definiciju šta znači da je lekar dostupan, a IsAvailable metoda baš tu proveru pravi.');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-2, -1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-2, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-20, 'Cilj nam je da funkcija ima što manji broj linija koda.', false, 'Izjava nije tačna. Preterivanje u ovom pravilu će rezultovati klasama koje broje desetine ili stotine funkcija čiji kod se u potpunosti mapira na ime funkcije, čime ništa nije postignuto. Funkcija treba da bude fokusirana na jedan zadatak, što podrazumeva da ima i neku pamet.', -2);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-21, 'Cilj nam je da funkcija rešava jedan zadatak.', true, 'Izjava je tačna. Zadatak je definisan nazivom funkcije.', -2);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-22, 'Izrazi sa više različitih operatora su dobar kandidat za ekstrakciju funkcije.', true, 'Izjava je tačna. Složene linije koda treba ekstrahovati u funkciju ili njihov rezultat smestiti u promenljivu koja će svojim nazivom opisati smisao složene logike.', -2);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-23, 'Sitne funkcije sa jasnim nazivima pospešuju princip OOP koji zovemo apstrakcija.', true, 'Izjava je tačna. Jasan naziv funkcije dobro apstrahuje njene detalje, zbog čega možemo brže da zaključimo koji deo koda nas interesuje, a koji ne.', -2);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-24, 'Formiranje čistih funkcija je izazovno, dok je prolazak kroz kod pun fokusiranih funkcija jednostavan.', true, 'Izjava je tačna. Potreban je trud da se identifikuje smislen deo logike i da se formira ime koje dobro opisuje datu logiku.', -2);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-25, 'Kada pišemo čiste funkcije, naši klijenti mogu da čitaju i razumeju naš kod.', false, 'Izjava nije tačna. Čiste funkcije koje opisuju poslovnu logiku treba da budu razumljive našim klijentima. Međutim, ne treba zaboraviti značajan deo logike koja će omogućiti obradu HTTP zahteva, interakciju sa bazom, kriptografiju i ostale tehničke detalje koji su poznati inženjnerima softvera, ali ne i ljudima za koje se pravi softver.', -2);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-3, -1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-3, 'Za sledeći kod:
```csharp
public List<Doctor> GetSuitableDoctors(Operation operation){
	List<Doctor> doctors = doctorRepository.FindAll();

	List<Doctor> suitableDoctors = new ArrayList<>();
	foreach(Doctor doctor in doctors) {
		if(IsCapable(doctor, operation.GetRequiredCapabilities())
		    && IsAvailable(doctor, operation.GetTimeSlot())) {
			suitableDoctors.Add(doctor);
		}
	}

	return suitableDoctors;
}
```
Zamisli sledeću strukturu funkcija:
	
- `GetSuitableDoctors` poziva `FindAll` i za svakog lekara `IsCapable` i `IsAvailable` metode.
- `FindAll` poziva `ConnectToStorage` i `ParseDoctor` metode.
- `IsAvailable` poziva `DoesTimeOverlap` metodu.

Uzmimo da svaka od navedeninih 7 funkcija ima 10 linija koda. Dolazi programer koji nije familijaran sa kodom sa ciljem da implementira izmenu kako bi se ispoštovao novi zahtev. Programer kreće od `GetSuitableDoctors` funkcije i spušta se kroz funkcije koje ona poziva. Organizuj zahteve u kolone koje ističu koliko će linija starog koda (iz navedenih funkcija) programer morati da pročita pre nego što će naći linije koje treba da izmeni.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-30, -3, '1-10');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-300,-30, 'Od mogućih, uvek odabrati lekara koji ima najveći stepen uspeha za dati tip operacije, a prvog kada je nerešeno.', 'Pred kraj GetSuitableDoctors funkcije se nalazi lista pogodnih lekara, gde će se nad ovom listom vršiti odabir.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-31, -3, '11-20');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-310,-31, 'Uzima u obzir da li je lekar na bitnom sastanku u traženo vreme.', 'Potrebno je ispitati GetSuitableDoctors i zatim IsAvailable.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-311,-31, 'Za izazovnu operaciju je potreban hirurg koji je bar jednom izveo dati tip operacije.', 'GetSuitableDoctors i IsCapable.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-32, -3, '21-30');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-33, -3, '31-40');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-330,-33, 'Potrebno je sačuvati podatke o lekarima u JSON datoteci, koristeći drugačiji format.', 'GetSuitableDoctors, pa FindAll, a zatim ConnectToStorage i ParseDoctor. U realnosti bi programer verovatno krenuo od repository klase, pa bi preskočio GetSuitableDoctors u celosti.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-34, -3, '41-50');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-4, -2);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-4, '
Analiziraj sledeći kod:
```csharp
protected override void CreateNestedDroplets(CancellationToken cancellationToken)
{
	base.CreateNestedHitObjects(cancellationToken);

	Event lastEvent = null;

	foreach (var e in SliderEventGenerator.Generate(Path.Distance, this.SpanCount(), cancellationToken))
	{
		// generates tiny droplets since the last point
		if (lastEvent != null)
		{
			double sinceLastTick = e.Time - lastEvent.Value.Time;

			if (sinceLastTick > 80)
			{
				double timeBetweenTiny = sinceLastTick;
				while (timeBetweenTiny > 100)
					timeBetweenTiny /= 2;

				for (double t = timeBetweenTiny; t < sinceLastTick; t += timeBetweenTiny)
				{
					cancellationToken.ThrowIfCancellationRequested();

					AddNested(new TinyDroplet
					{
						StartTime = t + lastEvent.Value.Time
					});
				}
			}
		}

		// Nest events
		lastEvent = e;
		AddNestedEvent(e);
	}
}
```
Navedena funkcija se može pojednostaviti ekstrakcijom funkcije koja sabira kohezivan region logike. Vodeći računa o nazivima, kako izgleda zaglavlje pogodne funkcije za ekstrakciju i koje linije koda ćemo prebaciti u njeno telo?');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-40, 'GeneratesTinyDropletsSinceLastPoint(Event current, Event last, CancellationToken token) sadrži kod između dva komentara.', false, 'Funkcija nije dobra. Dobro smo identifikovali kod koji vredi izdvojiti u posebnu funkciju, ali je naziv same funkcije loše formiran - nije glagol i sadrži redundantne podatke (last point).', -4);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-41, 'GenerateTinyDroplets(CancellationToken token) sadrži kod od Event lastEvent do kraja funkcije.', false, 'Funkcija nije dobra, gde nismo ništa postigli izdvajanjem ove funkcije. CreateNestedDroplets nema svrhu jer sadrži 2 linije koda, a GenerateTinyDroplets i dalje ima složenu logiku.', -4);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-42, 'GenerateDropletsBetweenEvents(Event current, Event previous, CancellationToken token) sadrži kod između dva komentara.', true, 'Funkcija je ispravna jer sadrži region koda koji vredi izdvojiti u posebnu funkciju i ima dobro-formiran naziv.', -4);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-43, 'GenerateDropletsBetweenPoints(Event current, Event previous, CancellationToken token) sadrži kod iz tela petlje.', false, 'Funkcija nije dobro koncipirana. Njen naziv ističe da se vrši generisanje "droleta", gde kompletna petlja radi više od toga.', -4);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-5, -2);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-5, 'Da imamo kratke metode ne treba da bude naš konačan cilj, već posledica praćenja dobrih praksi. Ipak, funkcija koja prevazilazi nekoliko desetina linija je dobar kandidat za refaktorisanje. U sklopu direktorijuma "Methods/01. Small Methods" ekstrahuj logički povezan kod tako da završiš sa kolekcijom sitnijih metoda čije ime jasno označava njihovu svrhu.', 'https://github.com/Clean-CaDET/challenge-repository', 'Methods.Small', 'https://youtu.be/79a8Zp6FBfU');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-71, 'Identifikuj regione povezanog koda (obrati pažnju na komentare) i izdvoj ih u funkciju kojoj možeš dati jasan naziv.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-71, -5, 'Methods.Small.AchievementService');
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-71);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-1, 'MELOC', 1, 18, -71, -71);

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-6, -2);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-6, '
Analiziraj sledeći kod i istakni koliko funkcija bi ekstrahovao da učiniš kod preglednijim.
```csharp
public static Uri BuildAuthorizationUrl(IEnumerable<string> scopes, string myShopifyUrl, string shopifyApiKey, string redirectUrl, string state, IEnumerable<string> grants)
{
	//Prepare a uri builder for the shop URL
	var builder = new UriBuilder(ShopifyService.BuildShopUri(myShopifyUrl));

	//Build the querystring
	var qs = new List<KeyValuePair<string, string>>()
	{
		new KeyValuePair<string, string>("client_id", shopifyApiKey),
		new KeyValuePair<string, string>("scope", string.Join(",", scopes)),
		new KeyValuePair<string, string>("redirect_uri", redirectUrl),
		new KeyValuePair<string, string>("state", state)
	};

	//Add grant options to querystring.
	foreach (var grant in grants)
	{
		qs.Add(new KeyValuePair<string, string>("grant_options[]", grant));
	}

	builder.Path = "admin/oauth/authorize";
	builder.Query = string.Join("&", qs.Select(s => $"{s.Key}={s.Value}"));

	return builder.Uri;
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-60, '0', false, 'Iako je navedena funkcija relativno jednostavna, povećavamo čitljivost ako izdvojimo najsloženiji region logike - formiranje query string-a - u zasebnu funkciju.', -6);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-61, '1', true, 'Ovo je pogodan broj, gde bismo logiku ispod drugog i trećeg komentara mogli da saberemo u jednu "CreateQueryString" funkciju.', -6);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-62, '2', false, 'Ovaj broj je verovatno preteran zbog jednostavnosti logike funkcije.', -6);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-63, '3', false, 'Ovaj broj je preteran pošto je logika funkcije jednostavna. Iako imamo 3 komentara, izdvajanjem toliko sitnih funkcija bismo dobili kolekciju glupavih funkcija čiji naziv nosi isto značenje kao i telo.', -6);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-7, -2);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-7, 'Označi sve linije koda koje ima smisla izdvojiti u posebnu funkciju:
```csharp
public string GetUriPath(string filename)
{
	if (string.IsNullOrEmpty(filename))
	{
		return "";
	}

	if (PathIncludesHome) {
		filename = Path.ExcludeHomeDir(filename);
	}
	if (PathNoExtension)
	{
		filename = Path.GetFileNameWithoutExtension(filename);
	}

	filename = URLHelpers.URLEncode(filename);


	string httpHomePath = GetHttpHomePath();
	if (string.IsNullOrEmpty(httpHomePath))
	{
		string url = Host;

		if (url.StartsWith("ftp."))
		{
			url = url.Substring(4);
		}

		if (HttpHomePathAutoAddSubFolderPath)
		{
			url = URLHelpers.CombineURL(url);
		}

		url = URLHelpers.CombineURL(url, filename);

		return new UriBuilder(url).Uri;
	}

	//Parse HttpHomePath in to host, path and query components
	int firstSlash = httpHomePath.IndexOf("/");
	string httpHome = firstSlash >= 0 ? httpHomePath.Substring(0, firstSlash) : httpHomePath;

	string httpHomePathAndQuery = firstSlash >= 0 ? httpHomePath.Substring(firstSlash + 1) : "";
	int querySpecifiedAt = httpHomePathAndQuery.LastIndexOf("?");
	string httpHomeDir = querySpecifiedAt >= 0 ? httpHomePathAndQuery.Substring(0, querySpecifiedAt) : httpHomePathAndQuery;
	string httpHomeQuery = querySpecifiedAt >= 0 ? httpHomePathAndQuery.Substring(querySpecifiedAt + 1) : "";


	//Build URI
	return new UriBuilder { Host = httpHome, Path = httpHomeDir, Query = httpHomeQuery }.Uri;
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-70, '3-16', false, 'Teško se date linije mogu izdvojiti u zasebnu funkciju zato što se zadatak i logika prvog grananja razlikuju od ostatka ovog regiona koda.', -7);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-71, '8-16', true, 'Date linije se smisleno mogu spakovati u funkciju poput "RemoveBaseAndExtension(filename)" koja vraća procesiran filename.', -7);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-72, '20-37', false, 'Problem sa izdvajanjem datih linija je što treba uvesti dodatnu proveru da li je rezultat nove funkcije null, pa da se nastavi sa izvršavanjem koda.', -7);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-73, '22-36', true, 'Date linije su pogodne za izdvajanje u funkciju poput "BuildUriWithoutHomePath()", pa bi glavna funkcija vratila rezultat ove funkcije ako je homePath NullOrEmpty.', -7);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-74, '39-50', true, 'Date linije su pogodne za izdvajanje u funkciju "BuildUriWithHomePath(httpHomePath)".', -7);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-75, '40-46', false, 'Datu logiku je teško izdvojiti u zasebnu funkciju pošto je potrebno vratiti 3 vrednosti kao rezultat.', -7);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-8, -3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-8, 'Razmotri sledeći kod i označi koje transformacije bi značajno doprinele redukciji njegove složenosti.
```csharp
public bool OnDropStyle(ShapeStyle style, double x, double y, bool bExecute)
{
	try
	{
		if (PageState.SelectedShapes.Count > 0)
		{
			if (bExecute)
			{
				OnApplyStyle(style);
			}
			return true;
		}
		else
		{
			var container = Project.CurrentContainer;
			if (container != null)
			{
				var result = HitTest.TryToGetShape(
					container.CurrentLayer.Shapes.Reverse(),
					new Point2(x, y),
					Project.Options.HitThreshold / PageState.ZoomX,
					PageState.ZoomX);
				if (result != null)
				{
					if (bExecute)
					{
						OnApplyStyle(style);
					}
					return true;
				}
			}
		}
	}
	catch (Exception ex)
	{
		Log?.LogException(ex);
	}
	return false;
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-80, 'Zameni linije 7-10 i 25-28 sa pozivom funkcije "OptionallyApplyStyle(style, bExecute)"', false, 'Refaktorisanje ne doprinosi redukciji složenosti. Naziv nove funkcije govori istu stvar kao i njeno telo.', -8);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-81, 'Definiši promenljivu shapes koja će sačuvati rezultat izraza u liniji 19.', true, 'Izraz u liniji 19 nije previše složen. Ipak, ima smisla redukovati složenost kompletnog poziva funkcije TryToGetShapes i ovo je validan način da se to postigne.', -8);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-82, 'Definiši promenljivu droppedPoint koja će sačuvati rezultat izraza u liniji 20.', false, 'Izraz u liniji 20 nije složen. Iako je kompletan poziv TryToGetShapes složen, više ima smisla izdvojiti rezultat linije 19 ili 21 u zasebnu promenljivu.', -8);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-83, 'Ukloni linije 13, 14 i 32.', true, 'IF u liniji 5 završava funkciju ako je povezani uslov istinit (linija 11). Zbog toga nam ne treba ELSE blok, već ga možemo ukloniti i time izbaciti jedan stepen ugnježdavanja.', -8);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-84, 'Zameni trenutnu liniju 16 sa "if (container == null) return false;"', true, 'Ovakva transformacija prati takozvani "return early" princip. Ako ostatak koda dozvoljava, inverzijom IF uslova možemo da izbegnemo potrebu za dodatnim stepenom ugnježdavanja. U ovom slučaju će kod između linije 18 i 30 moći da se uvuče za još jedan stepen. Sličan potez bismo mogli da uradimo sa IF-om na liniji 23, no dobit bi bila nešto manja jer povezani blok sadrži par linija koda.', -8);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-85, 'Izdvoj računanje rezultata (linije 18-22) u funkciju "GetShape(double x, double y)"', true, 'Pošto "container" dobijamo iz Project polja klase, možemo ga jednako izvući unutar GetShape funkcije, čime bismo prepolovili kod OnDropStyle funkcije.', -8);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-9, -3);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-9, 'Složene funkcije su one koje zahtevaju visok mentalni napor da se razume sva logika i tokovi kontrole. Mnogi aspekti koda doprinose otežanom razumevanju - nejasni nazivi, dugački izrazi, duboko ugnježdavanje. U sklopu direktorijuma "Methods/02. Simple Methods" refaktoriši funkcije tako da ih pojednostaviš i smanjiš dupliranje koda.', 'https://github.com/Clean-CaDET/challenge-repository', 'Methods.Simple', 'https://youtu.be/-TF5b_R9JG4');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-41, 'Razmisli kako bi pojednostavio datu metodu tako da smanjiš ugnježdavanje koda.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-42, 'Ne zaboravi da vodiš računa o linijama koda.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-41, -9, 'Methods.Simple.ScheduleService');
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-41);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-41, 'CYCLO', 1, 5, -41, -41);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-42, 'MELOC', 1, 12, -42, -41);

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-10, -3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-10, 'Razmotri sledeći kod i označi koje transformacije bi  doprinele redukciji njegove složenosti.
```csharp
public double? GetPrimaryImageAspectRatio(BaseItem item)
{
	var imageInfo = item.GetImageInfo(ImageType.Primary, 0);

	if (imageInfo == null)
	{
		return null;
	}
	
	ImageDimensions size;

	var defaultAspectRatio = item.GetDefaultPrimaryImageAspectRatio();

	if (defaultAspectRatio > 0)
	{
		return defaultAspectRatio;
	}

	if (!imageInfo.IsLocalFile)
	{
		return null;
	}
	
	try
	{
		size = _imageProcessor.GetImageDimensions(item, imageInfo);

		if (size.Width <= 0 || size.Height <= 0)
		{
			return null;
		}
	}
	catch (Exception ex)
	{
		_logger.LogError(ex, "Failed to determine aspect ratio for {0}", imageInfo.Path);
		return null;
	}

	if (size.Width <= 0 || size.Height <= 0)
	{
		return null;
	}

	return (double)size.Width / size.Height;
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-100, 'Premesti trenutne linije 10 na liniju 23.', true, 'Ova sitna transformacija pomaže da se poveća razumljivost funkcije. Naime, premeštamo deklaraciju promenljive neposredno pre nego što se ona koristi, umesto da je ostavljamo u sred nepovezane logike.', -10);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-101, 'Premesti linije 19-22 ispod linije 8.', false, 'Data transformacija nije ispravna pošto menja ponašanje funkcije. Iako bismo hteli da grupišemo sve provere za imageInfo na jednom mestu, moguće je da će se defaultAspectRatio vratiti kao rezultat pre nego što se proverava da li je IsLocalFile false.', -10);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-102, 'Ukloni linije 39-42.', true, 'Ova provera se već vrši u linijama 28-31. Jedini način da se zaobiđe je ako se desi izuzetak, ali funkcija u tom slučaju vraća null, što znači da je logika 39-42 redundantna i treba je ukloniti.', -10);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-103, 'Izdvoj size.Width u promenljivu width, a size.Height u promenljivu height.', false, 'Oba izraza su veoma jednostavna i pojavljuju se dva puta, što ne opravdava dve posebne promenljive.', -10);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-11, -3);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-11, 'Razmotri sledeći kod i označi koje transformacije bi značajno doprinele redukciji njegove složenosti.
```csharp
public override void DrawDcPoints(object dc, IShapeRenderer renderer)
{
	if (renderer.State.SelectedShapes != null)
	{
		if (renderer.State.SelectedShapes.Contains(this))
		{
			UpdatePoints();

			foreach (var point in _points)
			{
				point.DrawShape(dc, renderer);
			}
		}
		else
		{
			UpdatePoints();

			foreach (var point in _points)
			{
				if (renderer.State.SelectedShapes.Contains(point))
				{
					point.DrawShape(dc, renderer);
				}
			}
		}
	}
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-110, 'Izdvoj logiku definisanu u linijama 9-12 i 18-24 u funkciju "DrawPoints(object dc, IShapeRenderer renderer)".', false, 'Data izmena nije dobra ideja. Ovo bi zahtevalo premeštanje većine logike iz trenutne funkcije u novu, čime bi se izgubio smisao trenutne DrawDcPoints funkcije.', -11);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-111, 'Ukloni poziv funkcije "UpdatePoints()" iz linije 7 i 16 i premesti ga pred kraj funkcije, ispod linije 25.', false, 'UpdatePoints ima smisla izdvojiti iz IF i ELSE bloka pošto se poziva u oba slučaja. Međutim, možemo zaključiti da ga ne treba pozvati na kraju blokova zato što se u daljem kodu koristi "_points" koji se verovatno ažurira pozivom "UpdatePoints" funkcije. Pravo rešenje je da se premesti iznad linije 5.', -11);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-112, 'Definiši promenljivu selectedShapes koja će sačuvati rezultat izraza "renderer.State.SelectedShapes".', true, 'Dati izraz nije složen. Ipak, ima smisla izdvojiti ga u promenljivu sa kraćim nazivom zato što se pojavljuje na 3 mesta.', -11);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-113, 'Ukloni linije 14, 15 i 25.', false, 'Uklanjanjem ELSE bloka dobijamo dvostruko izvršavanje logike ako se ispostavi da je IF uslov u liniji 5 true. Prema tome, menjamo ponašanje funkcije ako ovo uradimo.', -11);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-114, 'Zameni trenutnu liniju 3 sa "if (renderer.State.SelectedShapes == null) return;"', true, 'Ovakva transformacija prati takozvani "return early" princip.  Inverzijom IF uslova možemo da izbegnemo potrebu za dodatnim stepenom ugnježdavanja. U ovom slučaju ćemo sav preostali kod uvući za jedan stepen indentacije.', -11);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-12, -4);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-12, '
Razmotri sledeći kod i označi koliko linija koda bi imala bolje organizovana logika koja funkcionalno radi istu stvar. Nemoj da brojiš zaglavlje funkcije i vitičaste zagrade koje definišu njeno telo.
```csharp
public bool IsTestPassed(int[] studentPoints)
{
    if (studentPoints.Length <= 0)
    {
        return false;
    }
    if (studentPoints.Length > 0)
    {
        int pointSum = Sum(studentPoints);
        if (pointSum > 50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    return false;
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-120, '1', true, 'Čitava funkcija se može svesti na jednu liniju koda - "return studentPoints.Length > 0 && Sum(studentPoints) > 50;"', -12);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-121, '4', false, 'Jeste unapređenje, ali ima prostora za još.', -12);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-122, '6', false, 'Jeste unapređenje, ali ima prostora za još.', -12);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-123, '10', false, 'Ne bismo puno uradili sa ovakvom transformacijom.', -12);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-13, -4);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-13, '
Razmotri sledeći kod i označi koliko linija koda bi imala bolje organizovana logika koja funkcionalno radi istu stvar. Nemoj da brojiš zaglavlje funkcije i vitičaste zagrade koje definišu njeno telo. Takođe nemoj da koristiš LINQ izraze.
```csharp
public Course FindOpenCourse(Course[] courses)
{
    List<Course> openCourses = new List<Course>();
    foreach (Course c in courses)
    {
        if (c.Status == CourseStatus.Open)
        {
            openCourses.Add(c);
        }
    }
    if (openCourses.Count > 0)
    {
        return openCourses[0];
    }
    else
    {
        return null;
    }
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-130, '1', false, 'Odgovor nije tačan zato što smo uveli ograničenje da ne smemo LINQ koristiti. Ako ne bismo imali ovo ograničenje odgovor bi bio ispravan i čitavo telo funkcije bismo sveli na "return courses.FirstOrDefault(c => c.Status == CourseStatus.Open);"', -13);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-131, '4', false, 'Odgovor nije tačan. Čak i da izbacimo vitičaste zagrade kod IF-a (odnosno, da imamo u jednoj liniji koda "if (c.Status == CourseStatus.Open) return c;") i dalje bismo imali 5 linija koda zbog return null.', -13);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-132, '8', true, 'Ovo je tačan odgovor. Pošto je logika da biramo prvi otvoren kurs, nemamo potrebu za "openCourses" listom. Izbacićemo svaki pomen, a u IF bloku ćemo napisati "return c;"', -13);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-133, '9', false, 'Ovaj broj možemo dobiti ako bismo za poslednji IF primenili ternarni operator tako da imamo izraz "return openCourses.Count > 0 ? openCourses[0] : null;" Međutim, možemo bolje organizovati logiku.', -13);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-134, '13', false, 'Ovaj broj možemo dobiti npr. izbacivanjem nepotrebnog ELSE bloka. Međutim to nije jedina stvar koju možemo promeniti.', -13);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-14, -5);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-14, '
Analiziraj kod i rasporedi ponuđene instrukcije u odgovarajuću funkciju.
```csharp
public ActionResult PostUpdatedMovies([FromQuery] string? tmdbId, [FromQuery] string? imdbId)
{
	var movies = _libraryManager.GetItemList(new MoviesQuery());

	if (!string.IsNullOrWhiteSpace(imdbId))
	{
		movies = movies.Where(i => string.Equals(imdbId, i.GetProviderId(MediaBrowser.Model.Entities.MetadataProvider.mId), StringComparison.OrdinalIgnoreCase)).ToList();
	}
	else if (!string.IsNullOrWhiteSpace(tmdbId))
	{
		movies = movies.Where(i => string.Equals(tmdbId, i.GetProviderId(MediaBrowser.Model.Entities.MetadataProvider.mId), StringComparison.OrdinalIgnoreCase)).ToList();
	}
	else
	{
		movies = new List<BaseItem>();
	}

	foreach (var item in movies)
	{
		_libraryMonitor.ReportFileSystemChanged(item.Path);
	}

	return NoContent();
}
```');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-140, -14, 'Zadržati u glavnoj funkciji');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1400,-140, '_libraryManager.GetItemList(new MoviesQuery())', 'Možda na prvi prolaz deluje složeno, ali ako znamo šta je _libraryManager i šta MoviesQuery ova logika se svodi na jedno instanciranje i poziv metode, što nije složena logika.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1401,-140, '!string.IsNullOrWhiteSpace(id)', 'Ako bismo ovu logiku izmestili u posebnu funkciju, funkcija bi nosila naziv koji znači isto što i kod.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1402,-140, '_libraryMonitor.ReportFileSystemChanged(item.Path);', 'Logika je relativno jednostavna. Možda ima smisla izdvojiti čitavu petlju u posebnu funkciju, kako bi se glavna pojednostavila.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-141, -14, 'Premesti u novu "GetMovies()" funkciju.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-142, -14, 'Premesti u novu "IsNotNullOrWhiteSpace(id)" funkciju.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-143, -14, 'Premesti u novu "FindMovie(movies, id)" funkciju');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1430,-143, 'movies.Where(i => string.Equals(id, i.GetProviderId(MediaBrowser.Model.Entities.MetadataProvider.mId)', 'Logiku ima smisla izdvojiti obzirom da se ponavlja na dva mesta i nije trivijalna.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-144, -14, 'Premesti u novu "ReportFileChange(item)" funkciju.');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-15, -5);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-15, 'Složene funkcije su one koje zahtevaju visok mentalni napor da se razume sva logika i tokovi kontrole. Mnogi aspekti koda doprinose otežanom razumevanju, gde je mnogo složene logike i duboko ugnježdavanje glavni krivac. U sklopu direktorijuma "Methods/04. Nesting" refaktoriši funkcije tako da redukuješ ugnježdavanje i izdvojiš složenost u zasebne funkcije.', 'https://github.com/Clean-CaDET/challenge-repository', 'Methods.Nesting', 'https://youtu.be/7N7H8W7LdFU');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-61, 'Da li možeš dodatno da redukuješ ugnježdavanje, tako što ćeš izdvojiti metodu ili invertovati uslov u grananju?');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-62, 'Ne zaboravi da vodiš računa o linijama koda.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-61, -15);
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-61);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-61, 'CYCLO', 1, 4, -61, -61);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-62, 'MMNB', 1, 2, -61, -61);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-63, 'MELOC', 1, 16, -62, -61);

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-16, -5);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-16, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-160, 'Niz instrukcija koji sadrži više od 3 tačke za poziv metode ili pristup atributima je dobar kandidat za izdvajanje u posebnu metodu.', true, 'Tvrdnja je istinita. "Kandidat" ne znači da je refaktorisanje obavezno. Primer instrukcije koja se ne mora izdvajati je Code.ToUpper().Equals(product.Code.ToUpper()). Ipak, prethodan niz instrukcija bi vredelo izdvojiti da ne koristi osnovne string operacije i da su nazivi složeniji.', -16);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-161, 'Niz instrukcija koji sadrži više od 5 tačke za poziv metode ili pristup atributima je dobar kandidat za izdvajanje u posebnu metodu.', true, 'Tvrdnja je istinita. Redak je primer ovakvog niza instrukcija koji ne treba izdvojiti u posebnu funkciju. Alternativa je da se neki podskup instrukcija izdvoji u zasebnu metodu, pa da se originalni izraz spusti sa npr. 6 tački na 3.', -16);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-162, 'Kada unutar petlje imamo grananje, treba da telo petlje izdvojimo u zasebnu funkciju.', false, 'Tvrdnja nije tačna. 2 stepena ugnježdavanja nisu problematična, posebno ako se unutar petlje nalazi jednostavan IF sa jednim izrazom.', -16);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-163, 'Niz instrukcija koji sadrži više od 4 operatora treba izdvojiti u zasebnu funkciju.', false, 'Tvrdnja nije tačna. Kada su u pitanju 5 različitih operatora (npr. &&, +, *, < i !=) onda je niz izraza verovatno izuzetno složen i u tom slučaju ga treba pojednostaviti. Međutim, niz instrukcija koji sadrži 5 operatora sabiranja (+) može biti jednostavan i ne moramo ga refaktorisati.', -16);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-164, 'Kada unutar grananja imamo petlju unutar koje imamo još jednu petlju u čijem telu stoji grananje, treba da izdvojimo deo ugnježdenih instrukcija u zasebnu funkciju.', false, 'Tvrdnja je previše rigorozna. Ovakvo ugnježdavanje je odličan kandidat za refaktorisanje i često ima smisla da se napravi posebna funkcija. Međutim, ako ne postoji višestruko grananje i sve instrukcije su jednostavne, možemo dozvoliti ovakvoj funkciji da postoji. Primer je IF koji proverava da li lista nije null, nakon čega prolazi kroz svaki objekat i svaki element liste koji dati objekat poseduje, nad kojim se vrši jednostavan upit (poslednje grananje).', -16);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-17, -5);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-17, 'Analiziraj kod i rasporedi ponuđene instrukcije u odgovarajuću funkciju.
```csharp
private void AddChildren(User user, bool includeLinkedChildren, Dictionary<Guid, BaseItem> result, bool recursive)
{
	foreach (var child in GetEligibleChildrenForRecursiveChildren(user))
	{
		if (UserViewBuilder.FilterItem(child))
		{
			if (child.IsVisible(user))
			{
				result[child.Id] = child;
			}
		}
	}
	
	foreach (var child in GetEligibleChildrenForRecursiveChildren(user))
	{
		if (child.IsVisible(user))
		{
			if (recursive && child.IsFolder)
			{
				var folder = (Folder)child;
				folder.AddChildren(user, includeLinkedChildren, result, true);
			}
		}
	}
	
	if (includeLinkedChildren)
	{
		foreach (var child in GetLinkedChildren(user))
		{
			if (UserViewBuilder.FilterItem(child))
			{
				if (child.IsVisible(user))
				{
					result[child.Id] = child;
				}
			}
		}
	}
}
```');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-170, -17, 'Ne treba posebno izdvajati');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1700,-170, '7-10', 'Izdvajanje ovog koda bi proizvelo previše jednostavnu funkciju čije zaglavlje je složenije od tela.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1701,-170, '32-35', 'Izdvajanje ovog koda bi proizvelo previše jednostavnu funkciju čije zaglavlje je složenije od tela.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1702,-170, '26-38', 'Ako izdvajamo ponavljajući kod (3-12, 28-37) u posebnu funkciju, onda bi se dodatno izdvajanje ove logike svelo na jednostavan IF i poziv funkcije.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-171, -17, 'AddIfChildVisible(ChildItem child, Dictionary<Guid, BaseItem> result)');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-172, -17, 'FindVisibleChildren(User user, List<ChildItem> children, Dictionary<Guid, BaseItem> result)');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1720,-172, '3-12', 'Navedene instrukcije sadrže određenu složenost koja se dva puta ponavlja u identičnom obliku.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-1721,-172, '28-37', 'Navedene instrukcije sadrže određenu složenost koja se dva puta ponavlja u identičnom obliku.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-173, -17, 'IncludeLinkedChildren(bool include, User user, List<ChildItem> children)');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-18, -6);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-18, 'Navedena funkcija prihvata čvor iz sintaksnog stabla programskog koda, uzima izvorni kod i uklanja sve komentare koji se u njemu pojavljuju.
```csharp
private static string RemoveCommentsFromCode(CSharpSyntaxNode node)
{
    var allCode = node.ToString();
    foreach (var c in node.DescendantTrivia().Where(t => t.IsKind(SyntaxKind.SingleLineCommentTrivia) || t.IsKind(SyntaxKind.MultiLineCommentTrivia)))
    {
        allCode = allCode.Replace(c.ToFullString(), "");
    }
    return allCode;
}
```
Kolekcija koja sadrži komentare se dobija složenim izrazom koji vredi premestiti iznad petlje i sačuvati njegov rezultat u *explanatory variable*. Šta je pogodan naziv za ovu promenljivu?', '{"comments", "allComments"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-19, -6);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-19, 'Sledeća funkcija vrši upload datoteke, gde se logika svodi na pripremu HTTP zahteva. Navedi broj linije koda (razdvojene zarezom ako ih ima više) koje smatraš da sadrže izraze koji su dovoljno složeni da ih treba izdvojiti u promenljivu sa značajnim nazivom.
```csharp
private string Upload(Stream stream, string fileName)
{
    Dictionary<string, string> args = new Dictionary<string, string>();
    args.Add("session_token", sessionToken);
    args.Add("response_format", "json");
    args.Add("token_version", MajorV + "." + MinorV);
    args.Add("keyInfo", (signatureKey  %  256).ToString())
    UploadResult res = SendRequestFile(
	    apiUrl + "?" + string.Join("&", args.Select(x => x.Key + "=" + x.Value).ToArray()), 
	    stream, 
	    fileName);
    return res;
}
```', '{"9"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-20, -7);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-20, 'Sledeća funkcija se nalazi u okviru `Uploader` klase. Zadatak instance ove klase je da vrši upload sadržaja određenog tipa (engl. *content type*) na udaljeni servis, vodeći računa da se servis ne preoptereti frekventnim uploadom i beležeći sve greške koje se dese u komunikaciji. `GetResponse` je metoda koja na zahtev korisnika priprema i sprovodi odgovarajući zahtev za upload, formirajući konačan odgovor i vraćajući ga kao rezultat.

Posmatrajući kod i način na koji se parametri funkcije koriste, šta bi bile ispravne transformacije funkcije da se redukuje broj parametra?
```csharp
public HttpWebResponse GetResponse(HttpMethod method, string baseUrl, Stream data, string contentType, Dictionary<string, string> args, NameValueCollection additionalHeaders)
{
	IsUploading = true;
	try
	{
		HttpWebRequest request = CreateWebRequest(method, baseUrl, args, contentType, additionalHeaders);

		using (Stream requestStream = request.GetRequestStream())
		{
			if (!TransferData(data, requestStream))
			{
				return null;
			}
		}
		IsUploading = false;
		return (HttpWebResponse)request.GetResponse();
	}
	catch (Exception e)
	{
		ProcessError(e, baseUrl);
	}
	finally
	{
		IsUploading = false;
	}

	return null;
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-200, 'Promovisanje "contentType" da bude atribut klase.', true, 'Pošto je na nivou klase definisano da je instanca zadužena za slanje sadržaja određenog tipa, ima smisla da se ovo izdvoji u poseban atribut. Time će se redukovati i broj parametra "CreateWebRequest" funkcije koju GetResponse poziva.', -20);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-201, 'Sabiranje baseUrl i args u posebnu klasu QueryString.', false, 'Argumenti query string-a nisu nešto više vezani za URL od HTTP metode, te nije semantički smisleno spojiti ih u posebnu klasu ako već grupišemo sva svojstva HTTP zahteva.', -20);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-202, 'Promovisanje "data" da bude atribut klase.', false, 'Pošto su podaci za upload veoma dinamičan podatak koji će se menjati sa svakim pozivom funkcije, nema smisla da ga smestimo u manje dinamičnu lokaciju kao što je atribut klase.', -20);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-203, 'Nije potrebno redukovati broj parametra funkcije.', false, 'Šest parametra će uglavnom biti problem, osim kada je u pitanju konstruktor ili funkcija čiji zadatak je da delegira veću količinu parametra nekoliko manjim funkcijama.', -20);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-21, -7);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-21, 'Redukcija broja parametra pozitivno utiče na razumevanje zaglavlja funkcije i zadatka koji rešava. Pored toga, redukcijom liste parametra često smanjujemo broj zadataka koje funkcija radi. U sklopu direktorijuma "Methods/03. Parameter Lists" primeni strategije za redukciju parametra i refaktoriši funkcije.', 'https://github.com/Clean-CaDET/challenge-repository', 'Methods.Params', 'https://youtu.be/yKnxsH0CJzY');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-51, 'Funkcija ima previše parametra. Razmisli koja strategija za redukciju parametra najviše odgovara skupu parametra u datoj funkciji, pa je primeni.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-52, 'Vredna strategija za redukciju parametra podrazumeva premeštanje metoda i polja klase tako da se ukloni potreba za parametrom. Razmisli da li ima smisla premestiti neku metodu iz ove klase u drugu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-51, -21, 'Methods.Params.CourseService');
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-51);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-51, 'NOP', 0, 1, -51, -51);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-52, 'NMD', 0, 2, -52, -51);

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-22, -7);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-22, 'Sledeća funkcija se nalazi u okviru `Engine` klase koja opisuje srž rada video igre. Zadatak navedene funkcije je da kreira instancu ove klase.

Posmatrajući kod i način na koji se parametri funkcije koriste, šta bi bile ispravne transformacije funkcije da se redukuje broj parametra?
```csharp
public Engine(string title, Version version, GameState state, int width, int height, bool fullscreen) {
	Title = title;
	Version = version;
	State = state;
	FullScreen = fullscreen;
	
	var graphics = new GraphicsDeviceManager(this);
	graphics.PreferMultiSampling = false;
	graphics.GraphicsProfile = GraphicsProfile.Reach;
	graphics.HardwareModeSwitch = false;
	
	Core = Core.Core.SelectCore(graphics);
	Core.Init(width, height, fullscreen);
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-220, 'Nije potrebno redukovati broj parametra funkcije.', true, 'Data funkcija je zapravo konstruktor, koji često imaju veći broj parametra kako bi postavili objekat u ispravno stanje.', -22);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-221, 'Sabiranje width, height i fullscreen parametra u WindowSettings klasu.', false, 'Navedena transformacija bi možda bila opravdana da se data tri podatka uvek koriste zajedno. Međutim, vidimo da u liniji 5 koristimo 1 od navedenih podataka samostalno, a pošto nemamo širi kontekst ne možemo da pretpostavimo da li ima više mesta u kodu gde se data tri podatka upotrebljavaju istovremeno, zbog čega nije opravdano uvođenje dodatne klase.', -22);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-222, 'Promovisanje "version" da bude atribut klase.', false, 'Version već jeste atribut klase.', -22);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-223, 'Sabiranje "title" i "version" parametra u GameSpecs klasu.', false, 'Nemamo informaciju da se ova dva podatka koriste zajedno, te nije opravdano uvođenje nove klase.', -22);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-23, -7);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-23, 'Sledeće dve funkcije se nalaze u okviru `ImageShape` klase koja opisuje geometrijsku reprezentaciju slike. Zadatak prve funkcije je da proveri da li se određena tačka nalazi u polju slike, dok druga funkcija proverava da li se određeno polje preklapa sa slikom.

Posmatrajući kod i način na koji se parametri funkcije koriste, šta bi bile ispravne transformacije funkcije da se redukuje broj parametra?
```csharp
public bool Contains(ImageShape image, Point2 target, double radius, double scale, IDictionary<Type, IBounds> registered)
{
	var rect = Rect2.FromPoints(
		image.TopLeft.X,
		image.TopLeft.Y,
		image.BottomRight.X,
		image.BottomRight.Y);

	if (image.State.Flags.HasFlag(ShapeStateFlags.Size) && scale != 1.0)
	{
		return HitTestHelper.Inflate(rect, scale).Contains(target);
	}
	
	return rect.Contains(target);
}

public bool Overlaps(ImageShape image, Rect2 target, double radius, double scale, IDictionary<Type, IBounds> registered)
{
	var rect = Rect2.FromPoints(
		image.TopLeft.X,
		image.TopLeft.Y,
		image.BottomRight.X,
		image.BottomRight.Y);

	if (image.State.Flags.HasFlag(ShapeStateFlags.Size) && scale != 1.0)
	{
		return HitTestHelper.Inflate(ref rect, scale).IntersectsWith(target);
	}

	return rect.IntersectsWith(target);
}
```');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-230, 'Nije potrebno redukovati broj parametra funkcije.', false, 'Data funkcija sadrži nekoliko parametra koji joj nisu potrebni.', -23);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-231, 'Uklanjanje "image" parametar.', true, 'Pošto se funkcija poziva nad instancom ImageShape klase, nije potrebno prosleđivati dodatan ImageShape za proveru. Umesto toga, možemo zamisliti poziv funkcije "image.Contains(target, scale);" gde će funkcija da pristupi "TopLeft" i "BottomRight" poljima "image" objekta nad kojim se poziva.', -23);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-232, 'Sabiranje "radius" i "scale" parametra u ShapeTransformation klasu.', false, '"radius" se ne koristi od strane navedenih funkcija i treba ga ukloniti potpuno.', -23);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-233, 'Promovisanje "image" parametra u atribut klase.', false, 'ImageShape već sadrži polja koja se koriste iz "image" parametra. Promovisanje ovog parametra u atribut bi napravilo rekurzivnu strukturu, gde ImageShape sadrži ImageShape.', -23);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-234, 'Uklanjanje "registered" parametra.', true, 'Navedeni parametar se nigde ne koristi i treba ga ukloniti.', -23);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-24, -8);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-24, 'Sledeća funkcija radi dva zadatka, gde je samo jedan definisan njenim imenom.

```csharp
private List<string> LoadSyntaxTrees(IEnumerable<string> sourceCode)
{
	var syntaxErrors = new List<string>();
	foreach (var code in sourceCode)
	{
		var syntaxTree = CSharpSyntaxTree.ParseText(code);
		_compilation = _compilation.AddSyntaxTrees(syntaxTree);

		var diagnostics = syntaxTree.GetDiagnostics().ToList();
		syntaxErrors.AddRange(diagnostics.Select(diagnostic => diagnostic.ToString()));
	}
	return syntaxErrors;
}
```
Navedi linije koda, razdvojene zarezom, koje se odnose na drugi zadatak.', '{"3, 9, 10, 12"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-25, -8);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-25, 'Sledeća funkcija prihvata HTML stranicu i modifikuje njen sadržaj tako da se dodaju metapodaci na početak stranice i na kraj. U zavisnosti od drugog parametra se dodaju dodatni podaci na početak i kraj stranice.

```csharp
public string BuildPageWithSetupAndTeardown(PageData pageData, bool includeSuiteSetup)
{
	WikiPage wikiPage = pageData.WikiPage;
	StringBuilder builder = new StringBuilder();

	if (includeSuiteSetup)
	{
		WikiPage suiteSetup = WikiPageCrawler.GetInheritedPage("SuiteSetup", wikiPage);
		if (suiteSetup != null)
		{
			WikiPagePath pagePath = suiteSetup.GetFullPath(suiteSetup);
			builder.Append("!include -setup .").Append(pagePath).Append("\n");
		}
	}

	WikiPage setup = WikiPageCrawler.GetInheritedPage("SetUp", wikiPage);
	if (setup != null)
	{
		WikiPagePath setupPath = wikiPage.GetFullPath(setup);
		builder.Append("!include -setup .").Append(setupPath).Append("\n");
	}

	builder.Append(pageData.Content).Append("\n");

	WikiPage teardown = WikiPageCrawler.GetInheritedPage("TearDown", wikiPage);
	if (teardown != null)
	{
		WikiPagePath tearDownPath = wikiPage.GetFullPath(teardown);
		builder.Append("!include -teardown .").Append(tearDownPath).Append("\n");
	}

	if (includeSuiteSetup)
	{
		WikiPage suiteTeardown = WikiPageCrawler.GetInheritedPage("SuiteTeardown", wikiPage);
		if (suiteTeardown != null)
		{
			WikiPagePath pagePath = suiteTeardown.GetFullPath(suiteTeardown);
			builder.Append("!include -teardown .").Append(pagePath).Append("\n");
		}
	}

	pageData.Content = builder.ToString();
	return pageData.ToHtml();
}
```

Trenutna funkcija rešava mnoštvo zadataka. Rasporedi linije koda po sledećim kontejnerima, tako da se kod transformiše u kolekciju funkcija koji su fokusirani na jedan zadatak.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-250, -25, 'string BuildSetupPages(WikiPage p, bool includeSuite)');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2500,-250, '6-21', 'string koji vraća ova funkcija se prosleđuje glavnom builderu.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-251, -25, 'string BuildTeardownPages(WikiPage p, bool includeSuite)');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2510,-251, '25-40', 'string koji vraća ova funkcija se prosleđuje glavnom builderu.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-252, -25, 'string BuildPageSupplement(WikiPage p, string pageIdentifier, string includePrefix)');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2520,-252, '8-13', 'Navedeni kod je dobar primer netrivijalnog dupliranja koda koji se može parametrizovati i izdvojiti u datu funkciju.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2521,-252, '25-30', 'Navedeni kod je dobar primer netrivijalnog dupliranja koda koji se može parametrizovati i izdvojiti u datu funkciju.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-253, -25, 'Ne bih posebno izdvajao');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2530,-253, '32-40', 'Kod unutar ovog opsega (34-39) bismo mogli zameniti pozivom BuildPageSupplement funkcije. Dodatno izdvajanje IF-a u 32. liniji neće povećati kvalitet koda.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2531,-253, '3-4', 'Nema smisla izdvojiti dati kod u posebnu funckiju pošto se obe promenljive koriste kroz čitavu funkciju i sama inicijalizacija je trivijalna.');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2532,-253, '23-43', 'Ovaj region koda ne predstavlja semantički kohezivnu celinu i nema smisla grupisati ga u posebnu funkciju.');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-26, -8);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-26, 'Zadatak "SetupRepository" funkcije je da postavi prosleđeni git repozitorijum na lokalnoj mašini. Funkcija prihvata lokaciju gde treba da se klonira repozitorijum, zajedno sa njegovom putanjom koja sadrži URL i konkretan commit koji treba da bude učitan (engl. *checkout*) da bi postavka bila kompletna (primer takve putanje je https://github.com/Clean-CaDET/tutor/tree/2219c278592c2d0893f63694c760ae16ccb91904).

```csharp
public void SetupRepository(string urlWithCommitHash, string projectPath)
{
	if(Directory.Exists(projectPath))
	{
		Directory.Delete(directory, true);
	}
	Directory.CreateDirectory(projectPath);
	
	var urlParts = urlWithCommitHash.Split("/tree/");
	var projectUrl = urlParts[0] + ".git";
	Repository.Clone(projectUrl, projectPath);

	var commitHash = urlParts[1];
	Commands.Checkout(new Repository(projectPath), commitHash);
}
```
Prethodna funkcija nije preterano složena, no svakako radi više zadataka nego što njen naziv sugeriše. Navedi nazive funkcija (PascalCase, razdvojene zarezom) koje bi izdvojio iz `SetupRepository`, tako da ova funkcija samo poznaje korake potrebne da se reši zadatak i ništa van toga.', '{"CreateDirectory, CloneRepository, CheckoutCommit", "CreateDirectory, CloneRepository, Checkout", "CloneRepository, CheckoutCommit", "CloneRepository, Checkout"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-27, -9);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-27, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-270, 'Uvek je bolje dodeliti identifikatoru duži naziv.', false, 'Izjava nije tačna. Iako je često bolje ime koje se sastoji od nekoliko reči umesto od par karaktera, treba da izbegavamo suvišne, redundantne i generične reči i da budemo koncizni. U određenim okolnostima, čak i ime od par karaktera je dopustivo (npr. kada je scope identifikatora ograničen na par linija koda).', -27);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-271, 'Formiranje jasnog imena ubrzava čitanje i pisanje koda.', false, 'Izjava nije tačna. Dobro ime značajno olakšava čitanje koda, no formulisanje jasnog imena je često zahtevan posao i može uzeti više minuta, dok je postavljanje besmislenog imena instant operacija.', -27);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-272, 'Kada formiramo ime za neki element, treba da uzmemo u obzir njegov kontekst (tip, modul kom pripada, itd.)', true, 'Izjava je tačna. Kada zadajemo ime treba da izbegnemo ponavljanje informacije koja je jasno vidljiva iz npr. tipa povratne vrednosti funkcije ili objekta nad kojim se poziva metoda.', -27);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-28, -9);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-28, 'Sabrali smo sve smernice i prakse za davanje značajnog naziva u jednostavan algoritam. U sklopu direktorijuma "Naming/03. Meaningful Names" isprati zadatke u zaglavlju klase i primeni dati algoritam kako bi unapredio nazive koji se koriste u kodu.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Meaning', 'https://youtu.be/kna0fx6TglA');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-31, 'Izbegavaj redundantne reči koje ponavljaju informacije koje već stoje u tipu (npr. List, Num).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-31, -28);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-31, '{"List","string"}', -31);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-32, 'Izbegavaj misteriozne nazive koji ne objašnjavaju šta dati identifikator predstavlja (npr. nazive sa jednim slovom, a da nisu iteratori petlje).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-32, -28);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-32, '{"s","e"}', -32);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-33, 'Razmisli kako da integrišeš domenski značajne reči poput "Syntagms", "pascalCase", "capital" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-33, -28);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-33, '{"syntagms","pascalCase","capital"}', -33);

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-29, -9);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-29, 'Analiziraj sledeći kod i rasporedi nazive u odgovarajuće kategorije u zavisnosti od toga da li krše neki princip dobrog imenovanja.
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
	(-290, -29, 'Naziv je ispravan');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2900,-290, 'itemEvaluations', 'Ovaj naziv kratko i jasno označava kakvi podaci se nalaze u promenljivoj.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-291, -29, 'Naziv nije na odgovarajućem nivou apstrakcije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-292, -29, 'Naziv ne prati timske konvencije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-293, -29, 'Naziv sadrži beznačajne reči');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2930,-293, 'itemMarkedFlag', '"Flag" je redundantna reč, gde je iz naziva i tipa jasno da je u pitanju flag podatak.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-294, -29, 'Naziv ne koristi ispravnu terminologiju domena problema');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2940,-294, 'CheckAnswers', '"Answers" se nigde ne pominje van ovog naziva, te bi ovu reč trebalo zameniti sa "Items".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-295, -29, 'Naziv ne uzima u obzir širi kontekst');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-2950,-295, 'EvaluateMrqSubmission', '"MrqSubmission" se jednostavno može izvući iz parametra.');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-30, -9);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-30, 'Iz sledećeg spiska odaberi istinite tvrdnje:');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-300, 'Treba da izbegavamo tehnološke reči u našim imenima.', false, 'Izjava nije tačna. U redu je da imamo reči poput "File", "HTTP" i "Queue" u našim nazivima, ali ciljamo da ove koncepte izdvojimo od poslovne logike.', -30);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-301, 'Kod koji opisuje poslovnu logiku treba u većoj meri da bude čitljiv od strane našeg klijenta.', true, 'Izjava je tačna. Kada koristimo imenice iz domena da opišemo klase i promenljive i glagole da opišemo metode, naš kod je čitljiv od strane osobe koja poznaje domen - naš klijent.', -30);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-302, 'Potrebno je dobro ime izabrati u startu, zato što je naknadna promena skupa.', false, 'Izjava nije tačna. Promena imena za gotovo svaki element koda je trivijalna operacija uz pomoć savremenih editora koda.', -30);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-31, -9);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-31, '
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
	(-310, -31, 'Naziv je ispravan');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-3100,-310, 'maxItemsLimit', 'Ovaj naziv kratko i jasno označava kakvi podaci se nalaze u atributu.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-311, -31, 'Naziv nije na odgovarajućem nivou apstrakcije');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-3110,-311, 'GetSumOfAllItemPrices', '"GetTotalPrice" ili sličan naziv bi bolje opisao šta metoda radi, bez da ulazi u detalje kako to radi.');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-312, -31, 'Naziv ne koristi ispravne tipove reči');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-3120,-312, 'NumberOfItems', 'Ovakav naziv je ispravan kao ime atributa ili property-a. Za metodu bi bolji naziv bio u obliku glagola, poput "CountItems" ili "GetNumberOfItems".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-313, -31, 'Naziv ne prati timske konvencije');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-314, -31, 'Naziv ne koristi ispravnu terminologiju domena problema');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-3140,-314, 'IsBasketEmpty', '"Basket" se nigde ne pominje van ovog naziva, te bi ovu reč trebalo zameniti sa "Cart".');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-315, -31, 'Naziv ne uzima u obzir širi kontekst');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-3150,-315, 'AddItemToCart', 'Pošto se poziva nad instancom klase Cart, "ToCart" je suvišno. Pošto prihvata kao jedini parametar CartItem, i "Item" može biti suvišno, posebno ako je ovo jedina metoda koja dodaje nešto.');


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-32, -10);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-32, 'Posmatrajući sledeću strukturu paketa, navedi nazive klasa (razdvojene zarezom i bez .cs) koji krše konvenciju.

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
	(-33, -10);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-33, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji krše česte konvencije u pisanju programa.
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

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-34, -11);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-34, 'Često definišemo naše nazive koristeći generične ili beznačajne reči koje ponavljaju očiglednu informaciju ili ništa posebno ne kažu. U sklopu direktorijuma "Naming/01. Noise Words" isprati zadatke u zaglavlju klase i ukloni suvišne reči iz imena u kodu.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Noise', 'https://youtu.be/sR8hjHldAfI');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-11, 'Izbegavaj generične reči koje se mogu koristiti da opišu bilo kakav kod (npr. Manager, Data), kao i one koje ponavljaju informacije koje već stoje u nazivu tipa (npr. List, Num).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-11, -34);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-11, '{"Data","Info","Str","Set","The"}', -11);

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-35, -11);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-35, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji sadrža beznačajne reči.
```csharp
public int GetEffectiveLinesOfCode(string codeAsString)
{
    string code = RemoveCommentsFromCode(codeAsString);
        
    var allLines = code.Split(new[] { "\r\n", "\r", "\n" });
    int ignoreLineCount = CountBlankLines(allLines);
    int ignoreLineCount2 = CountHeaderLines(allLines);
        
    return Math.Max(allLines.Length - (ignoreLineCount + ignoreLineCount2 + 2), 1);
}
```', '{"codeAsString, ignoreLineCount2"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-36, -11);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-36, 'Analiziraj sledeći kod i označi sve nazive koje smatraš da sadrže beznačajne reči.
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
	(-360, 'GetSignature', false, 'Uklanjanje bilo koje reči bi učinilo naziv nevalidnim, gde "Get" samo po sebi ne daje dovoljno informacija šta se dobavlja, a "Signature" predstavlja imenicu što nije pogodan tip reči za metodu.', -36);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-361, 'signatureBuilder', false, 'Obe reči su bitne. Iako nezgodan primer, "Builder" je bitna reč. Ukazuje na to da se u promenljivi ne nalazi potpis funkcije, već mehanizam za njegovu izgradnju.', -36);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-362, 'FullName', false, 'Obe reči su bitne. Ovaj primer zahteva dublje razumevanje koncepta punog imena klase, koji podrazumeva uz naziv klase i naziv namespace-a kom pripada.', -36);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-37, -12);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-37, 'Označi nazive koji ne poštuju pravilo za upotrebu prikladnog tipa reči.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-370, 'public bool IsValid(User user)', false, '"IsValid" predstavlja pitanje i prihvatljivo je da ovako formulišemo naziv.', -37);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-371, 'public void Validate(User user)', false, 'Ovo je ispravan naziv.', -37);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-372, 'public bool Valid(User user)', true, 'Ovo nije ispravan naziv, jer "Valid" ne predstavlja glagol, a koristi se kao naziv funkcije.', -37);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-373, 'public class UserValidator', false, 'Ovo je ispravan naziv, gde se imenica koristi da označi naziv klase.', -37);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-374, 'public class ValidateUser', true, 'Ovo nije ispravan naziv, jer se glagol koristi da označi naziv klase.', -37);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-38, -12);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-38, 'Posmatrajući sledeći kod, unesi naziv identifikatora koji ne koristi ispravan tip reči.
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

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-39, -12);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-39, 'Označi nazive koji predstavljaju ispravan tip reči.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-390, 'public void Put(List<Employee> employees)', true, 'Nazivi ove funkcije i njenih parametra su ispravni.', -39);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-391, 'public class GeneratedReport', true, 'Naziv ove klase je ispravan što se tiče tipa reči, no svakako je upitno šta predstavlja koncept "generisanog" izveštaja.', -39);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-392, 'public void Register(User createUser)', false, 'Naziv funkcije koristi ispravan tip reči, dok naziv parametra predstavlja glagol, gde je očekivano da bude imenica.', -39);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-393, 'public class Registry', true, 'Naziv klase je ispravno imenica.', -39);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-40, -13);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-40, '`Order` klasa predstavlja porudžbinu koju korisnik može da formira (npr. u kontekstu poručivanja hrane preko Wolt/Glovo aplikacija). Instance ove klase sadrže podatke poput stavki porudžbine i njenog statusa (npr. kreirana, prihvaćena, otkazana).
Koristeći terminologiju domena problema, kako bismo nazvali (na engleskom, *PascalCase*) metodu koja treba da se pozove nad instancom `Order` klase kada korisnik želi da otkaže svoje porudžbinu?', '{"Cancel", "CancelOrder"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-41, -13);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
	(-41, 'U svojoj brzopletosti, često nabacamo kratke nazive kako bismo što pre formirali kod koji radi. U sklopu direktorijuma "Naming/02. Domain Words" izmeni nazive tako da ukloniš potrebu za komentarima i isprati zadatke u zaglavlju klase.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Domain', 'https://youtu.be/8OYsu0dza0k');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-21, 'Razmisli kako da integrišeš domenski značajne reči poput "Enroll", "newCourse", "Maximum" i "Active" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-21, -41);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-21, '{"Enroll","newCourse","Maximum","Active"}', -21);

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-42, -13);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-42, 'Označi kod iz naredne liste koji smatraš da potiče iz klasa koje opisuju domen problema, odnosno poslovne logike.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-420, 'string.join(":", patientRecord)', false, 'Ovo nije naziv iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -42);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-421, 'Close(Account account)', true, 'Ovaj naziv je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -42);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-422, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovaj naziv ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je naziv metode bio samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -42);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-423, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj, a ne deo domena problema.', -42);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-424, 'Register(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. sportskog kluba ili biblioteke).', -42);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-43, -13);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-43, '`Schedule` klasa sabira sastanke i obaveze koje korisnik ima u toku dana (npr. u kontekstu *Google Calendar* aplikacije). Instance ove klase sadrže spisak događaja (engl. *Appointment*), gde je svaki definisan sa nazivom, vremenom početka i završetka.
Koristeći terminologiju domena problema, kako bismo nazvali (na engleskom, *PascalCase*) metodu koja se poziva nad `Schedule` objektom, prihvata dužinu trajanja događaja u minutima i pronalazi prvi slobodan termin (engl. Timeslot) kada se događaj može zakazati.', '{"FindFirstAvailableTimeslot", "GetFirstAvailableTimeslot"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-44, -14);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-44, 'Razmotri sledeći kod.
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
	(-440, 'DataSetProject', false, 'Naziv je korektan i označava projekat u okviru nekog skupa podataka.', -44);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-441, 'DSEObject', false, 'Naziv je korektan, no primer je nezgodan. DSE je korenski namespace, što znači da akronim DSE predstavlja ime aplikacije. Po logici ovog naziva bismo mogli svaku klasu da nazovemo sa prefiksom DSE, što bi bilo izuzetno redundantno. Međutim, u ovom slučaju ima smisla jer bez prefiksa ostaje ključna reč Object koja ima posebno značenje u objektno-orijentisanim jezicima. Možemo pretpostaviti da je DSEObject nekakva korenska klasa koja sadrži podatke i logiku zajedničku za značajan deo ove aplikacije.', -44);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-442, 'DataSetProjectName', true, 'Naziv polja redundantno ponavlja ime svoje klase. "Name" bi bilo dovoljno da se razume da podatak predstavlja ime projekta.', -44);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-443, 'ProjectState (naziv enumeracije)', false, 'Naziv je korektan. "State" bi bilo previše opšte, dok bi "DatasetProjectState" bilo donekle redundantno, pod pretpostavkom da DSE aplikacija nema više različitih projekata, posebno u Datasets namespace-u.', -44);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-444, 'ProjectState (naziv atributa)', true, 'Naziv sadrži redundantnu reč "Project". Pošto su ostali atributi izuzetno jasni u svom značenju, neće doći do konfuzije ako bismo ostavili samo reč "State" za naziv ovog polja.', -44);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-445, 'AddCandidateInstance', true, 'Naziv je redundantan, uzimajući u obzir naziv parametra i njegovog tipa. "Add" bi bio dovoljan pod pretpostavkom da nema drugih metoda koje nešto dodaju. U suprotnom bi "AddInstances" mogao da bude dovoljan.', -44);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-45, -14);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-45, 'Analiziraj sledeći kod koji je deo `CCMethod` klase i navedi sve nazive (odvojene zarezom) koje smatraš da se mogu pojednostaviti analizom šireg konteksta.
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

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-46, -14);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-46, 'Ako treba da analiziramo širi kontekst prilikom formiranja naziva, označi nazive funkcija koje sadrže dobar naziv.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-460, 'void RegisterTemporaryUser(User user)', true, 'Ovo je dobar naziv iako je težak primer. Reč "User" jeste redundantna, no njeno uklanjanje bi ostavilo reč "Temporary" da visi bez imenice na koju se odnosi. Ključno je da je operacija registracije privremenog korisnika drugačija od registracije redovnog korisnika zbog čega nam znači diferencijacija u nazivu.', -46);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-461, 'ChallengeEvaluation Evaluate(ChallengeSubmission submission)', true, 'Ovo je ispravan naziv. Iako se "Evaluate" ponavlja u delu naziva tipa povratne vrednosti, dati naziv jasno i koncizno opisuje da se ovde vrši provera submisije za izazov.', -46);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-462, 'List<Doctor> GetDoctorsForOperation(Operation operation)', false, 'Ovo nije dobar naziv jer redundantno opisuje parametar.', -46);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-463, 'Dictionary<MetricId, double>> GetMetricValueMap()', false, 'Ovo nije dobar naziv, jer redundantno opisuje tip povratne vrednosti. Reč Map je sinonim za Dictionary, te je treba izbaciti iz naziva.', -46);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-464, 'void RegisterUser(User user)', false, 'Ovo nije dobar naziv, gde je reč "User" redundantna.', -46);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-47, -15);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-47, 'Ako tvrdimo da jasan naziv objašnjava šta parče koda radi, a ne kako to radi, označi funkcije koje imaju naziv na dobrom nivou apstrakcije.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-470, 'Employee Get(int employeeId)', true, 'Ovo je dobar naziv, pod pretpostavkom da se glagol "Get" po konvenciji koristi za svako čuvanje entiteta.', -47);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-471, 'List<DatasetInstance> FindInstancesRequiringAdditionalAnnotation(Dataset dataset)', true, 'Ovo je dobar naziv, jer apstrahuje detalje koji određuju šta znači da instanca nije dovoljno anotirana, a opet dodatno opisuje šta će ta povratna vrednost da predstavlja, odnosno da nije bilo kakva lista instanci.', -47);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-472, 'decimal ApplyDiscountToOrder(Order order, Discount discount)', false, 'Ovo nije dobar naziv jer opisuje kako se cena računa. Bolje ime bi bilo "CalculatePrice(Order order, Discount discount)" koje ističe nameru funkcije, a iz parametra se vidi da se popust uvažava.', -47);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-473, 'void SaveIfValid(Employee employee)', false, 'Ovo nije dobar naziv jer otkriva detalje implementacije u vidu provere validnosti prosleđenog objekta. "Save" je naziv na boljem nivou apstrakcije.', -47);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-48, -15);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-48, 'Razmotri sledeći zahtev i definiši ime funkcije na prikladnom nivou apstrakcije (samo ime, bez zagrada i parametra), prateći *PascalCase* konvenciju i koristeći engleski jezik.

Pored osnovnih podataka, entitet zaposlenog sadrži listu odsustva koje uključuju godišnje odmore i bolovanja (engl. *sick leave*). Potrebno je definisati funkciju koja će da pronađe sve zaposlene koji nisu uzeli bolovanje u određenoj godini, gde se godina prosleđuje kao parametar. Šta je prikladno ime za ovu funkciju?', '{"GetEmployeesWithoutSickLeave", "FindEmployeesWithoutSickLeave", "GetEmployeesWithNoSickLeave", "FindEmployeesWithNoSickLeave"}');

INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-49, -15);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-49, 'Ako tvrdimo da jasan naziv objašnjava šta parče koda radi, a ne kako to radi, označi funkcije koje imaju naziv na dobrom nivou apstrakcije.');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-490, 'List<Doctor> GetAvailableAndCapableDoctors(Operation operation)', false, 'Ovo nije dobar naziv jer opisuje sadržaj tela funkcije.', -49);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-491, 'List<Doctor> GetDoctors(Operation operation)', false, 'Ovaj naziv je na granici, no verovatno je previše apstraktan. Naime, iz naziva nije jasno kakav skup lekara se dobija. Uzimajući u obzir i parametar se može naslutiti, no zahteva mentalno mapiranje.', -49);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-492, 'List<Doctor> GetSuitableDoctors(Operation operation)', true, 'Ovaj naziv se nalazi na optimalnom nivou apstrakcije.', -49);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-493, 'List<Doctor> Get(Operation operation)', false, 'Ovaj naziv je previše apstraktan. Uz ozbiljno mentalno mapiranje je moguće razumeti nameru ove funkcije ako se posmatra povratna vrednost i parametar. Ovakav napor želimo da izbegnemo u našem kodu.', -49);


INSERT INTO public."AssessmentEvents"("Id", "KnowledgeComponentId") VALUES
	(-50, -15);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-50, 'Razmotri sledeći zahtev i definiši ime funkcije na prikladnom nivou apstrakcije (samo ime, bez zagrada i parametra), prateći *PascalCase* konvenciju i koristeći engleski jezik.

Postoji klasa koja predstavlja duž (`Line`). Ona sadrži dva atributa tipa `Point` gde svaki predstavlja jednu tačku duži i sastoji se od koordinata X i Y. `Line` klasa nudi metodu koja računa rastojanje između dve tačke koristeći formulu `√((p2.x-p1.x)²+(p2.y-p1.y)²)`, čime se dobija dužina duži. Šta je prikladno ime za ovu funkciju?', '{"GetLength", "CalculateLength"}');