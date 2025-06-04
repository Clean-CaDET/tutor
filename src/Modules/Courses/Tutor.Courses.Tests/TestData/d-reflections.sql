INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-1, -2, 1, 'Refleksija nad petljama');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "CategoryId", "Type", "Labels", "ReflectionId"
)
VALUES
  (-1, 1, 'Koliko je gradivo bilo jasno izloženo?', NULL, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-2, 2, 'Koliko su pitanja bila jasno formulisana?', NULL, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-3, 3, 'Koliko su zadaci bili zahtevni?', NULL, 2, ARRAY['Ne mogu da krenem', 'Teški su', 'Taman', 'Laki su'], -1),
  (-4, 4, 'Koliki napredak vidiš kod sebe?', NULL, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -1),
  (-5, 5, 'Da li treba negde posebno da obratimo pažnju?', NULL, 1, NULL, -1);


INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-2, -3, 1, 'Refleksija nad grananjem');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "CategoryId", "Type", "Labels", "ReflectionId"
)
VALUES
  (-11, 1, 'Koliko je gradivo bilo jasno izloženo?', NULL, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-12, 2, 'Koliko su pitanja bila jasno formulisana?', NULL, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-13, 3, 'Koliki napredak vidiš kod sebe?', NULL, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -2);
