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
VALUES (-99992, -9999, -9998, '2023-10-20 21:29:50.379749+01', '2023-10-25 21:29:50.379749+01', 1);

INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99993, -9998, -9999, '2023-10-20 21:29:50.379749+01', '2023-10-23 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99994, -9998, -9998, '2023-10-20 21:29:50.379749+01', '2023-10-25 21:29:50.379749+01', 1);

INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99995, -9997, -9999, '2023-10-20 21:29:50.379749+01', '2023-10-23 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "BestBefore", "Status")
VALUES (-99996, -9997, -9998, '2023-10-20 21:29:50.379749+01', '2023-10-25 21:29:50.379749+01', 1);

-- Weekly feedback for testing CourseMonitoringController
INSERT INTO courses."WeeklyProgress"(
    "Id", "CourseId", "LearnerId", "InstructorId", "InstructorName", "WeekEnd", "Semaphore", "SemaphoreJustification", "Opinions", "AverageSatisfaction", "AchievedTaskPoints", "MaxTaskPoints")
VALUES (-9999, -9999, -9999, -9999, 'Test Instructor', '2023-10-22 23:59:59+01', 3, 'Good progress', NULL, 4.5, 85.0, 100.0);

INSERT INTO courses."WeeklyProgress"(
    "Id", "CourseId", "LearnerId", "InstructorId", "InstructorName", "WeekEnd", "Semaphore", "SemaphoreJustification", "Opinions", "AverageSatisfaction", "AchievedTaskPoints", "MaxTaskPoints")
VALUES (-9998, -9999, -9998, -9999, 'Test Instructor', '2023-10-22 23:59:59+01', 2, 'Needs improvement', NULL, 3.0, 60.0, 100.0);

INSERT INTO courses."WeeklyProgress"(
    "Id", "CourseId", "LearnerId", "InstructorId", "InstructorName", "WeekEnd", "Semaphore", "SemaphoreJustification", "Opinions", "AverageSatisfaction", "AchievedTaskPoints", "MaxTaskPoints")
VALUES (-9997, -9999, -9997, -9999, 'Test Instructor', '2023-10-22 23:59:59+01', 1, 'Struggling', NULL, 2.0, 30.0, 100.0);