-- ConceptRecord -1: "Encapsulation" (Course -1)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-1, -1, 'Encapsulation', 'Encapsulation is the bundling of data and methods within a class, restricting direct access to internal state.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level", "Order")
VALUES (-11, -1, 'Data and methods are bundled in a class', 0, 1);
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level", "Order")
VALUES (-12, -1, 'Access modifiers control visibility of members', 1, 2);
INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level", "Order")
VALUES (-13, -1, 'Internal invariants are protected from external corruption', 2, 3);

INSERT INTO elaborations."BoundaryConditions"("Id", "ConceptRecordId", "Statement", "Level", "Order")
VALUES (-11, -1, 'Does not mean hiding all data', 0, 1);
INSERT INTO elaborations."BoundaryConditions"("Id", "ConceptRecordId", "Statement", "Level", "Order")
VALUES (-12, -1, 'Public interfaces are part of encapsulation', 1, 2);

INSERT INTO elaborations."CommonMisconceptions"("Id", "ConceptRecordId", "Description", "Correction", "Order")
VALUES (-11, -1, 'Encapsulation means making everything private', 'Encapsulation is about controlled access, not total hiding', 1);
INSERT INTO elaborations."CommonMisconceptions"("Id", "ConceptRecordId", "Description", "Correction", "Order")
VALUES (-12, -1, 'Getters and setters are always good encapsulation', 'Blind getters/setters can break encapsulation by exposing internals', 2);

-- ConceptRecord -2: "Inheritance" (Course -1, minimal)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-2, -1, 'Inheritance', 'Inheritance allows a class to derive behavior from another class.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level", "Order")
VALUES (-21, -2, 'Child class inherits parent behavior', 0, 1);

-- ConceptRecord -3: "Polymorphism" (Course -2, for non-owner tests)
INSERT INTO elaborations."ConceptRecords"("Id", "CourseId", "Title", "CanonicalDefinition")
VALUES (-3, -2, 'Polymorphism', 'Polymorphism enables objects to be treated as instances of their parent type.');

INSERT INTO elaborations."KeyPropositions"("Id", "ConceptRecordId", "Statement", "Level", "Order")
VALUES (-31, -3, 'Objects can take multiple forms', 0, 1);
