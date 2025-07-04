INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-1, -2, 1, 'Refleksija nad petljama');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-1, 1, 'Koliko je gradivo bilo jasno izlo�eno?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-2, 2, 'Koliko su pitanja bila jasno formulisana?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-3, 3, 'Koliko su zadaci bili zahtevni?', 2, 2, ARRAY['Ne mogu da krenem', 'Te�ki su', 'Taman', 'Laki su'], -1),
  (-4, 4, 'Koliki napredak vidi� kod sebe?', 1, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -1),
  (-5, 5, 'Da li treba negde posebno da obratimo pa�nju?', 0, 1, NULL, -1);


INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-2, -3, 1, 'Refleksija nad grananjem');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-11, 1, 'Koliko je gradivo bilo jasno izlo�eno?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-12, 2, 'Koliko su pitanja bila jasno formulisana?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-13, 3, 'Koliki napredak vidi� kod sebe?', 1, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -2);


INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-9999, -9999, 1, 'Refleksija za monitoring 1');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-9991, 1, 'Koliko je gradivo bilo jasno izlo�eno?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -9999),
  (-9992, 2, 'Koliko su pitanja bila jasno formulisana?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -9999);

INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-9998, -9998, 1, 'Refleksija za monitoring 2');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-9998, 1, 'Koliko je gradivo bilo jasno izlo�eno?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -9998);



INSERT INTO courses."ReflectionAnswers" ("Id", "LearnerId", "ReflectionId", "Created", "Answers")
VALUES 
(-1, -2, -9999, '2025-06-07T09:00:00+02:00', '[{{"QuestionId": -9991, "Answer": "Good"}}, {{"QuestionId": -9992, "Answer": "Yes"}}]'),
(-2, -3, -9999, '2025-06-06T14:30:00+02:00', '[{{"QuestionId": -9991, "Answer": "4"}}, {{"QuestionId": -9992, "Answer": "No comments"}}]'),
(-3, -2, -9998, '2025-06-05T18:45:00+02:00', '[{{"QuestionId": -9998, "Answer": "Agree"}}]');
