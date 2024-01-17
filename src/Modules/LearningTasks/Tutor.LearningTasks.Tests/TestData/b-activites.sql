INSERT INTO "learningTasks"."Activities"(
    "Id", "CourseId", "Name", "Guidance", "Examples", "Subactivities")
	VALUES (-1, -1, 'Activity1', '{{"Description":"description1"}}', '[{{"Code":"C1A1E1", "Description":"Description1"}}, {{"Code":"C1A1E2", "Description":"Description2"}}]', '[{{"Order":1, "ChildId":-3}}, {{"Order":2, "ChildId":-4}}]');
INSERT INTO "learningTasks"."Activities"(
    "Id", "CourseId", "Name", "Guidance", "Examples", "Subactivities")
	VALUES (-2, -1, 'Activity2', '{{"Description":"description2"}}', null, '[{{"Order":1, "ChildId":-5}}]');
INSERT INTO "learningTasks"."Activities"(
    "Id", "CourseId", "Name", "Guidance", "Examples", "Subactivities")
	VALUES (-3, -1, 'Activity3', '{{"Description":"description3"}}', null, null);
INSERT INTO "learningTasks"."Activities"(
    "Id", "CourseId", "Name", "Guidance", "Examples", "Subactivities")
	VALUES (-4, -1, 'Activity4', '{{"Description":"description4"}}', null, null);
INSERT INTO "learningTasks"."Activities"(
    "Id", "CourseId", "Name", "Guidance", "Examples", "Subactivities")
	VALUES (-5, -1, 'Activity5', '{{"Description":"description5"}}', null, null);
INSERT INTO "learningTasks"."Activities"(
    "Id", "CourseId", "Name", "Guidance", "Examples", "Subactivities")
	VALUES (-6, -1, 'Activity6', '{{"Description":"description6"}}', null, null);
INSERT INTO "learningTasks"."Activities"(
    "Id", "CourseId", "Name", "Guidance", "Examples", "Subactivities")
	VALUES (-7, -2, 'Activity7', '{{"Description":"description7"}}', null, null);