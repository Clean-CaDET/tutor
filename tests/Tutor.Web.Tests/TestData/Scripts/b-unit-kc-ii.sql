INSERT INTO public."Courses"(
    "Id", "Code", "Name", "IsArchived", "StartDate")
VALUES (-1, 'T-1', 'TestCourse1', false, '9/11/2022 12:00:01 PM');

INSERT INTO public."Courses"(
    "Id", "Code", "Name", "IsArchived", "StartDate")
VALUES (-2, 'T-2', 'TestCourse2', false, '9/11/2022 12:00:01 PM');

INSERT INTO public."Courses"(
    "Id", "Code", "Name", "IsArchived", "StartDate")
VALUES (-3, 'T-3', 'EmptyCourse', false, '9/11/2022 12:00:01 PM');

INSERT INTO public."KnowledgeUnits"(
	"Id", "Name", "Description", "CourseId", "Order")
	VALUES (-1, 'T-1', 'T-1', -1, 1);

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-10, 'T-10', '', -1, 'N00', 1);
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
	VALUES (-2, 'T-2', 'T-2', -1, 2);

INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Order")
	VALUES (-21, 'Segmentiraj dugačke metode', '', -2, 1);
INSERT INTO public."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Order")
	VALUES (-211, 'Odredi semantičku svrhu metode', '', -2, 2);

INSERT INTO public."KnowledgeUnits"(
    "Id", "Name", "Description", "CourseId", "Order")
VALUES (-3, 'T-3', 'T-3', -2, 3);

INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Order")
VALUES (-31, 'Segmentiraj dugačke metode', '', -3, 1);
INSERT INTO public."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Order")
VALUES (-311, 'Odredi semantičku svrhu metode', '', -3, 2);

INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-101, -10, 1, 'Text', 'Test first text');
INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-102, -10, 2, 'Text', 'Test second text');
INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-103, -10, 3, 'Image', 'image_url', 'Test third image');
INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-111, -11, 1, 'Text', 'Imenovanje je proces određivanja i dodeljivanja imena identifikatoru. Identifikatore pronalazimo svuda u kodu. Tako imenujemo datoteke, direktorijume, klase, metode i promenljive. U Java programima imenujemo pakete i JAR datoteke, dok kod C# jezika imenujemo namespace i DLL datoteke. Dobro ime treba da **objasni svrhu elementa** koji imenujemo i da pokuša da odgovori na pitanja: Zašto dati element postoji? Šta radi? Kako se koristi?');
INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-112, -11, 2, 'Image', 'https://i.ibb.co/vqjMTyJ/simple-names-sr.png', 'U većini slučajeva kada hoćemo da stavimo komentar, pravo rešenje je smišljanje jasnijeg imena.');

INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-151, -15, 4, 'Image', 'https://i.ibb.co/Tw9qktR/domain-names-sr.png', 'Lakše ćemo razumeti nove zahteve kada koristimo u kodu isti jezik kao naši klijenti.');
INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-152, -15, 3, 'Image', 'https://i.ibb.co/f144vCk/names-example.png', 'Ovako objektno orijentisani programer imenuje stvari kada izbegava reči iz poslovnog domena.');

INSERT INTO public."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-311, -31, 1, 'Text', 'Imenovanje je proces određivanja i dodeljivanja imena identifikatoru. Identifikatore pronalazimo svuda u kodu. Tako imenujemo datoteke, direktorijume, klase, metode i promenljive. U Java programima imenujemo pakete i JAR datoteke, dok kod C# jezika imenujemo namespace i DLL datoteke. Dobro ime treba da **objasni svrhu elementa** koji imenujemo i da pokuša da odgovori na pitanja: Zašto dati element postoji? Šta radi? Kako se koristi?');

INSERT INTO public."KnowledgeUnits"(
    "Id", "Name", "Description", "CourseId", "Order")
VALUES (-4, 'T-4', 'T-4', -1, 3);