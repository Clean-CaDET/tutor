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
