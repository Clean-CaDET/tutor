INSERT INTO courses."Courses"(
    "Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-9999, 'T-9999', 'Monitoring Course', '', false, '2023-10-20 20:10:10.379749+01');

INSERT INTO courses."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-9999, -9999, -9999);
INSERT INTO courses."LearnerGroups"(
	"Id", "Name", "CourseId", "LearnerIds")
VALUES (-9999, 'Monitoring Group 1', -9999, '[-9999, -9998, -9997]');

INSERT INTO courses."KnowledgeUnits"(
	"Id", "Name", "Code", "Goals", "CourseId", "Order")
	VALUES (-9999, 'T-9999', 'T-9999', 'T-9999', -9999, 1);
INSERT INTO courses."KnowledgeUnits"(
	"Id", "Name", "Code", "Goals", "CourseId", "Order")
	VALUES (-9998, 'T-9998', 'T-9998', 'T-9998', -9999, 2);

INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99991, -9999, -9999, '2023-10-20 21:29:50.379749+01', '2023-10-23 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99992, -9999, -9998, '2023-10-20 21:29:50.379749+01', '2023-10-27 21:29:50.379749+01', 1);

INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99993, -9998, -9999, '2023-10-20 21:29:50.379749+01', '2023-10-23 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99994, -9998, -9998, '2023-10-20 21:29:50.379749+01', '2023-10-27 21:29:50.379749+01', 1);

INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99995, -9997, -9999, '2023-10-20 21:29:50.379749+01', '2023-10-23 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99996, -9997, -9998, '2023-10-20 21:29:50.379749+01', '2023-10-27 21:29:50.379749+01', 1);