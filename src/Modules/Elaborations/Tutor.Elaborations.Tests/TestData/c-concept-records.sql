-- ConceptRecord -1: "Encapsulation" (Course -1)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-1, -1, 'Encapsulation', 'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-11, -1, 'Data and methods are bundled in a class', 0);
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-12, -1, 'Access modifiers control visibility of members', 1);
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-13, -1, 'Internal invariants are protected from external corruption', 2);

INSERT INTO elaborations."BoundaryConditions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-11, -1, 'Does not mean hiding all data', 0);
INSERT INTO elaborations."BoundaryConditions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-12, -1, 'Public interfaces are part of encapsulation', 1);

INSERT INTO elaborations."CommonMisconceptions"("Id", "ConceptRecordId", "Description", "Correction")
VALUES (-11, -1, 'Encapsulation means making everything private', 'Encapsulation is about controlled access, not total hiding');
INSERT INTO elaborations."CommonMisconceptions"("Id", "ConceptRecordId", "Description", "Correction")
VALUES (-12, -1, 'Getters and setters are always good encapsulation', 'Blind getters/setters can break encapsulation by exposing internals');

-- ConceptRecord -2: "Inheritance" (Course -1, minimal)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-2, -1, 'Inheritance', 'Inheritance allows a class to derive behavior from another class.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-21, -2, 'Child class inherits parent behavior', 0);

-- ConceptRecord -4: "Abstraction" (Course -1, no task references, for delete test)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-4, -1, 'Abstraction', 'Abstraction focuses on essential qualities rather than specific details.');

-- ConceptRecord -3: "Polymorphism" (Course -2, for non-owner tests)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-3, -2, 'Polymorphism', 'Polymorphism enables objects to be treated as instances of their parent type.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-31, -3, 'Objects can take multiple forms', 0);

-- ConceptRecord -5: "Polymorphism Mechanics" (Course -1, KPs + KR only — exercises relations and minimal-prompt path)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-5, -1, 'Polymorphism Mechanics', 'Polymorphism resolves method calls at runtime via dynamic dispatch.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-50, -5, 'A subclass can override a parent method', 0);
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level")
VALUES (-51, -5, 'The runtime selects the implementation by the actual type', 0);

INSERT INTO elaborations."KeyRelations"("Id", "ConceptRecordId", "SourceKeyPropositionId", "TargetKeyPropositionId", "Mechanism", "Level")
VALUES (-100, -5, -50, -51, 'Override matters because dispatch happens at runtime, not compile time', 0);
