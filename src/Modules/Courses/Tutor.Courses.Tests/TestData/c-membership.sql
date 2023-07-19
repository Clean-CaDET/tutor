INSERT INTO courses."LearnerGroups"(
	"Id", "Name", "CourseId", "LearnerIds")
VALUES (-1, 'Test Group 1', -1, '-2, -3, -4, -5');
INSERT INTO courses."LearnerGroups"(
	"Id", "Name", "CourseId", "LearnerIds")
VALUES (-11, 'Test Group 2', -1, '-1');
INSERT INTO courses."LearnerGroups"(
	"Id", "Name", "CourseId", "LearnerIds")
VALUES (-12, 'Test Group 3', -1, '');
INSERT INTO courses."LearnerGroups"(
    "Id", "Name", "CourseId", "LearnerIds")
VALUES (-2, 'Test Group', -2, '-1, -2, -3, -4, -5');
INSERT INTO courses."LearnerGroups"(
    "Id", "Name", "CourseId", "LearnerIds")
VALUES (-3, 'Test Group', -2, '-1, -2, -3, -4, -5');
INSERT INTO courses."LearnerGroups"(
	"Id", "Name", "CourseId", "LearnerIds")
VALUES (-13, 'Archived Course Group 1', -5, '-1');

INSERT INTO courses."UnitEnrollments"(
	"Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
	VALUES (-1, -2, -1, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
	"Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
	VALUES (-2, -2, -2, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-3, -3, -1, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-4, -3, -2, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-5, -4, -1, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-6, -5, -1, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO courses."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-411, -4, -4, '2021-12-19 21:29:50.379749+01', 1);

INSERT INTO courses."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-1, -1, -51);
INSERT INTO courses."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-2, -1, -52);
INSERT INTO courses."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-3, -2, -52);
INSERT INTO courses."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-4, -4, -52);