-- Braces in JSON literals are doubled ({{ }}) because the test harness
-- loads this SQL via ExecuteSqlRaw, which runs it through string.Format first.

-- CET -1: Encapsulation (Basics), Unit -1, Order 1 (owned by Instructor -51 via Course -1)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "Description")
VALUES (-1, -1, 1, 'Encapsulation (Basics)', 'Introduction to encapsulation and data hiding.');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition", "KeyPropositions")
VALUES (-1, -1,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class","misconception":{{"description":"Encapsulation means making everything private","correction":"Encapsulation is about controlled access, not total hiding"}}}}]'::jsonb);

-- CET -2: Encapsulation (Members), Unit -1, Order 2
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "Description")
VALUES (-2, -1, 2, 'Encapsulation (Members)', 'Encapsulation applied to class members and access modifiers.');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition", "KeyPropositions")
VALUES (-2, -2,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class","misconception":{{"description":"Encapsulation means making everything private","correction":"Encapsulation is about controlled access, not total hiding"}}}},{{"key":"P2","statement":"Access modifiers control visibility of members","misconception":{{"description":"Getters and setters are always good encapsulation","correction":"Blind getters/setters can break encapsulation by exposing internals"}}}}]'::jsonb);

-- CET -3: Encapsulation (Basics — Unit 2), Unit -2, Order 1 (owned by Instructor -51)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "Description")
VALUES (-3, -2, 1, 'Encapsulation (Basics — Unit 2)', 'Introduction to encapsulation and data hiding.');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition", "KeyPropositions")
VALUES (-3, -3,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}}]'::jsonb);

-- CET -4: Inheritance, Unit -3, Order 1 (owned ONLY by Instructor -52, NOT -51)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "Description")
VALUES (-4, -3, 1, 'Inheritance', 'Class inheritance and behavior reuse.');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition", "KeyPropositions")
VALUES (-4, -4,
    'Inheritance allows a class to derive behavior from another class.',
    '[{{"key":"P1","statement":"Child class inherits parent behavior"}}]'::jsonb);

-- CET -5: Encapsulation (Members — Unit 2), Unit -2, Order 2 (isolated for StartConversation tests)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "Description")
VALUES (-5, -2, 2, 'Encapsulation (Members — Unit 2)', 'Encapsulation applied to class members and access modifiers.');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition", "KeyPropositions")
VALUES (-5, -5,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}},{{"key":"P2","statement":"Access modifiers control visibility of members"}}]'::jsonb);

-- CET -6: Encapsulation (Invariants), Unit -2, Order 3 (isolated for Start+Submit flow test)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "Description")
VALUES (-6, -2, 3, 'Encapsulation (Invariants)', 'Protecting internal invariants through encapsulation.');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition", "KeyPropositions")
VALUES (-6, -6,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}},{{"key":"P2","statement":"Access modifiers control visibility of members"}},{{"key":"P3","statement":"Internal invariants are protected from external corruption"}}]'::jsonb);

-- CET -7: Polymorphism Mechanics, Unit -2, Order 4 (isolated for authoring update/remove/delete tests)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "Description")
VALUES (-7, -2, 4, 'Polymorphism Mechanics', 'Runtime method dispatch and virtual call mechanics.');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition", "KeyPropositions")
VALUES (-7, -7,
    'Polymorphism resolves method calls at runtime via dynamic dispatch.',
    '[{{"key":"P1","statement":"A subclass can override a parent method"}},{{"key":"P2","statement":"The runtime selects the implementation by the actual type"}}]'::jsonb);
