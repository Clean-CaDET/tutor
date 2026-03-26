-- Task -1: Encapsulation at Beginner, Unit -1 (owned by Instructor -51). 1 KP in scope: -11
INSERT INTO elaborations."ElaborationTasks"("Id", "ConceptRecordId", "UnitId", "ExpectedLevel", "Order")
VALUES (-1, -1, -1, 0, 1);

-- Task -2: Encapsulation at Intermediate, Unit -1. 2 KPs in scope: -11, -12
INSERT INTO elaborations."ElaborationTasks"("Id", "ConceptRecordId", "UnitId", "ExpectedLevel", "Order")
VALUES (-2, -1, -1, 1, 2);

-- Task -3: Encapsulation at Beginner, Unit -2 (owned by Instructor -51)
INSERT INTO elaborations."ElaborationTasks"("Id", "ConceptRecordId", "UnitId", "ExpectedLevel", "Order")
VALUES (-3, -1, -2, 0, 1);

-- Task -4: Inheritance at Beginner, Unit -3 (owned ONLY by Instructor -52, NOT -51)
INSERT INTO elaborations."ElaborationTasks"("Id", "ConceptRecordId", "UnitId", "ExpectedLevel", "Order")
VALUES (-4, -2, -3, 0, 1);

-- Task -5: Encapsulation at Intermediate, Unit -2 (isolated for StartConversation tests)
INSERT INTO elaborations."ElaborationTasks"("Id", "ConceptRecordId", "UnitId", "ExpectedLevel", "Order")
VALUES (-5, -1, -2, 1, 2);

-- Task -6: Encapsulation at Advanced, Unit -2 (isolated for Start+Submit flow test)
INSERT INTO elaborations."ElaborationTasks"("Id", "ConceptRecordId", "UnitId", "ExpectedLevel", "Order")
VALUES (-6, -1, -2, 2, 3);
