-- Braces in JSON literals are doubled ({{ }}) because the test harness
-- loads this SQL via ExecuteSqlRaw, which runs it through string.Format first.

-- CET -1: Encapsulation (Basics), Unit -1, Order 1 (owned by Instructor -51 via Course -1)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title")
VALUES (-1, -1, 1, 'Encapsulation (Basics)');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition",
    "KeyPropositions", "BoundaryConditions", "CommonMisconceptions", "KeyRelations")
VALUES (-1, -1,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}}]'::jsonb,
    '[{{"key":"B1","statement":"Does not mean hiding all data"}}]'::jsonb,
    '[{{"key":"M1","description":"Encapsulation means making everything private","correction":"Encapsulation is about controlled access, not total hiding"}}]'::jsonb,
    '[]'::jsonb);

-- CET -2: Encapsulation (Members), Unit -1, Order 2
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title")
VALUES (-2, -1, 2, 'Encapsulation (Members)');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition",
    "KeyPropositions", "BoundaryConditions", "CommonMisconceptions", "KeyRelations")
VALUES (-2, -2,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}},{{"key":"P2","statement":"Access modifiers control visibility of members"}}]'::jsonb,
    '[{{"key":"B1","statement":"Does not mean hiding all data"}},{{"key":"B2","statement":"Public interfaces are part of encapsulation"}}]'::jsonb,
    '[{{"key":"M1","description":"Encapsulation means making everything private","correction":"Encapsulation is about controlled access, not total hiding"}},{{"key":"M2","description":"Getters and setters are always good encapsulation","correction":"Blind getters/setters can break encapsulation by exposing internals"}}]'::jsonb,
    '[]'::jsonb);

-- CET -3: Encapsulation (Basics — Unit 2), Unit -2, Order 1 (owned by Instructor -51)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title")
VALUES (-3, -2, 1, 'Encapsulation (Basics — Unit 2)');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition",
    "KeyPropositions", "BoundaryConditions", "CommonMisconceptions", "KeyRelations")
VALUES (-3, -3,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}}]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb);

-- CET -4: Inheritance, Unit -3, Order 1 (owned ONLY by Instructor -52, NOT -51)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title")
VALUES (-4, -3, 1, 'Inheritance');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition",
    "KeyPropositions", "BoundaryConditions", "CommonMisconceptions", "KeyRelations")
VALUES (-4, -4,
    'Inheritance allows a class to derive behavior from another class.',
    '[{{"key":"P1","statement":"Child class inherits parent behavior"}}]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb);

-- CET -5: Encapsulation (Members — Unit 2), Unit -2, Order 2 (isolated for StartConversation tests)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title")
VALUES (-5, -2, 2, 'Encapsulation (Members — Unit 2)');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition",
    "KeyPropositions", "BoundaryConditions", "CommonMisconceptions", "KeyRelations")
VALUES (-5, -5,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}},{{"key":"P2","statement":"Access modifiers control visibility of members"}}]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb);

-- CET -6: Encapsulation (Invariants), Unit -2, Order 3 (isolated for Start+Submit flow test)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title")
VALUES (-6, -2, 3, 'Encapsulation (Invariants)');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition",
    "KeyPropositions", "BoundaryConditions", "CommonMisconceptions", "KeyRelations")
VALUES (-6, -6,
    'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.',
    '[{{"key":"P1","statement":"Data and methods are bundled in a class"}},{{"key":"P2","statement":"Access modifiers control visibility of members"}},{{"key":"P3","statement":"Internal invariants are protected from external corruption"}}]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb);

-- CET -7: Polymorphism Mechanics, Unit -2, Order 4 (isolated, has KeyRelation)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title")
VALUES (-7, -2, 4, 'Polymorphism Mechanics');

INSERT INTO elaborations."ConceptRecords"(
    "Id", "ConceptElaborationTaskId", "CanonicalDefinition",
    "KeyPropositions", "BoundaryConditions", "CommonMisconceptions", "KeyRelations")
VALUES (-7, -7,
    'Polymorphism resolves method calls at runtime via dynamic dispatch.',
    '[{{"key":"P1","statement":"A subclass can override a parent method"}},{{"key":"P2","statement":"The runtime selects the implementation by the actual type"}}]'::jsonb,
    '[]'::jsonb,
    '[]'::jsonb,
    '[{{"key":"R1","sourceKey":"P1","targetKey":"P2","mechanism":"Override matters because dispatch happens at runtime, not compile time"}}]'::jsonb);
