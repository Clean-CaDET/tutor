﻿INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-1, 0, 1, 'U1-LT2-A1', 'Activity1', 'Guidance', '[{{"Code":"U1-LT2-A1-E1", "Url":"Url1"}}, {{"Code":"U1-LT2-A1-E2", "Url":"Url2"}}]', '{{"Type":0,"ValidationRule":"some validation", "Guidelines":""}}', 10, -2);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-2, 0, 2, 'U1-LT2-A2', 'Activity2', 'Guidance', '[{{"Code":"U1-LT2-A2-E1", "Url":"Url1"}}, {{"Code":"U1-LT2-A2-E2", "Url":"Url2"}}]', '{{"Type":1,"ValidationRule":"some validation", "Guidelines":""}}', 10, -2);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-3, 0, 1, 'U3-LT5-A1', 'Activity1', 'Guidance', '[{{"Code":"U3-LT5-A1-E1", "Url":"Url1"}}, {{"Code":"U3-LT5-A1-E2", "Url":"Url2"}}]', '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 5, -5);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-4, 0, 1, 'U2-LT4-A1', 'Activity1', 'Guidance', '[{{"Code":"U2-LT4-A1-E1", "Url":"Url1"}}, {{"Code":"U2-LT4-A1-E2", "Url":"Url2"}}]', '{{"Type":0,"ValidationRule":"some validation", "Guidelines":""}}', 10, -3);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-5, 0, 1, 'U2-LT5-A1', 'Activity1', 'Guidance', '[{{"Code":"U2-LT5-A1-E1", "Url":"Url1"}}, {{"Code":"U2-LT5-A1-E2", "Url":"Url2"}}]', '{{"Type":1,"ValidationRule":"some validation", "Guidelines":""}}', 10, -4);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-6, -3, 1, 'U3-LT5-A11', 'Activity11', 'Guidance', '[{{"Code":"U3-LT5-A11-E1", "Url":"Url1"}}, {{"Code":"U3-LT5-A11-E2", "Url":"Url2"}}]', '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 5, -5);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-7, 0, 1, 'U2-LT3-A1', 'Activity1', 'Guidance', '[{{"Code":"U2-LT3-A1-E1", "Url":"Url1"}}, {{"Code":"U2-LT3-A1-E2", "Url":"Url2"}}]', '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 5, -6);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-8, 0, 1, 'U2-LT4-A1', 'Activity1', 'Guidance', '[{{"Code":"U2-LT4-A1", "Url":"Url1"}}, {{"Code":"U2-LT4-A1", "Url":"Url2"}}]', '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 5, -7);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-9, 0, 1, 'U2-LT5-A1', 'Activity1', 'Guidance', '[{{"Code":"U2-LT5-A1", "Url":"Url1"}}, {{"Code":"U2-LT5-A1", "Url":"Url2"}}]', '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 5, -8);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-10, 0, 1, 'U1-LT3-A1', 'Activity1', 'Guidance', '[{{"Code":"U1-LT3-A1", "Url":"Url1"}}, {{"Code":"U1-LT3-A1", "Url":"Url2"}}]', '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 5, -9);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-11, 0, 1, 'U1-LT1-A1', 'Activity1', 'Guidance', null, '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 10, -1);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-12, -11, 1, 'U1-LT1-A11', 'Activity11', 'Guidance', null, '{{"Type":2,"ValidationRule":"some validation", "Guidelines":""}}', 0, -1);