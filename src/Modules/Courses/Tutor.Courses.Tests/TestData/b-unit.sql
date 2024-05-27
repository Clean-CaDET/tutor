INSERT INTO courses."Courses"(
    "Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-1, 'T-1', 'TestCourse1', '', false, '9/11/2022 12:00:01 PM');
INSERT INTO courses."Courses"(
    "Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-2, 'T-2', 'TestCourse2', '', false, '9/11/2022 12:00:01 PM');
INSERT INTO courses."Courses"(
    "Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-3, 'T-3', 'EmptyCourse', '', false, '9/11/2022 12:00:01 PM');
INSERT INTO courses."Courses"(
    "Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-4, 'T-4', 'EmptyCourseWithOwnership', '', false, '9/11/2022 12:00:01 PM');
INSERT INTO courses."Courses"(
    "Id", "Code", "Name", "Description", "IsArchived", "StartDate")
VALUES (-5, 'T-5', 'ArchivedCourse', '', true, '9/11/2022 12:00:01 PM');

INSERT INTO courses."KnowledgeUnits"(
	"Id", "Name", "Code", "Goals", "CourseId", "Order")
	VALUES (-1, 'T-1', 'T-1', 'T-1', -1, 1);
INSERT INTO courses."KnowledgeUnits"(
	"Id", "Name", "Code", "Goals", "CourseId", "Order")
	VALUES (-2, 'T-2', 'T-2', 'T-2', -1, 2);
INSERT INTO courses."KnowledgeUnits"(
    "Id", "Name", "Code", "Goals", "CourseId", "Order")
VALUES (-3, 'T-3', 'T-3', 'T-3', -2, 3);
INSERT INTO courses."KnowledgeUnits"(
    "Id", "Name", "Code", "Goals", "CourseId", "Order")
VALUES (-4, 'T-4', 'T-4', 'T-4', -1, 3);