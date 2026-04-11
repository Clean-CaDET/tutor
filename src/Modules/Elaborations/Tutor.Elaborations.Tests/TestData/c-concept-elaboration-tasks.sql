-- CET -1: Encapsulation (Basics), Unit -1, Order 1 (owned by Instructor -51 via Course -1)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "CanonicalDefinition")
VALUES (-1, -1, 1, 'Encapsulation (Basics)', 'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-10, -1, 'Data and methods are bundled in a class');

INSERT INTO elaborations."BoundaryConditions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-110, -1, 'Does not mean hiding all data');

INSERT INTO elaborations."CommonMisconceptions"("Id", "ConceptElaborationTaskId", "Description", "Correction")
VALUES (-210, -1, 'Encapsulation means making everything private', 'Encapsulation is about controlled access, not total hiding');

-- CET -2: Encapsulation (Members), Unit -1, Order 2
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "CanonicalDefinition")
VALUES (-2, -1, 2, 'Encapsulation (Members)', 'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-20, -2, 'Data and methods are bundled in a class');
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-21, -2, 'Access modifiers control visibility of members');

INSERT INTO elaborations."BoundaryConditions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-120, -2, 'Does not mean hiding all data');
INSERT INTO elaborations."BoundaryConditions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-121, -2, 'Public interfaces are part of encapsulation');

INSERT INTO elaborations."CommonMisconceptions"("Id", "ConceptElaborationTaskId", "Description", "Correction")
VALUES (-220, -2, 'Encapsulation means making everything private', 'Encapsulation is about controlled access, not total hiding');
INSERT INTO elaborations."CommonMisconceptions"("Id", "ConceptElaborationTaskId", "Description", "Correction")
VALUES (-221, -2, 'Getters and setters are always good encapsulation', 'Blind getters/setters can break encapsulation by exposing internals');

-- CET -3: Encapsulation (Basics — Unit 2), Unit -2, Order 1 (owned by Instructor -51)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "CanonicalDefinition")
VALUES (-3, -2, 1, 'Encapsulation (Basics — Unit 2)', 'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-30, -3, 'Data and methods are bundled in a class');

-- CET -4: Inheritance, Unit -3, Order 1 (owned ONLY by Instructor -52, NOT -51)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "CanonicalDefinition")
VALUES (-4, -3, 1, 'Inheritance', 'Inheritance allows a class to derive behavior from another class.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-40, -4, 'Child class inherits parent behavior');

-- CET -5: Encapsulation (Members — Unit 2), Unit -2, Order 2 (isolated for StartConversation tests)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "CanonicalDefinition")
VALUES (-5, -2, 2, 'Encapsulation (Members — Unit 2)', 'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-50, -5, 'Data and methods are bundled in a class');
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-51, -5, 'Access modifiers control visibility of members');

-- CET -6: Encapsulation (Invariants), Unit -2, Order 3 (isolated for Start+Submit flow test)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "CanonicalDefinition")
VALUES (-6, -2, 3, 'Encapsulation (Invariants)', 'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-60, -6, 'Data and methods are bundled in a class');
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-61, -6, 'Access modifiers control visibility of members');
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-62, -6, 'Internal invariants are protected from external corruption');

-- CET -7: Polymorphism Mechanics, Unit -2, Order 4 (isolated, has KeyRelation)
INSERT INTO elaborations."ConceptElaborationTasks"("Id", "UnitId", "Order", "Title", "CanonicalDefinition")
VALUES (-7, -2, 4, 'Polymorphism Mechanics', 'Polymorphism resolves method calls at runtime via dynamic dispatch.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-70, -7, 'A subclass can override a parent method');
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptElaborationTaskId", "Statement")
VALUES (-71, -7, 'The runtime selects the implementation by the actual type');

INSERT INTO elaborations."KeyRelations"("Id", "ConceptElaborationTaskId", "SourceKeyPropositionId", "TargetKeyPropositionId", "Mechanism")
VALUES (-370, -7, -70, -71, 'Override matters because dispatch happens at runtime, not compile time');
