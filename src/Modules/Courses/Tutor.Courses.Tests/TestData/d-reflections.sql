INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-1, -2, 1, 'Refleksija nad petljama');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-1, 1, 'Koliko je gradivo bilo jasno izloženo?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-2, 2, 'Koliko su pitanja bila jasno formulisana?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -1),
  (-3, 3, 'Koliko su zadaci bili zahtevni?', 2, 2, ARRAY['Ne mogu da krenem', 'Teški su', 'Taman', 'Laki su'], -1),
  (-4, 4, 'Koliki napredak vidiš kod sebe?', 1, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -1),
  (-5, 5, 'Da li treba negde posebno da obratimo pažnju?', 0, 1, NULL, -1);


INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-2, -3, 1, 'Refleksija nad grananjem');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-11, 1, 'Koliko je gradivo bilo jasno izloženo?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-12, 2, 'Koliko su pitanja bila jasno formulisana?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -2),
  (-13, 3, 'Koliki napredak vidiš kod sebe?', 1, 2, ARRAY['Nikakav', 'Slab', 'Korektan', 'Jak'], -2);


INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-9999, -9999, 1, 'Refleksija za monitoring 1');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-9991, 1, 'Koliko je gradivo bilo jasno izloženo?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -9999),
  (-9992, 2, 'Koliko su pitanja bila jasno formulisana?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -9999);

INSERT INTO courses."Reflections" (
  "Id", "UnitId", "Order", "Name"
)
VALUES (-9998, -9998, 1, 'Refleksija za monitoring 2');

INSERT INTO courses."ReflectionQuestions" (
  "Id", "Order", "Text", "Category", "Type", "Labels", "ReflectionId"
)
VALUES
  (-9998, 1, 'Koliko je gradivo bilo jasno izloženo?', 2, 2, ARRAY['Nimalo', 'Slabo', 'Korektno', 'Veoma'], -9998);