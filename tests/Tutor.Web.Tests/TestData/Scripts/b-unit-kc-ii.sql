INSERT INTO public."Courses"(
    "Id", "Name", "IsArchived", "StartDate")
VALUES (-1, 'TestCourse', false, '9/11/2022 12:00:01 PM');

INSERT INTO public."Courses"(
    "Id", "Name", "IsArchived", "StartDate")
VALUES (-2, 'TestCourse', false, '9/11/2022 12:00:01 PM');

INSERT INTO public."KnowledgeUnits"(
	"Id", "Name", "Description", "CourseId", "Order")
	VALUES (-1, 'Značajna imena', 'Imena pronalazimo u svim segmentima razvoja softvera - kao identifikator promenljive, funkcije, klase, ali i biblioteke i aplikacije. Jasno ime funkcije nas oslobađa od čitanja njenog tela, dok će misteriozno ime zahtevati dodatan mentalni napor da razumemo svrhu koncepta koji opisuje. U najgorem slučaju, loše ime će nas navesti na pogrešan put i drastično nam produžiti vreme razvoja. Kroz ovu lekciju ispitujemo dobre i loše prakse za imenovanje elemenata našeg koda.'
	, -1, 1);

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-10, 'Dodeli značajna imena identifikatorima', '', -1, 'N00', 1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-11, 'Dodeli značajna imena identifikatorima', '', -1, 'N01', 2);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-12, 'Koristi ispravne tipove reči', '', -1, 'N02', 3);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-13, 'Prati timske konvencije', '', -1, 'N03', 4);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-14, 'Izbegavaj beznačajne reči', '', -1, 'N04', 5);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-15, 'Koristi terminologiju domena problema', '', -1, 'N05', 6);

INSERT INTO public."KnowledgeUnits"(
	"Id", "Name", "Description", "CourseId", "Order")
	VALUES (-2, 'Čitljive funkcije', 'Čest savet je da naše funkcije treba da imaju mali broj linija koda. Ovako povećavamo fokusiranost i jasnoću funkcije, kao i mogućnost ponovne upotrebe ovog parčeta koda. Međutim, greška je reći da nam je cilj da imamo kratke funkcije. Nama je cilj da ispoštujemo više dobrih praksi za formiranje čistih funkcija, a kao posledicu primene tih praksi ćemo dobiti kratke funkcije. Kroz ovu lekciju analiziramo dobre i loše prakse za formiranje čistih funkcija.'
	, -1, 2);

INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Order")
	VALUES (-21, 'Segmentiraj dugačke metode', '', -2, 1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Order")
	VALUES (-211, 'Odredi semantičku svrhu metode', '', -2, 2);

INSERT INTO public."KnowledgeUnits"(
    "Id", "Name", "Description", "CourseId", "Order")
VALUES (-3, 'Značajna imena', 'Imena pronalazimo u svim segmentima razvoja softvera - kao identifikator promenljive, funkcije, klase, ali i biblioteke i aplikacije. Jasno ime funkcije nas oslobađa od čitanja njenog tela, dok će misteriozno ime zahtevati dodatan mentalni napor da razumemo svrhu koncepta koji opisuje. U najgorem slučaju, loše ime će nas navesti na pogrešan put i drastično nam produžiti vreme razvoja. Kroz ovu lekciju ispitujemo dobre i loše prakse za imenovanje elemenata našeg koda.'
       , -2, 3);

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Order")
VALUES (-31, 'Segmentiraj dugačke metode', '', -3, 1);
INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Order")
VALUES (-311, 'Odredi semantičku svrhu metode', '', -3, 2);

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
VALUES (-151, -15, 4);
INSERT INTO public."Images"(
    "Id", "Url", "Caption")
VALUES (-151, 'https://i.ibb.co/Tw9qktR/domain-names-sr.png', 'Lakše ćemo razumeti nove zahteve kada koristimo u kodu isti jezik kao naši klijenti.');
INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-152, -15, 3);
INSERT INTO public."Images"(
    "Id", "Url", "Caption")
VALUES (-152, 'https://i.ibb.co/f144vCk/names-example.png', 'Ovako objektno orijentisani programer imenuje stvari kada izbegava reči iz poslovnog domena.');

INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-311, -31, 1);
INSERT INTO public."Texts"(
    "Id", "Content")
VALUES (-311, 'Imenovanje je proces određivanja i dodeljivanja imena identifikatoru. Identifikatore pronalazimo svuda u kodu. Tako imenujemo datoteke, direktorijume, klase, metode i promenljive. U Java programima imenujemo pakete i JAR datoteke, dok kod C# jezika imenujemo namespace i DLL datoteke. Dobro ime treba da **objasni svrhu elementa** koji imenujemo i da pokuša da odgovori na pitanja: Zašto dati element postoji? Šta radi? Kako se koristi?');