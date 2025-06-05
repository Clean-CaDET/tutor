INSERT INTO courses."ReflectionQuestionCategories"("Id", "Code", "Name") VALUES
(-1, 'clarity', 'Jasnoca'),
(-2, 'engagement', 'Ukljucenost'),
(-3, 'difficulty', 'Tezina'),
(-4, 'usefulness', 'Korisnost'),
(-5, 'satisfaction', 'Zadovoljstvo');

INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-1, -2, 1, 'Refleksija nad petljama');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "CategoryId", "Type", "Labels", "ReflectionId"
)
VALUES
  (-1, 1, 'Koliko je gradivo bilo jasno izloženo?', -1, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-2, 2, 'Koliko su pitanja bila jasno formulisana?', -1, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-3, 3, 'Koliko su zadaci bili zahtevni?', -3, 2, ARRAY['Ne mogu da krenem', 'Teški su', 'Taman', 'Laki su'], -1),
  (-4, 4, 'Koliki napredak vidiš kod sebe?', -5, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -1),
  (-5, 5, 'Da li treba negde posebno da obratimo pažnju?', -5, 1, NULL, -1);


INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-2, -3, 1, 'Refleksija nad grananjem');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "CategoryId", "Type", "Labels", "ReflectionId"
)
VALUES
  (-11, 1, 'Koliko je gradivo bilo jasno izloženo?', -1, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-12, 2, 'Koliko su pitanja bila jasno formulisana?', -1, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-13, 3, 'Koliki napredak vidiš kod sebe?', -5, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -2);
