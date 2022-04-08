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
    "Id", "ChallengeId")
VALUES (-1341, -134);
INSERT INTO public."ChallengeHints"(
    "Id", "Content")
VALUES (-1341, 'Razmisli kako da integrišeš domenski značajne reči poput "Enroll", "newCourse", "Maximum" i "Active" u imena koja koristiš u svom kodu.');
INSERT INTO public."RequiredWordsCheckers"(
    "Id", "RequiredWords", "HintId")
VALUES (-1341, '{{"Enroll","newCourse","Maximum","Active"}}', -1341);


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
    (-956, -21, 2);
INSERT INTO public."Challenges"("Id", "Description", "Url", "TestSuiteLocation", "SolutionUrl") VALUES
    (-956, 'Redukcija broja parametra pozitivno utiče na razumevanje zaglavlja funkcije i zadatka koji rešava. Pored toga, redukcijom liste parametra često smanjujemo broj zadataka koje funkcija radi. U sklopu direktorijuma "Methods/03. Parameter Lists" primeni strategije za redukciju parametra i refaktoriši funkcije.', 'https://github.com/Clean-CaDET/challenge-repository', 'Methods.Params', 'https://youtu.be/yKnxsH0CJzY');
INSERT INTO public."ChallengeHints"(
    "Id", "Content")
VALUES (-51, 'Funkcija ima previše parametra. Razmisli koja strategija za redukciju parametra najviše odgovara skupu parametra u datoj funkciji, pa je primeni.');
INSERT INTO public."ChallengeHints"(
    "Id", "Content")
VALUES (-52, 'Vredna strategija za redukciju parametra podrazumeva premeštanje metoda i polja klase tako da se ukloni potreba za parametrom. Razmisli da li ima smisla premestiti neku metodu iz ove klase u drugu.');
INSERT INTO public."ChallengeFulfillmentStrategies"(
    "Id", "ChallengeId", "CodeSnippetId")
VALUES (-51, -956, 'Methods.Params.CourseService');
INSERT INTO public."BasicMetricCheckers"(
    "Id", "MetricName", "FromValue", "ToValue", "HintId")
VALUES (-51, 'NOP', 0, 1, -51);
INSERT INTO public."ChallengeFulfillmentStrategies"(
    "Id", "ChallengeId", "CodeSnippetId")
VALUES (-52, -956, 'Methods.Params.Course');
INSERT INTO public."BasicMetricCheckers"(
    "Id", "MetricName", "FromValue", "ToValue", "HintId")
VALUES (-52, 'NOP', 0, 1, -51);
INSERT INTO public."ChallengeFulfillmentStrategies"(
    "Id", "ChallengeId")
VALUES (-53, -956);
INSERT INTO public."BasicMetricCheckers"(
    "Id", "MetricName", "FromValue", "ToValue", "HintId")
VALUES (-53, 'NMD', 0, 2, -52);