-- Courses
INSERT INTO courses."Courses"("Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-1, 'T-1', 'TestCourse1', '', false, '2022-09-11 12:00:01');
INSERT INTO courses."Courses"("Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-2, 'T-2', 'TestCourse2', '', false, '2022-09-11 12:00:01');

-- Knowledge Units: -1, -2 in Course -1; -3 in Course -2
INSERT INTO courses."KnowledgeUnits"("Id", "Name", "Code", "Goals", "CourseId", "Order")
VALUES (-1, 'T-1', 'T-1', 'T-1', -1, 1);
INSERT INTO courses."KnowledgeUnits"("Id", "Name", "Code", "Goals", "CourseId", "Order")
VALUES (-2, 'T-2', 'T-2', 'T-2', -1, 2);
INSERT INTO courses."KnowledgeUnits"("Id", "Name", "Code", "Goals", "CourseId", "Order")
VALUES (-3, 'T-3', 'T-3', 'T-3', -2, 3);

-- Course Ownerships: Instructor -51 owns Course -1; Instructor -52 owns Courses -1 and -2
INSERT INTO courses."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES (-1, -1, -51);
INSERT INTO courses."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES (-2, -1, -52);
INSERT INTO courses."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES (-3, -2, -52);

-- Enrollments (BestBefore in future so they remain accessible)
INSERT INTO courses."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-1, -2, -1, '2021-12-19 21:29:50+01', '2027-12-25 21:29:50+01', 1);
INSERT INTO courses."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-2, -2, -2, '2021-12-19 21:29:50+01', '2027-12-25 21:29:50+01', 1);
INSERT INTO courses."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-3, -3, -1, '2021-12-19 21:29:50+01', '2027-12-25 21:29:50+01', 1);
INSERT INTO courses."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-4, -3, -2, '2021-12-19 21:29:50+01', '2027-12-25 21:29:50+01', 1);
INSERT INTO courses."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-5, -4, -1, '2021-12-19 21:29:50+01', '2027-12-25 21:29:50+01', 1);
INSERT INTO courses."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-7, -2, -3, '2021-12-19 21:29:50+01', '2027-12-25 21:29:50+01', 1);

-- Token Wallets (IDs -101+ to avoid collision with other modules)
INSERT INTO courses."WalletEvents"("Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (-101, 'Wallet', -101, '2024-01-01 10:00:00+00', -2, -1,
    '{{"$type":"WalletInitialized","InitialAllowance":2000000,"LearnerId":-2,"CourseId":-1,"TimeStamp":"2024-01-01T10:00:00Z"}}'::jsonb);
INSERT INTO courses."WalletEvents"("Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (-102, 'Wallet', -102, '2024-01-01 10:00:00+00', -3, -1,
    '{{"$type":"WalletInitialized","InitialAllowance":2500000,"LearnerId":-3,"CourseId":-1,"TimeStamp":"2024-01-01T10:00:00Z"}}'::jsonb);
INSERT INTO courses."WalletEvents"("Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (-103, 'Wallet', -103, '2024-01-01 10:00:00+00', -4, -1,
    '{{"$type":"WalletInitialized","InitialAllowance":100,"LearnerId":-4,"CourseId":-1,"TimeStamp":"2024-01-01T10:00:00Z"}}'::jsonb);
INSERT INTO courses."WalletEvents"("Id", "AggregateType", "AggregateId", "TimeStamp", "LearnerId", "CourseId", "DomainEvent")
VALUES (-104, 'Wallet', -103, '2024-01-02 10:00:00+00', -4, -1,
    '{{"$type":"TokensSpent","UnitId":-1,"PromptTokens":25,"CompletionTokens":25,"FeatureType":"Elaboration","EntityId":1,"PromptSummary":"Exhaust balance","LearnerId":-4,"CourseId":-1,"TimeStamp":"2024-01-02T10:00:00Z"}}'::jsonb);

INSERT INTO courses."TokenWallets"("Id", "LearnerId", "CourseId", "TotalAllowance", "TotalSpent")
VALUES (-101, -2, -1, 2000000, 150);
INSERT INTO courses."TokenWallets"("Id", "LearnerId", "CourseId", "TotalAllowance", "TotalSpent")
VALUES (-102, -3, -1, 2500000, 0);
INSERT INTO courses."TokenWallets"("Id", "LearnerId", "CourseId", "TotalAllowance", "TotalSpent")
VALUES (-103, -4, -1, 100, 100);
