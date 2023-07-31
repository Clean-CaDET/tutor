INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-10, 'T-10', '', -1, 'N00', 1);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-11, 'Dodeli značajna imena identifikatorima', '', -1, 'N01', 2);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-12, 'Koristi ispravne tipove reči', '', -1, 'N02', 3);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-13, 'Prati timske konvencije', '', -1, 'N03', 4);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-14, 'Izbegavaj beznačajne reči', '', -1, 'N04', 5);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-15, 'Koristi terminologiju domena problema', '', -1, 'N05', 6);

INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-21, 'Segmentiraj dugačke metode', '', -2, 'F01', 1);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
	"Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
	VALUES (-211, 'Odredi semantičku svrhu metode', '', -2, 'F02', 2);


INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
VALUES (-31, 'Segmentiraj dugačke metode', '', -3, 'F01', 1);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
VALUES (-311, 'Odredi semantičku svrhu metode', '', -3, 'F02', 2);

INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-101, -10, 1, 'Text', 'Test first text');
INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-102, -10, 2, 'Text', 'Test second text');
INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-103, -10, 3, 'Image', 'image_url', 'Test third image');
INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-111, -11, 1, 'Text', 'Imenovanje je proces određivanja i dodeljivanja imena identifikatoru. Identifikatore pronalazimo svuda u kodu. Tako imenujemo datoteke, direktorijume, klase, metode i promenljive. U Java programima imenujemo pakete i JAR datoteke, dok kod C# jezika imenujemo namespace i DLL datoteke. Dobro ime treba da **objasni svrhu elementa** koji imenujemo i da pokuša da odgovori na pitanja: Zašto dati element postoji? Šta radi? Kako se koristi?');
INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-112, -11, 2, 'Image', 'https://i.ibb.co/vqjMTyJ/simple-names-sr.png', 'U većini slučajeva kada hoćemo da stavimo komentar, pravo rešenje je smišljanje jasnijeg imena.');

INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-151, -15, 4, 'Image', 'https://i.ibb.co/Tw9qktR/domain-names-sr.png', 'Lakše ćemo razumeti nove zahteve kada koristimo u kodu isti jezik kao naši klijenti.');
INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Url", "Caption")
VALUES (-152, -15, 3, 'Image', 'https://i.ibb.co/f144vCk/names-example.png', 'Ovako objektno orijentisani programer imenuje stvari kada izbegava reči iz poslovnog domena.');

INSERT INTO "knowledgeComponents"."InstructionalItems"(
    "Id", "KnowledgeComponentId", "Order", "ItemType", "Content")
VALUES (-311, -31, 1, 'Text', 'Imenovanje je proces određivanja i dodeljivanja imena identifikatoru. Identifikatore pronalazimo svuda u kodu. Tako imenujemo datoteke, direktorijume, klase, metode i promenljive. U Java programima imenujemo pakete i JAR datoteke, dok kod C# jezika imenujemo namespace i DLL datoteke. Dobro ime treba da **objasni svrhu elementa** koji imenujemo i da pokuša da odgovori na pitanja: Zašto dati element postoji? Šta radi? Kako se koristi?');

INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order")
VALUES (-41, 'KC-4-4', '', -4, 'KC-4-4', 2);