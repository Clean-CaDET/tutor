DELETE FROM public."GroupMemberships";
DELETE FROM public."CourseOwnerships";
DELETE FROM public."Instructors";

DELETE FROM public."AssessmentItemMasteries";
DELETE FROM public."KcMasteries";
DELETE FROM public."UnitEnrollments";
DELETE FROM public."LearnerGroups";
DELETE FROM public."Learners";
DELETE FROM public."Events";

DELETE FROM public."Texts";
DELETE FROM public."Images";
DELETE FROM public."Videos";
DELETE FROM public."BasicMetricCheckers";
DELETE FROM public."BannedWordsCheckers";
DELETE FROM public."RequiredWordsCheckers";
DELETE FROM public."ChallengeHints";
DELETE FROM public."ChallengeFulfillmentStrategies";
DELETE FROM public."Challenges";
DELETE FROM public."MrqItems";
DELETE FROM public."MultiResponseQuestions";
DELETE FROM public."MultiChoiceQuestions";
DELETE FROM public."ArrangeTaskElements";
DELETE FROM public."ArrangeTaskContainers";
DELETE FROM public."ArrangeTasks";
DELETE FROM public."ShortAnswerQuestions";
DELETE FROM public."AssessmentItems";
DELETE FROM public."InstructionalItems";
DELETE FROM public."KnowledgeComponents";
DELETE FROM public."KnowledgeUnits";
DELETE FROM public."Courses";

DELETE FROM public."Users";
INSERT INTO public."Courses"("Id", "Code", "Name", "Description") VALUES
	(-100, 'RA-PSW', 'Projektovanje softvera', '');

INSERT INTO public."Courses"("Id", "Code", "Name", "Description") VALUES
	(-99, 'GEO-RP', 'Računarski praktikum', '');

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description", "CourseId") VALUES
	(-100, 'PSW01', 'PSW Unit 1', '', -100);

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description", "CourseId") VALUES
	(-99, 'PSW02', 'PSW Unit 2', '', -100);

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description", "CourseId") VALUES
	(-98, 'PSW03', 'PSW Unit 3', '', -100);

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description", "CourseId") VALUES
	(-97, 'PSW04', 'PSW Unit 4', '', -100);

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description", "CourseId") VALUES
	(-96, 'RP01', 'RP Unit 1', '', -99);

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description", "CourseId") VALUES
	(-95, 'RP02', 'RP Unit 2', '', -99);

INSERT INTO public."KnowledgeUnits"("Id", "Code", "Name", "Description", "CourseId") VALUES
	(-94, 'RP03', 'RP Unit 3', '', -99);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-100, 'PSW0101', 'PSW0101', '', 10, -100, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-99, 'PSW0201', 'PSW0201', '', 10, -99, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-98, 'PSW0202', 'PSW0202', '', 10, -99, -99);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-97, 'PSW0203', 'PSW0203', '', 10, -99, -99);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-96, 'PSW0301', 'PSW0301', '', 10, -98, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-95, 'PSW0302', 'PSW0302', '', 10, -98, -96);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-94, 'PSW0401', 'PSW0401', '', 10, -97, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-93, 'PSW0402', 'PSW0402', '', 10, -97, -94);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-92, 'RP0101', 'RP0101', '', 10, -96, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-91, 'RP0102', 'RP0102', '', 10, -96, -92);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-90, 'RP0201', 'RP0201', '', 10, -95, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-89, 'RP0202', 'RP0202', '', 10, -95, -90);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-88, 'RP0203', 'RP0203', '', 10, -95, -90);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-87, 'RP0301', 'RP0301', '', 10, -94, NULL);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-86, 'RP0302', 'RP0302', '', 10, -94, -87);

INSERT INTO public."KnowledgeComponents"("Id", "Code", "Name", "Description", "ExpectedDurationInMinutes", "KnowledgeUnitId", "ParentId") VALUES
	(-85, 'RP0303', 'RP0303', '', 10, -94, -86);

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-1000, -100, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-1000, 'PSW0101');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-999, -99, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-999, 'PSW0201');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-998, -98, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-998, 'PSW0202');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-997, -97, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-997, 'PSW0203');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-996, -96, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-996, 'PSW0301');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-995, -95, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-995, 'PSW0302');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-994, -94, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-994, 'PSW0401');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-993, -93, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-993, 'PSW0402');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-992, -92, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-992, 'RP0101');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-991, -91, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-991, 'RP0102');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-990, -90, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-990, 'RP0201');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-989, -89, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-989, 'RP0202');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-988, -88, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-988, 'RP0203');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-987, -87, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-987, 'RP0301');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-986, -86, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-986, 'RP0302');

INSERT INTO public."InstructionalItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-985, -85, 1);
INSERT INTO public."Texts"("Id", "Content") VALUES
	(-985, 'RP0303');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-1000, -100, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-1000, 'PSW0101');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-10000, 'Opcija 1', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -1000);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-10001, 'Opcija 2', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -1000);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-10002, 'Opcija 3', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -1000);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-10003, 'Opcija 4', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -1000);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-999, -99, 1);
INSERT INTO public."MultiChoiceQuestions"("Id", "Text", "PossibleAnswers", "CorrectAnswer", "Feedback") VALUES
	(-999, 'PSW0201', '{"Opcija 1","Opcija 2","Opcija 3","Opcija 4"}', 'Opcija 1', ' Ovo je feedback za kompletan zadatak.');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-998, -98, 1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-998, 'PSW0202');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9980, -998, 'Kategorija 1');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9981, -998, 'Kategorija 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99810,-9981, 'Prvi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99811,-9981, 'Drugi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9982, -998, 'Kategorija 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99820,-9982, 'Prvi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99821,-9982, 'Drugi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-997, -97, 1);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-997, 'PSW0203', '{"Svaka ćelija navodi prihatljiv odgovor", "Svaka ćelija navodi prihatljiv odgovor, Zarezom razdvajamo ako ima više elemenata"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-996, -96, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-996, 'PSW0301');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9960, 'Opcija 1', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -996);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9961, 'Opcija 2', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -996);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9962, 'Opcija 3', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -996);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9963, 'Opcija 4', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -996);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-995, -95, 1);
INSERT INTO public."MultiChoiceQuestions"("Id", "Text", "PossibleAnswers", "CorrectAnswer", "Feedback") VALUES
	(-995, 'PSW0302', '{"Opcija 1","Opcija 2","Opcija 3","Opcija 4"}', 'Opcija 1', ' Ovo je feedback za kompletan zadatak.');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-994, -94, 1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-994, 'PSW0401');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9940, -994, 'Kategorija 1');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9941, -994, 'Kategorija 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99410,-9941, 'Prvi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99411,-9941, 'Drugi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9942, -994, 'Kategorija 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99420,-9942, 'Prvi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99421,-9942, 'Drugi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-993, -93, 1);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-993, 'PSW0402', '{"Svaka ćelija navodi prihatljiv odgovor", "Svaka ćelija navodi prihatljiv odgovor, Zarezom razdvajamo ako ima više elemenata"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-992, -92, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-992, 'RP0101');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9920, 'Opcija 1', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -992);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9921, 'Opcija 2', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -992);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9922, 'Opcija 3', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -992);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9923, 'Opcija 4', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -992);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-991, -91, 1);
INSERT INTO public."MultiChoiceQuestions"("Id", "Text", "PossibleAnswers", "CorrectAnswer", "Feedback") VALUES
	(-991, 'RP0102', '{"Opcija 1","Opcija 2","Opcija 3","Opcija 4"}', 'Opcija 1', ' Ovo je feedback za kompletan zadatak.');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-990, -90, 1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-990, 'RP0201');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9900, -990, 'Kategorija 1');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9901, -990, 'Kategorija 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99010,-9901, 'Prvi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99011,-9901, 'Drugi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9902, -990, 'Kategorija 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99020,-9902, 'Prvi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-99021,-9902, 'Drugi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-989, -89, 1);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-989, 'RP0202', '{"Svaka ćelija navodi prihatljiv odgovor", "Svaka ćelija navodi prihatljiv odgovor, Zarezom razdvajamo ako ima više elemenata"}');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-988, -88, 1);
INSERT INTO public."MultiResponseQuestions"("Id", "Text") VALUES
	(-988, 'RP0203');
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9880, 'Opcija 1', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -988);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9881, 'Opcija 2', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -988);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9882, 'Opcija 3', true, 'Ovo je feedback za ovu izjavu, koja jeste ispravna.', -988);
INSERT INTO public."MrqItems"("Id", "Text", "IsCorrect", "Feedback", "MrqId") VALUES
	(-9883, 'Opcija 4', false, 'Ovo je feedback za ovu izjavu, koja nije ispravna.', -988);


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-987, -87, 1);
INSERT INTO public."MultiChoiceQuestions"("Id", "Text", "PossibleAnswers", "CorrectAnswer", "Feedback") VALUES
	(-987, 'RP0301', '{"Opcija 1","Opcija 2","Opcija 3","Opcija 4"}', 'Opcija 1', ' Ovo je feedback za kompletan zadatak.');

INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-986, -86, 1);
INSERT INTO public."ArrangeTasks"("Id", "Text") VALUES
	(-986, 'RP0302');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9860, -986, 'Kategorija 1');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9861, -986, 'Kategorija 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-98610,-9861, 'Prvi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-98611,-9861, 'Drugi element koji pripada kategoriji 2', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 2');
INSERT INTO public."ArrangeTaskContainers"("Id", "ArrangeTaskId", "Title") VALUES
	(-9862, -986, 'Kategorija 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-98620,-9862, 'Prvi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');
INSERT INTO public."ArrangeTaskElements"("Id", "ArrangeTaskContainerId", "Text", "Feedback") VALUES
	(-98621,-9862, 'Drugi element koji pripada kategoriji 3', 'Feedback koji objašnjava zašto ovaj element treba da bude u kategoriji 3');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
	(-985, -85, 1);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
	(-985, 'RP0303', '{"Svaka ćelija navodi prihatljiv odgovor", "Svaka ćelija navodi prihatljiv odgovor, Zarezom razdvajamo ako ima više elemenata"}');





INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-10000, 'RA-1-2021', 'NDxsNd4kbPnJE3+GzVRGgByfelK8zdJMB2PgX8ipgwg=', 'CmpquyxFlPIQl7drhEmlDw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-10000, -10000, 'RA-1-2021', 'Pera', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9999, 'RA-2-2021', 'Gwi8pxRD8q5FP7R/pzrGS7M9ozFaEKCBln1jaOQC56Q=', '0Ch0A3Q9BMSnrk3sHyvl+w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9999, -9999, 'RA-2-2021', 'Marko', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9998, 'RA-3-2021', 'VaPtEfz9JXyRcjWh0UT+i4B98DIhqm9Y+D2FKxg7Ecg=', 'tArTCkyQ99EfG4Wt6g4ZYw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9998, -9998, 'RA-3-2021', 'Mika', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9997, 'RA-4-2021', 'JO76/CO3oIiufi5zxQXtraKschuX8oDlM7k+q3pQy9I=', '+MlRIblxe+/7o782sQx7Ng==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9997, -9997, 'RA-4-2021', 'Stefan', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9996, 'RA-5-2021', 'qB5KIkrluFSQjQ8FAgwodi6c6mvO5kN+POCRI/7rYIM=', 'VUKPnYAQKvrYZ4hel5FHGw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9996, -9996, 'RA-5-2021', 'Franc', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9995, 'RA-6-2021', 'FztrYClHwpJuTnYY4/Gp6EKdkI653VscmkXCiMfasVs=', 'd5jU24mzjBfv5Z2vIoWIUQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9995, -9995, 'RA-6-2021', 'Ranc', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9994, 'RA-7-2021', 'mdwLCirc2ybCiYdhXrET4EXrI5xABmShbko43IV/OrQ=', 'oW/8th9l8zsCkMiGJkLLLw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9994, -9994, 'RA-7-2021', 'Kranc', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9993, 'RA-8-2021', 'YObqfi3BCMY4V/3TZvu8Wocwy2E3BQDuVMQLnQ1Q2ek=', 'rn7fuH4X3vfO9zQNWHYBsw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9993, -9993, 'RA-8-2021', 'Jelena', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9992, 'RA-1-2022', 'RJY1KJ0Yb5LO/lObiv008HMbLEXLeVDtHiUQlEk3zik=', 'jEGur3kLfoXlS3BDdTR2iw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9992, -9992, 'RA-1-2022', 'Milenko', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9991, 'RA-2-2022', 'd5jaAZXMShr2urQCtCEee2/wbv0cd1ycBUKWRvwZd70=', 'wttGsnFhyDH161eE3Gz6oQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9991, -9991, 'RA-2-2022', 'Nikola', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9990, 'RA-3-2022', 'EjxPPPJlLA4X0nvtI9qc99rkcKBVAKvpD00r2WDypoI=', 'FTekrilZ9u+G9t06KClHhA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9990, -9990, 'RA-3-2022', 'Pera', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9989, 'RA-4-2022', '+3St4HDbimTaXEC7RAeVcAIz1FsG06BXdWsPG3OqDI0=', 'c+4pbLqoNUcvVUkPn0A/dw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9989, -9989, 'RA-4-2022', 'Marko', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9988, 'RA-5-2022', 'Z/K0ycDW0H03v0PfoDoLuG7tCYD2oEP+algy9N7AIWo=', 'i1fbzKr1gC//1ofo57nT5Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9988, -9988, 'RA-5-2022', 'Mika', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9987, 'RA-6-2022', '4G4DANuLjX6hiOc0Ixt4fxW94V26JP2ELonukjmD7s8=', '+bbbNWhUmQV+lk6C3ITQOw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9987, -9987, 'RA-6-2022', 'Stefan', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9986, 'RA-7-2022', 'R6xfhdeVQZ5XtNSesyMWT7WX+fozsH7NneAlSNZYB2A=', 'mhKwgkx0d7il7bBK8VbK1w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9986, -9986, 'RA-7-2022', 'Franc', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9985, 'RA-8-2022', 'PIaSg2bEMnGw5QQ405t/D3oQX5jkSxIYRE5qMxrxYk8=', 'vKY6vQo274O5tQxg0+FiqQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9985, -9985, 'RA-8-2022', 'Ranc', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9984, 'RA-1-2023', 'riO/eda+lds2QiDWZQ8keL33lzbAoR9cw3HJjUWfjWI=', 'LdF2MkStYsOdsPGPb7Vqvg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9984, -9984, 'RA-1-2023', 'Kranc', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9983, 'RA-2-2023', 'st5JrIoGZWwaN+Jje+A7cgJiuaY2U2O7xCNrlQDywRk=', 'MJvpV/LbAd1awbdLK4S+Sg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9983, -9983, 'RA-2-2023', 'Jelena', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9982, 'RA-3-2023', 'OmIw3TxU1Zsqlz2PQhcf+Dn6fKeFRwI62LWgJxKVtKM=', '0t58dU7FYpv243M7qO4zDQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9982, -9982, 'RA-3-2023', 'Milenko', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9981, 'RA-4-2023', 'Hovm6YzM9DNBHgHBJNgXPcsnezs5vq2w/m8isZUqyHg=', 'IT5NW6FkMOECM46HpiXutA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9981, -9981, 'RA-4-2023', 'Nikola', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9980, 'RA-5-2023', 'IQQsBF4ZL0NuMBGXLHNprZAx3tX58rjmtDnLyz5rVW8=', 'g6xUmM3dFSPhAqho3qfnDg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9980, -9980, 'RA-5-2023', 'Pera', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9979, 'RA-6-2023', 'pYNYcc0qEtvCJK/Fy2vv6LFlV+10+oFewNZ80GUcbZU=', 'dUKgvFYXKyGfe8sKmgmV6g==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9979, -9979, 'RA-6-2023', 'Marko', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9978, 'RA-7-2023', 'wB2j2wlWmdikLgVZ8qd91zvdzIVPvfbXHqe/6iKc4G0=', '3sxjJYog+KJQ5lZBT0vizw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9978, -9978, 'RA-7-2023', 'Mika', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9977, 'RA-8-2023', 'Ua6esq6lZdMYDOi8BbLahDAuoUYrZrQ8h7XrTWW3GGU=', 'FpQcv8VnIoJLLGeK/V6zCg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9977, -9977, 'RA-8-2023', 'Stefan', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9976, 'RA-1-2024', 'Z5/JfwG+v4PdHGf4b68h58DcI13pLhMyugsNoaSdnk8=', 'N84KSBRgjhBYbe5AP9SCZg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9976, -9976, 'RA-1-2024', 'Franc', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9975, 'RA-2-2024', '8O3K0MZNy+25c64B/rLXUR1doFK9dQ00NJsASy/uQ/s=', 'CRfeA22CRk/de2bP9YCoiQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9975, -9975, 'RA-2-2024', 'Ranc', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9974, 'RA-3-2024', 'fv9lDnL8N4syEBrsWse1JYCIgCWRHgfZI48Uf7Pu3cw=', 'egE7HBvjARHzuCibnH3Dww==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9974, -9974, 'RA-3-2024', 'Kranc', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9973, 'RA-4-2024', 'curUAXgrmyAdwHkg9dc9QGEWCzGQo3XTAor505SwXgA=', 'Oy9gu64vLiNQ9tfzH7NusQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9973, -9973, 'RA-4-2024', 'Jelena', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9972, 'RA-5-2024', 'P3UpxMipzNkdADwZQRiZ+ul/QnE1Y/PuzA9OxeXx7do=', '16hMML4Nx31dv1cxBnP6vw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9972, -9972, 'RA-5-2024', 'Milenko', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9971, 'RA-6-2024', 'iAc70ynGxohp6bnSWEJ4I5GYZCS3ZTNEfxfRW61S7+g=', 'Ij8VgYOG7P7JGpLFpsCfiA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9971, -9971, 'RA-6-2024', 'Nikola', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9970, 'RA-7-2024', 'U92qO+gr2wxD+N08KxqdLXp7H5co6ifF4Of6Lgd02fo=', 'NlpE9cv9HGKeoHZ2+dPbtg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9970, -9970, 'RA-7-2024', 'Pera', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9969, 'RA-8-2024', '96j4o7wdxa6VfTXG71tiHrhVFuLX7acB86yu4uarQnc=', '5L/jXl42nApK8ytzC2G5Qw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9969, -9969, 'RA-8-2024', 'Marko', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9968, 'RA-1-2025', '05b3YnV605PpxPd0XnKlcf3zsd/ca3s7siF6mv7XdiY=', 'J6r+g5rNpHnV72gFC5yTkA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9968, -9968, 'RA-1-2025', 'Mika', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9967, 'RA-2-2025', 'EwK68JmGW/PBpA8GAwmomBLTV2Cx62If2OExI05eZmM=', 't1puE/Pw1DCk6A8b3QQQuw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9967, -9967, 'RA-2-2025', 'Stefan', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9966, 'RA-3-2025', 'baWIwNTOk7ZKDiRyCNo05IX1ngUEJ7DWdb/17YYkrbY=', 'UXgmBVzxtZxR3O9hJh4qZA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9966, -9966, 'RA-3-2025', 'Franc', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9965, 'RA-4-2025', 'KDoOx35/DyqsGGVYxHBMuKrHd+65OM/6Y3M7XVmzJqE=', '4rDZBHx5gqZQfBjlP3r2+w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9965, -9965, 'RA-4-2025', 'Ranc', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9964, 'RA-5-2025', 'd1QRVy2+n86EdvNiYEuMNi39LKI8JYtJLUa/Y2v1a0o=', 'R/Wf43bGDP5fmj2K7IHI0w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9964, -9964, 'RA-5-2025', 'Kranc', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9963, 'RA-6-2025', '2hjGOevKOnn6EV6jCerHWP41v7GsxDzs0Pj00yCQMEw=', 'WV97G7dqaAH3hHI0zcOpLg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9963, -9963, 'RA-6-2025', 'Jelena', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9962, 'RA-7-2025', 'Lod+puUrHoxQMR4Wu3EwogMPeCA340LJOK8SwwAKngs=', 'x9gLWG4QFbP/F1Daty3I8A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9962, -9962, 'RA-7-2025', 'Milenko', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9961, 'RA-8-2025', 'p6B8LiybZjtWVnXYtDugzoPNi1MODVG/KpM3E9E+X7k=', 'v4k2F4goQZn4Wq34lrG+Bg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9961, -9961, 'RA-8-2025', 'Nikola', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9960, 'RA-1-2026', 'K4xe1kWRyzcxfxJAybm/OjZ7HRFsTF3ws7IWqCPPNBc=', 'xzYuBTQN22o8g5NXRiT+Rg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9960, -9960, 'RA-1-2026', 'Pera', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9959, 'RA-2-2026', 'S0F+r1UZh2dwDnMJN6ldQ08geFee5zNYKF7ylwiFLdU=', 'yYeDXRe7vF+8HTIIBusNKw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9959, -9959, 'RA-2-2026', 'Marko', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9958, 'RA-3-2026', 'EF9JYIkT+6q7C/BRr3KH4gPAgHxFPgUokIhUJlNV2Qw=', 'hKDF6ChCKmK/ppFtZ7zJ8w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9958, -9958, 'RA-3-2026', 'Mika', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9957, 'RA-4-2026', 'YDYC2pS6yK7OslXq7Jn+v+rN9Dbwl/4mBOOPNLwUXps=', 'zXHBjfsv+Odds3v4iONByQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9957, -9957, 'RA-4-2026', 'Stefan', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9956, 'RA-5-2026', 'GHUGWMuCNaOb4mgRCYtmOYBcHh2ANMoIGHR0fcoCglk=', 'W5KxsCo1ZBMafg/lWgXNTA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9956, -9956, 'RA-5-2026', 'Franc', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9955, 'GE-1-2021', '4teMlzpGDuMeNZjmd/WHESonOinRVchUYSXVnRRaBpA=', 'QLqTQejHXnS2+toomtu+ng==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9955, -9955, 'GE-1-2021', 'Nikola', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9954, 'GE-2-2021', '/nIx+ZGZu4uYJ+qfs/Gjc6nxCPTO2U1ptIcmOBW+/1c=', 'B4dBeJxwabiSAIpT6ccd/g==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9954, -9954, 'GE-2-2021', 'Pera', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9953, 'GE-3-2021', 'B0Ii3z8QHqCCoqPeM0lWoSKDBzCYKnYnfTHJkBt6hEs=', 'O6ngiQV2FkuqIIpLA3Gc+Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9953, -9953, 'GE-3-2021', 'Marko', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9952, 'GE-4-2021', 'LbrQDO693w7PkBMPXcbZ/l4yuqaoBvp9iuYN+7pHZL4=', 'gex+eBu35YDRky2EOtoDNg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9952, -9952, 'GE-4-2021', 'Mika', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9951, 'GE-5-2021', '/sSa35eDCY8E7YYCFQ2qlVmXLcwRZKTEzgqPfgbZK/k=', 'udfL4tQWtwUciT2XFzIGEw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9951, -9951, 'GE-5-2021', 'Stefan', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9950, 'GE-6-2021', 'KwK0vy/rNsCU/ik9Z9eYQG3iBVAk60fKydKu2mc89+k=', '7FrFYwZDK5OwFtuyyPSb/A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9950, -9950, 'GE-6-2021', 'Franc', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9949, 'GE-7-2021', 'vl/fu9Ev7d0UecLSdbLad6Abmi+/DFZtUwHndNj4KTQ=', 'xmxTosQq225WlcUhu4LzsQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9949, -9949, 'GE-7-2021', 'Ranc', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9948, 'GE-8-2021', 'CO4VWvxr00MabYW6U9Vo1tFB6kWWnqJTeF96Xc0Ds0I=', 'Mkw+QHNxwWgoMJ0AhnppWg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9948, -9948, 'GE-8-2021', 'Kranc', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9947, 'GE-9-2021', 'jwy9AaVnOdjF99iXRrHMaBBZeIlhTHWciqxMz5tyT7c=', 'JusOuiWG6J4IXb5IbYLquw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9947, -9947, 'GE-9-2021', 'Jelena', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9946, 'GE-10-2021', 'rbcBqwaWFUTyUOp/eU3IORdBBS+wfLWh0DKrTcIposo=', 'geChSF59eXvWVwRXwFrQyg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9946, -9946, 'GE-10-2021', 'Milenko', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9945, 'GE-11-2021', '1WNdEBTjZkLJsYcevbtSm9h74BdbcBibjQJSRSxcCXU=', 'IqTwbdkAsL98ZfVL03paCw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9945, -9945, 'GE-11-2021', 'Nikola', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9944, 'GE-12-2021', 'RumBGY1BQkPvkliMJ9pM03OiPFKCpUeUOAZuiniXVWE=', 'i+jFHPj/JYQQ13vRLk/RIg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9944, -9944, 'GE-12-2021', 'Pera', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9943, 'GE-13-2021', 'nE4niF+mYuwOp1U4Worej8uz7PH5vPlv8UNxAzItIvM=', 'C8Mx2kcEV8GnwwVazPPyeg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9943, -9943, 'GE-13-2021', 'Marko', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9942, 'GE-14-2021', 'igH16duSBDivo7cGO0bhBdYwDvMYo3fFqAJX/K9t7DY=', 'LCItG8mF3yXZyaSHJ1KFhg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9942, -9942, 'GE-14-2021', 'Mika', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9941, 'GE-15-2021', 'KIOMU1ZEsXYZci6XY1w4XVFf44UUIiqJaQ9uxHoNjJo=', 'oWauEvO0bhBd545n2kvhOw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9941, -9941, 'GE-15-2021', 'Stefan', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9940, 'GE-16-2021', 'amKQTsuiA2QYKI0spHizPximB3TUfFdvx0PXRP2r3vo=', 'GiuqZNngZRJtZbi/hTOVGw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9940, -9940, 'GE-16-2021', 'Franc', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9939, 'GE-17-2021', '+hM2tc8Jnd2Jsnkx+VtoTQTjlWRc95kdWMhOz+v6fmc=', 'CBICgRc/KnCPfuuACWYYnA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9939, -9939, 'GE-17-2021', 'Ranc', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9938, 'GE-18-2021', 'A+nCTWazLUhE3hE872OaWYOXxapmFBvcXZzKrj+hV6k=', '0TlfakqDtWb8e2SQi9ZFGQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9938, -9938, 'GE-18-2021', 'Kranc', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9937, 'GE-19-2021', 'w9+aHEgYYH7nsUed32JT2Eg8b4/GxA+JmNzwlUm94lI=', 'd3e3q+v7B96Vzr8hHu7mSg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9937, -9937, 'GE-19-2021', 'Jelena', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9936, 'GE-20-2021', 'SK6w1Z+r69H6qbuwKJVLNbzMELNSe1gtx1t2HddcxYA=', 'gUsVkIKX/Rp7JMk2x1/+Uw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9936, -9936, 'GE-20-2021', 'Milenko', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9935, 'GE-21-2021', '8Ah1KAAWHHM5xMZMB1owNj6QoTkau5QmKWq0lM4XOpg=', '+nOpCd4o8N2B6qMZ5q/smA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9935, -9935, 'GE-21-2021', 'Nikola', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9934, 'GE-22-2021', 'Q9bArBmmZFQRF0tDZdAkJMbcfQF9Xt1Fc6ozH0FxqwE=', 'Q+wVGidm8Fk3HT55+3JEaA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9934, -9934, 'GE-22-2021', 'Pera', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9933, 'GE-23-2021', 'AsxDQ+krECGgXlL+VFsYY+9pEDLJe75Pu1q3t3iwSZs=', 'ApJwZ1NMynePOvSn23OEeA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9933, -9933, 'GE-23-2021', 'Marko', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9932, 'GE-24-2021', 'aYpp2BIR+j+VU5nNjy/Z7MmvDdvB+dKFBXYRex1itR0=', 'ER5tjR5KQ3fpXkwZ7CJfuw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9932, -9932, 'GE-24-2021', 'Mika', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9931, 'GE-25-2021', 'mBuxmQwT8Oflx9HjLD3E0HxET8fAzYlLtQq9qjpZ8r0=', 'PH7f7ecxAACG7SmbBI2JOw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9931, -9931, 'GE-25-2021', 'Stefan', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9930, 'GE-26-2021', 'q1PVIxJWoEgN7J1ZzOsl1dQvuF2nwoepMD7aEaHnf5I=', 'ZmjPmRUMuORbQYwyC8MF8w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9930, -9930, 'GE-26-2021', 'Franc', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9929, 'GE-27-2021', 'fgQsnXrWMB4kbcCP/KROuRTjm4MyHQKBjCiW/bsIbXY=', 'NFLEQHNcalOqKUHuqEUz8Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9929, -9929, 'GE-27-2021', 'Ranc', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9928, 'GE-28-2021', 'fxQ1GPj507Q0DbgY11dIsuaVHv85hnM+QRqfQCeK3HY=', '+twClnJ+T+NPSOnHY0+k6Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9928, -9928, 'GE-28-2021', 'Kranc', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9927, 'GE-29-2021', '++Qp+NZBDTknR+de2mt0DpXVUsY5QXUtqwmkNSXbyB8=', 'Su02wUDnBjyhCXSD2mrV+Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9927, -9927, 'GE-29-2021', 'Jelena', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9926, 'GE-30-2021', 'eaay8+7zWSA/j0X7EdHWtN41IOgJ+l7ccQRyIFRWOmA=', 'X+DMA1TRSut71HU7fG/+5Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9926, -9926, 'GE-30-2021', 'Milenko', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9925, 'GE-31-2021', 'Ncsm+370uadGrLtai76Bxf6Bx4zncCBPYXnE5vXTwnM=', 'fh7ktv8elICSsvhXfqEDrg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9925, -9925, 'GE-31-2021', 'Nikola', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9924, 'GE-32-2021', 'RvKR2atfs1QCWsW3ll1XZMB227TSUswE4zvv+kF9t/o=', '5eeISlqakfb2MQknmqcwyA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9924, -9924, 'GE-32-2021', 'Pera', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9923, 'GE-33-2021', 'd3JxtCb4g70i1+cuoOVhK/VgYQbuGaR/z2tu/kUsvC4=', 'mcblMN7/4QDaFT/ToJuxvw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9923, -9923, 'GE-33-2021', 'Marko', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9922, 'GE-34-2021', 'FTuROix9WauR42yVAwVe/96jSnkddtVmRqoyuF6NDm4=', 'Z106+ROp098gzOCSEnltvA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9922, -9922, 'GE-34-2021', 'Mika', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9921, 'GE-35-2021', 'C+uu3tKqjxxi82kpyXTrOhJP2CYJQvTtvdpkizO1xTA=', 'XtF5mkaatBr97JUqAtTpwA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9921, -9921, 'GE-35-2021', 'Stefan', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9920, 'GE-36-2021', 'urhYqhEB43z/TIUOQHQ191jKOAvREVDfJ5xe1+REvX4=', 'N7jnUG+nTk1w/YGtdqO1mA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9920, -9920, 'GE-36-2021', 'Franc', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9919, 'GE-37-2021', 'om4YC+W0AAGkOiqI8dd6MgoR7s2p25hWVkgmAlnKa/g=', 'e4sL98V1I+SyLqjGCZxGDw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9919, -9919, 'GE-37-2021', 'Ranc', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9918, 'GE-38-2021', 'ep1plOEJmAVbepwlgk/GGuBshZHEQ2Y9epRDxleThcI=', 'O5N9Lfx002yQLnLySp0bZQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9918, -9918, 'GE-38-2021', 'Kranc', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9917, 'GE-39-2021', 'Jy8YgO0wBCQwRy1BEsE3lWGUH1+is1fJXzWBU6vV7Yg=', 'jCdxGHnCu9i196AL/3fXYg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9917, -9917, 'GE-39-2021', 'Jelena', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9916, 'GE-40-2021', 'l6WuyL7r/GvaSwN7t6E5N0E197fgcUwN/IUAGYbh1xE=', 'FfrsOgE9wQrjO/y5CZTSIQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9916, -9916, 'GE-40-2021', 'Milenko', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9915, 'GE-41-2021', 'G4Jc3z2lT0OjepaisebpsEyxfHG5nzAfL/fqDFneY9Q=', '5i87RUB7mloBC4RNsAOT3A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9915, -9915, 'GE-41-2021', 'Nikola', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9914, 'GE-42-2021', '/CgzvFPosQ1UYBNNdVHLddZ72MkOx9RpybodlcmboD8=', 'EX6C3LTjZXRoEZ/axMs5Bg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9914, -9914, 'GE-42-2021', 'Pera', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9913, 'GE-43-2021', '+FKUhExBrE25QIb/8MUaHVoNfhaOB/HMS5SZv9MBnkQ=', 'ZU0c1MaZx0Rd37ZNqJ0LSQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9913, -9913, 'GE-43-2021', 'Marko', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9912, 'GE-44-2021', 'SQlpeDs/bfyn3OhLPeEHmagwC6s10RnvJcFjNeYuBqQ=', 'CVNWFLCMr5UU67LVEcdGnA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9912, -9912, 'GE-44-2021', 'Mika', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9911, 'GE-45-2021', 'RkzkjxuzRK3oRfrdWz8eZwDeCijkgbj14q2ko1KwjdE=', 'jtdSKjYq2uHyBcFFjcSB3g==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9911, -9911, 'GE-45-2021', 'Stefan', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9910, 'GE-46-2021', 'VwWj51txv6jhTboeQbF0uoFjnRiazA9nYDskUZ6+mPE=', '9SV59gAHBt0a6zex4Og5KQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9910, -9910, 'GE-46-2021', 'Franc', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9909, 'GE-47-2021', '2FAnFtgl7ysVzjR51JtlnHZhPSsTxgMS+o+0t4Kka+s=', 'CpUGJeETQURDzUVilpLFzw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9909, -9909, 'GE-47-2021', 'Ranc', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9908, 'GE-48-2021', 'fqC56A9hW/9TT+ANnCRR9XfEzdtsCPjfyjOK0MJTemU=', 'MQve9+WzijCbfHY0vUvwmw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9908, -9908, 'GE-48-2021', 'Kranc', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9907, 'GE-49-2021', 'MmwVzbFWalDZpwuNYOu0ETUiAJFfZ0N3bYv36VFMscs=', 'BwcojlaTHBIEZ1nCBR3thA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9907, -9907, 'GE-49-2021', 'Jelena', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9906, 'GE-50-2021', 'O9/EnGp0GU1nO5TF2bN5t8hLdlQT8e2FKDcTSk+rzP4=', 'w0LJVcK+IDPk6PEmrDJRQw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9906, -9906, 'GE-50-2021', 'Milenko', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9905, 'GE-51-2021', 'mlcqoURe2o7aujkRVDie8B2XcbEZ0z08sXVhg1oOf64=', 'xNtRdhPRtBj23dOjMkkMYA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9905, -9905, 'GE-51-2021', 'Sladislav', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9904, 'GE-52-2021', '7LkYXgFry2RMkdbMQoryH9VOUjmBsNr/FPWW0MX6IUQ=', 'mWrxlqmYfrmCinuN3gCcvw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9904, -9904, 'GE-52-2021', 'Vladislav', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9903, 'GE-53-2021', 'zyEndzGZU4MtmFZwY0TLqCdiprDKVVRkfotkmjShdT4=', 'ITkCZj/BXZseq6WPwZ2xGQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9903, -9903, 'GE-53-2021', 'Kranc', 'Lalić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9902, 'GE-54-2021', 'JmrJK4khrM28yu+4AidVGL/7A41rwDrRXIV+isyATTw=', 'pQ6RktJb2sEtmURmBDrdEw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9902, -9902, 'GE-54-2021', 'Marko', 'Lekić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9901, 'GE-58-2021', 'lrbzY1QQ5yzIPg/Omg/GfTdL1eMiwyNrF09qSJ3WApI=', 'wDlCQmIzwRGWEHsnywas1A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9901, -9901, 'GE-58-2021', 'Nikola', 'Kekić');



INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-30000, 'nikola.luburic', 'YI0f1j/50KzGQFMTdo5UONPEqYu3GBqlyZ3Gfkf4uBQ=', 'xEbT20CjFh6Jdl9pMi0APg==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-30000, -30000, 'Nikola', 'Luburić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-29999, 'natasa.rajtarov', '1cMTWbCuXFREBsl74LCDW8eZnWZdA0pdc7LO4me8QYA=', '/Vz2FVX4Fcwur+BuSGTrCQ==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-29999, -29999, 'Nataša', 'Rajtarov');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-29998, 'luka.doric', 'mujHug3IwVIJ3QlNKuvXYwzSHzfvWjF7v0YjRTWpSAU=', 'imglNow85dSoD34A1C1rlg==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-29998, -29998, 'Luka', 'Dorić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-29997, 'simona.prokic', 'PZg0eJzIB7MOcnmoRYZ9YB06TcqC104YRP2YbZWjGvs=', 'ugCCWkOIkGBGCGP5M15fEg==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-29997, -29997, 'Simona', 'Prokić');



INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-10000, 'RA-PSW 1', -100);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9999, 'RA-PSW 2', -100);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9998, 'RA-PSW 3', -100);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9997, 'RA-PSW All', -100);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9996, 'GEO-RP 1', -99);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9995, 'GEO-RP 2', -99);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9994, 'GEO-RP 3', -99);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9993, 'GEO-RP 4', -99);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9992, 'GEO-RP All', -99);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9999, -10000, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9998, -10000, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9997, -10000, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9996, -10000, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9995, -10000, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9994, -10000, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9993, -10000, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9999, 0.00, -100, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-100000, -1000, 0.00, 0, NULL, -9999);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9998, 0.00, -99, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99999, -999, 0.00, 0, NULL, -9998);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9997, 0.00, -98, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99998, -998, 0.00, 0, NULL, -9997);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9996, 0.00, -97, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99997, -997, 0.00, 0, NULL, -9996);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9995, 0.00, -96, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99996, -996, 0.00, 0, NULL, -9995);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9994, 0.00, -95, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99995, -995, 0.00, 0, NULL, -9994);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9993, 0.00, -94, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99994, -994, 0.00, 0, NULL, -9993);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9992, 0.00, -93, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99993, -993, 0.00, 0, NULL, -9992);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9991, 0.00, -92, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99992, -992, 0.00, 0, NULL, -9991);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9990, 0.00, -91, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99991, -991, 0.00, 0, NULL, -9990);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9989, 0.00, -90, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99990, -990, 0.00, 0, NULL, -9989);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9988, 0.00, -89, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99989, -989, 0.00, 0, NULL, -9988);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9987, 0.00, -88, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99988, -988, 0.00, 0, NULL, -9987);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9986, 0.00, -87, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99987, -987, 0.00, 0, NULL, -9986);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9985, 0.00, -86, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99986, -986, 0.00, 0, NULL, -9985);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9984, 0.00, -85, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99985, -985, 0.00, 0, NULL, -9984);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9992, -9999, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9991, -9999, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9990, -9999, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9989, -9999, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9988, -9999, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9987, -9999, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9986, -9999, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9983, 0.00, -100, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99984, -1000, 0.00, 0, NULL, -9983);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9982, 0.00, -99, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99983, -999, 0.00, 0, NULL, -9982);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9981, 0.00, -98, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99982, -998, 0.00, 0, NULL, -9981);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9980, 0.00, -97, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99981, -997, 0.00, 0, NULL, -9980);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9979, 0.00, -96, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99980, -996, 0.00, 0, NULL, -9979);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9978, 0.00, -95, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99979, -995, 0.00, 0, NULL, -9978);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9977, 0.00, -94, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99978, -994, 0.00, 0, NULL, -9977);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9976, 0.00, -93, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99977, -993, 0.00, 0, NULL, -9976);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9975, 0.00, -92, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99976, -992, 0.00, 0, NULL, -9975);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9974, 0.00, -91, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99975, -991, 0.00, 0, NULL, -9974);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9973, 0.00, -90, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99974, -990, 0.00, 0, NULL, -9973);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9972, 0.00, -89, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99973, -989, 0.00, 0, NULL, -9972);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9971, 0.00, -88, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99972, -988, 0.00, 0, NULL, -9971);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9970, 0.00, -87, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99971, -987, 0.00, 0, NULL, -9970);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9969, 0.00, -86, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99970, -986, 0.00, 0, NULL, -9969);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9968, 0.00, -85, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99969, -985, 0.00, 0, NULL, -9968);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9985, -9998, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9984, -9998, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9983, -9998, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9982, -9998, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9981, -9998, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9980, -9998, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9979, -9998, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9967, 0.00, -100, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99968, -1000, 0.00, 0, NULL, -9967);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9966, 0.00, -99, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99967, -999, 0.00, 0, NULL, -9966);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9965, 0.00, -98, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99966, -998, 0.00, 0, NULL, -9965);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9964, 0.00, -97, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99965, -997, 0.00, 0, NULL, -9964);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9963, 0.00, -96, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99964, -996, 0.00, 0, NULL, -9963);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9962, 0.00, -95, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99963, -995, 0.00, 0, NULL, -9962);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9961, 0.00, -94, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99962, -994, 0.00, 0, NULL, -9961);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9960, 0.00, -93, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99961, -993, 0.00, 0, NULL, -9960);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9959, 0.00, -92, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99960, -992, 0.00, 0, NULL, -9959);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9958, 0.00, -91, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99959, -991, 0.00, 0, NULL, -9958);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9957, 0.00, -90, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99958, -990, 0.00, 0, NULL, -9957);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9956, 0.00, -89, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99957, -989, 0.00, 0, NULL, -9956);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9955, 0.00, -88, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99956, -988, 0.00, 0, NULL, -9955);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9954, 0.00, -87, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99955, -987, 0.00, 0, NULL, -9954);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9953, 0.00, -86, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99954, -986, 0.00, 0, NULL, -9953);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9952, 0.00, -85, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99953, -985, 0.00, 0, NULL, -9952);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9978, -9997, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9977, -9997, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9976, -9997, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9975, -9997, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9974, -9997, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9973, -9997, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9972, -9997, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9951, 0.00, -100, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99952, -1000, 0.00, 0, NULL, -9951);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9950, 0.00, -99, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99951, -999, 0.00, 0, NULL, -9950);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9949, 0.00, -98, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99950, -998, 0.00, 0, NULL, -9949);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9948, 0.00, -97, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99949, -997, 0.00, 0, NULL, -9948);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9947, 0.00, -96, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99948, -996, 0.00, 0, NULL, -9947);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9946, 0.00, -95, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99947, -995, 0.00, 0, NULL, -9946);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9945, 0.00, -94, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99946, -994, 0.00, 0, NULL, -9945);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9944, 0.00, -93, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99945, -993, 0.00, 0, NULL, -9944);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9943, 0.00, -92, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99944, -992, 0.00, 0, NULL, -9943);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9942, 0.00, -91, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99943, -991, 0.00, 0, NULL, -9942);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9941, 0.00, -90, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99942, -990, 0.00, 0, NULL, -9941);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9940, 0.00, -89, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99941, -989, 0.00, 0, NULL, -9940);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9939, 0.00, -88, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99940, -988, 0.00, 0, NULL, -9939);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9938, 0.00, -87, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99939, -987, 0.00, 0, NULL, -9938);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9937, 0.00, -86, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99938, -986, 0.00, 0, NULL, -9937);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9936, 0.00, -85, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99937, -985, 0.00, 0, NULL, -9936);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9971, -9996, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9970, -9996, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9969, -9996, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9968, -9996, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9967, -9996, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9966, -9996, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9965, -9996, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9935, 0.00, -100, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99936, -1000, 0.00, 0, NULL, -9935);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9934, 0.00, -99, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99935, -999, 0.00, 0, NULL, -9934);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9933, 0.00, -98, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99934, -998, 0.00, 0, NULL, -9933);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9932, 0.00, -97, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99933, -997, 0.00, 0, NULL, -9932);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9931, 0.00, -96, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99932, -996, 0.00, 0, NULL, -9931);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9930, 0.00, -95, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99931, -995, 0.00, 0, NULL, -9930);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9929, 0.00, -94, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99930, -994, 0.00, 0, NULL, -9929);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9928, 0.00, -93, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99929, -993, 0.00, 0, NULL, -9928);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9927, 0.00, -92, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99928, -992, 0.00, 0, NULL, -9927);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9926, 0.00, -91, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99927, -991, 0.00, 0, NULL, -9926);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9925, 0.00, -90, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99926, -990, 0.00, 0, NULL, -9925);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9924, 0.00, -89, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99925, -989, 0.00, 0, NULL, -9924);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9923, 0.00, -88, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99924, -988, 0.00, 0, NULL, -9923);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9922, 0.00, -87, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99923, -987, 0.00, 0, NULL, -9922);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9921, 0.00, -86, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99922, -986, 0.00, 0, NULL, -9921);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9920, 0.00, -85, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99921, -985, 0.00, 0, NULL, -9920);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9964, -9995, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9963, -9995, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9962, -9995, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9961, -9995, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9960, -9995, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9959, -9995, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9958, -9995, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9919, 0.00, -100, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99920, -1000, 0.00, 0, NULL, -9919);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9918, 0.00, -99, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99919, -999, 0.00, 0, NULL, -9918);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9917, 0.00, -98, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99918, -998, 0.00, 0, NULL, -9917);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9916, 0.00, -97, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99917, -997, 0.00, 0, NULL, -9916);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9915, 0.00, -96, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99916, -996, 0.00, 0, NULL, -9915);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9914, 0.00, -95, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99915, -995, 0.00, 0, NULL, -9914);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9913, 0.00, -94, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99914, -994, 0.00, 0, NULL, -9913);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9912, 0.00, -93, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99913, -993, 0.00, 0, NULL, -9912);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9911, 0.00, -92, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99912, -992, 0.00, 0, NULL, -9911);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9910, 0.00, -91, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99911, -991, 0.00, 0, NULL, -9910);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9909, 0.00, -90, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99910, -990, 0.00, 0, NULL, -9909);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9908, 0.00, -89, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99909, -989, 0.00, 0, NULL, -9908);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9907, 0.00, -88, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99908, -988, 0.00, 0, NULL, -9907);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9906, 0.00, -87, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99907, -987, 0.00, 0, NULL, -9906);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9905, 0.00, -86, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99906, -986, 0.00, 0, NULL, -9905);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9904, 0.00, -85, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99905, -985, 0.00, 0, NULL, -9904);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9957, -9994, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9956, -9994, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9955, -9994, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9954, -9994, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9953, -9994, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9952, -9994, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9951, -9994, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9903, 0.00, -100, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99904, -1000, 0.00, 0, NULL, -9903);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9902, 0.00, -99, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99903, -999, 0.00, 0, NULL, -9902);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9901, 0.00, -98, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99902, -998, 0.00, 0, NULL, -9901);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9900, 0.00, -97, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99901, -997, 0.00, 0, NULL, -9900);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9899, 0.00, -96, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99900, -996, 0.00, 0, NULL, -9899);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9898, 0.00, -95, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99899, -995, 0.00, 0, NULL, -9898);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9897, 0.00, -94, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99898, -994, 0.00, 0, NULL, -9897);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9896, 0.00, -93, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99897, -993, 0.00, 0, NULL, -9896);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9895, 0.00, -92, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99896, -992, 0.00, 0, NULL, -9895);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9894, 0.00, -91, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99895, -991, 0.00, 0, NULL, -9894);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9893, 0.00, -90, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99894, -990, 0.00, 0, NULL, -9893);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9892, 0.00, -89, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99893, -989, 0.00, 0, NULL, -9892);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9891, 0.00, -88, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99892, -988, 0.00, 0, NULL, -9891);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9890, 0.00, -87, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99891, -987, 0.00, 0, NULL, -9890);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9889, 0.00, -86, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99890, -986, 0.00, 0, NULL, -9889);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9888, 0.00, -85, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99889, -985, 0.00, 0, NULL, -9888);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9950, -9993, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9949, -9993, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9948, -9993, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9947, -9993, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9946, -9993, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9945, -9993, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9944, -9993, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9887, 0.00, -100, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99888, -1000, 0.00, 0, NULL, -9887);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9886, 0.00, -99, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99887, -999, 0.00, 0, NULL, -9886);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9885, 0.00, -98, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99886, -998, 0.00, 0, NULL, -9885);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9884, 0.00, -97, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99885, -997, 0.00, 0, NULL, -9884);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9883, 0.00, -96, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99884, -996, 0.00, 0, NULL, -9883);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9882, 0.00, -95, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99883, -995, 0.00, 0, NULL, -9882);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9881, 0.00, -94, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99882, -994, 0.00, 0, NULL, -9881);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9880, 0.00, -93, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99881, -993, 0.00, 0, NULL, -9880);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9879, 0.00, -92, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99880, -992, 0.00, 0, NULL, -9879);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9878, 0.00, -91, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99879, -991, 0.00, 0, NULL, -9878);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9877, 0.00, -90, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99878, -990, 0.00, 0, NULL, -9877);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9876, 0.00, -89, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99877, -989, 0.00, 0, NULL, -9876);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9875, 0.00, -88, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99876, -988, 0.00, 0, NULL, -9875);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9874, 0.00, -87, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99875, -987, 0.00, 0, NULL, -9874);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9873, 0.00, -86, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99874, -986, 0.00, 0, NULL, -9873);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9872, 0.00, -85, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99873, -985, 0.00, 0, NULL, -9872);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9943, -9992, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9942, -9992, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9941, -9992, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9940, -9992, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9939, -9992, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9938, -9992, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9937, -9992, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9871, 0.00, -100, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99872, -1000, 0.00, 0, NULL, -9871);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9870, 0.00, -99, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99871, -999, 0.00, 0, NULL, -9870);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9869, 0.00, -98, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99870, -998, 0.00, 0, NULL, -9869);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9868, 0.00, -97, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99869, -997, 0.00, 0, NULL, -9868);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9867, 0.00, -96, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99868, -996, 0.00, 0, NULL, -9867);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9866, 0.00, -95, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99867, -995, 0.00, 0, NULL, -9866);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9865, 0.00, -94, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99866, -994, 0.00, 0, NULL, -9865);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9864, 0.00, -93, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99865, -993, 0.00, 0, NULL, -9864);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9863, 0.00, -92, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99864, -992, 0.00, 0, NULL, -9863);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9862, 0.00, -91, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99863, -991, 0.00, 0, NULL, -9862);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9861, 0.00, -90, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99862, -990, 0.00, 0, NULL, -9861);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9860, 0.00, -89, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99861, -989, 0.00, 0, NULL, -9860);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9859, 0.00, -88, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99860, -988, 0.00, 0, NULL, -9859);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9858, 0.00, -87, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99859, -987, 0.00, 0, NULL, -9858);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9857, 0.00, -86, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99858, -986, 0.00, 0, NULL, -9857);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9856, 0.00, -85, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99857, -985, 0.00, 0, NULL, -9856);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9936, -9991, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9935, -9991, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9934, -9991, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9933, -9991, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9932, -9991, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9931, -9991, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9930, -9991, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9855, 0.00, -100, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99856, -1000, 0.00, 0, NULL, -9855);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9854, 0.00, -99, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99855, -999, 0.00, 0, NULL, -9854);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9853, 0.00, -98, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99854, -998, 0.00, 0, NULL, -9853);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9852, 0.00, -97, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99853, -997, 0.00, 0, NULL, -9852);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9851, 0.00, -96, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99852, -996, 0.00, 0, NULL, -9851);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9850, 0.00, -95, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99851, -995, 0.00, 0, NULL, -9850);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9849, 0.00, -94, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99850, -994, 0.00, 0, NULL, -9849);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9848, 0.00, -93, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99849, -993, 0.00, 0, NULL, -9848);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9847, 0.00, -92, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99848, -992, 0.00, 0, NULL, -9847);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9846, 0.00, -91, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99847, -991, 0.00, 0, NULL, -9846);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9845, 0.00, -90, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99846, -990, 0.00, 0, NULL, -9845);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9844, 0.00, -89, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99845, -989, 0.00, 0, NULL, -9844);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9843, 0.00, -88, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99844, -988, 0.00, 0, NULL, -9843);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9842, 0.00, -87, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99843, -987, 0.00, 0, NULL, -9842);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9841, 0.00, -86, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99842, -986, 0.00, 0, NULL, -9841);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9840, 0.00, -85, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99841, -985, 0.00, 0, NULL, -9840);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9929, -9990, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9928, -9990, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9927, -9990, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9926, -9990, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9925, -9990, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9924, -9990, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9923, -9990, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9839, 0.00, -100, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99840, -1000, 0.00, 0, NULL, -9839);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9838, 0.00, -99, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99839, -999, 0.00, 0, NULL, -9838);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9837, 0.00, -98, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99838, -998, 0.00, 0, NULL, -9837);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9836, 0.00, -97, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99837, -997, 0.00, 0, NULL, -9836);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9835, 0.00, -96, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99836, -996, 0.00, 0, NULL, -9835);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9834, 0.00, -95, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99835, -995, 0.00, 0, NULL, -9834);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9833, 0.00, -94, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99834, -994, 0.00, 0, NULL, -9833);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9832, 0.00, -93, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99833, -993, 0.00, 0, NULL, -9832);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9831, 0.00, -92, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99832, -992, 0.00, 0, NULL, -9831);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9830, 0.00, -91, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99831, -991, 0.00, 0, NULL, -9830);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9829, 0.00, -90, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99830, -990, 0.00, 0, NULL, -9829);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9828, 0.00, -89, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99829, -989, 0.00, 0, NULL, -9828);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9827, 0.00, -88, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99828, -988, 0.00, 0, NULL, -9827);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9826, 0.00, -87, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99827, -987, 0.00, 0, NULL, -9826);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9825, 0.00, -86, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99826, -986, 0.00, 0, NULL, -9825);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9824, 0.00, -85, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99825, -985, 0.00, 0, NULL, -9824);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9922, -9989, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9921, -9989, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9920, -9989, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9919, -9989, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9918, -9989, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9917, -9989, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9916, -9989, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9823, 0.00, -100, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99824, -1000, 0.00, 0, NULL, -9823);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9822, 0.00, -99, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99823, -999, 0.00, 0, NULL, -9822);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9821, 0.00, -98, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99822, -998, 0.00, 0, NULL, -9821);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9820, 0.00, -97, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99821, -997, 0.00, 0, NULL, -9820);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9819, 0.00, -96, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99820, -996, 0.00, 0, NULL, -9819);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9818, 0.00, -95, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99819, -995, 0.00, 0, NULL, -9818);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9817, 0.00, -94, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99818, -994, 0.00, 0, NULL, -9817);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9816, 0.00, -93, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99817, -993, 0.00, 0, NULL, -9816);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9815, 0.00, -92, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99816, -992, 0.00, 0, NULL, -9815);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9814, 0.00, -91, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99815, -991, 0.00, 0, NULL, -9814);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9813, 0.00, -90, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99814, -990, 0.00, 0, NULL, -9813);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9812, 0.00, -89, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99813, -989, 0.00, 0, NULL, -9812);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9811, 0.00, -88, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99812, -988, 0.00, 0, NULL, -9811);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9810, 0.00, -87, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99811, -987, 0.00, 0, NULL, -9810);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9809, 0.00, -86, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99810, -986, 0.00, 0, NULL, -9809);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9808, 0.00, -85, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99809, -985, 0.00, 0, NULL, -9808);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9915, -9988, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9914, -9988, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9913, -9988, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9912, -9988, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9911, -9988, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9910, -9988, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9909, -9988, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9807, 0.00, -100, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99808, -1000, 0.00, 0, NULL, -9807);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9806, 0.00, -99, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99807, -999, 0.00, 0, NULL, -9806);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9805, 0.00, -98, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99806, -998, 0.00, 0, NULL, -9805);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9804, 0.00, -97, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99805, -997, 0.00, 0, NULL, -9804);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9803, 0.00, -96, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99804, -996, 0.00, 0, NULL, -9803);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9802, 0.00, -95, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99803, -995, 0.00, 0, NULL, -9802);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9801, 0.00, -94, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99802, -994, 0.00, 0, NULL, -9801);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9800, 0.00, -93, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99801, -993, 0.00, 0, NULL, -9800);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9799, 0.00, -92, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99800, -992, 0.00, 0, NULL, -9799);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9798, 0.00, -91, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99799, -991, 0.00, 0, NULL, -9798);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9797, 0.00, -90, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99798, -990, 0.00, 0, NULL, -9797);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9796, 0.00, -89, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99797, -989, 0.00, 0, NULL, -9796);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9795, 0.00, -88, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99796, -988, 0.00, 0, NULL, -9795);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9794, 0.00, -87, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99795, -987, 0.00, 0, NULL, -9794);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9793, 0.00, -86, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99794, -986, 0.00, 0, NULL, -9793);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9792, 0.00, -85, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99793, -985, 0.00, 0, NULL, -9792);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9908, -9987, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9907, -9987, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9906, -9987, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9905, -9987, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9904, -9987, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9903, -9987, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9902, -9987, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9791, 0.00, -100, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99792, -1000, 0.00, 0, NULL, -9791);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9790, 0.00, -99, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99791, -999, 0.00, 0, NULL, -9790);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9789, 0.00, -98, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99790, -998, 0.00, 0, NULL, -9789);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9788, 0.00, -97, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99789, -997, 0.00, 0, NULL, -9788);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9787, 0.00, -96, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99788, -996, 0.00, 0, NULL, -9787);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9786, 0.00, -95, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99787, -995, 0.00, 0, NULL, -9786);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9785, 0.00, -94, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99786, -994, 0.00, 0, NULL, -9785);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9784, 0.00, -93, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99785, -993, 0.00, 0, NULL, -9784);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9783, 0.00, -92, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99784, -992, 0.00, 0, NULL, -9783);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9782, 0.00, -91, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99783, -991, 0.00, 0, NULL, -9782);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9781, 0.00, -90, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99782, -990, 0.00, 0, NULL, -9781);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9780, 0.00, -89, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99781, -989, 0.00, 0, NULL, -9780);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9779, 0.00, -88, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99780, -988, 0.00, 0, NULL, -9779);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9778, 0.00, -87, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99779, -987, 0.00, 0, NULL, -9778);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9777, 0.00, -86, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99778, -986, 0.00, 0, NULL, -9777);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9776, 0.00, -85, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99777, -985, 0.00, 0, NULL, -9776);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9901, -9986, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9900, -9986, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9899, -9986, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9898, -9986, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9897, -9986, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9896, -9986, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9895, -9986, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9775, 0.00, -100, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99776, -1000, 0.00, 0, NULL, -9775);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9774, 0.00, -99, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99775, -999, 0.00, 0, NULL, -9774);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9773, 0.00, -98, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99774, -998, 0.00, 0, NULL, -9773);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9772, 0.00, -97, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99773, -997, 0.00, 0, NULL, -9772);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9771, 0.00, -96, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99772, -996, 0.00, 0, NULL, -9771);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9770, 0.00, -95, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99771, -995, 0.00, 0, NULL, -9770);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9769, 0.00, -94, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99770, -994, 0.00, 0, NULL, -9769);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9768, 0.00, -93, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99769, -993, 0.00, 0, NULL, -9768);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9767, 0.00, -92, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99768, -992, 0.00, 0, NULL, -9767);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9766, 0.00, -91, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99767, -991, 0.00, 0, NULL, -9766);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9765, 0.00, -90, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99766, -990, 0.00, 0, NULL, -9765);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9764, 0.00, -89, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99765, -989, 0.00, 0, NULL, -9764);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9763, 0.00, -88, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99764, -988, 0.00, 0, NULL, -9763);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9762, 0.00, -87, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99763, -987, 0.00, 0, NULL, -9762);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9761, 0.00, -86, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99762, -986, 0.00, 0, NULL, -9761);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9760, 0.00, -85, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99761, -985, 0.00, 0, NULL, -9760);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9894, -9985, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9893, -9985, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9892, -9985, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9891, -9985, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9890, -9985, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9889, -9985, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9888, -9985, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9759, 0.00, -100, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99760, -1000, 0.00, 0, NULL, -9759);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9758, 0.00, -99, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99759, -999, 0.00, 0, NULL, -9758);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9757, 0.00, -98, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99758, -998, 0.00, 0, NULL, -9757);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9756, 0.00, -97, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99757, -997, 0.00, 0, NULL, -9756);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9755, 0.00, -96, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99756, -996, 0.00, 0, NULL, -9755);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9754, 0.00, -95, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99755, -995, 0.00, 0, NULL, -9754);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9753, 0.00, -94, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99754, -994, 0.00, 0, NULL, -9753);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9752, 0.00, -93, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99753, -993, 0.00, 0, NULL, -9752);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9751, 0.00, -92, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99752, -992, 0.00, 0, NULL, -9751);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9750, 0.00, -91, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99751, -991, 0.00, 0, NULL, -9750);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9749, 0.00, -90, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99750, -990, 0.00, 0, NULL, -9749);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9748, 0.00, -89, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99749, -989, 0.00, 0, NULL, -9748);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9747, 0.00, -88, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99748, -988, 0.00, 0, NULL, -9747);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9746, 0.00, -87, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99747, -987, 0.00, 0, NULL, -9746);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9745, 0.00, -86, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99746, -986, 0.00, 0, NULL, -9745);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9744, 0.00, -85, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99745, -985, 0.00, 0, NULL, -9744);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9887, -9984, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9886, -9984, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9885, -9984, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9884, -9984, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9883, -9984, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9882, -9984, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9881, -9984, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9743, 0.00, -100, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99744, -1000, 0.00, 0, NULL, -9743);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9742, 0.00, -99, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99743, -999, 0.00, 0, NULL, -9742);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9741, 0.00, -98, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99742, -998, 0.00, 0, NULL, -9741);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9740, 0.00, -97, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99741, -997, 0.00, 0, NULL, -9740);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9739, 0.00, -96, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99740, -996, 0.00, 0, NULL, -9739);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9738, 0.00, -95, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99739, -995, 0.00, 0, NULL, -9738);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9737, 0.00, -94, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99738, -994, 0.00, 0, NULL, -9737);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9736, 0.00, -93, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99737, -993, 0.00, 0, NULL, -9736);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9735, 0.00, -92, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99736, -992, 0.00, 0, NULL, -9735);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9734, 0.00, -91, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99735, -991, 0.00, 0, NULL, -9734);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9733, 0.00, -90, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99734, -990, 0.00, 0, NULL, -9733);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9732, 0.00, -89, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99733, -989, 0.00, 0, NULL, -9732);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9731, 0.00, -88, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99732, -988, 0.00, 0, NULL, -9731);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9730, 0.00, -87, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99731, -987, 0.00, 0, NULL, -9730);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9729, 0.00, -86, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99730, -986, 0.00, 0, NULL, -9729);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9728, 0.00, -85, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99729, -985, 0.00, 0, NULL, -9728);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9880, -9983, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9879, -9983, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9878, -9983, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9877, -9983, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9876, -9983, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9875, -9983, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9874, -9983, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9727, 0.00, -100, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99728, -1000, 0.00, 0, NULL, -9727);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9726, 0.00, -99, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99727, -999, 0.00, 0, NULL, -9726);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9725, 0.00, -98, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99726, -998, 0.00, 0, NULL, -9725);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9724, 0.00, -97, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99725, -997, 0.00, 0, NULL, -9724);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9723, 0.00, -96, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99724, -996, 0.00, 0, NULL, -9723);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9722, 0.00, -95, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99723, -995, 0.00, 0, NULL, -9722);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9721, 0.00, -94, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99722, -994, 0.00, 0, NULL, -9721);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9720, 0.00, -93, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99721, -993, 0.00, 0, NULL, -9720);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9719, 0.00, -92, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99720, -992, 0.00, 0, NULL, -9719);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9718, 0.00, -91, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99719, -991, 0.00, 0, NULL, -9718);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9717, 0.00, -90, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99718, -990, 0.00, 0, NULL, -9717);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9716, 0.00, -89, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99717, -989, 0.00, 0, NULL, -9716);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9715, 0.00, -88, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99716, -988, 0.00, 0, NULL, -9715);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9714, 0.00, -87, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99715, -987, 0.00, 0, NULL, -9714);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9713, 0.00, -86, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99714, -986, 0.00, 0, NULL, -9713);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9712, 0.00, -85, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99713, -985, 0.00, 0, NULL, -9712);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9873, -9982, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9872, -9982, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9871, -9982, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9870, -9982, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9869, -9982, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9868, -9982, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9867, -9982, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9711, 0.00, -100, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99712, -1000, 0.00, 0, NULL, -9711);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9710, 0.00, -99, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99711, -999, 0.00, 0, NULL, -9710);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9709, 0.00, -98, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99710, -998, 0.00, 0, NULL, -9709);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9708, 0.00, -97, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99709, -997, 0.00, 0, NULL, -9708);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9707, 0.00, -96, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99708, -996, 0.00, 0, NULL, -9707);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9706, 0.00, -95, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99707, -995, 0.00, 0, NULL, -9706);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9705, 0.00, -94, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99706, -994, 0.00, 0, NULL, -9705);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9704, 0.00, -93, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99705, -993, 0.00, 0, NULL, -9704);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9703, 0.00, -92, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99704, -992, 0.00, 0, NULL, -9703);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9702, 0.00, -91, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99703, -991, 0.00, 0, NULL, -9702);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9701, 0.00, -90, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99702, -990, 0.00, 0, NULL, -9701);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9700, 0.00, -89, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99701, -989, 0.00, 0, NULL, -9700);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9699, 0.00, -88, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99700, -988, 0.00, 0, NULL, -9699);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9698, 0.00, -87, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99699, -987, 0.00, 0, NULL, -9698);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9697, 0.00, -86, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99698, -986, 0.00, 0, NULL, -9697);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9696, 0.00, -85, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99697, -985, 0.00, 0, NULL, -9696);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9866, -9981, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9865, -9981, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9864, -9981, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9863, -9981, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9862, -9981, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9861, -9981, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9860, -9981, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9695, 0.00, -100, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99696, -1000, 0.00, 0, NULL, -9695);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9694, 0.00, -99, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99695, -999, 0.00, 0, NULL, -9694);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9693, 0.00, -98, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99694, -998, 0.00, 0, NULL, -9693);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9692, 0.00, -97, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99693, -997, 0.00, 0, NULL, -9692);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9691, 0.00, -96, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99692, -996, 0.00, 0, NULL, -9691);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9690, 0.00, -95, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99691, -995, 0.00, 0, NULL, -9690);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9689, 0.00, -94, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99690, -994, 0.00, 0, NULL, -9689);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9688, 0.00, -93, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99689, -993, 0.00, 0, NULL, -9688);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9687, 0.00, -92, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99688, -992, 0.00, 0, NULL, -9687);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9686, 0.00, -91, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99687, -991, 0.00, 0, NULL, -9686);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9685, 0.00, -90, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99686, -990, 0.00, 0, NULL, -9685);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9684, 0.00, -89, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99685, -989, 0.00, 0, NULL, -9684);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9683, 0.00, -88, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99684, -988, 0.00, 0, NULL, -9683);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9682, 0.00, -87, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99683, -987, 0.00, 0, NULL, -9682);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9681, 0.00, -86, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99682, -986, 0.00, 0, NULL, -9681);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9680, 0.00, -85, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99681, -985, 0.00, 0, NULL, -9680);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9859, -9980, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9858, -9980, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9857, -9980, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9856, -9980, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9855, -9980, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9854, -9980, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9853, -9980, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9679, 0.00, -100, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99680, -1000, 0.00, 0, NULL, -9679);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9678, 0.00, -99, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99679, -999, 0.00, 0, NULL, -9678);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9677, 0.00, -98, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99678, -998, 0.00, 0, NULL, -9677);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9676, 0.00, -97, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99677, -997, 0.00, 0, NULL, -9676);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9675, 0.00, -96, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99676, -996, 0.00, 0, NULL, -9675);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9674, 0.00, -95, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99675, -995, 0.00, 0, NULL, -9674);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9673, 0.00, -94, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99674, -994, 0.00, 0, NULL, -9673);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9672, 0.00, -93, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99673, -993, 0.00, 0, NULL, -9672);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9671, 0.00, -92, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99672, -992, 0.00, 0, NULL, -9671);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9670, 0.00, -91, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99671, -991, 0.00, 0, NULL, -9670);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9669, 0.00, -90, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99670, -990, 0.00, 0, NULL, -9669);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9668, 0.00, -89, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99669, -989, 0.00, 0, NULL, -9668);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9667, 0.00, -88, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99668, -988, 0.00, 0, NULL, -9667);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9666, 0.00, -87, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99667, -987, 0.00, 0, NULL, -9666);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9665, 0.00, -86, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99666, -986, 0.00, 0, NULL, -9665);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9664, 0.00, -85, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99665, -985, 0.00, 0, NULL, -9664);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9852, -9979, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9851, -9979, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9850, -9979, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9849, -9979, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9848, -9979, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9847, -9979, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9846, -9979, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9663, 0.00, -100, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99664, -1000, 0.00, 0, NULL, -9663);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9662, 0.00, -99, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99663, -999, 0.00, 0, NULL, -9662);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9661, 0.00, -98, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99662, -998, 0.00, 0, NULL, -9661);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9660, 0.00, -97, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99661, -997, 0.00, 0, NULL, -9660);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9659, 0.00, -96, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99660, -996, 0.00, 0, NULL, -9659);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9658, 0.00, -95, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99659, -995, 0.00, 0, NULL, -9658);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9657, 0.00, -94, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99658, -994, 0.00, 0, NULL, -9657);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9656, 0.00, -93, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99657, -993, 0.00, 0, NULL, -9656);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9655, 0.00, -92, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99656, -992, 0.00, 0, NULL, -9655);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9654, 0.00, -91, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99655, -991, 0.00, 0, NULL, -9654);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9653, 0.00, -90, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99654, -990, 0.00, 0, NULL, -9653);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9652, 0.00, -89, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99653, -989, 0.00, 0, NULL, -9652);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9651, 0.00, -88, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99652, -988, 0.00, 0, NULL, -9651);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9650, 0.00, -87, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99651, -987, 0.00, 0, NULL, -9650);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9649, 0.00, -86, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99650, -986, 0.00, 0, NULL, -9649);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9648, 0.00, -85, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99649, -985, 0.00, 0, NULL, -9648);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9845, -9978, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9844, -9978, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9843, -9978, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9842, -9978, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9841, -9978, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9840, -9978, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9839, -9978, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9647, 0.00, -100, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99648, -1000, 0.00, 0, NULL, -9647);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9646, 0.00, -99, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99647, -999, 0.00, 0, NULL, -9646);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9645, 0.00, -98, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99646, -998, 0.00, 0, NULL, -9645);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9644, 0.00, -97, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99645, -997, 0.00, 0, NULL, -9644);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9643, 0.00, -96, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99644, -996, 0.00, 0, NULL, -9643);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9642, 0.00, -95, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99643, -995, 0.00, 0, NULL, -9642);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9641, 0.00, -94, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99642, -994, 0.00, 0, NULL, -9641);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9640, 0.00, -93, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99641, -993, 0.00, 0, NULL, -9640);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9639, 0.00, -92, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99640, -992, 0.00, 0, NULL, -9639);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9638, 0.00, -91, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99639, -991, 0.00, 0, NULL, -9638);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9637, 0.00, -90, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99638, -990, 0.00, 0, NULL, -9637);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9636, 0.00, -89, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99637, -989, 0.00, 0, NULL, -9636);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9635, 0.00, -88, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99636, -988, 0.00, 0, NULL, -9635);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9634, 0.00, -87, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99635, -987, 0.00, 0, NULL, -9634);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9633, 0.00, -86, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99634, -986, 0.00, 0, NULL, -9633);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9632, 0.00, -85, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99633, -985, 0.00, 0, NULL, -9632);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9838, -9977, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9837, -9977, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9836, -9977, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9835, -9977, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9834, -9977, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9833, -9977, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9832, -9977, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9631, 0.00, -100, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99632, -1000, 0.00, 0, NULL, -9631);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9630, 0.00, -99, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99631, -999, 0.00, 0, NULL, -9630);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9629, 0.00, -98, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99630, -998, 0.00, 0, NULL, -9629);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9628, 0.00, -97, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99629, -997, 0.00, 0, NULL, -9628);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9627, 0.00, -96, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99628, -996, 0.00, 0, NULL, -9627);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9626, 0.00, -95, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99627, -995, 0.00, 0, NULL, -9626);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9625, 0.00, -94, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99626, -994, 0.00, 0, NULL, -9625);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9624, 0.00, -93, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99625, -993, 0.00, 0, NULL, -9624);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9623, 0.00, -92, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99624, -992, 0.00, 0, NULL, -9623);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9622, 0.00, -91, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99623, -991, 0.00, 0, NULL, -9622);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9621, 0.00, -90, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99622, -990, 0.00, 0, NULL, -9621);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9620, 0.00, -89, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99621, -989, 0.00, 0, NULL, -9620);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9619, 0.00, -88, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99620, -988, 0.00, 0, NULL, -9619);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9618, 0.00, -87, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99619, -987, 0.00, 0, NULL, -9618);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9617, 0.00, -86, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99618, -986, 0.00, 0, NULL, -9617);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9616, 0.00, -85, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99617, -985, 0.00, 0, NULL, -9616);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9831, -9976, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9830, -9976, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9829, -9976, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9828, -9976, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9827, -9976, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9826, -9976, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9825, -9976, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9615, 0.00, -100, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99616, -1000, 0.00, 0, NULL, -9615);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9614, 0.00, -99, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99615, -999, 0.00, 0, NULL, -9614);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9613, 0.00, -98, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99614, -998, 0.00, 0, NULL, -9613);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9612, 0.00, -97, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99613, -997, 0.00, 0, NULL, -9612);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9611, 0.00, -96, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99612, -996, 0.00, 0, NULL, -9611);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9610, 0.00, -95, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99611, -995, 0.00, 0, NULL, -9610);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9609, 0.00, -94, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99610, -994, 0.00, 0, NULL, -9609);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9608, 0.00, -93, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99609, -993, 0.00, 0, NULL, -9608);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9607, 0.00, -92, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99608, -992, 0.00, 0, NULL, -9607);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9606, 0.00, -91, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99607, -991, 0.00, 0, NULL, -9606);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9605, 0.00, -90, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99606, -990, 0.00, 0, NULL, -9605);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9604, 0.00, -89, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99605, -989, 0.00, 0, NULL, -9604);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9603, 0.00, -88, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99604, -988, 0.00, 0, NULL, -9603);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9602, 0.00, -87, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99603, -987, 0.00, 0, NULL, -9602);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9601, 0.00, -86, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99602, -986, 0.00, 0, NULL, -9601);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9600, 0.00, -85, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99601, -985, 0.00, 0, NULL, -9600);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9824, -9975, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9823, -9975, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9822, -9975, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9821, -9975, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9820, -9975, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9819, -9975, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9818, -9975, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9599, 0.00, -100, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99600, -1000, 0.00, 0, NULL, -9599);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9598, 0.00, -99, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99599, -999, 0.00, 0, NULL, -9598);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9597, 0.00, -98, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99598, -998, 0.00, 0, NULL, -9597);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9596, 0.00, -97, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99597, -997, 0.00, 0, NULL, -9596);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9595, 0.00, -96, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99596, -996, 0.00, 0, NULL, -9595);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9594, 0.00, -95, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99595, -995, 0.00, 0, NULL, -9594);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9593, 0.00, -94, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99594, -994, 0.00, 0, NULL, -9593);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9592, 0.00, -93, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99593, -993, 0.00, 0, NULL, -9592);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9591, 0.00, -92, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99592, -992, 0.00, 0, NULL, -9591);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9590, 0.00, -91, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99591, -991, 0.00, 0, NULL, -9590);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9589, 0.00, -90, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99590, -990, 0.00, 0, NULL, -9589);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9588, 0.00, -89, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99589, -989, 0.00, 0, NULL, -9588);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9587, 0.00, -88, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99588, -988, 0.00, 0, NULL, -9587);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9586, 0.00, -87, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99587, -987, 0.00, 0, NULL, -9586);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9585, 0.00, -86, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99586, -986, 0.00, 0, NULL, -9585);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9584, 0.00, -85, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99585, -985, 0.00, 0, NULL, -9584);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9817, -9974, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9816, -9974, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9815, -9974, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9814, -9974, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9813, -9974, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9812, -9974, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9811, -9974, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9583, 0.00, -100, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99584, -1000, 0.00, 0, NULL, -9583);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9582, 0.00, -99, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99583, -999, 0.00, 0, NULL, -9582);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9581, 0.00, -98, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99582, -998, 0.00, 0, NULL, -9581);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9580, 0.00, -97, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99581, -997, 0.00, 0, NULL, -9580);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9579, 0.00, -96, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99580, -996, 0.00, 0, NULL, -9579);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9578, 0.00, -95, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99579, -995, 0.00, 0, NULL, -9578);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9577, 0.00, -94, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99578, -994, 0.00, 0, NULL, -9577);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9576, 0.00, -93, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99577, -993, 0.00, 0, NULL, -9576);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9575, 0.00, -92, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99576, -992, 0.00, 0, NULL, -9575);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9574, 0.00, -91, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99575, -991, 0.00, 0, NULL, -9574);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9573, 0.00, -90, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99574, -990, 0.00, 0, NULL, -9573);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9572, 0.00, -89, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99573, -989, 0.00, 0, NULL, -9572);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9571, 0.00, -88, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99572, -988, 0.00, 0, NULL, -9571);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9570, 0.00, -87, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99571, -987, 0.00, 0, NULL, -9570);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9569, 0.00, -86, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99570, -986, 0.00, 0, NULL, -9569);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9568, 0.00, -85, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99569, -985, 0.00, 0, NULL, -9568);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9810, -9973, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9809, -9973, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9808, -9973, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9807, -9973, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9806, -9973, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9805, -9973, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9804, -9973, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9567, 0.00, -100, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99568, -1000, 0.00, 0, NULL, -9567);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9566, 0.00, -99, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99567, -999, 0.00, 0, NULL, -9566);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9565, 0.00, -98, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99566, -998, 0.00, 0, NULL, -9565);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9564, 0.00, -97, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99565, -997, 0.00, 0, NULL, -9564);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9563, 0.00, -96, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99564, -996, 0.00, 0, NULL, -9563);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9562, 0.00, -95, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99563, -995, 0.00, 0, NULL, -9562);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9561, 0.00, -94, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99562, -994, 0.00, 0, NULL, -9561);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9560, 0.00, -93, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99561, -993, 0.00, 0, NULL, -9560);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9559, 0.00, -92, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99560, -992, 0.00, 0, NULL, -9559);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9558, 0.00, -91, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99559, -991, 0.00, 0, NULL, -9558);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9557, 0.00, -90, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99558, -990, 0.00, 0, NULL, -9557);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9556, 0.00, -89, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99557, -989, 0.00, 0, NULL, -9556);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9555, 0.00, -88, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99556, -988, 0.00, 0, NULL, -9555);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9554, 0.00, -87, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99555, -987, 0.00, 0, NULL, -9554);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9553, 0.00, -86, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99554, -986, 0.00, 0, NULL, -9553);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9552, 0.00, -85, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99553, -985, 0.00, 0, NULL, -9552);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9803, -9972, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9802, -9972, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9801, -9972, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9800, -9972, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9799, -9972, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9798, -9972, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9797, -9972, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9551, 0.00, -100, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99552, -1000, 0.00, 0, NULL, -9551);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9550, 0.00, -99, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99551, -999, 0.00, 0, NULL, -9550);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9549, 0.00, -98, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99550, -998, 0.00, 0, NULL, -9549);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9548, 0.00, -97, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99549, -997, 0.00, 0, NULL, -9548);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9547, 0.00, -96, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99548, -996, 0.00, 0, NULL, -9547);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9546, 0.00, -95, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99547, -995, 0.00, 0, NULL, -9546);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9545, 0.00, -94, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99546, -994, 0.00, 0, NULL, -9545);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9544, 0.00, -93, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99545, -993, 0.00, 0, NULL, -9544);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9543, 0.00, -92, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99544, -992, 0.00, 0, NULL, -9543);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9542, 0.00, -91, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99543, -991, 0.00, 0, NULL, -9542);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9541, 0.00, -90, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99542, -990, 0.00, 0, NULL, -9541);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9540, 0.00, -89, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99541, -989, 0.00, 0, NULL, -9540);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9539, 0.00, -88, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99540, -988, 0.00, 0, NULL, -9539);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9538, 0.00, -87, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99539, -987, 0.00, 0, NULL, -9538);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9537, 0.00, -86, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99538, -986, 0.00, 0, NULL, -9537);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9536, 0.00, -85, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99537, -985, 0.00, 0, NULL, -9536);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9796, -9971, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9795, -9971, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9794, -9971, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9793, -9971, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9792, -9971, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9791, -9971, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9790, -9971, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9535, 0.00, -100, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99536, -1000, 0.00, 0, NULL, -9535);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9534, 0.00, -99, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99535, -999, 0.00, 0, NULL, -9534);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9533, 0.00, -98, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99534, -998, 0.00, 0, NULL, -9533);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9532, 0.00, -97, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99533, -997, 0.00, 0, NULL, -9532);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9531, 0.00, -96, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99532, -996, 0.00, 0, NULL, -9531);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9530, 0.00, -95, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99531, -995, 0.00, 0, NULL, -9530);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9529, 0.00, -94, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99530, -994, 0.00, 0, NULL, -9529);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9528, 0.00, -93, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99529, -993, 0.00, 0, NULL, -9528);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9527, 0.00, -92, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99528, -992, 0.00, 0, NULL, -9527);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9526, 0.00, -91, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99527, -991, 0.00, 0, NULL, -9526);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9525, 0.00, -90, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99526, -990, 0.00, 0, NULL, -9525);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9524, 0.00, -89, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99525, -989, 0.00, 0, NULL, -9524);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9523, 0.00, -88, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99524, -988, 0.00, 0, NULL, -9523);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9522, 0.00, -87, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99523, -987, 0.00, 0, NULL, -9522);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9521, 0.00, -86, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99522, -986, 0.00, 0, NULL, -9521);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9520, 0.00, -85, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99521, -985, 0.00, 0, NULL, -9520);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9789, -9970, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9788, -9970, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9787, -9970, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9786, -9970, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9785, -9970, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9784, -9970, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9783, -9970, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9519, 0.00, -100, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99520, -1000, 0.00, 0, NULL, -9519);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9518, 0.00, -99, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99519, -999, 0.00, 0, NULL, -9518);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9517, 0.00, -98, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99518, -998, 0.00, 0, NULL, -9517);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9516, 0.00, -97, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99517, -997, 0.00, 0, NULL, -9516);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9515, 0.00, -96, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99516, -996, 0.00, 0, NULL, -9515);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9514, 0.00, -95, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99515, -995, 0.00, 0, NULL, -9514);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9513, 0.00, -94, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99514, -994, 0.00, 0, NULL, -9513);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9512, 0.00, -93, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99513, -993, 0.00, 0, NULL, -9512);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9511, 0.00, -92, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99512, -992, 0.00, 0, NULL, -9511);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9510, 0.00, -91, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99511, -991, 0.00, 0, NULL, -9510);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9509, 0.00, -90, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99510, -990, 0.00, 0, NULL, -9509);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9508, 0.00, -89, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99509, -989, 0.00, 0, NULL, -9508);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9507, 0.00, -88, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99508, -988, 0.00, 0, NULL, -9507);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9506, 0.00, -87, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99507, -987, 0.00, 0, NULL, -9506);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9505, 0.00, -86, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99506, -986, 0.00, 0, NULL, -9505);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9504, 0.00, -85, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99505, -985, 0.00, 0, NULL, -9504);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9782, -9969, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9781, -9969, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9780, -9969, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9779, -9969, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9778, -9969, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9777, -9969, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9776, -9969, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9503, 0.00, -100, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99504, -1000, 0.00, 0, NULL, -9503);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9502, 0.00, -99, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99503, -999, 0.00, 0, NULL, -9502);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9501, 0.00, -98, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99502, -998, 0.00, 0, NULL, -9501);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9500, 0.00, -97, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99501, -997, 0.00, 0, NULL, -9500);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9499, 0.00, -96, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99500, -996, 0.00, 0, NULL, -9499);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9498, 0.00, -95, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99499, -995, 0.00, 0, NULL, -9498);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9497, 0.00, -94, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99498, -994, 0.00, 0, NULL, -9497);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9496, 0.00, -93, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99497, -993, 0.00, 0, NULL, -9496);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9495, 0.00, -92, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99496, -992, 0.00, 0, NULL, -9495);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9494, 0.00, -91, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99495, -991, 0.00, 0, NULL, -9494);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9493, 0.00, -90, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99494, -990, 0.00, 0, NULL, -9493);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9492, 0.00, -89, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99493, -989, 0.00, 0, NULL, -9492);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9491, 0.00, -88, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99492, -988, 0.00, 0, NULL, -9491);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9490, 0.00, -87, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99491, -987, 0.00, 0, NULL, -9490);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9489, 0.00, -86, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99490, -986, 0.00, 0, NULL, -9489);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9488, 0.00, -85, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99489, -985, 0.00, 0, NULL, -9488);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9775, -9968, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9774, -9968, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9773, -9968, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9772, -9968, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9771, -9968, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9770, -9968, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9769, -9968, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9487, 0.00, -100, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99488, -1000, 0.00, 0, NULL, -9487);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9486, 0.00, -99, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99487, -999, 0.00, 0, NULL, -9486);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9485, 0.00, -98, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99486, -998, 0.00, 0, NULL, -9485);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9484, 0.00, -97, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99485, -997, 0.00, 0, NULL, -9484);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9483, 0.00, -96, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99484, -996, 0.00, 0, NULL, -9483);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9482, 0.00, -95, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99483, -995, 0.00, 0, NULL, -9482);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9481, 0.00, -94, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99482, -994, 0.00, 0, NULL, -9481);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9480, 0.00, -93, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99481, -993, 0.00, 0, NULL, -9480);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9479, 0.00, -92, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99480, -992, 0.00, 0, NULL, -9479);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9478, 0.00, -91, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99479, -991, 0.00, 0, NULL, -9478);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9477, 0.00, -90, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99478, -990, 0.00, 0, NULL, -9477);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9476, 0.00, -89, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99477, -989, 0.00, 0, NULL, -9476);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9475, 0.00, -88, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99476, -988, 0.00, 0, NULL, -9475);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9474, 0.00, -87, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99475, -987, 0.00, 0, NULL, -9474);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9473, 0.00, -86, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99474, -986, 0.00, 0, NULL, -9473);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9472, 0.00, -85, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99473, -985, 0.00, 0, NULL, -9472);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9768, -9967, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9767, -9967, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9766, -9967, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9765, -9967, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9764, -9967, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9763, -9967, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9762, -9967, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9471, 0.00, -100, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99472, -1000, 0.00, 0, NULL, -9471);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9470, 0.00, -99, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99471, -999, 0.00, 0, NULL, -9470);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9469, 0.00, -98, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99470, -998, 0.00, 0, NULL, -9469);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9468, 0.00, -97, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99469, -997, 0.00, 0, NULL, -9468);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9467, 0.00, -96, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99468, -996, 0.00, 0, NULL, -9467);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9466, 0.00, -95, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99467, -995, 0.00, 0, NULL, -9466);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9465, 0.00, -94, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99466, -994, 0.00, 0, NULL, -9465);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9464, 0.00, -93, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99465, -993, 0.00, 0, NULL, -9464);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9463, 0.00, -92, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99464, -992, 0.00, 0, NULL, -9463);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9462, 0.00, -91, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99463, -991, 0.00, 0, NULL, -9462);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9461, 0.00, -90, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99462, -990, 0.00, 0, NULL, -9461);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9460, 0.00, -89, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99461, -989, 0.00, 0, NULL, -9460);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9459, 0.00, -88, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99460, -988, 0.00, 0, NULL, -9459);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9458, 0.00, -87, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99459, -987, 0.00, 0, NULL, -9458);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9457, 0.00, -86, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99458, -986, 0.00, 0, NULL, -9457);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9456, 0.00, -85, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99457, -985, 0.00, 0, NULL, -9456);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9761, -9966, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9760, -9966, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9759, -9966, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9758, -9966, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9757, -9966, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9756, -9966, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9755, -9966, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9455, 0.00, -100, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99456, -1000, 0.00, 0, NULL, -9455);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9454, 0.00, -99, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99455, -999, 0.00, 0, NULL, -9454);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9453, 0.00, -98, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99454, -998, 0.00, 0, NULL, -9453);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9452, 0.00, -97, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99453, -997, 0.00, 0, NULL, -9452);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9451, 0.00, -96, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99452, -996, 0.00, 0, NULL, -9451);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9450, 0.00, -95, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99451, -995, 0.00, 0, NULL, -9450);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9449, 0.00, -94, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99450, -994, 0.00, 0, NULL, -9449);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9448, 0.00, -93, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99449, -993, 0.00, 0, NULL, -9448);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9447, 0.00, -92, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99448, -992, 0.00, 0, NULL, -9447);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9446, 0.00, -91, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99447, -991, 0.00, 0, NULL, -9446);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9445, 0.00, -90, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99446, -990, 0.00, 0, NULL, -9445);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9444, 0.00, -89, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99445, -989, 0.00, 0, NULL, -9444);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9443, 0.00, -88, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99444, -988, 0.00, 0, NULL, -9443);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9442, 0.00, -87, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99443, -987, 0.00, 0, NULL, -9442);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9441, 0.00, -86, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99442, -986, 0.00, 0, NULL, -9441);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9440, 0.00, -85, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99441, -985, 0.00, 0, NULL, -9440);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9754, -9965, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9753, -9965, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9752, -9965, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9751, -9965, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9750, -9965, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9749, -9965, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9748, -9965, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9439, 0.00, -100, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99440, -1000, 0.00, 0, NULL, -9439);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9438, 0.00, -99, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99439, -999, 0.00, 0, NULL, -9438);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9437, 0.00, -98, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99438, -998, 0.00, 0, NULL, -9437);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9436, 0.00, -97, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99437, -997, 0.00, 0, NULL, -9436);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9435, 0.00, -96, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99436, -996, 0.00, 0, NULL, -9435);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9434, 0.00, -95, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99435, -995, 0.00, 0, NULL, -9434);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9433, 0.00, -94, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99434, -994, 0.00, 0, NULL, -9433);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9432, 0.00, -93, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99433, -993, 0.00, 0, NULL, -9432);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9431, 0.00, -92, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99432, -992, 0.00, 0, NULL, -9431);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9430, 0.00, -91, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99431, -991, 0.00, 0, NULL, -9430);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9429, 0.00, -90, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99430, -990, 0.00, 0, NULL, -9429);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9428, 0.00, -89, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99429, -989, 0.00, 0, NULL, -9428);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9427, 0.00, -88, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99428, -988, 0.00, 0, NULL, -9427);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9426, 0.00, -87, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99427, -987, 0.00, 0, NULL, -9426);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9425, 0.00, -86, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99426, -986, 0.00, 0, NULL, -9425);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9424, 0.00, -85, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99425, -985, 0.00, 0, NULL, -9424);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9747, -9964, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9746, -9964, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9745, -9964, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9744, -9964, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9743, -9964, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9742, -9964, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9741, -9964, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9423, 0.00, -100, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99424, -1000, 0.00, 0, NULL, -9423);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9422, 0.00, -99, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99423, -999, 0.00, 0, NULL, -9422);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9421, 0.00, -98, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99422, -998, 0.00, 0, NULL, -9421);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9420, 0.00, -97, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99421, -997, 0.00, 0, NULL, -9420);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9419, 0.00, -96, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99420, -996, 0.00, 0, NULL, -9419);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9418, 0.00, -95, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99419, -995, 0.00, 0, NULL, -9418);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9417, 0.00, -94, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99418, -994, 0.00, 0, NULL, -9417);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9416, 0.00, -93, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99417, -993, 0.00, 0, NULL, -9416);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9415, 0.00, -92, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99416, -992, 0.00, 0, NULL, -9415);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9414, 0.00, -91, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99415, -991, 0.00, 0, NULL, -9414);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9413, 0.00, -90, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99414, -990, 0.00, 0, NULL, -9413);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9412, 0.00, -89, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99413, -989, 0.00, 0, NULL, -9412);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9411, 0.00, -88, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99412, -988, 0.00, 0, NULL, -9411);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9410, 0.00, -87, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99411, -987, 0.00, 0, NULL, -9410);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9409, 0.00, -86, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99410, -986, 0.00, 0, NULL, -9409);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9408, 0.00, -85, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99409, -985, 0.00, 0, NULL, -9408);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9740, -9963, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9739, -9963, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9738, -9963, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9737, -9963, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9736, -9963, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9735, -9963, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9734, -9963, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9407, 0.00, -100, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99408, -1000, 0.00, 0, NULL, -9407);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9406, 0.00, -99, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99407, -999, 0.00, 0, NULL, -9406);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9405, 0.00, -98, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99406, -998, 0.00, 0, NULL, -9405);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9404, 0.00, -97, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99405, -997, 0.00, 0, NULL, -9404);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9403, 0.00, -96, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99404, -996, 0.00, 0, NULL, -9403);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9402, 0.00, -95, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99403, -995, 0.00, 0, NULL, -9402);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9401, 0.00, -94, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99402, -994, 0.00, 0, NULL, -9401);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9400, 0.00, -93, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99401, -993, 0.00, 0, NULL, -9400);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9399, 0.00, -92, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99400, -992, 0.00, 0, NULL, -9399);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9398, 0.00, -91, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99399, -991, 0.00, 0, NULL, -9398);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9397, 0.00, -90, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99398, -990, 0.00, 0, NULL, -9397);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9396, 0.00, -89, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99397, -989, 0.00, 0, NULL, -9396);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9395, 0.00, -88, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99396, -988, 0.00, 0, NULL, -9395);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9394, 0.00, -87, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99395, -987, 0.00, 0, NULL, -9394);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9393, 0.00, -86, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99394, -986, 0.00, 0, NULL, -9393);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9392, 0.00, -85, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99393, -985, 0.00, 0, NULL, -9392);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9733, -9962, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9732, -9962, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9731, -9962, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9730, -9962, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9729, -9962, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9728, -9962, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9727, -9962, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9391, 0.00, -100, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99392, -1000, 0.00, 0, NULL, -9391);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9390, 0.00, -99, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99391, -999, 0.00, 0, NULL, -9390);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9389, 0.00, -98, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99390, -998, 0.00, 0, NULL, -9389);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9388, 0.00, -97, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99389, -997, 0.00, 0, NULL, -9388);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9387, 0.00, -96, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99388, -996, 0.00, 0, NULL, -9387);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9386, 0.00, -95, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99387, -995, 0.00, 0, NULL, -9386);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9385, 0.00, -94, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99386, -994, 0.00, 0, NULL, -9385);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9384, 0.00, -93, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99385, -993, 0.00, 0, NULL, -9384);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9383, 0.00, -92, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99384, -992, 0.00, 0, NULL, -9383);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9382, 0.00, -91, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99383, -991, 0.00, 0, NULL, -9382);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9381, 0.00, -90, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99382, -990, 0.00, 0, NULL, -9381);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9380, 0.00, -89, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99381, -989, 0.00, 0, NULL, -9380);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9379, 0.00, -88, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99380, -988, 0.00, 0, NULL, -9379);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9378, 0.00, -87, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99379, -987, 0.00, 0, NULL, -9378);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9377, 0.00, -86, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99378, -986, 0.00, 0, NULL, -9377);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9376, 0.00, -85, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99377, -985, 0.00, 0, NULL, -9376);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9726, -9961, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9725, -9961, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9724, -9961, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9723, -9961, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9722, -9961, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9721, -9961, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9720, -9961, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9375, 0.00, -100, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99376, -1000, 0.00, 0, NULL, -9375);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9374, 0.00, -99, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99375, -999, 0.00, 0, NULL, -9374);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9373, 0.00, -98, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99374, -998, 0.00, 0, NULL, -9373);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9372, 0.00, -97, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99373, -997, 0.00, 0, NULL, -9372);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9371, 0.00, -96, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99372, -996, 0.00, 0, NULL, -9371);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9370, 0.00, -95, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99371, -995, 0.00, 0, NULL, -9370);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9369, 0.00, -94, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99370, -994, 0.00, 0, NULL, -9369);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9368, 0.00, -93, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99369, -993, 0.00, 0, NULL, -9368);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9367, 0.00, -92, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99368, -992, 0.00, 0, NULL, -9367);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9366, 0.00, -91, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99367, -991, 0.00, 0, NULL, -9366);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9365, 0.00, -90, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99366, -990, 0.00, 0, NULL, -9365);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9364, 0.00, -89, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99365, -989, 0.00, 0, NULL, -9364);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9363, 0.00, -88, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99364, -988, 0.00, 0, NULL, -9363);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9362, 0.00, -87, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99363, -987, 0.00, 0, NULL, -9362);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9361, 0.00, -86, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99362, -986, 0.00, 0, NULL, -9361);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9360, 0.00, -85, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99361, -985, 0.00, 0, NULL, -9360);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9719, -9960, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9718, -9960, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9717, -9960, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9716, -9960, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9715, -9960, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9714, -9960, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9713, -9960, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9359, 0.00, -100, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99360, -1000, 0.00, 0, NULL, -9359);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9358, 0.00, -99, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99359, -999, 0.00, 0, NULL, -9358);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9357, 0.00, -98, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99358, -998, 0.00, 0, NULL, -9357);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9356, 0.00, -97, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99357, -997, 0.00, 0, NULL, -9356);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9355, 0.00, -96, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99356, -996, 0.00, 0, NULL, -9355);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9354, 0.00, -95, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99355, -995, 0.00, 0, NULL, -9354);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9353, 0.00, -94, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99354, -994, 0.00, 0, NULL, -9353);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9352, 0.00, -93, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99353, -993, 0.00, 0, NULL, -9352);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9351, 0.00, -92, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99352, -992, 0.00, 0, NULL, -9351);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9350, 0.00, -91, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99351, -991, 0.00, 0, NULL, -9350);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9349, 0.00, -90, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99350, -990, 0.00, 0, NULL, -9349);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9348, 0.00, -89, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99349, -989, 0.00, 0, NULL, -9348);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9347, 0.00, -88, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99348, -988, 0.00, 0, NULL, -9347);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9346, 0.00, -87, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99347, -987, 0.00, 0, NULL, -9346);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9345, 0.00, -86, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99346, -986, 0.00, 0, NULL, -9345);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9344, 0.00, -85, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99345, -985, 0.00, 0, NULL, -9344);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9712, -9959, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9711, -9959, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9710, -9959, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9709, -9959, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9708, -9959, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9707, -9959, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9706, -9959, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9343, 0.00, -100, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99344, -1000, 0.00, 0, NULL, -9343);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9342, 0.00, -99, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99343, -999, 0.00, 0, NULL, -9342);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9341, 0.00, -98, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99342, -998, 0.00, 0, NULL, -9341);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9340, 0.00, -97, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99341, -997, 0.00, 0, NULL, -9340);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9339, 0.00, -96, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99340, -996, 0.00, 0, NULL, -9339);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9338, 0.00, -95, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99339, -995, 0.00, 0, NULL, -9338);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9337, 0.00, -94, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99338, -994, 0.00, 0, NULL, -9337);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9336, 0.00, -93, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99337, -993, 0.00, 0, NULL, -9336);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9335, 0.00, -92, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99336, -992, 0.00, 0, NULL, -9335);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9334, 0.00, -91, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99335, -991, 0.00, 0, NULL, -9334);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9333, 0.00, -90, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99334, -990, 0.00, 0, NULL, -9333);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9332, 0.00, -89, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99333, -989, 0.00, 0, NULL, -9332);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9331, 0.00, -88, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99332, -988, 0.00, 0, NULL, -9331);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9330, 0.00, -87, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99331, -987, 0.00, 0, NULL, -9330);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9329, 0.00, -86, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99330, -986, 0.00, 0, NULL, -9329);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9328, 0.00, -85, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99329, -985, 0.00, 0, NULL, -9328);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9705, -9958, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9704, -9958, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9703, -9958, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9702, -9958, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9701, -9958, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9700, -9958, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9699, -9958, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9327, 0.00, -100, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99328, -1000, 0.00, 0, NULL, -9327);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9326, 0.00, -99, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99327, -999, 0.00, 0, NULL, -9326);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9325, 0.00, -98, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99326, -998, 0.00, 0, NULL, -9325);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9324, 0.00, -97, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99325, -997, 0.00, 0, NULL, -9324);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9323, 0.00, -96, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99324, -996, 0.00, 0, NULL, -9323);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9322, 0.00, -95, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99323, -995, 0.00, 0, NULL, -9322);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9321, 0.00, -94, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99322, -994, 0.00, 0, NULL, -9321);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9320, 0.00, -93, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99321, -993, 0.00, 0, NULL, -9320);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9319, 0.00, -92, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99320, -992, 0.00, 0, NULL, -9319);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9318, 0.00, -91, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99319, -991, 0.00, 0, NULL, -9318);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9317, 0.00, -90, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99318, -990, 0.00, 0, NULL, -9317);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9316, 0.00, -89, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99317, -989, 0.00, 0, NULL, -9316);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9315, 0.00, -88, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99316, -988, 0.00, 0, NULL, -9315);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9314, 0.00, -87, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99315, -987, 0.00, 0, NULL, -9314);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9313, 0.00, -86, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99314, -986, 0.00, 0, NULL, -9313);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9312, 0.00, -85, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99313, -985, 0.00, 0, NULL, -9312);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9698, -9957, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9697, -9957, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9696, -9957, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9695, -9957, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9694, -9957, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9693, -9957, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9692, -9957, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9311, 0.00, -100, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99312, -1000, 0.00, 0, NULL, -9311);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9310, 0.00, -99, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99311, -999, 0.00, 0, NULL, -9310);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9309, 0.00, -98, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99310, -998, 0.00, 0, NULL, -9309);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9308, 0.00, -97, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99309, -997, 0.00, 0, NULL, -9308);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9307, 0.00, -96, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99308, -996, 0.00, 0, NULL, -9307);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9306, 0.00, -95, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99307, -995, 0.00, 0, NULL, -9306);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9305, 0.00, -94, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99306, -994, 0.00, 0, NULL, -9305);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9304, 0.00, -93, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99305, -993, 0.00, 0, NULL, -9304);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9303, 0.00, -92, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99304, -992, 0.00, 0, NULL, -9303);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9302, 0.00, -91, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99303, -991, 0.00, 0, NULL, -9302);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9301, 0.00, -90, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99302, -990, 0.00, 0, NULL, -9301);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9300, 0.00, -89, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99301, -989, 0.00, 0, NULL, -9300);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9299, 0.00, -88, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99300, -988, 0.00, 0, NULL, -9299);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9298, 0.00, -87, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99299, -987, 0.00, 0, NULL, -9298);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9297, 0.00, -86, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99298, -986, 0.00, 0, NULL, -9297);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9296, 0.00, -85, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99297, -985, 0.00, 0, NULL, -9296);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9691, -9956, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9690, -9956, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9689, -9956, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9688, -9956, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9687, -9956, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9686, -9956, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9685, -9956, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9295, 0.00, -100, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99296, -1000, 0.00, 0, NULL, -9295);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9294, 0.00, -99, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99295, -999, 0.00, 0, NULL, -9294);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9293, 0.00, -98, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99294, -998, 0.00, 0, NULL, -9293);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9292, 0.00, -97, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99293, -997, 0.00, 0, NULL, -9292);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9291, 0.00, -96, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99292, -996, 0.00, 0, NULL, -9291);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9290, 0.00, -95, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99291, -995, 0.00, 0, NULL, -9290);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9289, 0.00, -94, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99290, -994, 0.00, 0, NULL, -9289);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9288, 0.00, -93, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99289, -993, 0.00, 0, NULL, -9288);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9287, 0.00, -92, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99288, -992, 0.00, 0, NULL, -9287);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9286, 0.00, -91, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99287, -991, 0.00, 0, NULL, -9286);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9285, 0.00, -90, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99286, -990, 0.00, 0, NULL, -9285);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9284, 0.00, -89, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99285, -989, 0.00, 0, NULL, -9284);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9283, 0.00, -88, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99284, -988, 0.00, 0, NULL, -9283);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9282, 0.00, -87, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99283, -987, 0.00, 0, NULL, -9282);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9281, 0.00, -86, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99282, -986, 0.00, 0, NULL, -9281);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9280, 0.00, -85, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99281, -985, 0.00, 0, NULL, -9280);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9684, -9955, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9683, -9955, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9682, -9955, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9681, -9955, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9680, -9955, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9679, -9955, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9678, -9955, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9279, 0.00, -100, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99280, -1000, 0.00, 0, NULL, -9279);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9278, 0.00, -99, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99279, -999, 0.00, 0, NULL, -9278);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9277, 0.00, -98, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99278, -998, 0.00, 0, NULL, -9277);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9276, 0.00, -97, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99277, -997, 0.00, 0, NULL, -9276);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9275, 0.00, -96, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99276, -996, 0.00, 0, NULL, -9275);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9274, 0.00, -95, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99275, -995, 0.00, 0, NULL, -9274);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9273, 0.00, -94, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99274, -994, 0.00, 0, NULL, -9273);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9272, 0.00, -93, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99273, -993, 0.00, 0, NULL, -9272);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9271, 0.00, -92, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99272, -992, 0.00, 0, NULL, -9271);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9270, 0.00, -91, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99271, -991, 0.00, 0, NULL, -9270);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9269, 0.00, -90, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99270, -990, 0.00, 0, NULL, -9269);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9268, 0.00, -89, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99269, -989, 0.00, 0, NULL, -9268);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9267, 0.00, -88, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99268, -988, 0.00, 0, NULL, -9267);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9266, 0.00, -87, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99267, -987, 0.00, 0, NULL, -9266);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9265, 0.00, -86, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99266, -986, 0.00, 0, NULL, -9265);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9264, 0.00, -85, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99265, -985, 0.00, 0, NULL, -9264);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9677, -9954, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9676, -9954, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9675, -9954, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9674, -9954, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9673, -9954, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9672, -9954, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9671, -9954, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9263, 0.00, -100, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99264, -1000, 0.00, 0, NULL, -9263);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9262, 0.00, -99, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99263, -999, 0.00, 0, NULL, -9262);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9261, 0.00, -98, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99262, -998, 0.00, 0, NULL, -9261);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9260, 0.00, -97, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99261, -997, 0.00, 0, NULL, -9260);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9259, 0.00, -96, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99260, -996, 0.00, 0, NULL, -9259);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9258, 0.00, -95, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99259, -995, 0.00, 0, NULL, -9258);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9257, 0.00, -94, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99258, -994, 0.00, 0, NULL, -9257);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9256, 0.00, -93, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99257, -993, 0.00, 0, NULL, -9256);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9255, 0.00, -92, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99256, -992, 0.00, 0, NULL, -9255);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9254, 0.00, -91, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99255, -991, 0.00, 0, NULL, -9254);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9253, 0.00, -90, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99254, -990, 0.00, 0, NULL, -9253);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9252, 0.00, -89, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99253, -989, 0.00, 0, NULL, -9252);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9251, 0.00, -88, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99252, -988, 0.00, 0, NULL, -9251);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9250, 0.00, -87, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99251, -987, 0.00, 0, NULL, -9250);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9249, 0.00, -86, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99250, -986, 0.00, 0, NULL, -9249);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9248, 0.00, -85, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99249, -985, 0.00, 0, NULL, -9248);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9670, -9953, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9669, -9953, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9668, -9953, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9667, -9953, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9666, -9953, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9665, -9953, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9664, -9953, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9247, 0.00, -100, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99248, -1000, 0.00, 0, NULL, -9247);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9246, 0.00, -99, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99247, -999, 0.00, 0, NULL, -9246);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9245, 0.00, -98, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99246, -998, 0.00, 0, NULL, -9245);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9244, 0.00, -97, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99245, -997, 0.00, 0, NULL, -9244);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9243, 0.00, -96, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99244, -996, 0.00, 0, NULL, -9243);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9242, 0.00, -95, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99243, -995, 0.00, 0, NULL, -9242);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9241, 0.00, -94, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99242, -994, 0.00, 0, NULL, -9241);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9240, 0.00, -93, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99241, -993, 0.00, 0, NULL, -9240);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9239, 0.00, -92, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99240, -992, 0.00, 0, NULL, -9239);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9238, 0.00, -91, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99239, -991, 0.00, 0, NULL, -9238);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9237, 0.00, -90, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99238, -990, 0.00, 0, NULL, -9237);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9236, 0.00, -89, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99237, -989, 0.00, 0, NULL, -9236);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9235, 0.00, -88, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99236, -988, 0.00, 0, NULL, -9235);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9234, 0.00, -87, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99235, -987, 0.00, 0, NULL, -9234);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9233, 0.00, -86, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99234, -986, 0.00, 0, NULL, -9233);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9232, 0.00, -85, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99233, -985, 0.00, 0, NULL, -9232);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9663, -9952, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9662, -9952, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9661, -9952, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9660, -9952, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9659, -9952, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9658, -9952, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9657, -9952, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9231, 0.00, -100, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99232, -1000, 0.00, 0, NULL, -9231);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9230, 0.00, -99, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99231, -999, 0.00, 0, NULL, -9230);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9229, 0.00, -98, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99230, -998, 0.00, 0, NULL, -9229);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9228, 0.00, -97, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99229, -997, 0.00, 0, NULL, -9228);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9227, 0.00, -96, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99228, -996, 0.00, 0, NULL, -9227);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9226, 0.00, -95, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99227, -995, 0.00, 0, NULL, -9226);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9225, 0.00, -94, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99226, -994, 0.00, 0, NULL, -9225);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9224, 0.00, -93, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99225, -993, 0.00, 0, NULL, -9224);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9223, 0.00, -92, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99224, -992, 0.00, 0, NULL, -9223);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9222, 0.00, -91, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99223, -991, 0.00, 0, NULL, -9222);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9221, 0.00, -90, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99222, -990, 0.00, 0, NULL, -9221);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9220, 0.00, -89, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99221, -989, 0.00, 0, NULL, -9220);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9219, 0.00, -88, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99220, -988, 0.00, 0, NULL, -9219);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9218, 0.00, -87, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99219, -987, 0.00, 0, NULL, -9218);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9217, 0.00, -86, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99218, -986, 0.00, 0, NULL, -9217);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9216, 0.00, -85, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99217, -985, 0.00, 0, NULL, -9216);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9656, -9951, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9655, -9951, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9654, -9951, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9653, -9951, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9652, -9951, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9651, -9951, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9650, -9951, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9215, 0.00, -100, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99216, -1000, 0.00, 0, NULL, -9215);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9214, 0.00, -99, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99215, -999, 0.00, 0, NULL, -9214);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9213, 0.00, -98, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99214, -998, 0.00, 0, NULL, -9213);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9212, 0.00, -97, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99213, -997, 0.00, 0, NULL, -9212);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9211, 0.00, -96, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99212, -996, 0.00, 0, NULL, -9211);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9210, 0.00, -95, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99211, -995, 0.00, 0, NULL, -9210);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9209, 0.00, -94, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99210, -994, 0.00, 0, NULL, -9209);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9208, 0.00, -93, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99209, -993, 0.00, 0, NULL, -9208);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9207, 0.00, -92, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99208, -992, 0.00, 0, NULL, -9207);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9206, 0.00, -91, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99207, -991, 0.00, 0, NULL, -9206);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9205, 0.00, -90, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99206, -990, 0.00, 0, NULL, -9205);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9204, 0.00, -89, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99205, -989, 0.00, 0, NULL, -9204);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9203, 0.00, -88, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99204, -988, 0.00, 0, NULL, -9203);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9202, 0.00, -87, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99203, -987, 0.00, 0, NULL, -9202);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9201, 0.00, -86, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99202, -986, 0.00, 0, NULL, -9201);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9200, 0.00, -85, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99201, -985, 0.00, 0, NULL, -9200);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9649, -9950, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9648, -9950, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9647, -9950, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9646, -9950, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9645, -9950, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9644, -9950, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9643, -9950, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9199, 0.00, -100, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99200, -1000, 0.00, 0, NULL, -9199);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9198, 0.00, -99, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99199, -999, 0.00, 0, NULL, -9198);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9197, 0.00, -98, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99198, -998, 0.00, 0, NULL, -9197);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9196, 0.00, -97, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99197, -997, 0.00, 0, NULL, -9196);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9195, 0.00, -96, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99196, -996, 0.00, 0, NULL, -9195);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9194, 0.00, -95, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99195, -995, 0.00, 0, NULL, -9194);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9193, 0.00, -94, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99194, -994, 0.00, 0, NULL, -9193);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9192, 0.00, -93, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99193, -993, 0.00, 0, NULL, -9192);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9191, 0.00, -92, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99192, -992, 0.00, 0, NULL, -9191);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9190, 0.00, -91, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99191, -991, 0.00, 0, NULL, -9190);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9189, 0.00, -90, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99190, -990, 0.00, 0, NULL, -9189);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9188, 0.00, -89, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99189, -989, 0.00, 0, NULL, -9188);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9187, 0.00, -88, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99188, -988, 0.00, 0, NULL, -9187);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9186, 0.00, -87, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99187, -987, 0.00, 0, NULL, -9186);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9185, 0.00, -86, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99186, -986, 0.00, 0, NULL, -9185);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9184, 0.00, -85, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99185, -985, 0.00, 0, NULL, -9184);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9642, -9949, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9641, -9949, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9640, -9949, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9639, -9949, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9638, -9949, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9637, -9949, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9636, -9949, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9183, 0.00, -100, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99184, -1000, 0.00, 0, NULL, -9183);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9182, 0.00, -99, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99183, -999, 0.00, 0, NULL, -9182);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9181, 0.00, -98, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99182, -998, 0.00, 0, NULL, -9181);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9180, 0.00, -97, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99181, -997, 0.00, 0, NULL, -9180);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9179, 0.00, -96, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99180, -996, 0.00, 0, NULL, -9179);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9178, 0.00, -95, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99179, -995, 0.00, 0, NULL, -9178);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9177, 0.00, -94, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99178, -994, 0.00, 0, NULL, -9177);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9176, 0.00, -93, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99177, -993, 0.00, 0, NULL, -9176);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9175, 0.00, -92, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99176, -992, 0.00, 0, NULL, -9175);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9174, 0.00, -91, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99175, -991, 0.00, 0, NULL, -9174);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9173, 0.00, -90, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99174, -990, 0.00, 0, NULL, -9173);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9172, 0.00, -89, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99173, -989, 0.00, 0, NULL, -9172);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9171, 0.00, -88, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99172, -988, 0.00, 0, NULL, -9171);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9170, 0.00, -87, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99171, -987, 0.00, 0, NULL, -9170);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9169, 0.00, -86, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99170, -986, 0.00, 0, NULL, -9169);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9168, 0.00, -85, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99169, -985, 0.00, 0, NULL, -9168);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9635, -9948, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9634, -9948, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9633, -9948, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9632, -9948, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9631, -9948, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9630, -9948, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9629, -9948, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9167, 0.00, -100, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99168, -1000, 0.00, 0, NULL, -9167);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9166, 0.00, -99, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99167, -999, 0.00, 0, NULL, -9166);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9165, 0.00, -98, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99166, -998, 0.00, 0, NULL, -9165);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9164, 0.00, -97, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99165, -997, 0.00, 0, NULL, -9164);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9163, 0.00, -96, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99164, -996, 0.00, 0, NULL, -9163);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9162, 0.00, -95, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99163, -995, 0.00, 0, NULL, -9162);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9161, 0.00, -94, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99162, -994, 0.00, 0, NULL, -9161);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9160, 0.00, -93, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99161, -993, 0.00, 0, NULL, -9160);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9159, 0.00, -92, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99160, -992, 0.00, 0, NULL, -9159);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9158, 0.00, -91, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99159, -991, 0.00, 0, NULL, -9158);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9157, 0.00, -90, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99158, -990, 0.00, 0, NULL, -9157);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9156, 0.00, -89, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99157, -989, 0.00, 0, NULL, -9156);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9155, 0.00, -88, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99156, -988, 0.00, 0, NULL, -9155);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9154, 0.00, -87, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99155, -987, 0.00, 0, NULL, -9154);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9153, 0.00, -86, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99154, -986, 0.00, 0, NULL, -9153);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9152, 0.00, -85, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99153, -985, 0.00, 0, NULL, -9152);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9628, -9947, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9627, -9947, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9626, -9947, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9625, -9947, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9624, -9947, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9623, -9947, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9622, -9947, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9151, 0.00, -100, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99152, -1000, 0.00, 0, NULL, -9151);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9150, 0.00, -99, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99151, -999, 0.00, 0, NULL, -9150);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9149, 0.00, -98, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99150, -998, 0.00, 0, NULL, -9149);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9148, 0.00, -97, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99149, -997, 0.00, 0, NULL, -9148);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9147, 0.00, -96, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99148, -996, 0.00, 0, NULL, -9147);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9146, 0.00, -95, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99147, -995, 0.00, 0, NULL, -9146);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9145, 0.00, -94, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99146, -994, 0.00, 0, NULL, -9145);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9144, 0.00, -93, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99145, -993, 0.00, 0, NULL, -9144);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9143, 0.00, -92, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99144, -992, 0.00, 0, NULL, -9143);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9142, 0.00, -91, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99143, -991, 0.00, 0, NULL, -9142);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9141, 0.00, -90, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99142, -990, 0.00, 0, NULL, -9141);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9140, 0.00, -89, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99141, -989, 0.00, 0, NULL, -9140);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9139, 0.00, -88, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99140, -988, 0.00, 0, NULL, -9139);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9138, 0.00, -87, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99139, -987, 0.00, 0, NULL, -9138);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9137, 0.00, -86, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99138, -986, 0.00, 0, NULL, -9137);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9136, 0.00, -85, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99137, -985, 0.00, 0, NULL, -9136);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9621, -9946, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9620, -9946, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9619, -9946, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9618, -9946, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9617, -9946, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9616, -9946, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9615, -9946, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9135, 0.00, -100, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99136, -1000, 0.00, 0, NULL, -9135);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9134, 0.00, -99, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99135, -999, 0.00, 0, NULL, -9134);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9133, 0.00, -98, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99134, -998, 0.00, 0, NULL, -9133);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9132, 0.00, -97, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99133, -997, 0.00, 0, NULL, -9132);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9131, 0.00, -96, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99132, -996, 0.00, 0, NULL, -9131);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9130, 0.00, -95, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99131, -995, 0.00, 0, NULL, -9130);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9129, 0.00, -94, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99130, -994, 0.00, 0, NULL, -9129);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9128, 0.00, -93, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99129, -993, 0.00, 0, NULL, -9128);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9127, 0.00, -92, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99128, -992, 0.00, 0, NULL, -9127);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9126, 0.00, -91, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99127, -991, 0.00, 0, NULL, -9126);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9125, 0.00, -90, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99126, -990, 0.00, 0, NULL, -9125);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9124, 0.00, -89, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99125, -989, 0.00, 0, NULL, -9124);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9123, 0.00, -88, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99124, -988, 0.00, 0, NULL, -9123);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9122, 0.00, -87, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99123, -987, 0.00, 0, NULL, -9122);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9121, 0.00, -86, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99122, -986, 0.00, 0, NULL, -9121);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9120, 0.00, -85, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99121, -985, 0.00, 0, NULL, -9120);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9614, -9945, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9613, -9945, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9612, -9945, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9611, -9945, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9610, -9945, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9609, -9945, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9608, -9945, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9119, 0.00, -100, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99120, -1000, 0.00, 0, NULL, -9119);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9118, 0.00, -99, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99119, -999, 0.00, 0, NULL, -9118);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9117, 0.00, -98, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99118, -998, 0.00, 0, NULL, -9117);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9116, 0.00, -97, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99117, -997, 0.00, 0, NULL, -9116);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9115, 0.00, -96, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99116, -996, 0.00, 0, NULL, -9115);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9114, 0.00, -95, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99115, -995, 0.00, 0, NULL, -9114);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9113, 0.00, -94, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99114, -994, 0.00, 0, NULL, -9113);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9112, 0.00, -93, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99113, -993, 0.00, 0, NULL, -9112);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9111, 0.00, -92, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99112, -992, 0.00, 0, NULL, -9111);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9110, 0.00, -91, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99111, -991, 0.00, 0, NULL, -9110);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9109, 0.00, -90, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99110, -990, 0.00, 0, NULL, -9109);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9108, 0.00, -89, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99109, -989, 0.00, 0, NULL, -9108);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9107, 0.00, -88, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99108, -988, 0.00, 0, NULL, -9107);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9106, 0.00, -87, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99107, -987, 0.00, 0, NULL, -9106);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9105, 0.00, -86, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99106, -986, 0.00, 0, NULL, -9105);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9104, 0.00, -85, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99105, -985, 0.00, 0, NULL, -9104);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9607, -9944, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9606, -9944, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9605, -9944, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9604, -9944, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9603, -9944, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9602, -9944, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9601, -9944, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9103, 0.00, -100, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99104, -1000, 0.00, 0, NULL, -9103);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9102, 0.00, -99, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99103, -999, 0.00, 0, NULL, -9102);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9101, 0.00, -98, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99102, -998, 0.00, 0, NULL, -9101);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9100, 0.00, -97, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99101, -997, 0.00, 0, NULL, -9100);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9099, 0.00, -96, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99100, -996, 0.00, 0, NULL, -9099);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9098, 0.00, -95, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99099, -995, 0.00, 0, NULL, -9098);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9097, 0.00, -94, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99098, -994, 0.00, 0, NULL, -9097);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9096, 0.00, -93, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99097, -993, 0.00, 0, NULL, -9096);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9095, 0.00, -92, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99096, -992, 0.00, 0, NULL, -9095);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9094, 0.00, -91, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99095, -991, 0.00, 0, NULL, -9094);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9093, 0.00, -90, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99094, -990, 0.00, 0, NULL, -9093);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9092, 0.00, -89, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99093, -989, 0.00, 0, NULL, -9092);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9091, 0.00, -88, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99092, -988, 0.00, 0, NULL, -9091);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9090, 0.00, -87, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99091, -987, 0.00, 0, NULL, -9090);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9089, 0.00, -86, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99090, -986, 0.00, 0, NULL, -9089);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9088, 0.00, -85, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99089, -985, 0.00, 0, NULL, -9088);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9600, -9943, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9599, -9943, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9598, -9943, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9597, -9943, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9596, -9943, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9595, -9943, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9594, -9943, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9087, 0.00, -100, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99088, -1000, 0.00, 0, NULL, -9087);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9086, 0.00, -99, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99087, -999, 0.00, 0, NULL, -9086);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9085, 0.00, -98, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99086, -998, 0.00, 0, NULL, -9085);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9084, 0.00, -97, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99085, -997, 0.00, 0, NULL, -9084);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9083, 0.00, -96, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99084, -996, 0.00, 0, NULL, -9083);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9082, 0.00, -95, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99083, -995, 0.00, 0, NULL, -9082);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9081, 0.00, -94, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99082, -994, 0.00, 0, NULL, -9081);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9080, 0.00, -93, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99081, -993, 0.00, 0, NULL, -9080);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9079, 0.00, -92, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99080, -992, 0.00, 0, NULL, -9079);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9078, 0.00, -91, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99079, -991, 0.00, 0, NULL, -9078);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9077, 0.00, -90, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99078, -990, 0.00, 0, NULL, -9077);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9076, 0.00, -89, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99077, -989, 0.00, 0, NULL, -9076);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9075, 0.00, -88, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99076, -988, 0.00, 0, NULL, -9075);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9074, 0.00, -87, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99075, -987, 0.00, 0, NULL, -9074);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9073, 0.00, -86, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99074, -986, 0.00, 0, NULL, -9073);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9072, 0.00, -85, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99073, -985, 0.00, 0, NULL, -9072);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9593, -9942, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9592, -9942, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9591, -9942, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9590, -9942, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9589, -9942, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9588, -9942, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9587, -9942, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9071, 0.00, -100, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99072, -1000, 0.00, 0, NULL, -9071);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9070, 0.00, -99, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99071, -999, 0.00, 0, NULL, -9070);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9069, 0.00, -98, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99070, -998, 0.00, 0, NULL, -9069);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9068, 0.00, -97, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99069, -997, 0.00, 0, NULL, -9068);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9067, 0.00, -96, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99068, -996, 0.00, 0, NULL, -9067);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9066, 0.00, -95, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99067, -995, 0.00, 0, NULL, -9066);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9065, 0.00, -94, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99066, -994, 0.00, 0, NULL, -9065);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9064, 0.00, -93, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99065, -993, 0.00, 0, NULL, -9064);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9063, 0.00, -92, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99064, -992, 0.00, 0, NULL, -9063);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9062, 0.00, -91, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99063, -991, 0.00, 0, NULL, -9062);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9061, 0.00, -90, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99062, -990, 0.00, 0, NULL, -9061);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9060, 0.00, -89, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99061, -989, 0.00, 0, NULL, -9060);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9059, 0.00, -88, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99060, -988, 0.00, 0, NULL, -9059);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9058, 0.00, -87, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99059, -987, 0.00, 0, NULL, -9058);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9057, 0.00, -86, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99058, -986, 0.00, 0, NULL, -9057);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9056, 0.00, -85, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99057, -985, 0.00, 0, NULL, -9056);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9586, -9941, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9585, -9941, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9584, -9941, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9583, -9941, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9582, -9941, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9581, -9941, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9580, -9941, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9055, 0.00, -100, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99056, -1000, 0.00, 0, NULL, -9055);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9054, 0.00, -99, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99055, -999, 0.00, 0, NULL, -9054);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9053, 0.00, -98, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99054, -998, 0.00, 0, NULL, -9053);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9052, 0.00, -97, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99053, -997, 0.00, 0, NULL, -9052);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9051, 0.00, -96, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99052, -996, 0.00, 0, NULL, -9051);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9050, 0.00, -95, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99051, -995, 0.00, 0, NULL, -9050);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9049, 0.00, -94, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99050, -994, 0.00, 0, NULL, -9049);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9048, 0.00, -93, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99049, -993, 0.00, 0, NULL, -9048);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9047, 0.00, -92, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99048, -992, 0.00, 0, NULL, -9047);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9046, 0.00, -91, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99047, -991, 0.00, 0, NULL, -9046);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9045, 0.00, -90, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99046, -990, 0.00, 0, NULL, -9045);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9044, 0.00, -89, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99045, -989, 0.00, 0, NULL, -9044);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9043, 0.00, -88, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99044, -988, 0.00, 0, NULL, -9043);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9042, 0.00, -87, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99043, -987, 0.00, 0, NULL, -9042);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9041, 0.00, -86, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99042, -986, 0.00, 0, NULL, -9041);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9040, 0.00, -85, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99041, -985, 0.00, 0, NULL, -9040);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9579, -9940, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9578, -9940, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9577, -9940, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9576, -9940, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9575, -9940, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9574, -9940, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9573, -9940, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9039, 0.00, -100, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99040, -1000, 0.00, 0, NULL, -9039);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9038, 0.00, -99, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99039, -999, 0.00, 0, NULL, -9038);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9037, 0.00, -98, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99038, -998, 0.00, 0, NULL, -9037);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9036, 0.00, -97, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99037, -997, 0.00, 0, NULL, -9036);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9035, 0.00, -96, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99036, -996, 0.00, 0, NULL, -9035);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9034, 0.00, -95, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99035, -995, 0.00, 0, NULL, -9034);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9033, 0.00, -94, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99034, -994, 0.00, 0, NULL, -9033);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9032, 0.00, -93, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99033, -993, 0.00, 0, NULL, -9032);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9031, 0.00, -92, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99032, -992, 0.00, 0, NULL, -9031);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9030, 0.00, -91, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99031, -991, 0.00, 0, NULL, -9030);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9029, 0.00, -90, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99030, -990, 0.00, 0, NULL, -9029);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9028, 0.00, -89, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99029, -989, 0.00, 0, NULL, -9028);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9027, 0.00, -88, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99028, -988, 0.00, 0, NULL, -9027);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9026, 0.00, -87, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99027, -987, 0.00, 0, NULL, -9026);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9025, 0.00, -86, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99026, -986, 0.00, 0, NULL, -9025);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9024, 0.00, -85, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99025, -985, 0.00, 0, NULL, -9024);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9572, -9939, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9571, -9939, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9570, -9939, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9569, -9939, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9568, -9939, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9567, -9939, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9566, -9939, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9023, 0.00, -100, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99024, -1000, 0.00, 0, NULL, -9023);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9022, 0.00, -99, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99023, -999, 0.00, 0, NULL, -9022);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9021, 0.00, -98, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99022, -998, 0.00, 0, NULL, -9021);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9020, 0.00, -97, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99021, -997, 0.00, 0, NULL, -9020);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9019, 0.00, -96, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99020, -996, 0.00, 0, NULL, -9019);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9018, 0.00, -95, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99019, -995, 0.00, 0, NULL, -9018);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9017, 0.00, -94, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99018, -994, 0.00, 0, NULL, -9017);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9016, 0.00, -93, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99017, -993, 0.00, 0, NULL, -9016);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9015, 0.00, -92, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99016, -992, 0.00, 0, NULL, -9015);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9014, 0.00, -91, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99015, -991, 0.00, 0, NULL, -9014);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9013, 0.00, -90, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99014, -990, 0.00, 0, NULL, -9013);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9012, 0.00, -89, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99013, -989, 0.00, 0, NULL, -9012);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9011, 0.00, -88, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99012, -988, 0.00, 0, NULL, -9011);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9010, 0.00, -87, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99011, -987, 0.00, 0, NULL, -9010);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9009, 0.00, -86, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99010, -986, 0.00, 0, NULL, -9009);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9008, 0.00, -85, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99009, -985, 0.00, 0, NULL, -9008);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9565, -9938, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9564, -9938, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9563, -9938, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9562, -9938, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9561, -9938, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9560, -9938, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9559, -9938, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9007, 0.00, -100, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99008, -1000, 0.00, 0, NULL, -9007);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9006, 0.00, -99, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99007, -999, 0.00, 0, NULL, -9006);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9005, 0.00, -98, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99006, -998, 0.00, 0, NULL, -9005);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9004, 0.00, -97, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99005, -997, 0.00, 0, NULL, -9004);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9003, 0.00, -96, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99004, -996, 0.00, 0, NULL, -9003);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9002, 0.00, -95, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99003, -995, 0.00, 0, NULL, -9002);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9001, 0.00, -94, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99002, -994, 0.00, 0, NULL, -9001);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9000, 0.00, -93, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99001, -993, 0.00, 0, NULL, -9000);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8999, 0.00, -92, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99000, -992, 0.00, 0, NULL, -8999);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8998, 0.00, -91, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98999, -991, 0.00, 0, NULL, -8998);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8997, 0.00, -90, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98998, -990, 0.00, 0, NULL, -8997);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8996, 0.00, -89, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98997, -989, 0.00, 0, NULL, -8996);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8995, 0.00, -88, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98996, -988, 0.00, 0, NULL, -8995);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8994, 0.00, -87, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98995, -987, 0.00, 0, NULL, -8994);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8993, 0.00, -86, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98994, -986, 0.00, 0, NULL, -8993);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8992, 0.00, -85, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98993, -985, 0.00, 0, NULL, -8992);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9558, -9937, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9557, -9937, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9556, -9937, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9555, -9937, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9554, -9937, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9553, -9937, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9552, -9937, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8991, 0.00, -100, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98992, -1000, 0.00, 0, NULL, -8991);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8990, 0.00, -99, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98991, -999, 0.00, 0, NULL, -8990);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8989, 0.00, -98, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98990, -998, 0.00, 0, NULL, -8989);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8988, 0.00, -97, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98989, -997, 0.00, 0, NULL, -8988);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8987, 0.00, -96, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98988, -996, 0.00, 0, NULL, -8987);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8986, 0.00, -95, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98987, -995, 0.00, 0, NULL, -8986);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8985, 0.00, -94, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98986, -994, 0.00, 0, NULL, -8985);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8984, 0.00, -93, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98985, -993, 0.00, 0, NULL, -8984);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8983, 0.00, -92, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98984, -992, 0.00, 0, NULL, -8983);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8982, 0.00, -91, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98983, -991, 0.00, 0, NULL, -8982);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8981, 0.00, -90, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98982, -990, 0.00, 0, NULL, -8981);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8980, 0.00, -89, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98981, -989, 0.00, 0, NULL, -8980);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8979, 0.00, -88, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98980, -988, 0.00, 0, NULL, -8979);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8978, 0.00, -87, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98979, -987, 0.00, 0, NULL, -8978);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8977, 0.00, -86, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98978, -986, 0.00, 0, NULL, -8977);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8976, 0.00, -85, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98977, -985, 0.00, 0, NULL, -8976);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9551, -9936, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9550, -9936, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9549, -9936, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9548, -9936, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9547, -9936, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9546, -9936, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9545, -9936, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8975, 0.00, -100, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98976, -1000, 0.00, 0, NULL, -8975);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8974, 0.00, -99, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98975, -999, 0.00, 0, NULL, -8974);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8973, 0.00, -98, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98974, -998, 0.00, 0, NULL, -8973);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8972, 0.00, -97, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98973, -997, 0.00, 0, NULL, -8972);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8971, 0.00, -96, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98972, -996, 0.00, 0, NULL, -8971);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8970, 0.00, -95, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98971, -995, 0.00, 0, NULL, -8970);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8969, 0.00, -94, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98970, -994, 0.00, 0, NULL, -8969);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8968, 0.00, -93, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98969, -993, 0.00, 0, NULL, -8968);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8967, 0.00, -92, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98968, -992, 0.00, 0, NULL, -8967);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8966, 0.00, -91, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98967, -991, 0.00, 0, NULL, -8966);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8965, 0.00, -90, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98966, -990, 0.00, 0, NULL, -8965);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8964, 0.00, -89, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98965, -989, 0.00, 0, NULL, -8964);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8963, 0.00, -88, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98964, -988, 0.00, 0, NULL, -8963);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8962, 0.00, -87, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98963, -987, 0.00, 0, NULL, -8962);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8961, 0.00, -86, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98962, -986, 0.00, 0, NULL, -8961);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8960, 0.00, -85, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98961, -985, 0.00, 0, NULL, -8960);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9544, -9935, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9543, -9935, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9542, -9935, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9541, -9935, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9540, -9935, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9539, -9935, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9538, -9935, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8959, 0.00, -100, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98960, -1000, 0.00, 0, NULL, -8959);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8958, 0.00, -99, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98959, -999, 0.00, 0, NULL, -8958);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8957, 0.00, -98, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98958, -998, 0.00, 0, NULL, -8957);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8956, 0.00, -97, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98957, -997, 0.00, 0, NULL, -8956);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8955, 0.00, -96, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98956, -996, 0.00, 0, NULL, -8955);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8954, 0.00, -95, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98955, -995, 0.00, 0, NULL, -8954);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8953, 0.00, -94, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98954, -994, 0.00, 0, NULL, -8953);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8952, 0.00, -93, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98953, -993, 0.00, 0, NULL, -8952);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8951, 0.00, -92, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98952, -992, 0.00, 0, NULL, -8951);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8950, 0.00, -91, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98951, -991, 0.00, 0, NULL, -8950);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8949, 0.00, -90, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98950, -990, 0.00, 0, NULL, -8949);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8948, 0.00, -89, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98949, -989, 0.00, 0, NULL, -8948);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8947, 0.00, -88, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98948, -988, 0.00, 0, NULL, -8947);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8946, 0.00, -87, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98947, -987, 0.00, 0, NULL, -8946);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8945, 0.00, -86, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98946, -986, 0.00, 0, NULL, -8945);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8944, 0.00, -85, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98945, -985, 0.00, 0, NULL, -8944);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9537, -9934, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9536, -9934, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9535, -9934, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9534, -9934, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9533, -9934, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9532, -9934, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9531, -9934, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8943, 0.00, -100, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98944, -1000, 0.00, 0, NULL, -8943);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8942, 0.00, -99, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98943, -999, 0.00, 0, NULL, -8942);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8941, 0.00, -98, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98942, -998, 0.00, 0, NULL, -8941);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8940, 0.00, -97, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98941, -997, 0.00, 0, NULL, -8940);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8939, 0.00, -96, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98940, -996, 0.00, 0, NULL, -8939);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8938, 0.00, -95, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98939, -995, 0.00, 0, NULL, -8938);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8937, 0.00, -94, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98938, -994, 0.00, 0, NULL, -8937);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8936, 0.00, -93, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98937, -993, 0.00, 0, NULL, -8936);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8935, 0.00, -92, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98936, -992, 0.00, 0, NULL, -8935);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8934, 0.00, -91, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98935, -991, 0.00, 0, NULL, -8934);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8933, 0.00, -90, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98934, -990, 0.00, 0, NULL, -8933);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8932, 0.00, -89, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98933, -989, 0.00, 0, NULL, -8932);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8931, 0.00, -88, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98932, -988, 0.00, 0, NULL, -8931);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8930, 0.00, -87, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98931, -987, 0.00, 0, NULL, -8930);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8929, 0.00, -86, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98930, -986, 0.00, 0, NULL, -8929);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8928, 0.00, -85, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98929, -985, 0.00, 0, NULL, -8928);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9530, -9933, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9529, -9933, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9528, -9933, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9527, -9933, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9526, -9933, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9525, -9933, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9524, -9933, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8927, 0.00, -100, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98928, -1000, 0.00, 0, NULL, -8927);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8926, 0.00, -99, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98927, -999, 0.00, 0, NULL, -8926);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8925, 0.00, -98, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98926, -998, 0.00, 0, NULL, -8925);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8924, 0.00, -97, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98925, -997, 0.00, 0, NULL, -8924);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8923, 0.00, -96, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98924, -996, 0.00, 0, NULL, -8923);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8922, 0.00, -95, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98923, -995, 0.00, 0, NULL, -8922);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8921, 0.00, -94, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98922, -994, 0.00, 0, NULL, -8921);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8920, 0.00, -93, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98921, -993, 0.00, 0, NULL, -8920);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8919, 0.00, -92, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98920, -992, 0.00, 0, NULL, -8919);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8918, 0.00, -91, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98919, -991, 0.00, 0, NULL, -8918);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8917, 0.00, -90, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98918, -990, 0.00, 0, NULL, -8917);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8916, 0.00, -89, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98917, -989, 0.00, 0, NULL, -8916);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8915, 0.00, -88, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98916, -988, 0.00, 0, NULL, -8915);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8914, 0.00, -87, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98915, -987, 0.00, 0, NULL, -8914);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8913, 0.00, -86, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98914, -986, 0.00, 0, NULL, -8913);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8912, 0.00, -85, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98913, -985, 0.00, 0, NULL, -8912);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9523, -9932, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9522, -9932, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9521, -9932, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9520, -9932, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9519, -9932, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9518, -9932, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9517, -9932, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8911, 0.00, -100, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98912, -1000, 0.00, 0, NULL, -8911);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8910, 0.00, -99, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98911, -999, 0.00, 0, NULL, -8910);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8909, 0.00, -98, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98910, -998, 0.00, 0, NULL, -8909);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8908, 0.00, -97, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98909, -997, 0.00, 0, NULL, -8908);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8907, 0.00, -96, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98908, -996, 0.00, 0, NULL, -8907);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8906, 0.00, -95, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98907, -995, 0.00, 0, NULL, -8906);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8905, 0.00, -94, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98906, -994, 0.00, 0, NULL, -8905);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8904, 0.00, -93, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98905, -993, 0.00, 0, NULL, -8904);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8903, 0.00, -92, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98904, -992, 0.00, 0, NULL, -8903);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8902, 0.00, -91, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98903, -991, 0.00, 0, NULL, -8902);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8901, 0.00, -90, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98902, -990, 0.00, 0, NULL, -8901);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8900, 0.00, -89, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98901, -989, 0.00, 0, NULL, -8900);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8899, 0.00, -88, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98900, -988, 0.00, 0, NULL, -8899);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8898, 0.00, -87, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98899, -987, 0.00, 0, NULL, -8898);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8897, 0.00, -86, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98898, -986, 0.00, 0, NULL, -8897);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8896, 0.00, -85, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98897, -985, 0.00, 0, NULL, -8896);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9516, -9931, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9515, -9931, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9514, -9931, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9513, -9931, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9512, -9931, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9511, -9931, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9510, -9931, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8895, 0.00, -100, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98896, -1000, 0.00, 0, NULL, -8895);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8894, 0.00, -99, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98895, -999, 0.00, 0, NULL, -8894);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8893, 0.00, -98, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98894, -998, 0.00, 0, NULL, -8893);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8892, 0.00, -97, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98893, -997, 0.00, 0, NULL, -8892);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8891, 0.00, -96, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98892, -996, 0.00, 0, NULL, -8891);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8890, 0.00, -95, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98891, -995, 0.00, 0, NULL, -8890);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8889, 0.00, -94, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98890, -994, 0.00, 0, NULL, -8889);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8888, 0.00, -93, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98889, -993, 0.00, 0, NULL, -8888);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8887, 0.00, -92, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98888, -992, 0.00, 0, NULL, -8887);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8886, 0.00, -91, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98887, -991, 0.00, 0, NULL, -8886);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8885, 0.00, -90, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98886, -990, 0.00, 0, NULL, -8885);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8884, 0.00, -89, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98885, -989, 0.00, 0, NULL, -8884);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8883, 0.00, -88, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98884, -988, 0.00, 0, NULL, -8883);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8882, 0.00, -87, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98883, -987, 0.00, 0, NULL, -8882);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8881, 0.00, -86, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98882, -986, 0.00, 0, NULL, -8881);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8880, 0.00, -85, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98881, -985, 0.00, 0, NULL, -8880);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9509, -9930, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9508, -9930, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9507, -9930, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9506, -9930, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9505, -9930, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9504, -9930, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9503, -9930, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8879, 0.00, -100, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98880, -1000, 0.00, 0, NULL, -8879);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8878, 0.00, -99, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98879, -999, 0.00, 0, NULL, -8878);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8877, 0.00, -98, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98878, -998, 0.00, 0, NULL, -8877);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8876, 0.00, -97, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98877, -997, 0.00, 0, NULL, -8876);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8875, 0.00, -96, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98876, -996, 0.00, 0, NULL, -8875);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8874, 0.00, -95, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98875, -995, 0.00, 0, NULL, -8874);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8873, 0.00, -94, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98874, -994, 0.00, 0, NULL, -8873);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8872, 0.00, -93, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98873, -993, 0.00, 0, NULL, -8872);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8871, 0.00, -92, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98872, -992, 0.00, 0, NULL, -8871);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8870, 0.00, -91, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98871, -991, 0.00, 0, NULL, -8870);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8869, 0.00, -90, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98870, -990, 0.00, 0, NULL, -8869);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8868, 0.00, -89, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98869, -989, 0.00, 0, NULL, -8868);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8867, 0.00, -88, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98868, -988, 0.00, 0, NULL, -8867);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8866, 0.00, -87, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98867, -987, 0.00, 0, NULL, -8866);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8865, 0.00, -86, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98866, -986, 0.00, 0, NULL, -8865);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8864, 0.00, -85, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98865, -985, 0.00, 0, NULL, -8864);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9502, -9929, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9501, -9929, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9500, -9929, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9499, -9929, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9498, -9929, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9497, -9929, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9496, -9929, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8863, 0.00, -100, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98864, -1000, 0.00, 0, NULL, -8863);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8862, 0.00, -99, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98863, -999, 0.00, 0, NULL, -8862);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8861, 0.00, -98, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98862, -998, 0.00, 0, NULL, -8861);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8860, 0.00, -97, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98861, -997, 0.00, 0, NULL, -8860);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8859, 0.00, -96, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98860, -996, 0.00, 0, NULL, -8859);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8858, 0.00, -95, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98859, -995, 0.00, 0, NULL, -8858);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8857, 0.00, -94, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98858, -994, 0.00, 0, NULL, -8857);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8856, 0.00, -93, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98857, -993, 0.00, 0, NULL, -8856);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8855, 0.00, -92, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98856, -992, 0.00, 0, NULL, -8855);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8854, 0.00, -91, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98855, -991, 0.00, 0, NULL, -8854);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8853, 0.00, -90, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98854, -990, 0.00, 0, NULL, -8853);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8852, 0.00, -89, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98853, -989, 0.00, 0, NULL, -8852);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8851, 0.00, -88, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98852, -988, 0.00, 0, NULL, -8851);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8850, 0.00, -87, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98851, -987, 0.00, 0, NULL, -8850);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8849, 0.00, -86, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98850, -986, 0.00, 0, NULL, -8849);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8848, 0.00, -85, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98849, -985, 0.00, 0, NULL, -8848);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9495, -9928, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9494, -9928, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9493, -9928, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9492, -9928, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9491, -9928, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9490, -9928, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9489, -9928, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8847, 0.00, -100, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98848, -1000, 0.00, 0, NULL, -8847);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8846, 0.00, -99, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98847, -999, 0.00, 0, NULL, -8846);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8845, 0.00, -98, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98846, -998, 0.00, 0, NULL, -8845);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8844, 0.00, -97, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98845, -997, 0.00, 0, NULL, -8844);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8843, 0.00, -96, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98844, -996, 0.00, 0, NULL, -8843);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8842, 0.00, -95, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98843, -995, 0.00, 0, NULL, -8842);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8841, 0.00, -94, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98842, -994, 0.00, 0, NULL, -8841);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8840, 0.00, -93, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98841, -993, 0.00, 0, NULL, -8840);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8839, 0.00, -92, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98840, -992, 0.00, 0, NULL, -8839);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8838, 0.00, -91, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98839, -991, 0.00, 0, NULL, -8838);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8837, 0.00, -90, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98838, -990, 0.00, 0, NULL, -8837);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8836, 0.00, -89, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98837, -989, 0.00, 0, NULL, -8836);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8835, 0.00, -88, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98836, -988, 0.00, 0, NULL, -8835);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8834, 0.00, -87, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98835, -987, 0.00, 0, NULL, -8834);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8833, 0.00, -86, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98834, -986, 0.00, 0, NULL, -8833);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8832, 0.00, -85, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98833, -985, 0.00, 0, NULL, -8832);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9488, -9927, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9487, -9927, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9486, -9927, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9485, -9927, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9484, -9927, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9483, -9927, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9482, -9927, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8831, 0.00, -100, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98832, -1000, 0.00, 0, NULL, -8831);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8830, 0.00, -99, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98831, -999, 0.00, 0, NULL, -8830);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8829, 0.00, -98, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98830, -998, 0.00, 0, NULL, -8829);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8828, 0.00, -97, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98829, -997, 0.00, 0, NULL, -8828);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8827, 0.00, -96, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98828, -996, 0.00, 0, NULL, -8827);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8826, 0.00, -95, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98827, -995, 0.00, 0, NULL, -8826);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8825, 0.00, -94, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98826, -994, 0.00, 0, NULL, -8825);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8824, 0.00, -93, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98825, -993, 0.00, 0, NULL, -8824);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8823, 0.00, -92, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98824, -992, 0.00, 0, NULL, -8823);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8822, 0.00, -91, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98823, -991, 0.00, 0, NULL, -8822);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8821, 0.00, -90, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98822, -990, 0.00, 0, NULL, -8821);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8820, 0.00, -89, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98821, -989, 0.00, 0, NULL, -8820);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8819, 0.00, -88, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98820, -988, 0.00, 0, NULL, -8819);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8818, 0.00, -87, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98819, -987, 0.00, 0, NULL, -8818);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8817, 0.00, -86, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98818, -986, 0.00, 0, NULL, -8817);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8816, 0.00, -85, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98817, -985, 0.00, 0, NULL, -8816);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9481, -9926, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9480, -9926, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9479, -9926, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9478, -9926, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9477, -9926, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9476, -9926, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9475, -9926, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8815, 0.00, -100, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98816, -1000, 0.00, 0, NULL, -8815);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8814, 0.00, -99, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98815, -999, 0.00, 0, NULL, -8814);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8813, 0.00, -98, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98814, -998, 0.00, 0, NULL, -8813);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8812, 0.00, -97, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98813, -997, 0.00, 0, NULL, -8812);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8811, 0.00, -96, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98812, -996, 0.00, 0, NULL, -8811);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8810, 0.00, -95, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98811, -995, 0.00, 0, NULL, -8810);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8809, 0.00, -94, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98810, -994, 0.00, 0, NULL, -8809);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8808, 0.00, -93, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98809, -993, 0.00, 0, NULL, -8808);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8807, 0.00, -92, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98808, -992, 0.00, 0, NULL, -8807);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8806, 0.00, -91, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98807, -991, 0.00, 0, NULL, -8806);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8805, 0.00, -90, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98806, -990, 0.00, 0, NULL, -8805);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8804, 0.00, -89, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98805, -989, 0.00, 0, NULL, -8804);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8803, 0.00, -88, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98804, -988, 0.00, 0, NULL, -8803);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8802, 0.00, -87, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98803, -987, 0.00, 0, NULL, -8802);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8801, 0.00, -86, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98802, -986, 0.00, 0, NULL, -8801);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8800, 0.00, -85, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98801, -985, 0.00, 0, NULL, -8800);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9474, -9925, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9473, -9925, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9472, -9925, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9471, -9925, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9470, -9925, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9469, -9925, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9468, -9925, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8799, 0.00, -100, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98800, -1000, 0.00, 0, NULL, -8799);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8798, 0.00, -99, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98799, -999, 0.00, 0, NULL, -8798);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8797, 0.00, -98, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98798, -998, 0.00, 0, NULL, -8797);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8796, 0.00, -97, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98797, -997, 0.00, 0, NULL, -8796);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8795, 0.00, -96, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98796, -996, 0.00, 0, NULL, -8795);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8794, 0.00, -95, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98795, -995, 0.00, 0, NULL, -8794);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8793, 0.00, -94, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98794, -994, 0.00, 0, NULL, -8793);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8792, 0.00, -93, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98793, -993, 0.00, 0, NULL, -8792);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8791, 0.00, -92, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98792, -992, 0.00, 0, NULL, -8791);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8790, 0.00, -91, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98791, -991, 0.00, 0, NULL, -8790);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8789, 0.00, -90, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98790, -990, 0.00, 0, NULL, -8789);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8788, 0.00, -89, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98789, -989, 0.00, 0, NULL, -8788);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8787, 0.00, -88, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98788, -988, 0.00, 0, NULL, -8787);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8786, 0.00, -87, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98787, -987, 0.00, 0, NULL, -8786);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8785, 0.00, -86, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98786, -986, 0.00, 0, NULL, -8785);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8784, 0.00, -85, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98785, -985, 0.00, 0, NULL, -8784);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9467, -9924, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9466, -9924, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9465, -9924, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9464, -9924, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9463, -9924, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9462, -9924, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9461, -9924, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8783, 0.00, -100, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98784, -1000, 0.00, 0, NULL, -8783);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8782, 0.00, -99, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98783, -999, 0.00, 0, NULL, -8782);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8781, 0.00, -98, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98782, -998, 0.00, 0, NULL, -8781);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8780, 0.00, -97, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98781, -997, 0.00, 0, NULL, -8780);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8779, 0.00, -96, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98780, -996, 0.00, 0, NULL, -8779);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8778, 0.00, -95, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98779, -995, 0.00, 0, NULL, -8778);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8777, 0.00, -94, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98778, -994, 0.00, 0, NULL, -8777);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8776, 0.00, -93, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98777, -993, 0.00, 0, NULL, -8776);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8775, 0.00, -92, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98776, -992, 0.00, 0, NULL, -8775);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8774, 0.00, -91, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98775, -991, 0.00, 0, NULL, -8774);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8773, 0.00, -90, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98774, -990, 0.00, 0, NULL, -8773);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8772, 0.00, -89, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98773, -989, 0.00, 0, NULL, -8772);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8771, 0.00, -88, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98772, -988, 0.00, 0, NULL, -8771);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8770, 0.00, -87, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98771, -987, 0.00, 0, NULL, -8770);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8769, 0.00, -86, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98770, -986, 0.00, 0, NULL, -8769);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8768, 0.00, -85, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98769, -985, 0.00, 0, NULL, -8768);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9460, -9923, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9459, -9923, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9458, -9923, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9457, -9923, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9456, -9923, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9455, -9923, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9454, -9923, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8767, 0.00, -100, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98768, -1000, 0.00, 0, NULL, -8767);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8766, 0.00, -99, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98767, -999, 0.00, 0, NULL, -8766);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8765, 0.00, -98, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98766, -998, 0.00, 0, NULL, -8765);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8764, 0.00, -97, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98765, -997, 0.00, 0, NULL, -8764);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8763, 0.00, -96, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98764, -996, 0.00, 0, NULL, -8763);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8762, 0.00, -95, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98763, -995, 0.00, 0, NULL, -8762);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8761, 0.00, -94, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98762, -994, 0.00, 0, NULL, -8761);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8760, 0.00, -93, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98761, -993, 0.00, 0, NULL, -8760);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8759, 0.00, -92, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98760, -992, 0.00, 0, NULL, -8759);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8758, 0.00, -91, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98759, -991, 0.00, 0, NULL, -8758);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8757, 0.00, -90, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98758, -990, 0.00, 0, NULL, -8757);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8756, 0.00, -89, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98757, -989, 0.00, 0, NULL, -8756);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8755, 0.00, -88, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98756, -988, 0.00, 0, NULL, -8755);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8754, 0.00, -87, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98755, -987, 0.00, 0, NULL, -8754);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8753, 0.00, -86, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98754, -986, 0.00, 0, NULL, -8753);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8752, 0.00, -85, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98753, -985, 0.00, 0, NULL, -8752);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9453, -9922, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9452, -9922, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9451, -9922, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9450, -9922, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9449, -9922, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9448, -9922, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9447, -9922, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8751, 0.00, -100, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98752, -1000, 0.00, 0, NULL, -8751);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8750, 0.00, -99, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98751, -999, 0.00, 0, NULL, -8750);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8749, 0.00, -98, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98750, -998, 0.00, 0, NULL, -8749);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8748, 0.00, -97, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98749, -997, 0.00, 0, NULL, -8748);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8747, 0.00, -96, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98748, -996, 0.00, 0, NULL, -8747);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8746, 0.00, -95, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98747, -995, 0.00, 0, NULL, -8746);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8745, 0.00, -94, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98746, -994, 0.00, 0, NULL, -8745);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8744, 0.00, -93, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98745, -993, 0.00, 0, NULL, -8744);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8743, 0.00, -92, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98744, -992, 0.00, 0, NULL, -8743);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8742, 0.00, -91, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98743, -991, 0.00, 0, NULL, -8742);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8741, 0.00, -90, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98742, -990, 0.00, 0, NULL, -8741);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8740, 0.00, -89, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98741, -989, 0.00, 0, NULL, -8740);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8739, 0.00, -88, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98740, -988, 0.00, 0, NULL, -8739);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8738, 0.00, -87, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98739, -987, 0.00, 0, NULL, -8738);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8737, 0.00, -86, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98738, -986, 0.00, 0, NULL, -8737);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8736, 0.00, -85, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98737, -985, 0.00, 0, NULL, -8736);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9446, -9921, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9445, -9921, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9444, -9921, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9443, -9921, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9442, -9921, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9441, -9921, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9440, -9921, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8735, 0.00, -100, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98736, -1000, 0.00, 0, NULL, -8735);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8734, 0.00, -99, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98735, -999, 0.00, 0, NULL, -8734);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8733, 0.00, -98, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98734, -998, 0.00, 0, NULL, -8733);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8732, 0.00, -97, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98733, -997, 0.00, 0, NULL, -8732);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8731, 0.00, -96, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98732, -996, 0.00, 0, NULL, -8731);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8730, 0.00, -95, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98731, -995, 0.00, 0, NULL, -8730);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8729, 0.00, -94, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98730, -994, 0.00, 0, NULL, -8729);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8728, 0.00, -93, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98729, -993, 0.00, 0, NULL, -8728);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8727, 0.00, -92, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98728, -992, 0.00, 0, NULL, -8727);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8726, 0.00, -91, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98727, -991, 0.00, 0, NULL, -8726);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8725, 0.00, -90, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98726, -990, 0.00, 0, NULL, -8725);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8724, 0.00, -89, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98725, -989, 0.00, 0, NULL, -8724);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8723, 0.00, -88, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98724, -988, 0.00, 0, NULL, -8723);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8722, 0.00, -87, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98723, -987, 0.00, 0, NULL, -8722);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8721, 0.00, -86, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98722, -986, 0.00, 0, NULL, -8721);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8720, 0.00, -85, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98721, -985, 0.00, 0, NULL, -8720);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9439, -9920, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9438, -9920, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9437, -9920, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9436, -9920, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9435, -9920, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9434, -9920, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9433, -9920, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8719, 0.00, -100, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98720, -1000, 0.00, 0, NULL, -8719);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8718, 0.00, -99, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98719, -999, 0.00, 0, NULL, -8718);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8717, 0.00, -98, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98718, -998, 0.00, 0, NULL, -8717);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8716, 0.00, -97, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98717, -997, 0.00, 0, NULL, -8716);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8715, 0.00, -96, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98716, -996, 0.00, 0, NULL, -8715);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8714, 0.00, -95, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98715, -995, 0.00, 0, NULL, -8714);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8713, 0.00, -94, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98714, -994, 0.00, 0, NULL, -8713);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8712, 0.00, -93, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98713, -993, 0.00, 0, NULL, -8712);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8711, 0.00, -92, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98712, -992, 0.00, 0, NULL, -8711);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8710, 0.00, -91, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98711, -991, 0.00, 0, NULL, -8710);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8709, 0.00, -90, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98710, -990, 0.00, 0, NULL, -8709);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8708, 0.00, -89, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98709, -989, 0.00, 0, NULL, -8708);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8707, 0.00, -88, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98708, -988, 0.00, 0, NULL, -8707);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8706, 0.00, -87, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98707, -987, 0.00, 0, NULL, -8706);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8705, 0.00, -86, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98706, -986, 0.00, 0, NULL, -8705);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8704, 0.00, -85, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98705, -985, 0.00, 0, NULL, -8704);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9432, -9919, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9431, -9919, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9430, -9919, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9429, -9919, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9428, -9919, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9427, -9919, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9426, -9919, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8703, 0.00, -100, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98704, -1000, 0.00, 0, NULL, -8703);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8702, 0.00, -99, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98703, -999, 0.00, 0, NULL, -8702);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8701, 0.00, -98, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98702, -998, 0.00, 0, NULL, -8701);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8700, 0.00, -97, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98701, -997, 0.00, 0, NULL, -8700);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8699, 0.00, -96, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98700, -996, 0.00, 0, NULL, -8699);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8698, 0.00, -95, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98699, -995, 0.00, 0, NULL, -8698);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8697, 0.00, -94, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98698, -994, 0.00, 0, NULL, -8697);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8696, 0.00, -93, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98697, -993, 0.00, 0, NULL, -8696);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8695, 0.00, -92, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98696, -992, 0.00, 0, NULL, -8695);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8694, 0.00, -91, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98695, -991, 0.00, 0, NULL, -8694);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8693, 0.00, -90, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98694, -990, 0.00, 0, NULL, -8693);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8692, 0.00, -89, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98693, -989, 0.00, 0, NULL, -8692);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8691, 0.00, -88, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98692, -988, 0.00, 0, NULL, -8691);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8690, 0.00, -87, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98691, -987, 0.00, 0, NULL, -8690);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8689, 0.00, -86, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98690, -986, 0.00, 0, NULL, -8689);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8688, 0.00, -85, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98689, -985, 0.00, 0, NULL, -8688);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9425, -9918, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9424, -9918, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9423, -9918, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9422, -9918, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9421, -9918, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9420, -9918, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9419, -9918, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8687, 0.00, -100, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98688, -1000, 0.00, 0, NULL, -8687);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8686, 0.00, -99, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98687, -999, 0.00, 0, NULL, -8686);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8685, 0.00, -98, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98686, -998, 0.00, 0, NULL, -8685);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8684, 0.00, -97, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98685, -997, 0.00, 0, NULL, -8684);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8683, 0.00, -96, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98684, -996, 0.00, 0, NULL, -8683);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8682, 0.00, -95, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98683, -995, 0.00, 0, NULL, -8682);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8681, 0.00, -94, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98682, -994, 0.00, 0, NULL, -8681);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8680, 0.00, -93, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98681, -993, 0.00, 0, NULL, -8680);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8679, 0.00, -92, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98680, -992, 0.00, 0, NULL, -8679);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8678, 0.00, -91, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98679, -991, 0.00, 0, NULL, -8678);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8677, 0.00, -90, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98678, -990, 0.00, 0, NULL, -8677);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8676, 0.00, -89, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98677, -989, 0.00, 0, NULL, -8676);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8675, 0.00, -88, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98676, -988, 0.00, 0, NULL, -8675);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8674, 0.00, -87, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98675, -987, 0.00, 0, NULL, -8674);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8673, 0.00, -86, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98674, -986, 0.00, 0, NULL, -8673);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8672, 0.00, -85, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98673, -985, 0.00, 0, NULL, -8672);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9418, -9917, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9417, -9917, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9416, -9917, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9415, -9917, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9414, -9917, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9413, -9917, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9412, -9917, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8671, 0.00, -100, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98672, -1000, 0.00, 0, NULL, -8671);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8670, 0.00, -99, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98671, -999, 0.00, 0, NULL, -8670);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8669, 0.00, -98, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98670, -998, 0.00, 0, NULL, -8669);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8668, 0.00, -97, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98669, -997, 0.00, 0, NULL, -8668);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8667, 0.00, -96, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98668, -996, 0.00, 0, NULL, -8667);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8666, 0.00, -95, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98667, -995, 0.00, 0, NULL, -8666);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8665, 0.00, -94, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98666, -994, 0.00, 0, NULL, -8665);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8664, 0.00, -93, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98665, -993, 0.00, 0, NULL, -8664);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8663, 0.00, -92, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98664, -992, 0.00, 0, NULL, -8663);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8662, 0.00, -91, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98663, -991, 0.00, 0, NULL, -8662);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8661, 0.00, -90, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98662, -990, 0.00, 0, NULL, -8661);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8660, 0.00, -89, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98661, -989, 0.00, 0, NULL, -8660);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8659, 0.00, -88, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98660, -988, 0.00, 0, NULL, -8659);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8658, 0.00, -87, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98659, -987, 0.00, 0, NULL, -8658);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8657, 0.00, -86, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98658, -986, 0.00, 0, NULL, -8657);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8656, 0.00, -85, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98657, -985, 0.00, 0, NULL, -8656);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9411, -9916, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9410, -9916, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9409, -9916, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9408, -9916, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9407, -9916, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9406, -9916, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9405, -9916, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8655, 0.00, -100, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98656, -1000, 0.00, 0, NULL, -8655);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8654, 0.00, -99, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98655, -999, 0.00, 0, NULL, -8654);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8653, 0.00, -98, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98654, -998, 0.00, 0, NULL, -8653);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8652, 0.00, -97, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98653, -997, 0.00, 0, NULL, -8652);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8651, 0.00, -96, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98652, -996, 0.00, 0, NULL, -8651);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8650, 0.00, -95, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98651, -995, 0.00, 0, NULL, -8650);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8649, 0.00, -94, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98650, -994, 0.00, 0, NULL, -8649);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8648, 0.00, -93, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98649, -993, 0.00, 0, NULL, -8648);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8647, 0.00, -92, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98648, -992, 0.00, 0, NULL, -8647);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8646, 0.00, -91, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98647, -991, 0.00, 0, NULL, -8646);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8645, 0.00, -90, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98646, -990, 0.00, 0, NULL, -8645);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8644, 0.00, -89, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98645, -989, 0.00, 0, NULL, -8644);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8643, 0.00, -88, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98644, -988, 0.00, 0, NULL, -8643);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8642, 0.00, -87, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98643, -987, 0.00, 0, NULL, -8642);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8641, 0.00, -86, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98642, -986, 0.00, 0, NULL, -8641);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8640, 0.00, -85, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98641, -985, 0.00, 0, NULL, -8640);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9404, -9915, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9403, -9915, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9402, -9915, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9401, -9915, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9400, -9915, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9399, -9915, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9398, -9915, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8639, 0.00, -100, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98640, -1000, 0.00, 0, NULL, -8639);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8638, 0.00, -99, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98639, -999, 0.00, 0, NULL, -8638);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8637, 0.00, -98, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98638, -998, 0.00, 0, NULL, -8637);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8636, 0.00, -97, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98637, -997, 0.00, 0, NULL, -8636);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8635, 0.00, -96, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98636, -996, 0.00, 0, NULL, -8635);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8634, 0.00, -95, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98635, -995, 0.00, 0, NULL, -8634);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8633, 0.00, -94, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98634, -994, 0.00, 0, NULL, -8633);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8632, 0.00, -93, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98633, -993, 0.00, 0, NULL, -8632);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8631, 0.00, -92, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98632, -992, 0.00, 0, NULL, -8631);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8630, 0.00, -91, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98631, -991, 0.00, 0, NULL, -8630);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8629, 0.00, -90, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98630, -990, 0.00, 0, NULL, -8629);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8628, 0.00, -89, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98629, -989, 0.00, 0, NULL, -8628);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8627, 0.00, -88, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98628, -988, 0.00, 0, NULL, -8627);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8626, 0.00, -87, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98627, -987, 0.00, 0, NULL, -8626);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8625, 0.00, -86, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98626, -986, 0.00, 0, NULL, -8625);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8624, 0.00, -85, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98625, -985, 0.00, 0, NULL, -8624);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9397, -9914, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9396, -9914, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9395, -9914, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9394, -9914, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9393, -9914, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9392, -9914, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9391, -9914, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8623, 0.00, -100, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98624, -1000, 0.00, 0, NULL, -8623);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8622, 0.00, -99, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98623, -999, 0.00, 0, NULL, -8622);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8621, 0.00, -98, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98622, -998, 0.00, 0, NULL, -8621);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8620, 0.00, -97, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98621, -997, 0.00, 0, NULL, -8620);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8619, 0.00, -96, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98620, -996, 0.00, 0, NULL, -8619);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8618, 0.00, -95, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98619, -995, 0.00, 0, NULL, -8618);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8617, 0.00, -94, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98618, -994, 0.00, 0, NULL, -8617);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8616, 0.00, -93, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98617, -993, 0.00, 0, NULL, -8616);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8615, 0.00, -92, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98616, -992, 0.00, 0, NULL, -8615);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8614, 0.00, -91, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98615, -991, 0.00, 0, NULL, -8614);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8613, 0.00, -90, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98614, -990, 0.00, 0, NULL, -8613);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8612, 0.00, -89, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98613, -989, 0.00, 0, NULL, -8612);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8611, 0.00, -88, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98612, -988, 0.00, 0, NULL, -8611);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8610, 0.00, -87, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98611, -987, 0.00, 0, NULL, -8610);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8609, 0.00, -86, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98610, -986, 0.00, 0, NULL, -8609);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8608, 0.00, -85, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98609, -985, 0.00, 0, NULL, -8608);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9390, -9913, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9389, -9913, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9388, -9913, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9387, -9913, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9386, -9913, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9385, -9913, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9384, -9913, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8607, 0.00, -100, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98608, -1000, 0.00, 0, NULL, -8607);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8606, 0.00, -99, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98607, -999, 0.00, 0, NULL, -8606);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8605, 0.00, -98, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98606, -998, 0.00, 0, NULL, -8605);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8604, 0.00, -97, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98605, -997, 0.00, 0, NULL, -8604);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8603, 0.00, -96, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98604, -996, 0.00, 0, NULL, -8603);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8602, 0.00, -95, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98603, -995, 0.00, 0, NULL, -8602);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8601, 0.00, -94, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98602, -994, 0.00, 0, NULL, -8601);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8600, 0.00, -93, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98601, -993, 0.00, 0, NULL, -8600);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8599, 0.00, -92, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98600, -992, 0.00, 0, NULL, -8599);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8598, 0.00, -91, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98599, -991, 0.00, 0, NULL, -8598);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8597, 0.00, -90, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98598, -990, 0.00, 0, NULL, -8597);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8596, 0.00, -89, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98597, -989, 0.00, 0, NULL, -8596);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8595, 0.00, -88, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98596, -988, 0.00, 0, NULL, -8595);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8594, 0.00, -87, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98595, -987, 0.00, 0, NULL, -8594);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8593, 0.00, -86, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98594, -986, 0.00, 0, NULL, -8593);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8592, 0.00, -85, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98593, -985, 0.00, 0, NULL, -8592);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9383, -9912, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9382, -9912, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9381, -9912, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9380, -9912, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9379, -9912, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9378, -9912, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9377, -9912, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8591, 0.00, -100, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98592, -1000, 0.00, 0, NULL, -8591);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8590, 0.00, -99, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98591, -999, 0.00, 0, NULL, -8590);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8589, 0.00, -98, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98590, -998, 0.00, 0, NULL, -8589);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8588, 0.00, -97, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98589, -997, 0.00, 0, NULL, -8588);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8587, 0.00, -96, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98588, -996, 0.00, 0, NULL, -8587);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8586, 0.00, -95, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98587, -995, 0.00, 0, NULL, -8586);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8585, 0.00, -94, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98586, -994, 0.00, 0, NULL, -8585);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8584, 0.00, -93, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98585, -993, 0.00, 0, NULL, -8584);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8583, 0.00, -92, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98584, -992, 0.00, 0, NULL, -8583);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8582, 0.00, -91, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98583, -991, 0.00, 0, NULL, -8582);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8581, 0.00, -90, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98582, -990, 0.00, 0, NULL, -8581);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8580, 0.00, -89, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98581, -989, 0.00, 0, NULL, -8580);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8579, 0.00, -88, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98580, -988, 0.00, 0, NULL, -8579);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8578, 0.00, -87, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98579, -987, 0.00, 0, NULL, -8578);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8577, 0.00, -86, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98578, -986, 0.00, 0, NULL, -8577);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8576, 0.00, -85, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98577, -985, 0.00, 0, NULL, -8576);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9376, -9911, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9375, -9911, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9374, -9911, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9373, -9911, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9372, -9911, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9371, -9911, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9370, -9911, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8575, 0.00, -100, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98576, -1000, 0.00, 0, NULL, -8575);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8574, 0.00, -99, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98575, -999, 0.00, 0, NULL, -8574);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8573, 0.00, -98, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98574, -998, 0.00, 0, NULL, -8573);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8572, 0.00, -97, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98573, -997, 0.00, 0, NULL, -8572);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8571, 0.00, -96, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98572, -996, 0.00, 0, NULL, -8571);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8570, 0.00, -95, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98571, -995, 0.00, 0, NULL, -8570);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8569, 0.00, -94, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98570, -994, 0.00, 0, NULL, -8569);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8568, 0.00, -93, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98569, -993, 0.00, 0, NULL, -8568);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8567, 0.00, -92, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98568, -992, 0.00, 0, NULL, -8567);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8566, 0.00, -91, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98567, -991, 0.00, 0, NULL, -8566);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8565, 0.00, -90, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98566, -990, 0.00, 0, NULL, -8565);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8564, 0.00, -89, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98565, -989, 0.00, 0, NULL, -8564);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8563, 0.00, -88, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98564, -988, 0.00, 0, NULL, -8563);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8562, 0.00, -87, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98563, -987, 0.00, 0, NULL, -8562);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8561, 0.00, -86, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98562, -986, 0.00, 0, NULL, -8561);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8560, 0.00, -85, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98561, -985, 0.00, 0, NULL, -8560);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9369, -9910, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9368, -9910, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9367, -9910, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9366, -9910, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9365, -9910, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9364, -9910, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9363, -9910, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8559, 0.00, -100, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98560, -1000, 0.00, 0, NULL, -8559);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8558, 0.00, -99, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98559, -999, 0.00, 0, NULL, -8558);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8557, 0.00, -98, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98558, -998, 0.00, 0, NULL, -8557);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8556, 0.00, -97, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98557, -997, 0.00, 0, NULL, -8556);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8555, 0.00, -96, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98556, -996, 0.00, 0, NULL, -8555);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8554, 0.00, -95, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98555, -995, 0.00, 0, NULL, -8554);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8553, 0.00, -94, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98554, -994, 0.00, 0, NULL, -8553);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8552, 0.00, -93, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98553, -993, 0.00, 0, NULL, -8552);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8551, 0.00, -92, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98552, -992, 0.00, 0, NULL, -8551);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8550, 0.00, -91, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98551, -991, 0.00, 0, NULL, -8550);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8549, 0.00, -90, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98550, -990, 0.00, 0, NULL, -8549);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8548, 0.00, -89, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98549, -989, 0.00, 0, NULL, -8548);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8547, 0.00, -88, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98548, -988, 0.00, 0, NULL, -8547);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8546, 0.00, -87, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98547, -987, 0.00, 0, NULL, -8546);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8545, 0.00, -86, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98546, -986, 0.00, 0, NULL, -8545);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8544, 0.00, -85, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98545, -985, 0.00, 0, NULL, -8544);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9362, -9909, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9361, -9909, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9360, -9909, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9359, -9909, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9358, -9909, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9357, -9909, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9356, -9909, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8543, 0.00, -100, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98544, -1000, 0.00, 0, NULL, -8543);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8542, 0.00, -99, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98543, -999, 0.00, 0, NULL, -8542);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8541, 0.00, -98, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98542, -998, 0.00, 0, NULL, -8541);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8540, 0.00, -97, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98541, -997, 0.00, 0, NULL, -8540);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8539, 0.00, -96, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98540, -996, 0.00, 0, NULL, -8539);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8538, 0.00, -95, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98539, -995, 0.00, 0, NULL, -8538);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8537, 0.00, -94, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98538, -994, 0.00, 0, NULL, -8537);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8536, 0.00, -93, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98537, -993, 0.00, 0, NULL, -8536);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8535, 0.00, -92, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98536, -992, 0.00, 0, NULL, -8535);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8534, 0.00, -91, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98535, -991, 0.00, 0, NULL, -8534);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8533, 0.00, -90, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98534, -990, 0.00, 0, NULL, -8533);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8532, 0.00, -89, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98533, -989, 0.00, 0, NULL, -8532);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8531, 0.00, -88, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98532, -988, 0.00, 0, NULL, -8531);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8530, 0.00, -87, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98531, -987, 0.00, 0, NULL, -8530);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8529, 0.00, -86, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98530, -986, 0.00, 0, NULL, -8529);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8528, 0.00, -85, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98529, -985, 0.00, 0, NULL, -8528);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9355, -9908, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9354, -9908, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9353, -9908, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9352, -9908, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9351, -9908, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9350, -9908, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9349, -9908, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8527, 0.00, -100, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98528, -1000, 0.00, 0, NULL, -8527);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8526, 0.00, -99, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98527, -999, 0.00, 0, NULL, -8526);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8525, 0.00, -98, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98526, -998, 0.00, 0, NULL, -8525);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8524, 0.00, -97, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98525, -997, 0.00, 0, NULL, -8524);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8523, 0.00, -96, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98524, -996, 0.00, 0, NULL, -8523);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8522, 0.00, -95, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98523, -995, 0.00, 0, NULL, -8522);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8521, 0.00, -94, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98522, -994, 0.00, 0, NULL, -8521);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8520, 0.00, -93, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98521, -993, 0.00, 0, NULL, -8520);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8519, 0.00, -92, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98520, -992, 0.00, 0, NULL, -8519);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8518, 0.00, -91, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98519, -991, 0.00, 0, NULL, -8518);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8517, 0.00, -90, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98518, -990, 0.00, 0, NULL, -8517);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8516, 0.00, -89, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98517, -989, 0.00, 0, NULL, -8516);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8515, 0.00, -88, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98516, -988, 0.00, 0, NULL, -8515);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8514, 0.00, -87, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98515, -987, 0.00, 0, NULL, -8514);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8513, 0.00, -86, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98514, -986, 0.00, 0, NULL, -8513);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8512, 0.00, -85, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98513, -985, 0.00, 0, NULL, -8512);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9348, -9907, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9347, -9907, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9346, -9907, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9345, -9907, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9344, -9907, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9343, -9907, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9342, -9907, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8511, 0.00, -100, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98512, -1000, 0.00, 0, NULL, -8511);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8510, 0.00, -99, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98511, -999, 0.00, 0, NULL, -8510);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8509, 0.00, -98, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98510, -998, 0.00, 0, NULL, -8509);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8508, 0.00, -97, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98509, -997, 0.00, 0, NULL, -8508);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8507, 0.00, -96, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98508, -996, 0.00, 0, NULL, -8507);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8506, 0.00, -95, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98507, -995, 0.00, 0, NULL, -8506);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8505, 0.00, -94, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98506, -994, 0.00, 0, NULL, -8505);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8504, 0.00, -93, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98505, -993, 0.00, 0, NULL, -8504);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8503, 0.00, -92, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98504, -992, 0.00, 0, NULL, -8503);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8502, 0.00, -91, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98503, -991, 0.00, 0, NULL, -8502);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8501, 0.00, -90, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98502, -990, 0.00, 0, NULL, -8501);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8500, 0.00, -89, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98501, -989, 0.00, 0, NULL, -8500);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8499, 0.00, -88, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98500, -988, 0.00, 0, NULL, -8499);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8498, 0.00, -87, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98499, -987, 0.00, 0, NULL, -8498);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8497, 0.00, -86, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98498, -986, 0.00, 0, NULL, -8497);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8496, 0.00, -85, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98497, -985, 0.00, 0, NULL, -8496);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9341, -9906, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9340, -9906, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9339, -9906, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9338, -9906, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9337, -9906, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9336, -9906, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9335, -9906, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8495, 0.00, -100, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98496, -1000, 0.00, 0, NULL, -8495);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8494, 0.00, -99, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98495, -999, 0.00, 0, NULL, -8494);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8493, 0.00, -98, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98494, -998, 0.00, 0, NULL, -8493);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8492, 0.00, -97, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98493, -997, 0.00, 0, NULL, -8492);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8491, 0.00, -96, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98492, -996, 0.00, 0, NULL, -8491);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8490, 0.00, -95, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98491, -995, 0.00, 0, NULL, -8490);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8489, 0.00, -94, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98490, -994, 0.00, 0, NULL, -8489);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8488, 0.00, -93, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98489, -993, 0.00, 0, NULL, -8488);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8487, 0.00, -92, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98488, -992, 0.00, 0, NULL, -8487);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8486, 0.00, -91, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98487, -991, 0.00, 0, NULL, -8486);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8485, 0.00, -90, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98486, -990, 0.00, 0, NULL, -8485);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8484, 0.00, -89, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98485, -989, 0.00, 0, NULL, -8484);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8483, 0.00, -88, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98484, -988, 0.00, 0, NULL, -8483);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8482, 0.00, -87, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98483, -987, 0.00, 0, NULL, -8482);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8481, 0.00, -86, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98482, -986, 0.00, 0, NULL, -8481);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8480, 0.00, -85, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98481, -985, 0.00, 0, NULL, -8480);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9334, -9905, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9333, -9905, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9332, -9905, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9331, -9905, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9330, -9905, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9329, -9905, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9328, -9905, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8479, 0.00, -100, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98480, -1000, 0.00, 0, NULL, -8479);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8478, 0.00, -99, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98479, -999, 0.00, 0, NULL, -8478);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8477, 0.00, -98, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98478, -998, 0.00, 0, NULL, -8477);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8476, 0.00, -97, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98477, -997, 0.00, 0, NULL, -8476);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8475, 0.00, -96, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98476, -996, 0.00, 0, NULL, -8475);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8474, 0.00, -95, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98475, -995, 0.00, 0, NULL, -8474);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8473, 0.00, -94, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98474, -994, 0.00, 0, NULL, -8473);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8472, 0.00, -93, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98473, -993, 0.00, 0, NULL, -8472);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8471, 0.00, -92, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98472, -992, 0.00, 0, NULL, -8471);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8470, 0.00, -91, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98471, -991, 0.00, 0, NULL, -8470);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8469, 0.00, -90, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98470, -990, 0.00, 0, NULL, -8469);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8468, 0.00, -89, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98469, -989, 0.00, 0, NULL, -8468);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8467, 0.00, -88, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98468, -988, 0.00, 0, NULL, -8467);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8466, 0.00, -87, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98467, -987, 0.00, 0, NULL, -8466);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8465, 0.00, -86, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98466, -986, 0.00, 0, NULL, -8465);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8464, 0.00, -85, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98465, -985, 0.00, 0, NULL, -8464);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9327, -9904, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9326, -9904, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9325, -9904, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9324, -9904, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9323, -9904, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9322, -9904, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9321, -9904, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8463, 0.00, -100, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98464, -1000, 0.00, 0, NULL, -8463);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8462, 0.00, -99, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98463, -999, 0.00, 0, NULL, -8462);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8461, 0.00, -98, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98462, -998, 0.00, 0, NULL, -8461);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8460, 0.00, -97, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98461, -997, 0.00, 0, NULL, -8460);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8459, 0.00, -96, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98460, -996, 0.00, 0, NULL, -8459);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8458, 0.00, -95, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98459, -995, 0.00, 0, NULL, -8458);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8457, 0.00, -94, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98458, -994, 0.00, 0, NULL, -8457);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8456, 0.00, -93, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98457, -993, 0.00, 0, NULL, -8456);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8455, 0.00, -92, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98456, -992, 0.00, 0, NULL, -8455);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8454, 0.00, -91, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98455, -991, 0.00, 0, NULL, -8454);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8453, 0.00, -90, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98454, -990, 0.00, 0, NULL, -8453);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8452, 0.00, -89, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98453, -989, 0.00, 0, NULL, -8452);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8451, 0.00, -88, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98452, -988, 0.00, 0, NULL, -8451);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8450, 0.00, -87, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98451, -987, 0.00, 0, NULL, -8450);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8449, 0.00, -86, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98450, -986, 0.00, 0, NULL, -8449);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8448, 0.00, -85, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98449, -985, 0.00, 0, NULL, -8448);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9320, -9903, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9319, -9903, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9318, -9903, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9317, -9903, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9316, -9903, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9315, -9903, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9314, -9903, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8447, 0.00, -100, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98448, -1000, 0.00, 0, NULL, -8447);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8446, 0.00, -99, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98447, -999, 0.00, 0, NULL, -8446);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8445, 0.00, -98, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98446, -998, 0.00, 0, NULL, -8445);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8444, 0.00, -97, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98445, -997, 0.00, 0, NULL, -8444);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8443, 0.00, -96, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98444, -996, 0.00, 0, NULL, -8443);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8442, 0.00, -95, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98443, -995, 0.00, 0, NULL, -8442);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8441, 0.00, -94, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98442, -994, 0.00, 0, NULL, -8441);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8440, 0.00, -93, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98441, -993, 0.00, 0, NULL, -8440);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8439, 0.00, -92, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98440, -992, 0.00, 0, NULL, -8439);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8438, 0.00, -91, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98439, -991, 0.00, 0, NULL, -8438);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8437, 0.00, -90, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98438, -990, 0.00, 0, NULL, -8437);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8436, 0.00, -89, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98437, -989, 0.00, 0, NULL, -8436);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8435, 0.00, -88, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98436, -988, 0.00, 0, NULL, -8435);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8434, 0.00, -87, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98435, -987, 0.00, 0, NULL, -8434);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8433, 0.00, -86, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98434, -986, 0.00, 0, NULL, -8433);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8432, 0.00, -85, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98433, -985, 0.00, 0, NULL, -8432);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9313, -9902, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9312, -9902, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9311, -9902, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9310, -9902, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9309, -9902, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9308, -9902, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9307, -9902, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8431, 0.00, -100, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98432, -1000, 0.00, 0, NULL, -8431);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8430, 0.00, -99, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98431, -999, 0.00, 0, NULL, -8430);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8429, 0.00, -98, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98430, -998, 0.00, 0, NULL, -8429);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8428, 0.00, -97, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98429, -997, 0.00, 0, NULL, -8428);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8427, 0.00, -96, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98428, -996, 0.00, 0, NULL, -8427);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8426, 0.00, -95, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98427, -995, 0.00, 0, NULL, -8426);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8425, 0.00, -94, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98426, -994, 0.00, 0, NULL, -8425);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8424, 0.00, -93, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98425, -993, 0.00, 0, NULL, -8424);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8423, 0.00, -92, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98424, -992, 0.00, 0, NULL, -8423);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8422, 0.00, -91, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98423, -991, 0.00, 0, NULL, -8422);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8421, 0.00, -90, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98422, -990, 0.00, 0, NULL, -8421);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8420, 0.00, -89, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98421, -989, 0.00, 0, NULL, -8420);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8419, 0.00, -88, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98420, -988, 0.00, 0, NULL, -8419);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8418, 0.00, -87, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98419, -987, 0.00, 0, NULL, -8418);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8417, 0.00, -86, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98418, -986, 0.00, 0, NULL, -8417);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8416, 0.00, -85, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98417, -985, 0.00, 0, NULL, -8416);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9306, -9901, -100, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9305, -9901, -99, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9304, -9901, -98, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9303, -9901, -97, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9302, -9901, -96, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9301, -9901, -95, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9300, -9901, -94, '9/27/2022 10:03:00 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8415, 0.00, -100, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98416, -1000, 0.00, 0, NULL, -8415);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8414, 0.00, -99, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98415, -999, 0.00, 0, NULL, -8414);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8413, 0.00, -98, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98414, -998, 0.00, 0, NULL, -8413);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8412, 0.00, -97, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98413, -997, 0.00, 0, NULL, -8412);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8411, 0.00, -96, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98412, -996, 0.00, 0, NULL, -8411);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8410, 0.00, -95, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98411, -995, 0.00, 0, NULL, -8410);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8409, 0.00, -94, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98410, -994, 0.00, 0, NULL, -8409);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8408, 0.00, -93, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98409, -993, 0.00, 0, NULL, -8408);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8407, 0.00, -92, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98408, -992, 0.00, 0, NULL, -8407);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8406, 0.00, -91, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98407, -991, 0.00, 0, NULL, -8406);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8405, 0.00, -90, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98406, -990, 0.00, 0, NULL, -8405);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8404, 0.00, -89, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98405, -989, 0.00, 0, NULL, -8404);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8403, 0.00, -88, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98404, -988, 0.00, 0, NULL, -8403);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8402, 0.00, -87, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98403, -987, 0.00, 0, NULL, -8402);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8401, 0.00, -86, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98402, -986, 0.00, 0, NULL, -8401);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-8400, 0.00, -85, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-98401, -985, 0.00, 0, NULL, -8400);

INSERT INTO public."GroupMemberships"(
    "Id", "LearnerGroupId", "LearnerId", "InstructorId", "Role")
VALUES (-1000, -9999, -10000, null, 0);

INSERT INTO public."GroupMemberships"(
    "Id", "LearnerGroupId", "LearnerId", "InstructorId", "Role")
VALUES (-999, -9999, null, -30000, 1);

INSERT INTO public."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-1000, -100, -30000);