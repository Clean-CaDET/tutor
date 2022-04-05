DELETE FROM public."Submissions";
DELETE FROM public."ArrangeTaskContainerSubmissions";
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
DELETE FROM public."AssessmentItems";
DELETE FROM public."ShortAnswerQuestions";
DELETE FROM public."InstructionalItems";
DELETE FROM public."KcMasteries";
DELETE FROM public."KnowledgeComponents";
DELETE FROM public."Units";

DELETE FROM public."Learners";

INSERT INTO public."Learners"(
    "Id", "StudentIndex", "WorkspacePath", "Password", "Salt") -- Password: 123
VALUES (-1, 'SU-1-2021', 'C:/Smart-Tutor/1/Workspace', 'SXQ0w0gW19OPoX3+jZ+tmcU6xl9uQFa5wRFcYbN8UKo=', '+ZcRExvqgCaST38r2oPT5A==');
INSERT INTO public."Learners"(
    "Id", "StudentIndex", "WorkspacePath", "Password", "Salt") -- Password: 123
VALUES (-2, 'SU-2-2021', 'C:/Smart-Tutor/2/Workspace', 'SXQ0w0gW19OPoX3+jZ+tmcU6xl9uQFa5wRFcYbN8UKo=', '+ZcRExvqgCaST38r2oPT5A==');
INSERT INTO public."Learners"(
    "Id", "StudentIndex", "WorkspacePath", "Password", "Salt") -- Password: 123
VALUES (-3, 'SU-3-2021', 'C:/Smart-Tutor/3/Workspace', 'SXQ0w0gW19OPoX3+jZ+tmcU6xl9uQFa5wRFcYbN8UKo=', '+ZcRExvqgCaST38r2oPT5A==');

--== Unit 1: Meaningful names
INSERT INTO public."Units"(
	"Id", "Name", "Description")
	VALUES (-1, 'Značajna imena', 'Imena pronalazimo u svim segmentima razvoja softvera - kao identifikator promenljive, funkcije, klase, ali i biblioteke i aplikacije. Jasno ime funkcije nas oslobađa od čitanja njenog tela, dok će misteriozno ime zahtevati dodatan mentalni napor da razumemo svrhu koncepta koji opisuje. U najgorem slučaju, loše ime će nas navesti na pogrešan put i drastično nam produžiti vreme razvoja. Kroz ovu lekciju ispitujemo dobre i loše prakse za imenovanje elemenata našeg koda.');

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "Description", "UnitId")
VALUES (-10, 'Dodeli značajna imena identifikatorima', '', -1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-11, 'Dodeli značajna imena identifikatorima', '', -1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-12, 'Koristi ispravne tipove reči', '', -1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-13, 'Prati timske konvencije', '', -1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-14, 'Izbegavaj beznačajne reči', '', -1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-15, 'Koristi terminologiju domena problema', '', -1);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-49, 0.0, -10, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-1, 0.0, -11, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-2, 0.0, -12, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-3, 0.0, -13, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-4, 0.0, -14, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-5, 0.0, -15, -1, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-50, 0.0, -10, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-6, 0.1, -11, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-7, 0.2, -12, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-8, 0.3, -13, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-9, 0.4, -14, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-10, 0.5, -15, -2, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-11, 0.0, -11, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-12, 0.0, -12, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-13, 0.0, -13, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-14, 0.0, -14, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-15, 0.0, -15, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-51, 0.0, -10, -3, false, false, false);

INSERT INTO public."InstructionalItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-111, -11, 1);
INSERT INTO public."Texts"(
	"Id", "Content")
	VALUES (-111, 'Imenovanje je proces određivanja i dodeljivanja imena identifikatoru. Identifikatore pronalazimo svuda u kodu. Tako imenujemo datoteke, direktorijume, klase, metode i promenljive. U Java programima imenujemo pakete i JAR datoteke, dok kod C# jezika imenujemo namespace i DLL datoteke. Dobro ime treba da **objasni svrhu elementa** koji imenujemo i da pokuša da odgovori na pitanja: Zašto dati element postoji? Šta radi? Kako se koristi?');
INSERT INTO public."InstructionalItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-112, -11, 2);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (-112, 'https://i.ibb.co/vqjMTyJ/simple-names-sr.png', 'U većini slučajeva kada hoćemo da stavimo komentar, pravo rešenje je smišljanje jasnijeg imena.');

INSERT INTO public."InstructionalItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-151, -15, 3);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (-151, 'https://i.ibb.co/Tw9qktR/domain-names-sr.png', 'Lakše ćemo razumeti nove zahteve kada koristimo u kodu isti jezik kao naši klijenti.');
INSERT INTO public."InstructionalItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-152, -15, 4);
INSERT INTO public."Images"(
	"Id", "Url", "Caption")
	VALUES (-152, 'https://i.ibb.co/f144vCk/names-example.png', 'Ovako objektno orijentisani programer imenuje stvari kada izbegava reči iz poslovnog domena.');

INSERT INTO public."AssessmentItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-153, -15, 1);
INSERT INTO public."MultiResponseQuestions"(
	"Id", "Text")
	VALUES (-153, 'Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za sama imena, gde objekti i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Označi imena funkcija koje smatraš da potiču iz domena poslovne logike:');
INSERT INTO public."MrqItems"(
	"Id", "Text", "IsCorrect", "Feedback", "MrqId")
	VALUES (-1531, 'string.join(":", patientRecord)', false, 'Ovo nije ime iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -153);
INSERT INTO public."MrqItems"(
	"Id", "Text", "IsCorrect", "Feedback", "MrqId")
	VALUES (-1532, 'Close(Account account)', true, 'Ovo ime je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -153);
INSERT INTO public."MrqItems"(
	"Id", "Text", "IsCorrect", "Feedback", "MrqId")
	VALUES (-1533, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovo ime ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je ime metode bilo samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -153);
INSERT INTO public."MrqItems"(
	"Id", "Text", "IsCorrect", "Feedback", "MrqId")
	VALUES (-1534, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj.', -153);
INSERT INTO public."MrqItems"(
	"Id", "Text", "IsCorrect", "Feedback", "MrqId")
	VALUES (-1535, 'RegisterMember(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. biblioteke). Naspram toga, operacija registracije korisnika aplikacije (npr. RegisterUser) bi podrazumevala tehnološku logiku koja bi mogla da uključi poslovnu ako bi se prilikom registracije formirao i član koji nije samo sistemski korisnik.', -153);

INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-155, -15, 2);
INSERT INTO public."MultiResponseQuestions"(
    "Id", "Text")
VALUES (-155, 'Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za sama imena, gde objekti i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Označi imena funkcija koje smatraš da potiču iz domena poslovne logike:');
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1551, 'string.join(":", patientRecord)', false, 'Ovo nije ime iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -155);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1552, 'Close(Account account)', true, 'Ovo ime je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -155);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1553, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovo ime ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je ime metode bilo samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -155);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1554, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj.', -155);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1555, 'RegisterMember(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. biblioteke). Naspram toga, operacija registracije korisnika aplikacije (npr. RegisterUser) bi podrazumevala tehnološku logiku koja bi mogla da uključi poslovnu ako bi se prilikom registracije formirao i član koji nije samo sistemski korisnik.', -155);

INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-156, -15, 3);
INSERT INTO public."MultiResponseQuestions"(
    "Id", "Text")
VALUES (-156, 'Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za sama imena, gde objekti i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Označi imena funkcija koje smatraš da potiču iz domena poslovne logike:');
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1561, 'string.join(":", patientRecord)', false, 'Ovo nije ime iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -156);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1562, 'Close(Account account)', true, 'Ovo ime je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -156);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1563, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovo ime ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je ime metode bilo samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -156);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1564, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj.', -156);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1565, 'RegisterMember(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. biblioteke). Naspram toga, operacija registracije korisnika aplikacije (npr. RegisterUser) bi podrazumevala tehnološku logiku koja bi mogla da uključi poslovnu ako bi se prilikom registracije formirao i član koji nije samo sistemski korisnik.', -156);

INSERT INTO public."AssessmentItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-154, -15, 4);
INSERT INTO public."Challenges"(
	"Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl")
	VALUES (-154, 'U svojoj brzopletosti, često nabacamo kratka imena kako bismo što pre ispisali kod koji radi. U sklopu direktorijuma "Naming/02. Meaningful Words" proširi kod korisnim imenima koji uklanjaju potrebe za komentarima i isprati zadatke u zaglavlju klase.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Meaning', 'https://youtu.be/8OYsu0dza0k');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId")
	VALUES (-1541, -154);

INSERT INTO public."ChallengeHints"(
    "Id", "Content")
VALUES (-1541, 'Razmisli kako da integrišeš domenski značajne reči poput "Enroll", "newCourse", "Maximum" i "Active" u imena koja koristiš u svom kodu.');
INSERT INTO public."RequiredWordsCheckers"(
    "Id", "RequiredWords", "HintId")
VALUES (-1541, '{{"Enroll","newCourse","Maximum","Active"}}', -1541);

INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-134, -13, 5);
INSERT INTO public."Challenges"(
    "Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl")
VALUES (-134, 'U svojoj brzopletosti, često nabacamo kratka imena kako bismo što pre ispisali kod koji radi. U sklopu direktorijuma "Naming/02. Meaningful Words" proširi kod korisnim imenima koji uklanjaju potrebe za komentarima i isprati zadatke u zaglavlju klase.', 'https://github.com/Clean-CaDET/challenge-repository', 'Naming.Meaning', 'https://youtu.be/8OYsu0dza0k');
INSERT INTO public."ChallengeFulfillmentStrategies"(
    "Id", "ChallengeId", "CodeSnippetId")
VALUES (-1341, -134, 'Naming.MeaningfulWords.Course');

INSERT INTO public."ChallengeHints"(
    "Id", "Content")
VALUES (-1341, 'Razmisli kako da integrišeš domenski značajne reči poput "Enroll", "newCourse", "Maximum" i "Active" u imena koja koristiš u svom kodu.');
INSERT INTO public."RequiredWordsCheckers"(
    "Id", "RequiredWords", "HintId")
VALUES (-1341, '{{"Enroll","newCourse","Maximum","Active"}}', -1341);

INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-143, -14, 6);
INSERT INTO public."MultiResponseQuestions"(
    "Id", "Text")
VALUES (-143, 'Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za sama imena, gde objekti i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Označi imena funkcija koje smatraš da potiču iz domena poslovne logike:');
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1431, 'string.join(":", patientRecord)', false, 'Ovo nije ime iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -143);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1432, 'Close(Account account)', true, 'Ovo ime je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -143);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1433, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovo ime ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je ime metode bilo samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -143);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1434, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj.', -143);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1435, 'RegisterMember(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. biblioteke). Naspram toga, operacija registracije korisnika aplikacije (npr. RegisterUser) bi podrazumevala tehnološku logiku koja bi mogla da uključi poslovnu ako bi se prilikom registracije formirao i član koji nije samo sistemski korisnik.', -143);

INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-144, -14, 7);
INSERT INTO public."MultiResponseQuestions"(
    "Id", "Text")
VALUES (-144, 'Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za sama imena, gde objekti i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Označi imena funkcija koje smatraš da potiču iz domena poslovne logike:');
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1441, 'string.join(":", patientRecord)', false, 'Ovo nije ime iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -144);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1442, 'Close(Account account)', true, 'Ovo ime je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -144);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1443, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovo ime ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je ime metode bilo samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -144);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1444, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj.', -144);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1445, 'RegisterMember(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. biblioteke). Naspram toga, operacija registracije korisnika aplikacije (npr. RegisterUser) bi podrazumevala tehnološku logiku koja bi mogla da uključi poslovnu ako bi se prilikom registracije formirao i član koji nije samo sistemski korisnik.', -144);

INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-106, -10, 8);
INSERT INTO public."MultiResponseQuestions"(
    "Id", "Text")
VALUES (-106, 'Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za sama imena, gde objekti i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Označi imena funkcija koje smatraš da potiču iz domena poslovne logike:');
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1061, 'string.join(":", patientRecord)', false, 'Ovo nije ime iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -106);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1062, 'Close(Account account)', true, 'Ovo ime je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -106);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1063, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovo ime ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je ime metode bilo samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -106);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1064, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj.', -106);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1065, 'RegisterMember(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. biblioteke). Naspram toga, operacija registracije korisnika aplikacije (npr. RegisterUser) bi podrazumevala tehnološku logiku koja bi mogla da uključi poslovnu ako bi se prilikom registracije formirao i član koji nije samo sistemski korisnik.', -106);

INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-107, -10, 9);
INSERT INTO public."MultiResponseQuestions"(
    "Id", "Text")
VALUES (-107, 'Kada dizajniramo softver, bitan cilj je da razdvojimo funkcionalnosti poslovne logike (npr. pravilo kako se stornira kupovina) od logike koja je vezana za tehnološke detalje (npr. kod za formiranje HTTP zahteva). Ovo pravilo važi i za sama imena, gde objekti i funkcije poslovne logike treba da sadrže samo reči koje potiču iz domena problema, odnosno od naših klijenata. Označi imena funkcija koje smatraš da potiču iz domena poslovne logike:');
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1071, 'string.join(":", patientRecord)', false, 'Ovo nije ime iz domena problema već funkcija za spajanje elementa niza u string - tehnološki detalj.', -107);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1072, 'Close(Account account)', true, 'Ovo ime je iz domena problema bankarskog poslovanja. Zatvaranje naloga je poslovna operacija koja se praktikovala i pre nego što su banke imale softver.', -107);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1073, 'SaveToFile(MedicalHistory patientCard)', false, 'Ovo ime ističe tehnološki detalj - datoteku kao način perzistencije podataka. Da je ime metode bilo samo "Save" mogli bismo ga svrstati u domen problema kao poslovnu želju da se trajno sačuva ova informacija. Međutim, poslovnu logiku ne zanima da li je to čuvanje u datoteci, bazi podataka ili na cloud-u.', -107);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1074, 'RefreshEmployeeRegistryView()', false, 'Po imenu možemo zaključiti da ova metoda osvežava neki prikaz (npr. tabele) što je tehnološki detalj.', -107);
INSERT INTO public."MrqItems"(
    "Id", "Text", "IsCorrect", "Feedback", "MrqId")
VALUES (-1075, 'RegisterMember(Member newMember)', true, 'Ovakva funkcija je deo poslovne logike oko registracije novog člana (npr. biblioteke). Naspram toga, operacija registracije korisnika aplikacije (npr. RegisterUser) bi podrazumevala tehnološku logiku koja bi mogla da uključi poslovnu ako bi se prilikom registracije formirao i član koji nije samo sistemski korisnik.', -107);

INSERT INTO public."Submissions"(
    "Id", "AssessmentItemId", "LearnerId", "IsCorrect", "TimeStamp", "Discriminator", "CorrectnessLevel")
VALUES (-1, -134, -2, false, '2021-12-19 21:25:50.379749+01', 'MrqSubmission', 0.75);

INSERT INTO public."Submissions"(
    "Id", "AssessmentItemId", "LearnerId", "IsCorrect", "TimeStamp", "Discriminator", "CorrectnessLevel")
VALUES (-2, -155, -2, false, '2021-12-19 21:26:50.379749+01', 'MrqSubmission', 0.75);

INSERT INTO public."Submissions"(
    "Id", "AssessmentItemId", "LearnerId", "IsCorrect", "TimeStamp", "Discriminator", "CorrectnessLevel")
VALUES (-3, -155, -2, false, '2021-12-19 21:27:50.379749+01', 'MrqSubmission', 0.3);

INSERT INTO public."Submissions"(
    "Id", "AssessmentItemId", "LearnerId", "IsCorrect", "TimeStamp", "Discriminator", "CorrectnessLevel")
VALUES (-4, -153, -2, false, '2021-12-19 21:28:50.379749+01', 'MrqSubmission', 0.6);

INSERT INTO public."Submissions"(
    "Id", "AssessmentItemId", "LearnerId", "IsCorrect", "TimeStamp", "Discriminator", "CorrectnessLevel")
VALUES (-5, -154, -2, false, '2021-12-19 21:29:50.379749+01', 'MrqSubmission', 0.7);

INSERT INTO public."Submissions"(
    "Id", "AssessmentItemId", "LearnerId", "IsCorrect", "TimeStamp", "Discriminator", "CorrectnessLevel")
VALUES (-6, -156, -2, false, '2021-12-19 21:30:50.379749+01', 'MrqSubmission', 0.4);

INSERT INTO public."Submissions"(
    "Id", "AssessmentItemId", "LearnerId", "IsCorrect", "TimeStamp", "Discriminator", "CorrectnessLevel")
VALUES (-7, -143, -2, false, '2021-12-19 21:25:50.379749+01', 'MrqSubmission', 1.0);

-- == Unit 2: Readable methods
INSERT INTO public."Units"(
	"Id", "Name", "Description")
	VALUES (-2, 'Čitljive funkcije', 'Čest savet je da naše funkcije treba da imaju mali broj linija koda. Ovako povećavamo fokusiranost i jasnoću funkcije, kao i mogućnost ponovne upotrebe ovog parčeta koda. Međutim, greška je reći da nam je cilj da imamo kratke funkcije. Nama je cilj da ispoštujemo više dobrih praksi za formiranje čistih funkcija, a kao posledicu primene tih praksi ćemo dobiti kratke funkcije. Kroz ovu lekciju analiziramo dobre i loše prakse za formiranje čistih funkcija.');
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-21, 'Segmentiraj dugačke metode', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-22, 'Redukuj kompleksnost funkcije', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-23, 'Reorganizuj logiku', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-24, 'Ekstrahuj složenu logiku', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-25, 'Imenuj složenu logiku', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-26, 'Redukuj broj parametra funkcije', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-27, 'Premesti metodu u prikladniji modul', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-28, 'Promoviši parametar u atribut', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-29, 'Enkapsuliraj skup usko povezanih parametara', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-210, 'Ekstrahuj pojedinačne zadatke iz metode', '', -2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "UnitId")
	VALUES (-211, 'Odredi semantičku svrhu metode', '', -2);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-16, 0.0, -21, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-17, 0.0, -22, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-18, 0.0, -23, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-19, 0.0, -24, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-20, 0.0, -25, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-21, 0.0, -26, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-22, 0.0, -27, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-23, 0.0, -28, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-24, 0.0, -29, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-25, 0.0, -210, -1, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-26, 0.0, -211, -1, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-27, 0.0, -21, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-28, 0.0, -22, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-29, 0.0, -23, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-30, 0.0, -24, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-31, 0.0, -25, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-32, 0.0, -26, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-33, 0.0, -27, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-34, 0.0, -28, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-35, 0.0, -29, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-36, 0.0, -210, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-37, 0.0, -211, -2, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-38, 0.0, -21, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-39, 0.0, -22, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-40, 0.0, -23, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-41, 0.0, -24, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-42, 0.0, -25, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-43, 0.0, -26, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-44, 0.0, -27, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-45, 0.0, -28, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-46, 0.0, -29, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-47, 0.0, -210, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-48, 0.0, -211, -3, false, false, false);

INSERT INTO public."AssessmentItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-2111, -211, 10);
INSERT INTO public."ArrangeTasks"(
	"Id", "Text")
	VALUES (-2111, 'Prateći kod predstavlja primer čiste funkcije.

    public List<Doctor> GetSuitableDoctors(Operation operation){{
    	List<Doctor> doctors = doctorRepository.FindAll();
    
    	List<Doctor> suitableDoctors = new ArrayList<>();
    	foreach(Doctor doctor in doctors){{
    		if(IsCapable(doctor, operation.GetRequiredCapabilities())
    		    && IsAvailable(doctor, operation.GetTimeSlot())){{
    			suitableDoctors.Add(doctor);
    		}}
    	}}
    
    	return suitableDoctors;
    }}

Rasporedi zahteve za izmenu softvera tako da su vezani za funkcije koje bismo verovatno menjali da bismo ih ispoštovali.');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (-1, -2111, 'Nijedna od navedenih');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (-1, -1, 'Dopuni format data transfer objekta da prikaže podatke novoj klijentskoj aplikaciji.');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (-2, -2111, 'FindAll');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (-2, -2, 'Potrebno je sačuvati podatke o lekarima u NoSQL bazi umesto u SQL bazi.');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (-3, -2111, 'GetSuitableDoctors');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (-3, -3, 'Od mogućih, uvek odabrati lekara koji ima najveći stepen uspeha za dati tip operacije, a prvog kada je nerešeno.');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (-4, -2111, 'IsCapable');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (-4, -4, 'Za izazovnu operaciju je potreban hirurg koji je bar jednom izveo dati tip operacije.');
INSERT INTO public."ArrangeTaskContainers"(
	"Id", "ArrangeTaskId", "Title")
	VALUES (-5, -2111, 'IsAvailable');
INSERT INTO public."ArrangeTaskElements"(
	"Id", "ArrangeTaskContainerId", "Text")
	VALUES (-5, -5, 'Uzima u obzir da li je lekar na bitnom sastanku u traženo vreme.');

INSERT INTO public."AssessmentItems"(
	"Id", "KnowledgeComponentId", "Order")
	VALUES (-211, -21, 11);
INSERT INTO public."Challenges"(
	"Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl")
	VALUES (-211, 'Da imamo kratke metode ne treba da bude naš konačan cilj, već posledica praćenja dobrih praksi. Ipak, funkcija koja prevazilazi nekoliko desetina linija je dobar kandidat za refaktorisanje. U sklopu direktorijuma "Methods/01. Small Methods" ekstrahuj logički povezan kod tako da završiš sa kolekcijom sitnijih metoda čije ime jasno označava njihovu svrhu.', 'https://github.com/Clean-CaDET/challenge-repository', 'Methods.Small', 'https://youtu.be/79a8Zp6FBfU');
INSERT INTO public."ChallengeHints"(
	"Id", "Content")
	VALUES (-1, 'Ispitaj da li možeš datu funkciju da pojednostaviš reorganizacijom logike ili ekstrakcijom smislenog podskupa koda u funkciju kojoj možeš dati jasno ime.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
	"Id", "ChallengeId", "CodeSnippetId")
	VALUES (-1, -211, 'Methods.Small.AchievementService');
INSERT INTO public."BasicMetricCheckers"(
	"Id", "MetricName", "FromValue", "ToValue", "HintId")
	VALUES (-1, 'MELOC', 1, 18, -1);

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-212, -21, 12);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-212, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji krše česte konvencije u pisanju programa.

    public List<string> GetCamelCaseWords(List<string> Words)
    {{
        List<string> camelCaseWords = new List<string>();
        foreach (string word in Words)
        {{
            var word_parts = Regex.Split(word, "[A-Z]");
            var matches = Regex.Matches(word, "[A-Z]");
            for (int idx = 0; idx < word_parts.Length - 1; idx++)
            {{
                word_parts[idx + 1] = matches[idx] + word_parts[idx + 1];
            }}
            camelCaseWords.AddRange(word_parts);
        }}

        return camelCaseWords;
    }}', '{{"Words, word_parts, idx, abc"}}');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-995, -21, 13);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-995, 'Posmatrajući sledeću strukturu paketa, navedi nazive klasa (razdvojene zarezom i bez .cs) koji krše konvenciju.

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
    - ScheduleController.cs', '{{"MedicalRecordService, PhysicianStorage"}}');