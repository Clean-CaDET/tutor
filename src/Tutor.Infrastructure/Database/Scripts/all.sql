-- F02 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-71, 'Identifikuj regione povezanog koda (obrati pažnju na komentare) i izdvoj ih u funkciju kojoj možeš dati jasan naziv.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-71, /*TODO*/, 'Methods.SmallMethods.Achievement');
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-71);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-1, 'MELOC', 1, 18, -71, -71);

	
-- F03 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-41, 'Razmisli kako bi pojednostavio datu metodu tako da smanjiš ugnježdavanje koda.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-42, 'Ne zaboravi da vodiš računa o linijama koda.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-41, /*TODO*/, 'Methods.SimpleMethods.Schedule');
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-41);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-41, 'CYCLO', 1, 5, -41, -41);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-42, 'MELOC', 1, 12, -42, -41);

	
-- F07 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-51, 'Funkcija ima previše parametra. Razmisli koja strategija za redukciju parametra najviše odgovara skupu parametra u datoj funkciji, pa je primeni.');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-52, 'Vredna strategija za redukciju parametra podrazumeva premeštanje metoda i polja klase tako da se ukloni potreba za parametrom. Razmisli da li ima smisla premestiti neku metodu iz ove klase u drugu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-51, /*TODO*/, 'Methods.ParameterLists.CourseService');
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-51);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-51, 'NOP', 0, 1, -51, -51);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-52, 'NMD', 0, 2, -52, -51);
	
	
-- F05 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-61, 'Da li možeš dodatno da redukuješ ugnježdavanje, tako što ćeš izdvojiti metodu ili invertovati uslov u grananju?');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-62, 'Ne zaboravi da vodiš računa o linijama koda.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-61, /*TODO*/);
INSERT INTO public."BasicMetricCheckers"(
	"Id")
	VALUES (-61);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-61, 'CYCLO', 1, 4, -61, -61);
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-62, 'MMNB', 1, 2, -61, -61); -- TODO: Check if 3 is suitable; Check these rules in general
INSERT INTO public."MetricRangeRules"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId", "MetricCheckerForeignKey")
	VALUES (-63, 'MELOC', 1, 16, -52, -61);


-- N03 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-11, 'Izbegavaj generične reči koje se mogu koristiti da opišu bilo kakav kod (npr. Manager, Data), kao i one koje ponavljaju informacije koje već stoje u nazivu tipa (npr. List, Num).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-11, /*TODO*/, 'Naming.NoiseWords.Doctor');
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-11, '{"Data","Info","Str","Set","The"}', -11);
	

-- N05 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-21, 'Razmisli kako da integrišeš domenski značajne reči poput "Enroll", "newCourse", "Maximum" i "Active" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-21, /*TODO*/, 'Naming.MeaningfulWords.Course');
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-21, '{"Enroll","newCourse","Maximum","Active"}', -21);


-- N01 challenge strategies & hints
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-31, 'Izbegavaj redundantne reči koje ponavljaju informacije koje već stoje u tipu (npr. List, Num).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-31, /*TODO*/);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-31, '{"List","string"}', -31);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-32, 'Izbegavaj misteriozne nazive koji ne objašnjavaju šta dati identifikator predstavlja (npr. nazive sa jednim slovom, a da nisu iteratori petlje).');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-32, /*TODO*/);
INSERT INTO public."BannedWordsCheckers"(
	"Id", "BannedWords", "HintId")
	VALUES (-32, '{"s","e"}', -32);
	
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-33, 'Razmisli kako da integrišeš domenski značajne reči poput "Syntagms", "pascalCase", "capital" u nazive koje koristiš u svom kodu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-33, /*TODO*/);
INSERT INTO public."RequiredWordsCheckers"(
	"Id", "RequiredWords", "HintId")
	VALUES (-33, '{"syntagms","pascalCase","capital"}', -33);
	
	
	
--== Methods ==- CK Node
INSERT INTO public."KnowledgeNodes"(
	"Id", "LearningObjective", "Type", "LectureId") -- TODO: KN many to many prerequisites (after experiment)
	VALUES (14, 'Razumi posledice održavanja koda koji se sastoji od funkcija gde je svaka fokusirana na manji broj zadataka (idealno jedan).', 2, 2);

INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (60, 'Refactoring Extract Method', 14);

INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId") -- Not sure what to do with this Description field.
	VALUES (61, 'Function LINQ', 14);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (62, 'Function Hierarchy', 14); -- Dva LO - slika i task
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (63, 'Refactoring One Thing', 14);

INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (64, 'Function Big Picture', 14);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (65, 'Function Recap', 14);
	
-- Methods LO - CK Node
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




--== Cohesion ==- FK Node	
INSERT INTO public."KnowledgeNodes"(
	"Id", "LearningObjective", "Type", "LectureId")
	VALUES (15, 'Definiši razliku između strukturalne i semantičke kohezije.', 0, 3);

INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (100, 'Semantic Cohesion Definition', 15);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (101, 'Semantic Cohesion Example', 15);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (102, 'Structural Cohesion Definition', 15);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (103, 'Structural Cohesion Example', 15);
	

-- Cohesion - FK Node
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (100, 100);
INSERT INTO public."Texts"(
	"Id", "Content")
	VALUES (100, 'Kohezija modula definiše koliko njegovi elementi formiraju značajnu i atomičnu celinu. 

Elementi *visoko-kohezivnog modula* smisleno "pripadaju zajedno" i zajedno ostvaruju jasno definisan zadatak. Za ovakve module kažemo da imaju jednu odgovornost. Tako instrukcije koje čine visoko-kohezivnu funkciju zajedno izvršavaju jedan zadatak, dok klasa sadrži metode koje su usko povezane i zajedno izvršavaju jednu odgovornost. Takve module je lakše imenovati jer ime definiše tu odgovornost, odnosno zadatak koji modul vrši.

*Nisko-kohezivni moduli* rade više stvari i čine skup slabo povezanih elemenata. Klasa koja se bavi obradom HTTP zahteva, radom sa datotekama i poslovnom logikom sadrži više značajnih celina u sebi, odgovara na više odgovornosti i kao celina ima nisku koheziju.

Tip kohezije koji smo opisali do sada nazivamo **semantička kohezija**. Pod semantikom smatramo značenje koje pridodajemo određenom segmentu koda - nešto što definišemo kroz njegovo ime i zadatke, odgovornosti ili ciljeve koje dati kod treba da ispuni. Pošto je semantika zasnovana na jeziku kojim se služimo i zavisi od domena za koji pravimo softver, semantičku koheziju je izazovno odrediti.');

INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (101, 101);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (101, 'https://i.ibb.co/56Fzt6L/RS-semantic-example.png', 'Leva klasa izvršava par odgovornosti - više nego što njeno ime ističe.');

INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (102, 102);
INSERT INTO public."Texts"(
	"Id", "Content")
	VALUES (102, 'Kohezija modula se može definisati kao strukturalna metrika. Primeri jednostavnih strukturalnih metrika su broj linija koda klase (engl. *lines of code*; *LOC*) i broj metoda klase (engl. *number of methods defined*; *NMD*).

Kohezija ili nedostatak kohezije (engl. *Lack of cohesion of methods*; *LCOM*) je složenija strukturalna metrika koja određuje stepen "umreženosti" elemenata modula. Ovo podrazumeva brojanje veza između elemenata, gde bi primer veze kod klase bio pristup atributa od strane metode.

Visoko-kohezivne klase imaju gustu mrežu veza, gde će većina metoda koristiti većinu atributa. Nisko-kohezivne klase imaju retku mrežu, gde će većina metoda pristupati manjem podskupu atributa.');

INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (103, 103);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (103, 'https://i.ibb.co/QQ7XDK5/structural-cohesion-example.png', 'Koja klasa ima gušću mrežu? Kako bismo refaktorisali klasu sa niskom kohezijom?');
	

--== Cohesion ==- PK Node 1
INSERT INTO public."KnowledgeNodes"(
	"Id", "LearningObjective", "Type", "LectureId")
	VALUES (16, 'Primeni formulu za računanje strukturalne kohezije klase i skup refaktorisanja za njeno unapređenje.', 1, 3);

INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (110, 'Structural Cohesion Advanced Example', 16);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (111, 'Structural Cohesion Formula', 16);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (112, 'Structural Cohesion Calculation', 16);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (113, 'Structural Cohesion Exceptions', 16); -- TODO: Another LO that is based on text (or image)
	
/*INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (114, 'Challenge Structural Cohesion', 16);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (115, 'Challenge Structural Cohesion Solution', 16); TODO*/
	
-- Cohesion - PK Node 1
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (110, 110);
INSERT INTO public."ArrangeTasks"(
	"Id", "Text")
	VALUES (110, 'Ispitaj sledeću klasu:
	
    class StoreApplication
    {
        private string _fileLocation;
        private string _lineSeparator;
        private List<Product> _availableProducts;
    
        //Constructor omitted for brevity.
        public void RefreshInventory()
        {
            File.Create(_fileLocation);
        }

        public void LoadInventory()
        {
            string[] lines = File.ReadAllLines(_fileLocation);
            foreach (string line in lines)
            {
                string[] productElements = line.Split(_lineSeparator);
                _availableProducts.Add(new Product(productElements));
            }
        }

        public Product GetProduct(string name)
        {
            foreach (var product in _availableProducts)
            {
                if (product.Name.Equals(name)) return product;
            }
            return null;
        }

        public List<Product> GetProductsCheaperThan(double price)
        {
            List<Product> retVal = new List<Product>();
            foreach (var product in _availableProducts)
            {
                if (product.Price < price) retVal.Add(product);
            }

            return retVal;
        }
    }

Ako posmatramo strukturalnu koheziju klase kao broj veza (pristupa polja od strane metode) u klasi, rasporedi navedena polja i atribute u sledeće klase da proizvedeš što kohezivnije klase.');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (111, 110, 'StoreApplication');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (112, 110, 'ProductStorage');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (111, 112, '_fileLocation');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (112, 112, '_lineSeparator');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (113, 112, 'RefreshInventory');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (114, 112, 'LoadInventory');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (113, 110, 'ProductCache');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (115, 113, '_availableProducts');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (116, 113, 'GetProduct');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (117, 113, 'GetProductsCheaperThan');
	
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (111, 111);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (111, 'https://i.ibb.co/w6T0Mg5/RS-structural-formula.png', 'Izračunaj vrednost strukturalne kohezije za proizvoljan primer koda kako bi utemeljio razumevanje ove formule.');
	
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (112, 112);
INSERT INTO public."Questions"(
	"Id", "Text")
	VALUES (112, 'Primeni prethodnu formulu da izračunaš strukturalnu koheziju za sledeću klasu:
	
	class StudentEnrollments
    {
        private List<Course> _activeCourses;
        private List<Course> _completedCourses;

        //Constructor omitted for brevity.
        public int GetActiveCoursesESPB()
        {
            int totalEspb = 0;
            foreach (Course course in _activeCourses)
            {
                totalEspb += course.ESPB;
            }
            return totalEspb;
        }

        public void EnrollInCourse(Course newCourse)
        {
            if (GetActiveCoursesESPB() + newCourse.ESPB > EnrollmentConstants.MAX_ALLOWED_ACTIVE_ESPB)
                throw new InsufficientESPBRemainingException();

            foreach (Course prerequisite in newCourse.PrerequisiteCourses)
            {
                if(_completedCourses.Contains(prerequisite)) continue;
                throw new PrerequisiteCourseNotCompletedException();
            }

            _activeCourses.Add(newCourse);
        }
    }
	');
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (110, 'Kohezija je 0.', false, '', 112);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (111, 'Kohezija je 0.25.', false, '', 112);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (112, 'Kohezija je 0.5.', false, '', 112);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (113, 'Kohezija je 0.75.', true, 'Ovaj odgovor je ispravan. Klasa ima 2 metode i 2 polja. EnrollInCourse koristi oba polja, dok GetActiveCoursesESPB koristi samo jedno. Primenom formule dobijamo (2+1)/(2*2) = 0.75.', 112);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (114, 'Kohezija je 1.', false, '', 112);

INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (113, 113);
INSERT INTO public."Questions"(
	"Id", "Text")
	VALUES (113, 'Primeni prethodnu formulu da izračunaš strukturalnu koheziju za sledeće klase:
	
	class Course
    {
        private string _name;
		private int _espb;
		
		public string GetName()
		{
		    return _name;
		}
		
		public int GetEspb()
		{
		    return _espb;
		}
    }
	
	class CourseValidator
	{
        public bool IsValid(Course c)
		{
		    if(c.GetName() == null || c.GetName().Equals("")) return false;
			return c.GetEspb() > 0;
		}
	}
	');
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (120, 'Kohezija Course klase je 0.5, a CourseValidator klase je 0.', false, '', 113);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (121, 'Kohezija Course klase je 0, a CourseValidator klase nije moguće izračunati.', false, '', 113);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (122, 'Kohezija Course klase je 0.5, a CourseValidator klase nije moguće izračunati.', true, 'Ova izjava je tačna. Kroz ovaj primer uočavamo okolnosti u kojima strukturalna kohezija ne daje značajan podatak. Ako je klasa funkcionalna klasa (sadrži samo metode bez polja) formula koju koristimo nije primenljiva jer posmatra vezu kao spoj polja i metode. Ako je klasa suštinski struktura podataka (ima samo polja uz getter i setter metode) kohezija je niska i mogli bismo je povećati podelom u klase koje imaju po 1 polje, što bi bilo besmisleno. Iz navedenog vidimo da je strukturalna kohezija korisna samo kada radimo sa "pravim objektima" - kolekcijom atributa i metoda koje koriste veći broj atributa da izvrše zadatak i kolektivno ispune neku odgovornost.', 113);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (123, 'Kohezija Course i CourseValidator klase je 0.', false, '', 113);
INSERT INTO public."QuestionAnswers"(
	"Id", "Text", "IsCorrect", "Feedback", "QuestionId")
	VALUES (124, 'Kohezija Course klase je 0.5, a CourseValidator klase je 1.', false, '', 113);


--== Cohesion ==- PK Node 2
INSERT INTO public."KnowledgeNodes"(
	"Id", "LearningObjective", "Type", "LectureId")
	VALUES (17, 'Primeni formulu za računanje semantičke kohezije klase i skup refaktorisanja za njeno unapređenje.', 1, 3);

INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (120, 'Semantic Cohesion Advanced Example', 17);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (121, 'Semantic Cohesion Formula', 17); -- TODO: Zadatak (npr. ArrangeTask za odgovornosti).
	
/*INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (122, 'Challenge Semantic Cohesion', 17);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (123, 'Challenge Semantic Cohesion Solution', 17);TODO*/
	
-- Cohesion - PK Node 2
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (120, 120);
INSERT INTO public."Videos"(
	"Id", "Url")
	VALUES (120, 'https://www.youtube.com/watch?v=qE-Gmu_YuQE'); -- TODO: RS
	
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (121, 121);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (121, 'https://i.ibb.co/HzzCFVC/RS-semantic-cohesion.png', 'Nepreciznost ove formule potiče od labave definicije "odgovornosti" i semantičkog značenja koji dodeljujemo nekom parčetu koda. Problem je dodatno otežan što se prati izvršavanje date odgovornosti na nivou čitavog sistema, a ne samo posmatranog modula.');
	--TODO PK1 and PK2 challenges

--== Cohesion ==- CK Node
INSERT INTO public."KnowledgeNodes"(
	"Id", "LearningObjective", "Type", "LectureId")
	VALUES (18, 'Razumi značaj kohezivnih modula za održivi razvoj softvera.', 2, 3);

INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (130, 'Cohesion Analogy', 18);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (131, 'Cohesion Adhesion', 18);
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (132, 'Cohesion Big Picture', 18); -- Paketi servisi.
	
INSERT INTO public."LearningObjectSummaries"(
	"Id", "Description", "KnowledgeNodeId")
	VALUES (133, 'Cohesion Recap', 18);


-- Cohesion -- CK Node
INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (130, 130);
INSERT INTO public."Texts"(
	"Id", "Content")
	VALUES (130, 'Programski kod je mehanizam putem kog komuniciramo sa računarom. U složenom softveru, istovremeno vodimo više razgovora. Dogovaramo se kako da bezbedno transportujemo podatke, kako da keširamo odgovore na zahteve, šta čini validan unos i koji su koraci odabrane poslovne kalkulacije.
	
Polazeći od ove analogije, možemo da posmatramo sistem izgrađen od nisko-kohezivnih modula kao glasnu žurku gde se mnoge glasne konverzacije vode. U takvom ambijentu je teško fokusirati se na jedan razgovor i često čujemo pogrešne reši (ili ne čujemo pa klimamo glavom kao da je sve jasno).
	
Naspram toga, sistem izgrađen od visoko-kohezivnih modula je poput kvalitetnog foruma za onlajn diskusiju. Svaki segment foruma je fokusiran na jednu temu, tako da je lako ispratiti o čemu se priča. Kada je neophodno pronaći podatak o nekoj temi, lako je izdvojiti relevantni deo foruma.');

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

INSERT INTO public."LearningObjects"(
	"Id", "LearningObjectSummaryId")
	VALUES (133, 133);
INSERT INTO public."Texts"(
	"Id", "Content")
	VALUES (133, 'TODO');

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "KnowledgeComponentId")
    VALUES (1, 'Čiste funkcije', null);

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "KnowledgeComponentId")
VALUES (2, 'Čista imena', 1);

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "KnowledgeComponentId")
VALUES (3, 'Redukcija broja parametara', 1);

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "KnowledgeComponentId")
VALUES (4, 'Kratke funkcije', 1);
