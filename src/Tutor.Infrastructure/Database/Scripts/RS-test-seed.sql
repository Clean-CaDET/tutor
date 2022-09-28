
DELETE FROM public."EmotionsFeedbacks";
DELETE FROM public."TutorImprovementFeedbacks";
DELETE FROM public."Notes";

DELETE FROM public."AssessmentItemMasteries";
DELETE FROM public."KcMasteries";
DELETE FROM public."UnitEnrollments";
DELETE FROM public."GroupMemberships";
DELETE FROM public."LearnerGroups";
DELETE FROM public."CourseOwnerships";
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

DELETE FROM public."Learners";
DELETE FROM public."Instructors";
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
	(-10000, 'RA-1-2021', 'l69gloJt4kQkfrk3Nw73ARhMBFQ1B/mlEef/zv+h510=', '+FEAPtdtHqqlpSjsWNFs+g==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-10000, -10000, 'RA-1-2021', 'Pera', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9999, 'RA-2-2021', '50+e7yN3Wbn9yp2DfKSsFC1hPNyDESCuA3daMbZnUZ4=', 'fsBxQhVtD1uUmSzR6r0TWg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9999, -9999, 'RA-2-2021', 'Marko', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9998, 'RA-3-2021', '9tnX0x8YxBLkgZA+ZZ6ZLX37Ym1CdK84KQqJ4GUPgJw=', 'wv6DLstSGSceiNvahZ1tng==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9998, -9998, 'RA-3-2021', 'Mika', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9997, 'RA-4-2021', 'g/yAx2WEpG1JYGmdnN32nRvSKDGZDU4nzwZ3AB3Ls8s=', 'ldZTBc2QQS/JjMiMP/QkdA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9997, -9997, 'RA-4-2021', 'Stefan', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9996, 'RA-5-2021', 'imTOKtKeFQ+43U7VCF3YaEF+PnivB0Y+RyEc0/vHbqo=', 'uKIaPsCDai7gCXVVhEo4uA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9996, -9996, 'RA-5-2021', 'Franc', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9995, 'RA-6-2021', 'tltG1mNBa6QIWH8Eynjk9B7w1OwcA0LggXeQCVmchvA=', 'izjwtVcWz3l5Trq2fwp3zw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9995, -9995, 'RA-6-2021', 'Ranc', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9994, 'RA-7-2021', 'bF0rrHtsrWA9DB1l2+vGWLd07d2RESgufi0laDq2C9g=', 'WW19UZzoSOkUfwitFaSIqg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9994, -9994, 'RA-7-2021', 'Kranc', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9993, 'RA-8-2021', 'qqGWCwkvXjOmWf9VcW+gYla9BOk5qtsrCs/7AuFk2aM=', 'M6ao7ko0Zm1xmCuEEUJZ6g==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9993, -9993, 'RA-8-2021', 'Jelena', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9992, 'RA-1-2022', 'jBSsHD+N1EMYHUKzqiwTOQhEaO+3uIuWXaIsHteayWE=', 'Qj+QrUJ+TyzO79jz/i/TeQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9992, -9992, 'RA-1-2022', 'Milenko', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9991, 'RA-2-2022', 'VP44dX9OCeZ8M02jfSBIJSPZpwSFE5pvMAn6SFgSOTM=', 'bIKfdt0o+1ymGQscXTvp8w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9991, -9991, 'RA-2-2022', 'Nikola', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9990, 'RA-3-2022', 'kJ+yJJufpcy4naPxdzQ8bC7sYMIhIOW3cb1zysTXMW8=', '7kWaRjckHq35KmQgYMMzIA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9990, -9990, 'RA-3-2022', 'Pera', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9989, 'RA-4-2022', 'kKDOZ2u4+hVlmPpFPIzGFYUfUhTZ3m9gc9eYZM8PhJc=', 'QHGKyf4c2xjAlureN+i+xw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9989, -9989, 'RA-4-2022', 'Marko', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9988, 'RA-5-2022', 'iTa3tsfcIz7SW+qKMoLgnaYPAxQElGS1iqwPEDRpNjc=', 'W4VzUPWI27+mfho6IcOyPQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9988, -9988, 'RA-5-2022', 'Mika', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9987, 'RA-6-2022', '8j+LRUz8nohD8zNsY0gMRYMl3CidIpJX8Wbi378b9d4=', 'seYQ/8NFIoiPKFiu+iqPqA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9987, -9987, 'RA-6-2022', 'Stefan', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9986, 'RA-7-2022', 'PtiaDNPToMpTHSBpONw2rJB5T9GYBsahRQnyhmnuk7I=', 'cNhVV/5Wp6LtY/2ib/nDig==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9986, -9986, 'RA-7-2022', 'Franc', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9985, 'RA-8-2022', 'qCgS2Pa6fKCjhpPH7vjoSoZPyI0WgC3dfHEsTnSVbS0=', 'BIQbQ9MuNwOor5SD/Gxv/A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9985, -9985, 'RA-8-2022', 'Ranc', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9984, 'RA-1-2023', 'iZ7jMuh36Rq2+2vLRA/A6OoNWhU+HRZBF7b7H7MLCc0=', 'tpQ5hizRp2cXbZWaS7oZqw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9984, -9984, 'RA-1-2023', 'Kranc', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9983, 'RA-2-2023', 'lXjXeC8VQAzovMvAltUsoJhVxJGObufb4mGwX7q0oG0=', 'K9d9KhHuSV6OnUVfrtt7gw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9983, -9983, 'RA-2-2023', 'Jelena', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9982, 'RA-3-2023', 'OFTtzhAwdRJy8kFjaQns1cUZ0BpN2y5dk5jqw7efVqg=', 'n4pnOTlynK9tL2dEN81J0Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9982, -9982, 'RA-3-2023', 'Milenko', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9981, 'RA-4-2023', 'M/EDdX2wwU2BQ+wvmBCPmZ3lCLM0ih8ZTSyXwJNapW0=', 'Va17t9VWaOE0pVMFnFAykw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9981, -9981, 'RA-4-2023', 'Nikola', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9980, 'RA-5-2023', 'JKEdYYNO1/GlwRkDnKNdKIllQ0QmQ7GUgMvk3EFKEUY=', '58+irCO0pXj61AZJLD0Kbw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9980, -9980, 'RA-5-2023', 'Pera', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9979, 'RA-6-2023', 'QguITf5MJGPYSLrkagvOF0eQ8vtEE27JNzkvJMTD/P0=', 'WIGR2ZCDXCfleAL0a54dCA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9979, -9979, 'RA-6-2023', 'Marko', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9978, 'RA-7-2023', 'SWL0PGUbRLeDiEZChZv1sCzLzSKOEwXF5aQeCvkGFZI=', 'sIr+pBn62kpkunJRmuz+sQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9978, -9978, 'RA-7-2023', 'Mika', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9977, 'RA-8-2023', 'l96SYImyYgZknEk13W4HhzGU8/jUdz2kUUQKISKRHzY=', '7IFzjk5mKIvLa5xsF7iAWw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9977, -9977, 'RA-8-2023', 'Stefan', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9976, 'RA-1-2024', 'lSc5GXe4ZMnr5LMlSqkAA6JBvJAjJ9MWxeVnpYp4aI8=', 'lFY9Cd2eSo0UuiOT0KThQQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9976, -9976, 'RA-1-2024', 'Franc', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9975, 'RA-2-2024', '24jagE9GJaqzgqcwaw/Ahf9BKxZCyyofwRSe4arNNVI=', 'i7HkvAJuq/5XjyKgNCFx1A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9975, -9975, 'RA-2-2024', 'Ranc', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9974, 'RA-3-2024', 'HXCzfwGJ7a7JTaKrbwMlvoN6iL6Kd5N5lRDZ4MtfmWw=', 'UG/WewGdCTqz5SutJO/KTw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9974, -9974, 'RA-3-2024', 'Kranc', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9973, 'RA-4-2024', '86lMTo3Lnl3wYvioG5fFSNMC3qglp2aEENvNIgTfvFI=', 'slQQmJ3cJEtMmClvUIzEyQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9973, -9973, 'RA-4-2024', 'Jelena', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9972, 'RA-5-2024', 'rShyhbyW8Hyy823QRWzmnWvsWo66N88raJcbVuiu00s=', 'uULB7ELl7ZYnlLXOgPWRpA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9972, -9972, 'RA-5-2024', 'Milenko', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9971, 'RA-6-2024', 'qC6fNKKWluaPvRyQV55YSKZvnIgRta4odBvp3vzbisw=', '09FWDA2pBsMV04Hoy2ZB6g==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9971, -9971, 'RA-6-2024', 'Nikola', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9970, 'RA-7-2024', 'B8cEPmuUJpTBuiy88lofFo5BT7jrEoZdtdnAiU7XcQI=', 'kuv1SLowUl6oF6vBPh55gw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9970, -9970, 'RA-7-2024', 'Pera', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9969, 'RA-8-2024', 'DHEJ/+QMl8kxChFbxpn0CtU9SbcdVCkYogDDbCGTPeM=', 'm0Z6Za1DfP0TeJPg4iM0rw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9969, -9969, 'RA-8-2024', 'Marko', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9968, 'RA-1-2025', 'ad/oZ7la5O/vdTUZ7GE8J8DUE3XCRkcoC4jkMPe19pI=', 'GbXdRZkajb5r1M7QqTTgjg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9968, -9968, 'RA-1-2025', 'Mika', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9967, 'RA-2-2025', 'ZXrTbbISnu9S7l9/7OD+UJFTs8obNN+50Xt6SC4YE+8=', 'akMgiHjOho3W9xrunT0LKQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9967, -9967, 'RA-2-2025', 'Stefan', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9966, 'RA-3-2025', 'PWE17CzNXd7k38aH6HxaxtzyFeRPA5O+VSxttHodbaw=', '0MMYLxSAZaUjGXiiTQ1PMg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9966, -9966, 'RA-3-2025', 'Franc', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9965, 'RA-4-2025', 'Ur16K+fUxkJhXr845qPAPUtQtQld7c2kA9P2RDwLhCY=', 'iNkmyT2D16mzlcluD+OElw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9965, -9965, 'RA-4-2025', 'Ranc', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9964, 'RA-5-2025', 'phtBOP2FOhz7q7e6UytlffJfWweeIRrFms2rrWHUzR8=', 'rmNf0I4tAlZVWW1nlj1QmA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9964, -9964, 'RA-5-2025', 'Kranc', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9963, 'RA-6-2025', 'wwK/NPLrbfebX5YoYRKzaLDiH8MSoyKEaceHre5/fAI=', 'hLmwtsk/WvtMd5RDA8yw2Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9963, -9963, 'RA-6-2025', 'Jelena', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9962, 'RA-7-2025', 'wS8Dmv6KWeE9XnzzXK7PryhbxL0vGb/3MzeKcgAcSj8=', 'YYhOCHGta4z+zfvq6wDWWA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9962, -9962, 'RA-7-2025', 'Milenko', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9961, 'RA-8-2025', 't3AHvKRtUVn5Yn7/Nk3vnLaXa0Idhi48gf/DiZhCCiU=', 'AQD3Lc/rwNUTWgP7TseP3A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9961, -9961, 'RA-8-2025', 'Nikola', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9960, 'RA-1-2026', 'e1yS22J/6JU1n7p5E/bkIIDRA8GsPGfmmtFvJfG/9WY=', 'FbrOjhBLQm/IIeDY7iTtyw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9960, -9960, 'RA-1-2026', 'Pera', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9959, 'RA-2-2026', '4Bp+35Yzral+GkoH0Z+7jaK5XrB4h5AcoYdiIg5USrQ=', '9DqpHcssOBeB5UPM/zE2yQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9959, -9959, 'RA-2-2026', 'Marko', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9958, 'RA-3-2026', 'Eo4tQeVlTMVqtKDKgvlnYs30HcuOhhlVCWoV3zOdS/s=', 'xGrW6+m1L5qwupHe4jrx+g==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9958, -9958, 'RA-3-2026', 'Mika', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9957, 'RA-4-2026', 'KlwapRdMXURBwnrS+DE541p8vmQTjqbXadEeM8eUybw=', '4xLfDJ2ZfIdPo3NLNbFziw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9957, -9957, 'RA-4-2026', 'Stefan', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9956, 'RA-5-2026', 'hV/HioLEer5bYvInIfw72DrfR197AvAECXh1t/ZJMec=', '4XvRqEu1W1CPuBj14Ycmnw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9956, -9956, 'RA-5-2026', 'Franc', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9955, 'GE-1-2021', 'nLz7uQT3bHmv496CHmcKoWI0893jFjGoupo89V0TiBM=', '4bwOjTKAdE5IbZS44IDxDA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9955, -9955, 'GE-1-2021', 'Nikola', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9954, 'GE-2-2021', 'wany7RdOwfEs9Ps97xkBuAFA6IwDQIann7nikwmnX5I=', 'fbIpr8VUEUeZ963wc2RCdQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9954, -9954, 'GE-2-2021', 'Pera', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9953, 'GE-3-2021', 'aFXcZWmwyXw3MSb3bL4VB7e9RXwmXCJlzcb80d+7Va8=', 'AkDMm03FqqSYZ+wd6c4BZg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9953, -9953, 'GE-3-2021', 'Marko', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9952, 'GE-4-2021', 'BCdzKbx0G0bKRUtbRWaYcVuD/sl9y8hNMhU9uESrB4Y=', 'a3Vk9QnqgdmAxJ8f6wb6vQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9952, -9952, 'GE-4-2021', 'Mika', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9951, 'GE-5-2021', 'fPgyijuqqDgLamQfQffYNhRIcUvj+Sxd8LkkS4vwYaU=', 'nn5BbU9yOQ5RHjaAbYy1aw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9951, -9951, 'GE-5-2021', 'Stefan', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9950, 'GE-6-2021', 'M+Y+o/W5gY8vkFEZl4pkj2k/3eOZ58K7Mj7O5cuzzJE=', 'lui68kZD8Og5tsoZOi3Www==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9950, -9950, 'GE-6-2021', 'Franc', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9949, 'GE-7-2021', 'KaHn1nWyF14VB5YYlgvOCbETL8M1eCId5MZrnJC8ysM=', 'TYXxYtgXTRWDMz/RNQTROg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9949, -9949, 'GE-7-2021', 'Ranc', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9948, 'GE-8-2021', 'QNqddwX/DNJqs2vl6HFekvhqYm1kYcwoF3DanJlCBYY=', 'GYbGNHtdXSP5py5RGt30Qg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9948, -9948, 'GE-8-2021', 'Kranc', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9947, 'GE-9-2021', '3ysX76KH4Vr03HL0yMQRf2w7X61c+19O/36byBrZtJo=', 'dyV1i/CEV068lApOuVdNYQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9947, -9947, 'GE-9-2021', 'Jelena', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9946, 'GE-10-2021', '+4VrPHethAfPXm7QD2uFhCnzXmfkYsn1R2L6bKRJCm8=', 'AVghZu75Gp/lnEuDopRwwA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9946, -9946, 'GE-10-2021', 'Milenko', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9945, 'GE-11-2021', 'p1zaMas7wFnFsWKNgQJIImzMsIPYtVuCS8A7tW0epkk=', 'kw8c9mO59It0pL8lnQVdcg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9945, -9945, 'GE-11-2021', 'Nikola', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9944, 'GE-12-2021', 'oqlAvXLNM9x2Jc4OgD5wo6i2k22LuCfkACOLxiCXY2s=', 'ATiIFevC5Xd7JNhDbtIvTQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9944, -9944, 'GE-12-2021', 'Pera', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9943, 'GE-13-2021', 'YIAEcExf1/xYazw9KZByfvARG+ACO5Z9U7z1Urn61K4=', '81efPeBvKFGtgkNtWZIYCw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9943, -9943, 'GE-13-2021', 'Marko', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9942, 'GE-14-2021', 'W2ZzQ4iFMORW341DMnEF0++sxlnv7r8mquE4o2t+2EY=', '4j8kA8BbnN6/MgcfeNMTBg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9942, -9942, 'GE-14-2021', 'Mika', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9941, 'GE-15-2021', 'sJoMqLGrwzFGPMjCi6GxhpIh2L+lBvtKTpbAQYqjngM=', 'A3AcsV3f0r6tuTVKSgE7jQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9941, -9941, 'GE-15-2021', 'Stefan', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9940, 'GE-16-2021', 'UrkeEOgXKJCYqzigTmzPRXhEkkTda1SMv5zMScWniNE=', '6+tjScpj0FIgAXHMBLqxpg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9940, -9940, 'GE-16-2021', 'Franc', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9939, 'GE-17-2021', 'TGJVQEQE3LQv8YN7F+pdKU2elw8qR2yqtsv3ayANlVg=', 'mZ+seh64OlYys3FJ5ZznMQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9939, -9939, 'GE-17-2021', 'Ranc', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9938, 'GE-18-2021', 'vl/hDBYI7bOUvVdht0zT2ewE3SGjPNVfA0fVnm4XFjs=', '8YP4q4EE5A5C4s+sQPbNvQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9938, -9938, 'GE-18-2021', 'Kranc', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9937, 'GE-19-2021', 'N7uqZf+WaEdZGTwVxsz6vZungHFevgBx8PI0XVVTWw4=', 'DZe6QilrUCwM1N28ZacGDw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9937, -9937, 'GE-19-2021', 'Jelena', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9936, 'GE-20-2021', 'Bp7eVd0bQ/dkgUPK11ZYk+886e74DWvZ9OfIDl09frs=', 'Q5mkWUkenaRSeHNxZcKDKQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9936, -9936, 'GE-20-2021', 'Milenko', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9935, 'GE-21-2021', '1AV8MbtHUaLF4+8WShaWwA3G+CXM7RzUHFvAi6O8SyE=', 'c9ub8NN+g5ntEOhMymuW8w==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9935, -9935, 'GE-21-2021', 'Nikola', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9934, 'GE-22-2021', '5UmvcsWc8n7fQfryYyi5stoiCVgTumRJQ97QOnHRLw4=', 'jmaCM8XHtH4w25vlYGWcfw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9934, -9934, 'GE-22-2021', 'Pera', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9933, 'GE-23-2021', 'peDxgjkNmmbgVzHJWaO65RR72bsAC8hKIEoyPYCEmao=', 'YtMMU3Sf52TKxArzYR/nFQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9933, -9933, 'GE-23-2021', 'Marko', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9932, 'GE-24-2021', 'B6AcId/8EG4UD3AZgB8cqgUQbYS8ab8ojX1XUlcO19c=', 'D8ayAbVd3669ffUdqfkmgQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9932, -9932, 'GE-24-2021', 'Mika', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9931, 'GE-25-2021', 'PiXHNN1vybszOPWO+M4nxOKnScn53nCTcgzHOO+1sI0=', '3CW4pXatHOhu1xEYBGOjOw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9931, -9931, 'GE-25-2021', 'Stefan', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9930, 'GE-26-2021', 'AtwPgnVxwtSRxCSc7aiTDFCVPWNDEcomSKI+vYIp0cM=', '5FBvBd/zYipTSTv8qGTYAA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9930, -9930, 'GE-26-2021', 'Franc', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9929, 'GE-27-2021', 'itHSaYR1s/2tRk8m+f9sfB9lHgjfnSnjWs/a+fW26YY=', 'R6mTNOxbJ8Y6PIlzWccIig==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9929, -9929, 'GE-27-2021', 'Ranc', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9928, 'GE-28-2021', '67+xvt0SEUHGVH+HyKBsN/WDTiGulZix5xLlBIDN+SI=', 'ihFEjGoJj+jYusm4oh16zA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9928, -9928, 'GE-28-2021', 'Kranc', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9927, 'GE-29-2021', 'Vw9bMr/dWkgRqnmT1f+Co3QTiPimYhV6xUrDzLAVDlo=', 'zt2mZ23YxVMVh7leGoYGmA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9927, -9927, 'GE-29-2021', 'Jelena', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9926, 'GE-30-2021', 'CNNy+kraB3kdUP77xX/1VfsV5B00X3DoNcn8R7UQrQM=', '55zF/muKnRScdcIJG2aPcw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9926, -9926, 'GE-30-2021', 'Milenko', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9925, 'GE-31-2021', 'thIBMJhiKZ9sVnbRp20Q5akK5H5es/ph/W/etGFJ1r4=', 'Z8O4GJWv5l/D+loLEMy3lQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9925, -9925, 'GE-31-2021', 'Nikola', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9924, 'GE-32-2021', 'fJIG3bx1gnmPk6cSYQw/iVCOXoCFYArsArj+r00NLjk=', 'eaZvLbLxQSLya6PqkJrqrw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9924, -9924, 'GE-32-2021', 'Pera', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9923, 'GE-33-2021', 'W8MTCG6gIVoP54u1YzBh+P3B7DcG0r0kYR1NGoy049g=', 'xHXJeqH3fyA4+NawHV5LgQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9923, -9923, 'GE-33-2021', 'Marko', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9922, 'GE-34-2021', 'tW5JLUdQSAFKNgn73cyVOCdVo5JER1RC0M5K/FTt9LQ=', 'JcvdSq4f4A4LeBgdPxO7LA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9922, -9922, 'GE-34-2021', 'Mika', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9921, 'GE-35-2021', 'r5+XOFzW+TSGboEXzXKKn/ILfUNrVsgzgoCdaznnF84=', '/3OqqKgpzrlJa7RSVTK2Cw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9921, -9921, 'GE-35-2021', 'Stefan', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9920, 'GE-36-2021', '/2uQIxDCJnRpm31WFLJBQSaU273/UvsOs4ELl2501PI=', '4cfICndAYsvVNKGHxqGG3Q==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9920, -9920, 'GE-36-2021', 'Franc', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9919, 'GE-37-2021', '8ZUuURxLV9hB/9vbOjotRLX1Wj7h08QJ1WZ5TeboxSw=', '1akRtbo1MWRbjUuorcC0Og==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9919, -9919, 'GE-37-2021', 'Ranc', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9918, 'GE-38-2021', 'YzgtdrN4APP8b0+8t5UI5GkzhL3fFPuBM4qLtjY7ZUY=', 'dAowWhqjwBUqaMvlui6jkw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9918, -9918, 'GE-38-2021', 'Kranc', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9917, 'GE-39-2021', 'Sy9uKf3Ktcs1461xi8c9Vw8bnhHJwcQGhiA/r1i1a+s=', 'ORoJRm7KWyhSfjf6KV+AZw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9917, -9917, 'GE-39-2021', 'Jelena', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9916, 'GE-40-2021', '6Z6FMUjra8C89bg9omjaO5mSjbCfqzbbK6VDUmlja0Q=', 'U/lSmFPyJS+Pp/oc1WdQNg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9916, -9916, 'GE-40-2021', 'Milenko', 'Perić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9915, 'GE-41-2021', 'ZfPFolfPALY/0ZeCezZVtnaVIOLHd2n5Cv2fejy0UGE=', 'hzFFpNau1PW43M+uuagKTg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9915, -9915, 'GE-41-2021', 'Nikola', 'Mikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9914, 'GE-42-2021', 'U4tJubuwwMJjUfqOM4udfzsQTgzfM957UqESL9I8oJM=', 'nOUpyoyocfx491I5qkyWsQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9914, -9914, 'GE-42-2021', 'Pera', 'Fikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9913, 'GE-43-2021', 'xcmoqq8LBfrQUt35h7pPLmKIslW9Gju9Lc8HmjtL/Gw=', 'kOoSTpqC7BeT9MSCn21llQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9913, -9913, 'GE-43-2021', 'Marko', 'Tikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9912, 'GE-44-2021', '80YXdv6df0u0ca6onSquRqPrO9j32mrIj8Q+lEO6Jr0=', 'sodBFkxJzfXJ2DWDpk3kAA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9912, -9912, 'GE-44-2021', 'Mika', 'Likić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9911, 'GE-45-2021', 'NFWEYqh/e9S3WAi0vGtvuW+IJcPjQUoqEWAMT7o+dhw=', 'zsq2CloCqNY7rSLUsazoeA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9911, -9911, 'GE-45-2021', 'Stefan', 'Kikić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9910, 'GE-46-2021', 'RpP7Dm+2uZbJNXwfc9RZqsqn5Ck0pRx1ZKEPjTNWdNA=', 'TUwEpM03F+AzHEokGfxdWA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9910, -9910, 'GE-46-2021', 'Franc', 'Sinić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9909, 'GE-47-2021', 'BMDazXAIVttHxVE49M4tpqDJ5k3SkY2QIRxSHculTYk=', 'TS4kjDGoTFwuTfroc5/XZg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9909, -9909, 'GE-47-2021', 'Ranc', 'Simić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9908, 'GE-48-2021', '5/H5ikPv8Z5MvSEeqS7wPH5kqa7/yA7oNXlG40Gu8Fc=', 'SQSgdGDmfls1n9wt8uBT/A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9908, -9908, 'GE-48-2021', 'Kranc', 'Milić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9907, 'GE-49-2021', 'LG4jeHqV7sDoyFd34Lj3T0L79YUenRGdVeVhd5kveRs=', 'bWLJC2ySF5OTusDEmfDAqw==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9907, -9907, 'GE-49-2021', 'Jelena', 'Mamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9906, 'GE-50-2021', 'vHDR8xdYrxuIHSl9daczBE6SeLMeLETa3/WQHdVr59o=', 'kWsV/qhX8vOmjXQNTc+MSQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9906, -9906, 'GE-50-2021', 'Milenko', 'Pamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9905, 'GE-51-2021', '3MzGLrLA9elfkpi5Ue0VAqtkdSA+J/ARPOQrgXrflpI=', 'nEymcIKJK+OWulk+QBbLrQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9905, -9905, 'GE-51-2021', 'Sladislav', 'Tamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9904, 'GE-52-2021', '80FtOEkbsaNlXhg7Ix+wF3UZFKANDKgGLaxJvB4dTKA=', 'aREDmHllRK7kWLkij+TgMQ==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9904, -9904, 'GE-52-2021', 'Vladislav', 'Kamić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9903, 'GE-53-2021', 'jUa89bbiAtckar3TB4AbTANbV9kf5Yt6GILy0CqOQhE=', 'iLT/00ORB+8wXku07FpAMg==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9903, -9903, 'GE-53-2021', 'Kranc', 'Lalić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9902, 'GE-54-2021', '0i9ERi7LzImmYahpDvo5Eo/J7dl6Wq+IeAYSCbabRRg=', 'S2AuXakqIuNey4gneHK8+A==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9902, -9902, 'GE-54-2021', 'Marko', 'Lekić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-9901, 'GE-58-2021', '9uu8Rg/7EM4R6iWgpHOgvQZLIeIHch8anJDIU3hgg/0=', 'jYabvO+IQ2uRL4h/VhHbSA==', 2);

INSERT INTO public."Learners"("Id", "UserId", "Index", "Name", "Surname") VALUES
	(-9901, -9901, 'GE-58-2021', 'Nikola', 'Kekić');



INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-30000, 'nikola.luburic', 'iW8RHEOkGuwth4Gn4z2Z2XOy8DXmE/7PjQe1SerzzyQ=', 'PpGe7DA/t9Tx2b7IeqYkNg==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-30000, -30000, 'Nikola', 'Luburić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-29999, 'natasa.rajtarov', 'nr6UQ1vdRiAvoRsY1ltpvgN4jzKYB1vktTQXe48ux44=', '/nHxZM7hNBskIijwmLDfkg==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-29999, -29999, 'Nataša', 'Rajtarov');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-29998, 'luka.doric', 'UcbQxuIy6D/3l3KuHMT6y9aXzZkKu1xuWOzcfk81xak=', '7sxstHAIVOy9cDRaQsPTTw==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-29998, -29998, 'Luka', 'Dorić');

INSERT INTO public."Users"("Id", "Username", "Password", "Salt", "Role") VALUES
	(-29997, 'simona.prokic', 'kAvRmlIYQaPF/8lF55GH9Y7j5Innah3DrsKoTTVADp0=', 'cv3g86yyx8Y7xxNjAiemrQ==', 1);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname") VALUES
	(-29997, -29997, 'Simona', 'Prokić');



INSERT INTO public."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES
	(-10000, -100, -29998);

INSERT INTO public."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES
	(-9999, -100, -29997);

INSERT INTO public."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES
	(-9998, -100, -30000);

INSERT INTO public."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES
	(-9997, -99, -30000);

INSERT INTO public."CourseOwnerships"("Id", "CourseId", "InstructorId") VALUES
	(-9996, -99, -29999);



INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-10000, 'RA-PSW 1', -100);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-100000, -10000, -29997, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99999, -10000, -10000, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99998, -10000, -9999, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99997, -10000, -9998, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99996, -10000, -9997, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99995, -10000, -9996, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99994, -10000, -9995, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99993, -10000, -9994, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99992, -10000, -9993, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99991, -10000, -9992, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99990, -10000, -9991, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99989, -10000, -9990, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99988, -10000, -9989, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99987, -10000, -9988, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99986, -10000, -9987, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99985, -10000, -9986, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99984, -10000, -9985, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9999, 'RA-PSW 2', -100);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99983, -9999, -29997, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99982, -9999, -9984, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99981, -9999, -9983, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99980, -9999, -9982, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99979, -9999, -9981, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99978, -9999, -9980, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99977, -9999, -9979, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99976, -9999, -9978, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99975, -9999, -9977, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99974, -9999, -9976, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99973, -9999, -9975, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99972, -9999, -9974, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99971, -9999, -9973, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99970, -9999, -9972, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99969, -9999, -9971, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99968, -9999, -9970, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99967, -9999, -9969, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9998, 'RA-PSW 3', -100);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99966, -9998, -29998, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99965, -9998, -9968, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99964, -9998, -9967, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99963, -9998, -9966, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99962, -9998, -9965, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99961, -9998, -9964, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99960, -9998, -9963, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99959, -9998, -9962, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99958, -9998, -9961, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99957, -9998, -9960, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99956, -9998, -9959, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99955, -9998, -9958, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99954, -9998, -9957, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99953, -9998, -9956, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9997, 'RA-PSW All', -100);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99952, -9997, -30000, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99951, -9997, -29998, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99950, -9997, -29997, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99949, -9997, -10000, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99948, -9997, -9999, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99947, -9997, -9998, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99946, -9997, -9997, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99945, -9997, -9996, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99944, -9997, -9995, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99943, -9997, -9994, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99942, -9997, -9993, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99941, -9997, -9992, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99940, -9997, -9991, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99939, -9997, -9990, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99938, -9997, -9989, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99937, -9997, -9988, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99936, -9997, -9987, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99935, -9997, -9986, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99934, -9997, -9985, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99933, -9997, -9984, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99932, -9997, -9983, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99931, -9997, -9982, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99930, -9997, -9981, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99929, -9997, -9980, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99928, -9997, -9979, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99927, -9997, -9978, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99926, -9997, -9977, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99925, -9997, -9976, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99924, -9997, -9975, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99923, -9997, -9974, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99922, -9997, -9973, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99921, -9997, -9972, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99920, -9997, -9971, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99919, -9997, -9970, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99918, -9997, -9969, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99917, -9997, -9968, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99916, -9997, -9967, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99915, -9997, -9966, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99914, -9997, -9965, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99913, -9997, -9964, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99912, -9997, -9963, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99911, -9997, -9962, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99910, -9997, -9961, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99909, -9997, -9960, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99908, -9997, -9959, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99907, -9997, -9958, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99906, -9997, -9957, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99905, -9997, -9956, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9996, 'GEO-RP 1', -99);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99904, -9996, -29999, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99903, -9996, -9955, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99902, -9996, -9954, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99901, -9996, -9953, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99900, -9996, -9952, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99899, -9996, -9951, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99898, -9996, -9950, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99897, -9996, -9949, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99896, -9996, -9948, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99895, -9996, -9947, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99894, -9996, -9946, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99893, -9996, -9945, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99892, -9996, -9944, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99891, -9996, -9943, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99890, -9996, -9942, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99889, -9996, -9941, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99888, -9996, -9940, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9995, 'GEO-RP 2', -99);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99887, -9995, -29999, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99886, -9995, -9939, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99885, -9995, -9938, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99884, -9995, -9937, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99883, -9995, -9936, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99882, -9995, -9935, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99881, -9995, -9934, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99880, -9995, -9933, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99879, -9995, -9932, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99878, -9995, -9931, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99877, -9995, -9930, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99876, -9995, -9929, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99875, -9995, -9928, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99874, -9995, -9927, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99873, -9995, -9926, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99872, -9995, -9925, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99871, -9995, -9924, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9994, 'GEO-RP 3', -99);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99870, -9994, -29999, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99869, -9994, -9923, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99868, -9994, -9922, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99867, -9994, -9921, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99866, -9994, -9920, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99865, -9994, -9919, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99864, -9994, -9918, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99863, -9994, -9917, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99862, -9994, -9916, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99861, -9994, -9915, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99860, -9994, -9914, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99859, -9994, -9913, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99858, -9994, -9912, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99857, -9994, -9911, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99856, -9994, -9910, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99855, -9994, -9909, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99854, -9994, -9908, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9993, 'GEO-RP 4', -99);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99853, -9993, -29999, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99852, -9993, -9907, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99851, -9993, -9906, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99850, -9993, -9905, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99849, -9993, -9904, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99848, -9993, -9903, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99847, -9993, -9902, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99846, -9993, -9901, 0);

INSERT INTO public."LearnerGroups"("Id", "Name", "CourseId") VALUES
	(-9992, 'GEO-RP All', -99);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99845, -9992, -29999, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "InstructorId", "Role") VALUES
	(-99844, -9992, -30000, 1);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99843, -9992, -9955, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99842, -9992, -9954, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99841, -9992, -9953, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99840, -9992, -9952, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99839, -9992, -9951, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99838, -9992, -9950, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99837, -9992, -9949, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99836, -9992, -9948, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99835, -9992, -9947, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99834, -9992, -9946, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99833, -9992, -9945, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99832, -9992, -9944, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99831, -9992, -9943, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99830, -9992, -9942, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99829, -9992, -9941, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99828, -9992, -9940, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99827, -9992, -9939, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99826, -9992, -9938, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99825, -9992, -9937, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99824, -9992, -9936, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99823, -9992, -9935, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99822, -9992, -9934, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99821, -9992, -9933, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99820, -9992, -9932, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99819, -9992, -9931, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99818, -9992, -9930, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99817, -9992, -9929, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99816, -9992, -9928, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99815, -9992, -9927, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99814, -9992, -9926, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99813, -9992, -9925, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99812, -9992, -9924, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99811, -9992, -9923, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99810, -9992, -9922, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99809, -9992, -9921, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99808, -9992, -9920, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99807, -9992, -9919, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99806, -9992, -9918, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99805, -9992, -9917, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99804, -9992, -9916, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99803, -9992, -9915, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99802, -9992, -9914, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99801, -9992, -9913, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99800, -9992, -9912, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99799, -9992, -9911, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99798, -9992, -9910, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99797, -9992, -9909, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99796, -9992, -9908, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99795, -9992, -9907, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99794, -9992, -9906, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99793, -9992, -9905, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99792, -9992, -9904, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99791, -9992, -9903, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99790, -9992, -9902, 0);

INSERT INTO public."GroupMemberships"("Id", "LearnerGroupId", "LearnerId", "Role") VALUES
	(-99789, -9992, -9901, 0);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9999, -10000, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9999, 0.00, -100, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-100000, -1000, 0.00, 0, NULL, -9999);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9998, -10000, -99, '9/28/2022 6:58:23 AM', 0);

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

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9997, -10000, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9995, 0.00, -96, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99996, -996, 0.00, 0, NULL, -9995);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9994, 0.00, -95, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99995, -995, 0.00, 0, NULL, -9994);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9996, -10000, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9993, 0.00, -94, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99994, -994, 0.00, 0, NULL, -9993);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9992, 0.00, -93, -10000, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99993, -993, 0.00, 0, NULL, -9992);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9995, -9999, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9991, 0.00, -100, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99992, -1000, 0.00, 0, NULL, -9991);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9994, -9999, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9990, 0.00, -99, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99991, -999, 0.00, 0, NULL, -9990);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9989, 0.00, -98, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99990, -998, 0.00, 0, NULL, -9989);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9988, 0.00, -97, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99989, -997, 0.00, 0, NULL, -9988);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9993, -9999, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9987, 0.00, -96, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99988, -996, 0.00, 0, NULL, -9987);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9986, 0.00, -95, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99987, -995, 0.00, 0, NULL, -9986);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9992, -9999, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9985, 0.00, -94, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99986, -994, 0.00, 0, NULL, -9985);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9984, 0.00, -93, -9999, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99985, -993, 0.00, 0, NULL, -9984);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9991, -9998, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9983, 0.00, -100, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99984, -1000, 0.00, 0, NULL, -9983);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9990, -9998, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9982, 0.00, -99, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99983, -999, 0.00, 0, NULL, -9982);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9981, 0.00, -98, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99982, -998, 0.00, 0, NULL, -9981);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9980, 0.00, -97, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99981, -997, 0.00, 0, NULL, -9980);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9989, -9998, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9979, 0.00, -96, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99980, -996, 0.00, 0, NULL, -9979);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9978, 0.00, -95, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99979, -995, 0.00, 0, NULL, -9978);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9988, -9998, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9977, 0.00, -94, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99978, -994, 0.00, 0, NULL, -9977);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9976, 0.00, -93, -9998, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99977, -993, 0.00, 0, NULL, -9976);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9987, -9997, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9975, 0.00, -100, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99976, -1000, 0.00, 0, NULL, -9975);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9986, -9997, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9974, 0.00, -99, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99975, -999, 0.00, 0, NULL, -9974);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9973, 0.00, -98, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99974, -998, 0.00, 0, NULL, -9973);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9972, 0.00, -97, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99973, -997, 0.00, 0, NULL, -9972);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9985, -9997, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9971, 0.00, -96, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99972, -996, 0.00, 0, NULL, -9971);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9970, 0.00, -95, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99971, -995, 0.00, 0, NULL, -9970);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9984, -9997, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9969, 0.00, -94, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99970, -994, 0.00, 0, NULL, -9969);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9968, 0.00, -93, -9997, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99969, -993, 0.00, 0, NULL, -9968);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9983, -9996, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9967, 0.00, -100, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99968, -1000, 0.00, 0, NULL, -9967);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9982, -9996, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9966, 0.00, -99, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99967, -999, 0.00, 0, NULL, -9966);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9965, 0.00, -98, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99966, -998, 0.00, 0, NULL, -9965);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9964, 0.00, -97, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99965, -997, 0.00, 0, NULL, -9964);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9981, -9996, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9963, 0.00, -96, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99964, -996, 0.00, 0, NULL, -9963);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9962, 0.00, -95, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99963, -995, 0.00, 0, NULL, -9962);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9980, -9996, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9961, 0.00, -94, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99962, -994, 0.00, 0, NULL, -9961);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9960, 0.00, -93, -9996, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99961, -993, 0.00, 0, NULL, -9960);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9979, -9995, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9959, 0.00, -100, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99960, -1000, 0.00, 0, NULL, -9959);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9978, -9995, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9958, 0.00, -99, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99959, -999, 0.00, 0, NULL, -9958);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9957, 0.00, -98, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99958, -998, 0.00, 0, NULL, -9957);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9956, 0.00, -97, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99957, -997, 0.00, 0, NULL, -9956);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9977, -9995, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9955, 0.00, -96, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99956, -996, 0.00, 0, NULL, -9955);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9954, 0.00, -95, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99955, -995, 0.00, 0, NULL, -9954);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9976, -9995, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9953, 0.00, -94, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99954, -994, 0.00, 0, NULL, -9953);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9952, 0.00, -93, -9995, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99953, -993, 0.00, 0, NULL, -9952);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9975, -9994, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9951, 0.00, -100, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99952, -1000, 0.00, 0, NULL, -9951);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9974, -9994, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9950, 0.00, -99, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99951, -999, 0.00, 0, NULL, -9950);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9949, 0.00, -98, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99950, -998, 0.00, 0, NULL, -9949);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9948, 0.00, -97, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99949, -997, 0.00, 0, NULL, -9948);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9973, -9994, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9947, 0.00, -96, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99948, -996, 0.00, 0, NULL, -9947);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9946, 0.00, -95, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99947, -995, 0.00, 0, NULL, -9946);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9972, -9994, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9945, 0.00, -94, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99946, -994, 0.00, 0, NULL, -9945);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9944, 0.00, -93, -9994, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99945, -993, 0.00, 0, NULL, -9944);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9971, -9993, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9943, 0.00, -100, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99944, -1000, 0.00, 0, NULL, -9943);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9970, -9993, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9942, 0.00, -99, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99943, -999, 0.00, 0, NULL, -9942);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9941, 0.00, -98, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99942, -998, 0.00, 0, NULL, -9941);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9940, 0.00, -97, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99941, -997, 0.00, 0, NULL, -9940);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9969, -9993, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9939, 0.00, -96, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99940, -996, 0.00, 0, NULL, -9939);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9938, 0.00, -95, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99939, -995, 0.00, 0, NULL, -9938);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9968, -9993, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9937, 0.00, -94, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99938, -994, 0.00, 0, NULL, -9937);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9936, 0.00, -93, -9993, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99937, -993, 0.00, 0, NULL, -9936);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9967, -9992, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9935, 0.00, -100, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99936, -1000, 0.00, 0, NULL, -9935);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9966, -9992, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9934, 0.00, -99, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99935, -999, 0.00, 0, NULL, -9934);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9933, 0.00, -98, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99934, -998, 0.00, 0, NULL, -9933);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9932, 0.00, -97, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99933, -997, 0.00, 0, NULL, -9932);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9965, -9992, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9931, 0.00, -96, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99932, -996, 0.00, 0, NULL, -9931);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9930, 0.00, -95, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99931, -995, 0.00, 0, NULL, -9930);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9964, -9992, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9929, 0.00, -94, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99930, -994, 0.00, 0, NULL, -9929);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9928, 0.00, -93, -9992, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99929, -993, 0.00, 0, NULL, -9928);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9963, -9991, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9927, 0.00, -100, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99928, -1000, 0.00, 0, NULL, -9927);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9962, -9991, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9926, 0.00, -99, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99927, -999, 0.00, 0, NULL, -9926);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9925, 0.00, -98, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99926, -998, 0.00, 0, NULL, -9925);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9924, 0.00, -97, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99925, -997, 0.00, 0, NULL, -9924);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9961, -9991, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9923, 0.00, -96, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99924, -996, 0.00, 0, NULL, -9923);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9922, 0.00, -95, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99923, -995, 0.00, 0, NULL, -9922);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9960, -9991, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9921, 0.00, -94, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99922, -994, 0.00, 0, NULL, -9921);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9920, 0.00, -93, -9991, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99921, -993, 0.00, 0, NULL, -9920);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9959, -9990, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9919, 0.00, -100, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99920, -1000, 0.00, 0, NULL, -9919);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9958, -9990, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9918, 0.00, -99, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99919, -999, 0.00, 0, NULL, -9918);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9917, 0.00, -98, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99918, -998, 0.00, 0, NULL, -9917);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9916, 0.00, -97, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99917, -997, 0.00, 0, NULL, -9916);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9957, -9990, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9915, 0.00, -96, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99916, -996, 0.00, 0, NULL, -9915);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9914, 0.00, -95, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99915, -995, 0.00, 0, NULL, -9914);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9956, -9990, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9913, 0.00, -94, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99914, -994, 0.00, 0, NULL, -9913);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9912, 0.00, -93, -9990, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99913, -993, 0.00, 0, NULL, -9912);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9955, -9989, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9911, 0.00, -100, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99912, -1000, 0.00, 0, NULL, -9911);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9954, -9989, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9910, 0.00, -99, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99911, -999, 0.00, 0, NULL, -9910);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9909, 0.00, -98, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99910, -998, 0.00, 0, NULL, -9909);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9908, 0.00, -97, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99909, -997, 0.00, 0, NULL, -9908);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9953, -9989, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9907, 0.00, -96, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99908, -996, 0.00, 0, NULL, -9907);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9906, 0.00, -95, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99907, -995, 0.00, 0, NULL, -9906);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9952, -9989, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9905, 0.00, -94, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99906, -994, 0.00, 0, NULL, -9905);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9904, 0.00, -93, -9989, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99905, -993, 0.00, 0, NULL, -9904);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9951, -9988, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9903, 0.00, -100, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99904, -1000, 0.00, 0, NULL, -9903);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9950, -9988, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9902, 0.00, -99, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99903, -999, 0.00, 0, NULL, -9902);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9901, 0.00, -98, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99902, -998, 0.00, 0, NULL, -9901);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9900, 0.00, -97, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99901, -997, 0.00, 0, NULL, -9900);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9949, -9988, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9899, 0.00, -96, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99900, -996, 0.00, 0, NULL, -9899);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9898, 0.00, -95, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99899, -995, 0.00, 0, NULL, -9898);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9948, -9988, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9897, 0.00, -94, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99898, -994, 0.00, 0, NULL, -9897);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9896, 0.00, -93, -9988, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99897, -993, 0.00, 0, NULL, -9896);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9947, -9987, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9895, 0.00, -100, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99896, -1000, 0.00, 0, NULL, -9895);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9946, -9987, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9894, 0.00, -99, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99895, -999, 0.00, 0, NULL, -9894);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9893, 0.00, -98, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99894, -998, 0.00, 0, NULL, -9893);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9892, 0.00, -97, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99893, -997, 0.00, 0, NULL, -9892);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9945, -9987, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9891, 0.00, -96, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99892, -996, 0.00, 0, NULL, -9891);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9890, 0.00, -95, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99891, -995, 0.00, 0, NULL, -9890);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9944, -9987, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9889, 0.00, -94, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99890, -994, 0.00, 0, NULL, -9889);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9888, 0.00, -93, -9987, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99889, -993, 0.00, 0, NULL, -9888);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9943, -9986, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9887, 0.00, -100, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99888, -1000, 0.00, 0, NULL, -9887);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9942, -9986, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9886, 0.00, -99, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99887, -999, 0.00, 0, NULL, -9886);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9885, 0.00, -98, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99886, -998, 0.00, 0, NULL, -9885);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9884, 0.00, -97, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99885, -997, 0.00, 0, NULL, -9884);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9941, -9986, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9883, 0.00, -96, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99884, -996, 0.00, 0, NULL, -9883);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9882, 0.00, -95, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99883, -995, 0.00, 0, NULL, -9882);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9940, -9986, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9881, 0.00, -94, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99882, -994, 0.00, 0, NULL, -9881);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9880, 0.00, -93, -9986, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99881, -993, 0.00, 0, NULL, -9880);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9939, -9985, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9879, 0.00, -100, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99880, -1000, 0.00, 0, NULL, -9879);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9938, -9985, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9878, 0.00, -99, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99879, -999, 0.00, 0, NULL, -9878);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9877, 0.00, -98, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99878, -998, 0.00, 0, NULL, -9877);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9876, 0.00, -97, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99877, -997, 0.00, 0, NULL, -9876);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9937, -9985, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9875, 0.00, -96, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99876, -996, 0.00, 0, NULL, -9875);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9874, 0.00, -95, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99875, -995, 0.00, 0, NULL, -9874);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9936, -9985, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9873, 0.00, -94, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99874, -994, 0.00, 0, NULL, -9873);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9872, 0.00, -93, -9985, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99873, -993, 0.00, 0, NULL, -9872);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9935, -9984, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9871, 0.00, -100, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99872, -1000, 0.00, 0, NULL, -9871);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9934, -9984, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9870, 0.00, -99, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99871, -999, 0.00, 0, NULL, -9870);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9869, 0.00, -98, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99870, -998, 0.00, 0, NULL, -9869);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9868, 0.00, -97, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99869, -997, 0.00, 0, NULL, -9868);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9933, -9984, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9867, 0.00, -96, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99868, -996, 0.00, 0, NULL, -9867);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9866, 0.00, -95, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99867, -995, 0.00, 0, NULL, -9866);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9932, -9984, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9865, 0.00, -94, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99866, -994, 0.00, 0, NULL, -9865);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9864, 0.00, -93, -9984, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99865, -993, 0.00, 0, NULL, -9864);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9931, -9983, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9863, 0.00, -100, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99864, -1000, 0.00, 0, NULL, -9863);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9930, -9983, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9862, 0.00, -99, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99863, -999, 0.00, 0, NULL, -9862);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9861, 0.00, -98, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99862, -998, 0.00, 0, NULL, -9861);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9860, 0.00, -97, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99861, -997, 0.00, 0, NULL, -9860);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9929, -9983, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9859, 0.00, -96, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99860, -996, 0.00, 0, NULL, -9859);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9858, 0.00, -95, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99859, -995, 0.00, 0, NULL, -9858);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9928, -9983, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9857, 0.00, -94, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99858, -994, 0.00, 0, NULL, -9857);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9856, 0.00, -93, -9983, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99857, -993, 0.00, 0, NULL, -9856);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9927, -9982, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9855, 0.00, -100, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99856, -1000, 0.00, 0, NULL, -9855);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9926, -9982, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9854, 0.00, -99, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99855, -999, 0.00, 0, NULL, -9854);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9853, 0.00, -98, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99854, -998, 0.00, 0, NULL, -9853);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9852, 0.00, -97, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99853, -997, 0.00, 0, NULL, -9852);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9925, -9982, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9851, 0.00, -96, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99852, -996, 0.00, 0, NULL, -9851);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9850, 0.00, -95, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99851, -995, 0.00, 0, NULL, -9850);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9924, -9982, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9849, 0.00, -94, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99850, -994, 0.00, 0, NULL, -9849);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9848, 0.00, -93, -9982, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99849, -993, 0.00, 0, NULL, -9848);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9923, -9981, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9847, 0.00, -100, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99848, -1000, 0.00, 0, NULL, -9847);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9922, -9981, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9846, 0.00, -99, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99847, -999, 0.00, 0, NULL, -9846);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9845, 0.00, -98, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99846, -998, 0.00, 0, NULL, -9845);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9844, 0.00, -97, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99845, -997, 0.00, 0, NULL, -9844);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9921, -9981, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9843, 0.00, -96, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99844, -996, 0.00, 0, NULL, -9843);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9842, 0.00, -95, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99843, -995, 0.00, 0, NULL, -9842);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9920, -9981, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9841, 0.00, -94, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99842, -994, 0.00, 0, NULL, -9841);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9840, 0.00, -93, -9981, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99841, -993, 0.00, 0, NULL, -9840);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9919, -9980, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9839, 0.00, -100, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99840, -1000, 0.00, 0, NULL, -9839);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9918, -9980, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9838, 0.00, -99, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99839, -999, 0.00, 0, NULL, -9838);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9837, 0.00, -98, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99838, -998, 0.00, 0, NULL, -9837);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9836, 0.00, -97, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99837, -997, 0.00, 0, NULL, -9836);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9917, -9980, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9835, 0.00, -96, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99836, -996, 0.00, 0, NULL, -9835);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9834, 0.00, -95, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99835, -995, 0.00, 0, NULL, -9834);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9916, -9980, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9833, 0.00, -94, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99834, -994, 0.00, 0, NULL, -9833);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9832, 0.00, -93, -9980, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99833, -993, 0.00, 0, NULL, -9832);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9915, -9979, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9831, 0.00, -100, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99832, -1000, 0.00, 0, NULL, -9831);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9914, -9979, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9830, 0.00, -99, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99831, -999, 0.00, 0, NULL, -9830);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9829, 0.00, -98, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99830, -998, 0.00, 0, NULL, -9829);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9828, 0.00, -97, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99829, -997, 0.00, 0, NULL, -9828);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9913, -9979, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9827, 0.00, -96, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99828, -996, 0.00, 0, NULL, -9827);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9826, 0.00, -95, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99827, -995, 0.00, 0, NULL, -9826);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9912, -9979, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9825, 0.00, -94, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99826, -994, 0.00, 0, NULL, -9825);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9824, 0.00, -93, -9979, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99825, -993, 0.00, 0, NULL, -9824);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9911, -9978, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9823, 0.00, -100, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99824, -1000, 0.00, 0, NULL, -9823);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9910, -9978, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9822, 0.00, -99, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99823, -999, 0.00, 0, NULL, -9822);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9821, 0.00, -98, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99822, -998, 0.00, 0, NULL, -9821);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9820, 0.00, -97, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99821, -997, 0.00, 0, NULL, -9820);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9909, -9978, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9819, 0.00, -96, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99820, -996, 0.00, 0, NULL, -9819);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9818, 0.00, -95, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99819, -995, 0.00, 0, NULL, -9818);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9908, -9978, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9817, 0.00, -94, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99818, -994, 0.00, 0, NULL, -9817);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9816, 0.00, -93, -9978, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99817, -993, 0.00, 0, NULL, -9816);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9907, -9977, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9815, 0.00, -100, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99816, -1000, 0.00, 0, NULL, -9815);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9906, -9977, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9814, 0.00, -99, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99815, -999, 0.00, 0, NULL, -9814);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9813, 0.00, -98, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99814, -998, 0.00, 0, NULL, -9813);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9812, 0.00, -97, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99813, -997, 0.00, 0, NULL, -9812);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9905, -9977, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9811, 0.00, -96, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99812, -996, 0.00, 0, NULL, -9811);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9810, 0.00, -95, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99811, -995, 0.00, 0, NULL, -9810);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9904, -9977, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9809, 0.00, -94, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99810, -994, 0.00, 0, NULL, -9809);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9808, 0.00, -93, -9977, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99809, -993, 0.00, 0, NULL, -9808);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9903, -9976, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9807, 0.00, -100, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99808, -1000, 0.00, 0, NULL, -9807);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9902, -9976, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9806, 0.00, -99, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99807, -999, 0.00, 0, NULL, -9806);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9805, 0.00, -98, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99806, -998, 0.00, 0, NULL, -9805);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9804, 0.00, -97, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99805, -997, 0.00, 0, NULL, -9804);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9901, -9976, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9803, 0.00, -96, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99804, -996, 0.00, 0, NULL, -9803);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9802, 0.00, -95, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99803, -995, 0.00, 0, NULL, -9802);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9900, -9976, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9801, 0.00, -94, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99802, -994, 0.00, 0, NULL, -9801);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9800, 0.00, -93, -9976, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99801, -993, 0.00, 0, NULL, -9800);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9899, -9975, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9799, 0.00, -100, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99800, -1000, 0.00, 0, NULL, -9799);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9898, -9975, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9798, 0.00, -99, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99799, -999, 0.00, 0, NULL, -9798);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9797, 0.00, -98, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99798, -998, 0.00, 0, NULL, -9797);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9796, 0.00, -97, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99797, -997, 0.00, 0, NULL, -9796);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9897, -9975, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9795, 0.00, -96, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99796, -996, 0.00, 0, NULL, -9795);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9794, 0.00, -95, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99795, -995, 0.00, 0, NULL, -9794);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9896, -9975, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9793, 0.00, -94, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99794, -994, 0.00, 0, NULL, -9793);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9792, 0.00, -93, -9975, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99793, -993, 0.00, 0, NULL, -9792);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9895, -9974, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9791, 0.00, -100, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99792, -1000, 0.00, 0, NULL, -9791);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9894, -9974, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9790, 0.00, -99, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99791, -999, 0.00, 0, NULL, -9790);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9789, 0.00, -98, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99790, -998, 0.00, 0, NULL, -9789);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9788, 0.00, -97, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99789, -997, 0.00, 0, NULL, -9788);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9893, -9974, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9787, 0.00, -96, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99788, -996, 0.00, 0, NULL, -9787);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9786, 0.00, -95, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99787, -995, 0.00, 0, NULL, -9786);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9892, -9974, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9785, 0.00, -94, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99786, -994, 0.00, 0, NULL, -9785);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9784, 0.00, -93, -9974, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99785, -993, 0.00, 0, NULL, -9784);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9891, -9973, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9783, 0.00, -100, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99784, -1000, 0.00, 0, NULL, -9783);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9890, -9973, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9782, 0.00, -99, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99783, -999, 0.00, 0, NULL, -9782);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9781, 0.00, -98, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99782, -998, 0.00, 0, NULL, -9781);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9780, 0.00, -97, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99781, -997, 0.00, 0, NULL, -9780);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9889, -9973, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9779, 0.00, -96, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99780, -996, 0.00, 0, NULL, -9779);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9778, 0.00, -95, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99779, -995, 0.00, 0, NULL, -9778);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9888, -9973, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9777, 0.00, -94, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99778, -994, 0.00, 0, NULL, -9777);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9776, 0.00, -93, -9973, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99777, -993, 0.00, 0, NULL, -9776);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9887, -9972, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9775, 0.00, -100, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99776, -1000, 0.00, 0, NULL, -9775);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9886, -9972, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9774, 0.00, -99, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99775, -999, 0.00, 0, NULL, -9774);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9773, 0.00, -98, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99774, -998, 0.00, 0, NULL, -9773);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9772, 0.00, -97, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99773, -997, 0.00, 0, NULL, -9772);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9885, -9972, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9771, 0.00, -96, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99772, -996, 0.00, 0, NULL, -9771);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9770, 0.00, -95, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99771, -995, 0.00, 0, NULL, -9770);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9884, -9972, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9769, 0.00, -94, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99770, -994, 0.00, 0, NULL, -9769);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9768, 0.00, -93, -9972, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99769, -993, 0.00, 0, NULL, -9768);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9883, -9971, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9767, 0.00, -100, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99768, -1000, 0.00, 0, NULL, -9767);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9882, -9971, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9766, 0.00, -99, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99767, -999, 0.00, 0, NULL, -9766);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9765, 0.00, -98, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99766, -998, 0.00, 0, NULL, -9765);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9764, 0.00, -97, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99765, -997, 0.00, 0, NULL, -9764);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9881, -9971, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9763, 0.00, -96, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99764, -996, 0.00, 0, NULL, -9763);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9762, 0.00, -95, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99763, -995, 0.00, 0, NULL, -9762);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9880, -9971, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9761, 0.00, -94, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99762, -994, 0.00, 0, NULL, -9761);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9760, 0.00, -93, -9971, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99761, -993, 0.00, 0, NULL, -9760);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9879, -9970, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9759, 0.00, -100, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99760, -1000, 0.00, 0, NULL, -9759);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9878, -9970, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9758, 0.00, -99, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99759, -999, 0.00, 0, NULL, -9758);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9757, 0.00, -98, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99758, -998, 0.00, 0, NULL, -9757);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9756, 0.00, -97, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99757, -997, 0.00, 0, NULL, -9756);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9877, -9970, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9755, 0.00, -96, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99756, -996, 0.00, 0, NULL, -9755);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9754, 0.00, -95, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99755, -995, 0.00, 0, NULL, -9754);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9876, -9970, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9753, 0.00, -94, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99754, -994, 0.00, 0, NULL, -9753);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9752, 0.00, -93, -9970, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99753, -993, 0.00, 0, NULL, -9752);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9875, -9969, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9751, 0.00, -100, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99752, -1000, 0.00, 0, NULL, -9751);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9874, -9969, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9750, 0.00, -99, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99751, -999, 0.00, 0, NULL, -9750);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9749, 0.00, -98, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99750, -998, 0.00, 0, NULL, -9749);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9748, 0.00, -97, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99749, -997, 0.00, 0, NULL, -9748);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9873, -9969, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9747, 0.00, -96, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99748, -996, 0.00, 0, NULL, -9747);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9746, 0.00, -95, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99747, -995, 0.00, 0, NULL, -9746);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9872, -9969, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9745, 0.00, -94, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99746, -994, 0.00, 0, NULL, -9745);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9744, 0.00, -93, -9969, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99745, -993, 0.00, 0, NULL, -9744);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9871, -9968, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9743, 0.00, -100, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99744, -1000, 0.00, 0, NULL, -9743);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9870, -9968, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9742, 0.00, -99, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99743, -999, 0.00, 0, NULL, -9742);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9741, 0.00, -98, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99742, -998, 0.00, 0, NULL, -9741);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9740, 0.00, -97, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99741, -997, 0.00, 0, NULL, -9740);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9869, -9968, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9739, 0.00, -96, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99740, -996, 0.00, 0, NULL, -9739);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9738, 0.00, -95, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99739, -995, 0.00, 0, NULL, -9738);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9868, -9968, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9737, 0.00, -94, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99738, -994, 0.00, 0, NULL, -9737);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9736, 0.00, -93, -9968, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99737, -993, 0.00, 0, NULL, -9736);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9867, -9967, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9735, 0.00, -100, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99736, -1000, 0.00, 0, NULL, -9735);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9866, -9967, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9734, 0.00, -99, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99735, -999, 0.00, 0, NULL, -9734);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9733, 0.00, -98, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99734, -998, 0.00, 0, NULL, -9733);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9732, 0.00, -97, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99733, -997, 0.00, 0, NULL, -9732);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9865, -9967, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9731, 0.00, -96, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99732, -996, 0.00, 0, NULL, -9731);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9730, 0.00, -95, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99731, -995, 0.00, 0, NULL, -9730);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9864, -9967, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9729, 0.00, -94, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99730, -994, 0.00, 0, NULL, -9729);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9728, 0.00, -93, -9967, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99729, -993, 0.00, 0, NULL, -9728);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9863, -9966, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9727, 0.00, -100, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99728, -1000, 0.00, 0, NULL, -9727);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9862, -9966, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9726, 0.00, -99, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99727, -999, 0.00, 0, NULL, -9726);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9725, 0.00, -98, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99726, -998, 0.00, 0, NULL, -9725);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9724, 0.00, -97, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99725, -997, 0.00, 0, NULL, -9724);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9861, -9966, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9723, 0.00, -96, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99724, -996, 0.00, 0, NULL, -9723);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9722, 0.00, -95, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99723, -995, 0.00, 0, NULL, -9722);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9860, -9966, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9721, 0.00, -94, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99722, -994, 0.00, 0, NULL, -9721);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9720, 0.00, -93, -9966, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99721, -993, 0.00, 0, NULL, -9720);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9859, -9965, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9719, 0.00, -100, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99720, -1000, 0.00, 0, NULL, -9719);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9858, -9965, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9718, 0.00, -99, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99719, -999, 0.00, 0, NULL, -9718);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9717, 0.00, -98, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99718, -998, 0.00, 0, NULL, -9717);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9716, 0.00, -97, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99717, -997, 0.00, 0, NULL, -9716);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9857, -9965, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9715, 0.00, -96, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99716, -996, 0.00, 0, NULL, -9715);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9714, 0.00, -95, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99715, -995, 0.00, 0, NULL, -9714);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9856, -9965, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9713, 0.00, -94, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99714, -994, 0.00, 0, NULL, -9713);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9712, 0.00, -93, -9965, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99713, -993, 0.00, 0, NULL, -9712);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9855, -9964, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9711, 0.00, -100, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99712, -1000, 0.00, 0, NULL, -9711);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9854, -9964, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9710, 0.00, -99, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99711, -999, 0.00, 0, NULL, -9710);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9709, 0.00, -98, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99710, -998, 0.00, 0, NULL, -9709);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9708, 0.00, -97, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99709, -997, 0.00, 0, NULL, -9708);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9853, -9964, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9707, 0.00, -96, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99708, -996, 0.00, 0, NULL, -9707);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9706, 0.00, -95, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99707, -995, 0.00, 0, NULL, -9706);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9852, -9964, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9705, 0.00, -94, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99706, -994, 0.00, 0, NULL, -9705);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9704, 0.00, -93, -9964, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99705, -993, 0.00, 0, NULL, -9704);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9851, -9963, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9703, 0.00, -100, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99704, -1000, 0.00, 0, NULL, -9703);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9850, -9963, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9702, 0.00, -99, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99703, -999, 0.00, 0, NULL, -9702);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9701, 0.00, -98, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99702, -998, 0.00, 0, NULL, -9701);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9700, 0.00, -97, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99701, -997, 0.00, 0, NULL, -9700);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9849, -9963, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9699, 0.00, -96, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99700, -996, 0.00, 0, NULL, -9699);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9698, 0.00, -95, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99699, -995, 0.00, 0, NULL, -9698);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9848, -9963, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9697, 0.00, -94, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99698, -994, 0.00, 0, NULL, -9697);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9696, 0.00, -93, -9963, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99697, -993, 0.00, 0, NULL, -9696);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9847, -9962, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9695, 0.00, -100, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99696, -1000, 0.00, 0, NULL, -9695);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9846, -9962, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9694, 0.00, -99, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99695, -999, 0.00, 0, NULL, -9694);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9693, 0.00, -98, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99694, -998, 0.00, 0, NULL, -9693);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9692, 0.00, -97, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99693, -997, 0.00, 0, NULL, -9692);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9845, -9962, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9691, 0.00, -96, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99692, -996, 0.00, 0, NULL, -9691);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9690, 0.00, -95, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99691, -995, 0.00, 0, NULL, -9690);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9844, -9962, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9689, 0.00, -94, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99690, -994, 0.00, 0, NULL, -9689);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9688, 0.00, -93, -9962, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99689, -993, 0.00, 0, NULL, -9688);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9843, -9961, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9687, 0.00, -100, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99688, -1000, 0.00, 0, NULL, -9687);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9842, -9961, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9686, 0.00, -99, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99687, -999, 0.00, 0, NULL, -9686);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9685, 0.00, -98, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99686, -998, 0.00, 0, NULL, -9685);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9684, 0.00, -97, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99685, -997, 0.00, 0, NULL, -9684);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9841, -9961, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9683, 0.00, -96, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99684, -996, 0.00, 0, NULL, -9683);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9682, 0.00, -95, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99683, -995, 0.00, 0, NULL, -9682);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9840, -9961, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9681, 0.00, -94, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99682, -994, 0.00, 0, NULL, -9681);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9680, 0.00, -93, -9961, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99681, -993, 0.00, 0, NULL, -9680);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9839, -9960, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9679, 0.00, -100, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99680, -1000, 0.00, 0, NULL, -9679);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9838, -9960, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9678, 0.00, -99, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99679, -999, 0.00, 0, NULL, -9678);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9677, 0.00, -98, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99678, -998, 0.00, 0, NULL, -9677);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9676, 0.00, -97, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99677, -997, 0.00, 0, NULL, -9676);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9837, -9960, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9675, 0.00, -96, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99676, -996, 0.00, 0, NULL, -9675);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9674, 0.00, -95, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99675, -995, 0.00, 0, NULL, -9674);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9836, -9960, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9673, 0.00, -94, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99674, -994, 0.00, 0, NULL, -9673);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9672, 0.00, -93, -9960, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99673, -993, 0.00, 0, NULL, -9672);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9835, -9959, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9671, 0.00, -100, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99672, -1000, 0.00, 0, NULL, -9671);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9834, -9959, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9670, 0.00, -99, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99671, -999, 0.00, 0, NULL, -9670);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9669, 0.00, -98, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99670, -998, 0.00, 0, NULL, -9669);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9668, 0.00, -97, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99669, -997, 0.00, 0, NULL, -9668);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9833, -9959, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9667, 0.00, -96, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99668, -996, 0.00, 0, NULL, -9667);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9666, 0.00, -95, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99667, -995, 0.00, 0, NULL, -9666);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9832, -9959, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9665, 0.00, -94, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99666, -994, 0.00, 0, NULL, -9665);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9664, 0.00, -93, -9959, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99665, -993, 0.00, 0, NULL, -9664);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9831, -9958, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9663, 0.00, -100, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99664, -1000, 0.00, 0, NULL, -9663);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9830, -9958, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9662, 0.00, -99, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99663, -999, 0.00, 0, NULL, -9662);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9661, 0.00, -98, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99662, -998, 0.00, 0, NULL, -9661);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9660, 0.00, -97, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99661, -997, 0.00, 0, NULL, -9660);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9829, -9958, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9659, 0.00, -96, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99660, -996, 0.00, 0, NULL, -9659);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9658, 0.00, -95, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99659, -995, 0.00, 0, NULL, -9658);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9828, -9958, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9657, 0.00, -94, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99658, -994, 0.00, 0, NULL, -9657);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9656, 0.00, -93, -9958, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99657, -993, 0.00, 0, NULL, -9656);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9827, -9957, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9655, 0.00, -100, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99656, -1000, 0.00, 0, NULL, -9655);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9826, -9957, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9654, 0.00, -99, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99655, -999, 0.00, 0, NULL, -9654);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9653, 0.00, -98, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99654, -998, 0.00, 0, NULL, -9653);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9652, 0.00, -97, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99653, -997, 0.00, 0, NULL, -9652);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9825, -9957, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9651, 0.00, -96, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99652, -996, 0.00, 0, NULL, -9651);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9650, 0.00, -95, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99651, -995, 0.00, 0, NULL, -9650);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9824, -9957, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9649, 0.00, -94, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99650, -994, 0.00, 0, NULL, -9649);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9648, 0.00, -93, -9957, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99649, -993, 0.00, 0, NULL, -9648);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9823, -9956, -100, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9647, 0.00, -100, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99648, -1000, 0.00, 0, NULL, -9647);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9822, -9956, -99, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9646, 0.00, -99, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99647, -999, 0.00, 0, NULL, -9646);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9645, 0.00, -98, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99646, -998, 0.00, 0, NULL, -9645);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9644, 0.00, -97, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99645, -997, 0.00, 0, NULL, -9644);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9821, -9956, -98, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9643, 0.00, -96, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99644, -996, 0.00, 0, NULL, -9643);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9642, 0.00, -95, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99643, -995, 0.00, 0, NULL, -9642);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9820, -9956, -97, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9641, 0.00, -94, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99642, -994, 0.00, 0, NULL, -9641);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9640, 0.00, -93, -9956, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99641, -993, 0.00, 0, NULL, -9640);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9819, -9955, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9639, 0.00, -92, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99640, -992, 0.00, 0, NULL, -9639);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9638, 0.00, -91, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99639, -991, 0.00, 0, NULL, -9638);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9818, -9955, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9637, 0.00, -90, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99638, -990, 0.00, 0, NULL, -9637);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9636, 0.00, -89, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99637, -989, 0.00, 0, NULL, -9636);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9635, 0.00, -88, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99636, -988, 0.00, 0, NULL, -9635);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9817, -9955, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9634, 0.00, -87, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99635, -987, 0.00, 0, NULL, -9634);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9633, 0.00, -86, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99634, -986, 0.00, 0, NULL, -9633);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9632, 0.00, -85, -9955, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99633, -985, 0.00, 0, NULL, -9632);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9816, -9954, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9631, 0.00, -92, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99632, -992, 0.00, 0, NULL, -9631);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9630, 0.00, -91, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99631, -991, 0.00, 0, NULL, -9630);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9815, -9954, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9629, 0.00, -90, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99630, -990, 0.00, 0, NULL, -9629);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9628, 0.00, -89, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99629, -989, 0.00, 0, NULL, -9628);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9627, 0.00, -88, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99628, -988, 0.00, 0, NULL, -9627);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9814, -9954, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9626, 0.00, -87, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99627, -987, 0.00, 0, NULL, -9626);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9625, 0.00, -86, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99626, -986, 0.00, 0, NULL, -9625);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9624, 0.00, -85, -9954, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99625, -985, 0.00, 0, NULL, -9624);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9813, -9953, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9623, 0.00, -92, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99624, -992, 0.00, 0, NULL, -9623);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9622, 0.00, -91, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99623, -991, 0.00, 0, NULL, -9622);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9812, -9953, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9621, 0.00, -90, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99622, -990, 0.00, 0, NULL, -9621);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9620, 0.00, -89, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99621, -989, 0.00, 0, NULL, -9620);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9619, 0.00, -88, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99620, -988, 0.00, 0, NULL, -9619);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9811, -9953, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9618, 0.00, -87, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99619, -987, 0.00, 0, NULL, -9618);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9617, 0.00, -86, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99618, -986, 0.00, 0, NULL, -9617);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9616, 0.00, -85, -9953, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99617, -985, 0.00, 0, NULL, -9616);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9810, -9952, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9615, 0.00, -92, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99616, -992, 0.00, 0, NULL, -9615);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9614, 0.00, -91, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99615, -991, 0.00, 0, NULL, -9614);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9809, -9952, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9613, 0.00, -90, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99614, -990, 0.00, 0, NULL, -9613);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9612, 0.00, -89, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99613, -989, 0.00, 0, NULL, -9612);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9611, 0.00, -88, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99612, -988, 0.00, 0, NULL, -9611);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9808, -9952, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9610, 0.00, -87, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99611, -987, 0.00, 0, NULL, -9610);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9609, 0.00, -86, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99610, -986, 0.00, 0, NULL, -9609);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9608, 0.00, -85, -9952, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99609, -985, 0.00, 0, NULL, -9608);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9807, -9951, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9607, 0.00, -92, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99608, -992, 0.00, 0, NULL, -9607);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9606, 0.00, -91, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99607, -991, 0.00, 0, NULL, -9606);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9806, -9951, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9605, 0.00, -90, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99606, -990, 0.00, 0, NULL, -9605);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9604, 0.00, -89, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99605, -989, 0.00, 0, NULL, -9604);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9603, 0.00, -88, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99604, -988, 0.00, 0, NULL, -9603);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9805, -9951, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9602, 0.00, -87, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99603, -987, 0.00, 0, NULL, -9602);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9601, 0.00, -86, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99602, -986, 0.00, 0, NULL, -9601);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9600, 0.00, -85, -9951, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99601, -985, 0.00, 0, NULL, -9600);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9804, -9950, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9599, 0.00, -92, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99600, -992, 0.00, 0, NULL, -9599);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9598, 0.00, -91, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99599, -991, 0.00, 0, NULL, -9598);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9803, -9950, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9597, 0.00, -90, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99598, -990, 0.00, 0, NULL, -9597);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9596, 0.00, -89, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99597, -989, 0.00, 0, NULL, -9596);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9595, 0.00, -88, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99596, -988, 0.00, 0, NULL, -9595);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9802, -9950, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9594, 0.00, -87, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99595, -987, 0.00, 0, NULL, -9594);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9593, 0.00, -86, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99594, -986, 0.00, 0, NULL, -9593);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9592, 0.00, -85, -9950, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99593, -985, 0.00, 0, NULL, -9592);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9801, -9949, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9591, 0.00, -92, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99592, -992, 0.00, 0, NULL, -9591);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9590, 0.00, -91, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99591, -991, 0.00, 0, NULL, -9590);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9800, -9949, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9589, 0.00, -90, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99590, -990, 0.00, 0, NULL, -9589);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9588, 0.00, -89, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99589, -989, 0.00, 0, NULL, -9588);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9587, 0.00, -88, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99588, -988, 0.00, 0, NULL, -9587);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9799, -9949, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9586, 0.00, -87, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99587, -987, 0.00, 0, NULL, -9586);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9585, 0.00, -86, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99586, -986, 0.00, 0, NULL, -9585);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9584, 0.00, -85, -9949, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99585, -985, 0.00, 0, NULL, -9584);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9798, -9948, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9583, 0.00, -92, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99584, -992, 0.00, 0, NULL, -9583);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9582, 0.00, -91, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99583, -991, 0.00, 0, NULL, -9582);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9797, -9948, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9581, 0.00, -90, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99582, -990, 0.00, 0, NULL, -9581);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9580, 0.00, -89, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99581, -989, 0.00, 0, NULL, -9580);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9579, 0.00, -88, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99580, -988, 0.00, 0, NULL, -9579);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9796, -9948, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9578, 0.00, -87, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99579, -987, 0.00, 0, NULL, -9578);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9577, 0.00, -86, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99578, -986, 0.00, 0, NULL, -9577);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9576, 0.00, -85, -9948, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99577, -985, 0.00, 0, NULL, -9576);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9795, -9947, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9575, 0.00, -92, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99576, -992, 0.00, 0, NULL, -9575);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9574, 0.00, -91, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99575, -991, 0.00, 0, NULL, -9574);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9794, -9947, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9573, 0.00, -90, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99574, -990, 0.00, 0, NULL, -9573);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9572, 0.00, -89, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99573, -989, 0.00, 0, NULL, -9572);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9571, 0.00, -88, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99572, -988, 0.00, 0, NULL, -9571);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9793, -9947, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9570, 0.00, -87, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99571, -987, 0.00, 0, NULL, -9570);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9569, 0.00, -86, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99570, -986, 0.00, 0, NULL, -9569);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9568, 0.00, -85, -9947, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99569, -985, 0.00, 0, NULL, -9568);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9792, -9946, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9567, 0.00, -92, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99568, -992, 0.00, 0, NULL, -9567);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9566, 0.00, -91, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99567, -991, 0.00, 0, NULL, -9566);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9791, -9946, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9565, 0.00, -90, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99566, -990, 0.00, 0, NULL, -9565);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9564, 0.00, -89, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99565, -989, 0.00, 0, NULL, -9564);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9563, 0.00, -88, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99564, -988, 0.00, 0, NULL, -9563);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9790, -9946, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9562, 0.00, -87, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99563, -987, 0.00, 0, NULL, -9562);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9561, 0.00, -86, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99562, -986, 0.00, 0, NULL, -9561);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9560, 0.00, -85, -9946, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99561, -985, 0.00, 0, NULL, -9560);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9789, -9945, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9559, 0.00, -92, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99560, -992, 0.00, 0, NULL, -9559);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9558, 0.00, -91, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99559, -991, 0.00, 0, NULL, -9558);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9788, -9945, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9557, 0.00, -90, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99558, -990, 0.00, 0, NULL, -9557);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9556, 0.00, -89, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99557, -989, 0.00, 0, NULL, -9556);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9555, 0.00, -88, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99556, -988, 0.00, 0, NULL, -9555);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9787, -9945, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9554, 0.00, -87, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99555, -987, 0.00, 0, NULL, -9554);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9553, 0.00, -86, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99554, -986, 0.00, 0, NULL, -9553);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9552, 0.00, -85, -9945, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99553, -985, 0.00, 0, NULL, -9552);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9786, -9944, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9551, 0.00, -92, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99552, -992, 0.00, 0, NULL, -9551);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9550, 0.00, -91, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99551, -991, 0.00, 0, NULL, -9550);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9785, -9944, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9549, 0.00, -90, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99550, -990, 0.00, 0, NULL, -9549);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9548, 0.00, -89, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99549, -989, 0.00, 0, NULL, -9548);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9547, 0.00, -88, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99548, -988, 0.00, 0, NULL, -9547);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9784, -9944, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9546, 0.00, -87, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99547, -987, 0.00, 0, NULL, -9546);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9545, 0.00, -86, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99546, -986, 0.00, 0, NULL, -9545);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9544, 0.00, -85, -9944, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99545, -985, 0.00, 0, NULL, -9544);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9783, -9943, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9543, 0.00, -92, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99544, -992, 0.00, 0, NULL, -9543);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9542, 0.00, -91, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99543, -991, 0.00, 0, NULL, -9542);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9782, -9943, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9541, 0.00, -90, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99542, -990, 0.00, 0, NULL, -9541);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9540, 0.00, -89, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99541, -989, 0.00, 0, NULL, -9540);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9539, 0.00, -88, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99540, -988, 0.00, 0, NULL, -9539);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9781, -9943, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9538, 0.00, -87, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99539, -987, 0.00, 0, NULL, -9538);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9537, 0.00, -86, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99538, -986, 0.00, 0, NULL, -9537);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9536, 0.00, -85, -9943, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99537, -985, 0.00, 0, NULL, -9536);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9780, -9942, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9535, 0.00, -92, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99536, -992, 0.00, 0, NULL, -9535);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9534, 0.00, -91, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99535, -991, 0.00, 0, NULL, -9534);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9779, -9942, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9533, 0.00, -90, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99534, -990, 0.00, 0, NULL, -9533);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9532, 0.00, -89, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99533, -989, 0.00, 0, NULL, -9532);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9531, 0.00, -88, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99532, -988, 0.00, 0, NULL, -9531);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9778, -9942, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9530, 0.00, -87, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99531, -987, 0.00, 0, NULL, -9530);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9529, 0.00, -86, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99530, -986, 0.00, 0, NULL, -9529);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9528, 0.00, -85, -9942, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99529, -985, 0.00, 0, NULL, -9528);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9777, -9941, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9527, 0.00, -92, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99528, -992, 0.00, 0, NULL, -9527);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9526, 0.00, -91, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99527, -991, 0.00, 0, NULL, -9526);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9776, -9941, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9525, 0.00, -90, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99526, -990, 0.00, 0, NULL, -9525);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9524, 0.00, -89, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99525, -989, 0.00, 0, NULL, -9524);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9523, 0.00, -88, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99524, -988, 0.00, 0, NULL, -9523);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9775, -9941, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9522, 0.00, -87, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99523, -987, 0.00, 0, NULL, -9522);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9521, 0.00, -86, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99522, -986, 0.00, 0, NULL, -9521);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9520, 0.00, -85, -9941, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99521, -985, 0.00, 0, NULL, -9520);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9774, -9940, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9519, 0.00, -92, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99520, -992, 0.00, 0, NULL, -9519);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9518, 0.00, -91, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99519, -991, 0.00, 0, NULL, -9518);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9773, -9940, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9517, 0.00, -90, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99518, -990, 0.00, 0, NULL, -9517);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9516, 0.00, -89, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99517, -989, 0.00, 0, NULL, -9516);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9515, 0.00, -88, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99516, -988, 0.00, 0, NULL, -9515);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9772, -9940, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9514, 0.00, -87, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99515, -987, 0.00, 0, NULL, -9514);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9513, 0.00, -86, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99514, -986, 0.00, 0, NULL, -9513);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9512, 0.00, -85, -9940, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99513, -985, 0.00, 0, NULL, -9512);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9771, -9939, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9511, 0.00, -92, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99512, -992, 0.00, 0, NULL, -9511);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9510, 0.00, -91, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99511, -991, 0.00, 0, NULL, -9510);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9770, -9939, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9509, 0.00, -90, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99510, -990, 0.00, 0, NULL, -9509);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9508, 0.00, -89, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99509, -989, 0.00, 0, NULL, -9508);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9507, 0.00, -88, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99508, -988, 0.00, 0, NULL, -9507);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9769, -9939, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9506, 0.00, -87, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99507, -987, 0.00, 0, NULL, -9506);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9505, 0.00, -86, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99506, -986, 0.00, 0, NULL, -9505);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9504, 0.00, -85, -9939, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99505, -985, 0.00, 0, NULL, -9504);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9768, -9938, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9503, 0.00, -92, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99504, -992, 0.00, 0, NULL, -9503);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9502, 0.00, -91, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99503, -991, 0.00, 0, NULL, -9502);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9767, -9938, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9501, 0.00, -90, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99502, -990, 0.00, 0, NULL, -9501);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9500, 0.00, -89, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99501, -989, 0.00, 0, NULL, -9500);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9499, 0.00, -88, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99500, -988, 0.00, 0, NULL, -9499);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9766, -9938, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9498, 0.00, -87, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99499, -987, 0.00, 0, NULL, -9498);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9497, 0.00, -86, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99498, -986, 0.00, 0, NULL, -9497);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9496, 0.00, -85, -9938, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99497, -985, 0.00, 0, NULL, -9496);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9765, -9937, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9495, 0.00, -92, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99496, -992, 0.00, 0, NULL, -9495);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9494, 0.00, -91, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99495, -991, 0.00, 0, NULL, -9494);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9764, -9937, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9493, 0.00, -90, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99494, -990, 0.00, 0, NULL, -9493);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9492, 0.00, -89, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99493, -989, 0.00, 0, NULL, -9492);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9491, 0.00, -88, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99492, -988, 0.00, 0, NULL, -9491);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9763, -9937, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9490, 0.00, -87, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99491, -987, 0.00, 0, NULL, -9490);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9489, 0.00, -86, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99490, -986, 0.00, 0, NULL, -9489);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9488, 0.00, -85, -9937, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99489, -985, 0.00, 0, NULL, -9488);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9762, -9936, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9487, 0.00, -92, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99488, -992, 0.00, 0, NULL, -9487);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9486, 0.00, -91, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99487, -991, 0.00, 0, NULL, -9486);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9761, -9936, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9485, 0.00, -90, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99486, -990, 0.00, 0, NULL, -9485);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9484, 0.00, -89, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99485, -989, 0.00, 0, NULL, -9484);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9483, 0.00, -88, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99484, -988, 0.00, 0, NULL, -9483);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9760, -9936, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9482, 0.00, -87, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99483, -987, 0.00, 0, NULL, -9482);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9481, 0.00, -86, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99482, -986, 0.00, 0, NULL, -9481);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9480, 0.00, -85, -9936, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99481, -985, 0.00, 0, NULL, -9480);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9759, -9935, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9479, 0.00, -92, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99480, -992, 0.00, 0, NULL, -9479);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9478, 0.00, -91, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99479, -991, 0.00, 0, NULL, -9478);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9758, -9935, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9477, 0.00, -90, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99478, -990, 0.00, 0, NULL, -9477);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9476, 0.00, -89, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99477, -989, 0.00, 0, NULL, -9476);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9475, 0.00, -88, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99476, -988, 0.00, 0, NULL, -9475);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9757, -9935, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9474, 0.00, -87, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99475, -987, 0.00, 0, NULL, -9474);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9473, 0.00, -86, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99474, -986, 0.00, 0, NULL, -9473);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9472, 0.00, -85, -9935, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99473, -985, 0.00, 0, NULL, -9472);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9756, -9934, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9471, 0.00, -92, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99472, -992, 0.00, 0, NULL, -9471);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9470, 0.00, -91, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99471, -991, 0.00, 0, NULL, -9470);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9755, -9934, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9469, 0.00, -90, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99470, -990, 0.00, 0, NULL, -9469);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9468, 0.00, -89, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99469, -989, 0.00, 0, NULL, -9468);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9467, 0.00, -88, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99468, -988, 0.00, 0, NULL, -9467);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9754, -9934, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9466, 0.00, -87, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99467, -987, 0.00, 0, NULL, -9466);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9465, 0.00, -86, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99466, -986, 0.00, 0, NULL, -9465);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9464, 0.00, -85, -9934, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99465, -985, 0.00, 0, NULL, -9464);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9753, -9933, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9463, 0.00, -92, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99464, -992, 0.00, 0, NULL, -9463);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9462, 0.00, -91, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99463, -991, 0.00, 0, NULL, -9462);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9752, -9933, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9461, 0.00, -90, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99462, -990, 0.00, 0, NULL, -9461);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9460, 0.00, -89, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99461, -989, 0.00, 0, NULL, -9460);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9459, 0.00, -88, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99460, -988, 0.00, 0, NULL, -9459);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9751, -9933, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9458, 0.00, -87, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99459, -987, 0.00, 0, NULL, -9458);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9457, 0.00, -86, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99458, -986, 0.00, 0, NULL, -9457);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9456, 0.00, -85, -9933, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99457, -985, 0.00, 0, NULL, -9456);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9750, -9932, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9455, 0.00, -92, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99456, -992, 0.00, 0, NULL, -9455);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9454, 0.00, -91, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99455, -991, 0.00, 0, NULL, -9454);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9749, -9932, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9453, 0.00, -90, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99454, -990, 0.00, 0, NULL, -9453);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9452, 0.00, -89, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99453, -989, 0.00, 0, NULL, -9452);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9451, 0.00, -88, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99452, -988, 0.00, 0, NULL, -9451);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9748, -9932, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9450, 0.00, -87, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99451, -987, 0.00, 0, NULL, -9450);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9449, 0.00, -86, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99450, -986, 0.00, 0, NULL, -9449);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9448, 0.00, -85, -9932, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99449, -985, 0.00, 0, NULL, -9448);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9747, -9931, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9447, 0.00, -92, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99448, -992, 0.00, 0, NULL, -9447);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9446, 0.00, -91, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99447, -991, 0.00, 0, NULL, -9446);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9746, -9931, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9445, 0.00, -90, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99446, -990, 0.00, 0, NULL, -9445);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9444, 0.00, -89, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99445, -989, 0.00, 0, NULL, -9444);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9443, 0.00, -88, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99444, -988, 0.00, 0, NULL, -9443);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9745, -9931, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9442, 0.00, -87, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99443, -987, 0.00, 0, NULL, -9442);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9441, 0.00, -86, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99442, -986, 0.00, 0, NULL, -9441);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9440, 0.00, -85, -9931, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99441, -985, 0.00, 0, NULL, -9440);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9744, -9930, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9439, 0.00, -92, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99440, -992, 0.00, 0, NULL, -9439);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9438, 0.00, -91, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99439, -991, 0.00, 0, NULL, -9438);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9743, -9930, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9437, 0.00, -90, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99438, -990, 0.00, 0, NULL, -9437);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9436, 0.00, -89, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99437, -989, 0.00, 0, NULL, -9436);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9435, 0.00, -88, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99436, -988, 0.00, 0, NULL, -9435);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9742, -9930, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9434, 0.00, -87, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99435, -987, 0.00, 0, NULL, -9434);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9433, 0.00, -86, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99434, -986, 0.00, 0, NULL, -9433);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9432, 0.00, -85, -9930, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99433, -985, 0.00, 0, NULL, -9432);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9741, -9929, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9431, 0.00, -92, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99432, -992, 0.00, 0, NULL, -9431);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9430, 0.00, -91, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99431, -991, 0.00, 0, NULL, -9430);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9740, -9929, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9429, 0.00, -90, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99430, -990, 0.00, 0, NULL, -9429);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9428, 0.00, -89, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99429, -989, 0.00, 0, NULL, -9428);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9427, 0.00, -88, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99428, -988, 0.00, 0, NULL, -9427);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9739, -9929, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9426, 0.00, -87, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99427, -987, 0.00, 0, NULL, -9426);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9425, 0.00, -86, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99426, -986, 0.00, 0, NULL, -9425);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9424, 0.00, -85, -9929, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99425, -985, 0.00, 0, NULL, -9424);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9738, -9928, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9423, 0.00, -92, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99424, -992, 0.00, 0, NULL, -9423);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9422, 0.00, -91, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99423, -991, 0.00, 0, NULL, -9422);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9737, -9928, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9421, 0.00, -90, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99422, -990, 0.00, 0, NULL, -9421);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9420, 0.00, -89, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99421, -989, 0.00, 0, NULL, -9420);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9419, 0.00, -88, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99420, -988, 0.00, 0, NULL, -9419);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9736, -9928, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9418, 0.00, -87, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99419, -987, 0.00, 0, NULL, -9418);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9417, 0.00, -86, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99418, -986, 0.00, 0, NULL, -9417);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9416, 0.00, -85, -9928, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99417, -985, 0.00, 0, NULL, -9416);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9735, -9927, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9415, 0.00, -92, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99416, -992, 0.00, 0, NULL, -9415);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9414, 0.00, -91, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99415, -991, 0.00, 0, NULL, -9414);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9734, -9927, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9413, 0.00, -90, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99414, -990, 0.00, 0, NULL, -9413);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9412, 0.00, -89, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99413, -989, 0.00, 0, NULL, -9412);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9411, 0.00, -88, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99412, -988, 0.00, 0, NULL, -9411);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9733, -9927, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9410, 0.00, -87, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99411, -987, 0.00, 0, NULL, -9410);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9409, 0.00, -86, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99410, -986, 0.00, 0, NULL, -9409);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9408, 0.00, -85, -9927, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99409, -985, 0.00, 0, NULL, -9408);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9732, -9926, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9407, 0.00, -92, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99408, -992, 0.00, 0, NULL, -9407);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9406, 0.00, -91, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99407, -991, 0.00, 0, NULL, -9406);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9731, -9926, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9405, 0.00, -90, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99406, -990, 0.00, 0, NULL, -9405);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9404, 0.00, -89, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99405, -989, 0.00, 0, NULL, -9404);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9403, 0.00, -88, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99404, -988, 0.00, 0, NULL, -9403);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9730, -9926, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9402, 0.00, -87, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99403, -987, 0.00, 0, NULL, -9402);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9401, 0.00, -86, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99402, -986, 0.00, 0, NULL, -9401);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9400, 0.00, -85, -9926, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99401, -985, 0.00, 0, NULL, -9400);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9729, -9925, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9399, 0.00, -92, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99400, -992, 0.00, 0, NULL, -9399);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9398, 0.00, -91, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99399, -991, 0.00, 0, NULL, -9398);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9728, -9925, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9397, 0.00, -90, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99398, -990, 0.00, 0, NULL, -9397);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9396, 0.00, -89, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99397, -989, 0.00, 0, NULL, -9396);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9395, 0.00, -88, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99396, -988, 0.00, 0, NULL, -9395);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9727, -9925, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9394, 0.00, -87, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99395, -987, 0.00, 0, NULL, -9394);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9393, 0.00, -86, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99394, -986, 0.00, 0, NULL, -9393);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9392, 0.00, -85, -9925, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99393, -985, 0.00, 0, NULL, -9392);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9726, -9924, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9391, 0.00, -92, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99392, -992, 0.00, 0, NULL, -9391);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9390, 0.00, -91, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99391, -991, 0.00, 0, NULL, -9390);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9725, -9924, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9389, 0.00, -90, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99390, -990, 0.00, 0, NULL, -9389);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9388, 0.00, -89, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99389, -989, 0.00, 0, NULL, -9388);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9387, 0.00, -88, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99388, -988, 0.00, 0, NULL, -9387);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9724, -9924, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9386, 0.00, -87, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99387, -987, 0.00, 0, NULL, -9386);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9385, 0.00, -86, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99386, -986, 0.00, 0, NULL, -9385);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9384, 0.00, -85, -9924, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99385, -985, 0.00, 0, NULL, -9384);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9723, -9923, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9383, 0.00, -92, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99384, -992, 0.00, 0, NULL, -9383);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9382, 0.00, -91, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99383, -991, 0.00, 0, NULL, -9382);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9722, -9923, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9381, 0.00, -90, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99382, -990, 0.00, 0, NULL, -9381);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9380, 0.00, -89, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99381, -989, 0.00, 0, NULL, -9380);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9379, 0.00, -88, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99380, -988, 0.00, 0, NULL, -9379);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9721, -9923, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9378, 0.00, -87, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99379, -987, 0.00, 0, NULL, -9378);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9377, 0.00, -86, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99378, -986, 0.00, 0, NULL, -9377);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9376, 0.00, -85, -9923, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99377, -985, 0.00, 0, NULL, -9376);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9720, -9922, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9375, 0.00, -92, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99376, -992, 0.00, 0, NULL, -9375);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9374, 0.00, -91, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99375, -991, 0.00, 0, NULL, -9374);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9719, -9922, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9373, 0.00, -90, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99374, -990, 0.00, 0, NULL, -9373);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9372, 0.00, -89, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99373, -989, 0.00, 0, NULL, -9372);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9371, 0.00, -88, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99372, -988, 0.00, 0, NULL, -9371);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9718, -9922, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9370, 0.00, -87, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99371, -987, 0.00, 0, NULL, -9370);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9369, 0.00, -86, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99370, -986, 0.00, 0, NULL, -9369);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9368, 0.00, -85, -9922, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99369, -985, 0.00, 0, NULL, -9368);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9717, -9921, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9367, 0.00, -92, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99368, -992, 0.00, 0, NULL, -9367);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9366, 0.00, -91, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99367, -991, 0.00, 0, NULL, -9366);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9716, -9921, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9365, 0.00, -90, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99366, -990, 0.00, 0, NULL, -9365);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9364, 0.00, -89, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99365, -989, 0.00, 0, NULL, -9364);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9363, 0.00, -88, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99364, -988, 0.00, 0, NULL, -9363);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9715, -9921, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9362, 0.00, -87, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99363, -987, 0.00, 0, NULL, -9362);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9361, 0.00, -86, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99362, -986, 0.00, 0, NULL, -9361);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9360, 0.00, -85, -9921, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99361, -985, 0.00, 0, NULL, -9360);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9714, -9920, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9359, 0.00, -92, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99360, -992, 0.00, 0, NULL, -9359);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9358, 0.00, -91, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99359, -991, 0.00, 0, NULL, -9358);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9713, -9920, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9357, 0.00, -90, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99358, -990, 0.00, 0, NULL, -9357);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9356, 0.00, -89, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99357, -989, 0.00, 0, NULL, -9356);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9355, 0.00, -88, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99356, -988, 0.00, 0, NULL, -9355);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9712, -9920, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9354, 0.00, -87, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99355, -987, 0.00, 0, NULL, -9354);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9353, 0.00, -86, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99354, -986, 0.00, 0, NULL, -9353);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9352, 0.00, -85, -9920, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99353, -985, 0.00, 0, NULL, -9352);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9711, -9919, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9351, 0.00, -92, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99352, -992, 0.00, 0, NULL, -9351);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9350, 0.00, -91, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99351, -991, 0.00, 0, NULL, -9350);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9710, -9919, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9349, 0.00, -90, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99350, -990, 0.00, 0, NULL, -9349);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9348, 0.00, -89, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99349, -989, 0.00, 0, NULL, -9348);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9347, 0.00, -88, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99348, -988, 0.00, 0, NULL, -9347);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9709, -9919, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9346, 0.00, -87, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99347, -987, 0.00, 0, NULL, -9346);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9345, 0.00, -86, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99346, -986, 0.00, 0, NULL, -9345);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9344, 0.00, -85, -9919, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99345, -985, 0.00, 0, NULL, -9344);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9708, -9918, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9343, 0.00, -92, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99344, -992, 0.00, 0, NULL, -9343);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9342, 0.00, -91, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99343, -991, 0.00, 0, NULL, -9342);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9707, -9918, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9341, 0.00, -90, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99342, -990, 0.00, 0, NULL, -9341);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9340, 0.00, -89, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99341, -989, 0.00, 0, NULL, -9340);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9339, 0.00, -88, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99340, -988, 0.00, 0, NULL, -9339);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9706, -9918, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9338, 0.00, -87, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99339, -987, 0.00, 0, NULL, -9338);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9337, 0.00, -86, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99338, -986, 0.00, 0, NULL, -9337);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9336, 0.00, -85, -9918, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99337, -985, 0.00, 0, NULL, -9336);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9705, -9917, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9335, 0.00, -92, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99336, -992, 0.00, 0, NULL, -9335);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9334, 0.00, -91, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99335, -991, 0.00, 0, NULL, -9334);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9704, -9917, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9333, 0.00, -90, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99334, -990, 0.00, 0, NULL, -9333);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9332, 0.00, -89, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99333, -989, 0.00, 0, NULL, -9332);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9331, 0.00, -88, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99332, -988, 0.00, 0, NULL, -9331);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9703, -9917, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9330, 0.00, -87, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99331, -987, 0.00, 0, NULL, -9330);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9329, 0.00, -86, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99330, -986, 0.00, 0, NULL, -9329);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9328, 0.00, -85, -9917, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99329, -985, 0.00, 0, NULL, -9328);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9702, -9916, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9327, 0.00, -92, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99328, -992, 0.00, 0, NULL, -9327);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9326, 0.00, -91, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99327, -991, 0.00, 0, NULL, -9326);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9701, -9916, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9325, 0.00, -90, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99326, -990, 0.00, 0, NULL, -9325);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9324, 0.00, -89, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99325, -989, 0.00, 0, NULL, -9324);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9323, 0.00, -88, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99324, -988, 0.00, 0, NULL, -9323);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9700, -9916, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9322, 0.00, -87, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99323, -987, 0.00, 0, NULL, -9322);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9321, 0.00, -86, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99322, -986, 0.00, 0, NULL, -9321);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9320, 0.00, -85, -9916, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99321, -985, 0.00, 0, NULL, -9320);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9699, -9915, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9319, 0.00, -92, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99320, -992, 0.00, 0, NULL, -9319);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9318, 0.00, -91, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99319, -991, 0.00, 0, NULL, -9318);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9698, -9915, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9317, 0.00, -90, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99318, -990, 0.00, 0, NULL, -9317);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9316, 0.00, -89, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99317, -989, 0.00, 0, NULL, -9316);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9315, 0.00, -88, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99316, -988, 0.00, 0, NULL, -9315);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9697, -9915, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9314, 0.00, -87, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99315, -987, 0.00, 0, NULL, -9314);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9313, 0.00, -86, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99314, -986, 0.00, 0, NULL, -9313);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9312, 0.00, -85, -9915, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99313, -985, 0.00, 0, NULL, -9312);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9696, -9914, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9311, 0.00, -92, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99312, -992, 0.00, 0, NULL, -9311);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9310, 0.00, -91, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99311, -991, 0.00, 0, NULL, -9310);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9695, -9914, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9309, 0.00, -90, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99310, -990, 0.00, 0, NULL, -9309);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9308, 0.00, -89, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99309, -989, 0.00, 0, NULL, -9308);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9307, 0.00, -88, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99308, -988, 0.00, 0, NULL, -9307);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9694, -9914, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9306, 0.00, -87, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99307, -987, 0.00, 0, NULL, -9306);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9305, 0.00, -86, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99306, -986, 0.00, 0, NULL, -9305);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9304, 0.00, -85, -9914, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99305, -985, 0.00, 0, NULL, -9304);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9693, -9913, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9303, 0.00, -92, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99304, -992, 0.00, 0, NULL, -9303);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9302, 0.00, -91, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99303, -991, 0.00, 0, NULL, -9302);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9692, -9913, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9301, 0.00, -90, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99302, -990, 0.00, 0, NULL, -9301);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9300, 0.00, -89, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99301, -989, 0.00, 0, NULL, -9300);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9299, 0.00, -88, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99300, -988, 0.00, 0, NULL, -9299);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9691, -9913, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9298, 0.00, -87, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99299, -987, 0.00, 0, NULL, -9298);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9297, 0.00, -86, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99298, -986, 0.00, 0, NULL, -9297);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9296, 0.00, -85, -9913, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99297, -985, 0.00, 0, NULL, -9296);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9690, -9912, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9295, 0.00, -92, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99296, -992, 0.00, 0, NULL, -9295);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9294, 0.00, -91, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99295, -991, 0.00, 0, NULL, -9294);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9689, -9912, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9293, 0.00, -90, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99294, -990, 0.00, 0, NULL, -9293);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9292, 0.00, -89, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99293, -989, 0.00, 0, NULL, -9292);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9291, 0.00, -88, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99292, -988, 0.00, 0, NULL, -9291);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9688, -9912, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9290, 0.00, -87, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99291, -987, 0.00, 0, NULL, -9290);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9289, 0.00, -86, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99290, -986, 0.00, 0, NULL, -9289);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9288, 0.00, -85, -9912, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99289, -985, 0.00, 0, NULL, -9288);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9687, -9911, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9287, 0.00, -92, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99288, -992, 0.00, 0, NULL, -9287);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9286, 0.00, -91, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99287, -991, 0.00, 0, NULL, -9286);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9686, -9911, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9285, 0.00, -90, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99286, -990, 0.00, 0, NULL, -9285);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9284, 0.00, -89, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99285, -989, 0.00, 0, NULL, -9284);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9283, 0.00, -88, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99284, -988, 0.00, 0, NULL, -9283);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9685, -9911, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9282, 0.00, -87, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99283, -987, 0.00, 0, NULL, -9282);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9281, 0.00, -86, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99282, -986, 0.00, 0, NULL, -9281);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9280, 0.00, -85, -9911, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99281, -985, 0.00, 0, NULL, -9280);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9684, -9910, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9279, 0.00, -92, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99280, -992, 0.00, 0, NULL, -9279);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9278, 0.00, -91, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99279, -991, 0.00, 0, NULL, -9278);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9683, -9910, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9277, 0.00, -90, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99278, -990, 0.00, 0, NULL, -9277);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9276, 0.00, -89, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99277, -989, 0.00, 0, NULL, -9276);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9275, 0.00, -88, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99276, -988, 0.00, 0, NULL, -9275);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9682, -9910, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9274, 0.00, -87, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99275, -987, 0.00, 0, NULL, -9274);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9273, 0.00, -86, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99274, -986, 0.00, 0, NULL, -9273);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9272, 0.00, -85, -9910, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99273, -985, 0.00, 0, NULL, -9272);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9681, -9909, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9271, 0.00, -92, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99272, -992, 0.00, 0, NULL, -9271);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9270, 0.00, -91, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99271, -991, 0.00, 0, NULL, -9270);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9680, -9909, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9269, 0.00, -90, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99270, -990, 0.00, 0, NULL, -9269);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9268, 0.00, -89, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99269, -989, 0.00, 0, NULL, -9268);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9267, 0.00, -88, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99268, -988, 0.00, 0, NULL, -9267);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9679, -9909, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9266, 0.00, -87, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99267, -987, 0.00, 0, NULL, -9266);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9265, 0.00, -86, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99266, -986, 0.00, 0, NULL, -9265);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9264, 0.00, -85, -9909, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99265, -985, 0.00, 0, NULL, -9264);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9678, -9908, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9263, 0.00, -92, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99264, -992, 0.00, 0, NULL, -9263);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9262, 0.00, -91, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99263, -991, 0.00, 0, NULL, -9262);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9677, -9908, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9261, 0.00, -90, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99262, -990, 0.00, 0, NULL, -9261);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9260, 0.00, -89, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99261, -989, 0.00, 0, NULL, -9260);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9259, 0.00, -88, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99260, -988, 0.00, 0, NULL, -9259);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9676, -9908, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9258, 0.00, -87, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99259, -987, 0.00, 0, NULL, -9258);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9257, 0.00, -86, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99258, -986, 0.00, 0, NULL, -9257);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9256, 0.00, -85, -9908, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99257, -985, 0.00, 0, NULL, -9256);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9675, -9907, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9255, 0.00, -92, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99256, -992, 0.00, 0, NULL, -9255);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9254, 0.00, -91, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99255, -991, 0.00, 0, NULL, -9254);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9674, -9907, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9253, 0.00, -90, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99254, -990, 0.00, 0, NULL, -9253);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9252, 0.00, -89, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99253, -989, 0.00, 0, NULL, -9252);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9251, 0.00, -88, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99252, -988, 0.00, 0, NULL, -9251);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9673, -9907, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9250, 0.00, -87, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99251, -987, 0.00, 0, NULL, -9250);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9249, 0.00, -86, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99250, -986, 0.00, 0, NULL, -9249);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9248, 0.00, -85, -9907, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99249, -985, 0.00, 0, NULL, -9248);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9672, -9906, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9247, 0.00, -92, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99248, -992, 0.00, 0, NULL, -9247);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9246, 0.00, -91, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99247, -991, 0.00, 0, NULL, -9246);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9671, -9906, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9245, 0.00, -90, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99246, -990, 0.00, 0, NULL, -9245);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9244, 0.00, -89, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99245, -989, 0.00, 0, NULL, -9244);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9243, 0.00, -88, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99244, -988, 0.00, 0, NULL, -9243);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9670, -9906, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9242, 0.00, -87, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99243, -987, 0.00, 0, NULL, -9242);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9241, 0.00, -86, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99242, -986, 0.00, 0, NULL, -9241);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9240, 0.00, -85, -9906, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99241, -985, 0.00, 0, NULL, -9240);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9669, -9905, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9239, 0.00, -92, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99240, -992, 0.00, 0, NULL, -9239);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9238, 0.00, -91, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99239, -991, 0.00, 0, NULL, -9238);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9668, -9905, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9237, 0.00, -90, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99238, -990, 0.00, 0, NULL, -9237);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9236, 0.00, -89, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99237, -989, 0.00, 0, NULL, -9236);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9235, 0.00, -88, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99236, -988, 0.00, 0, NULL, -9235);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9667, -9905, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9234, 0.00, -87, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99235, -987, 0.00, 0, NULL, -9234);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9233, 0.00, -86, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99234, -986, 0.00, 0, NULL, -9233);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9232, 0.00, -85, -9905, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99233, -985, 0.00, 0, NULL, -9232);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9666, -9904, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9231, 0.00, -92, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99232, -992, 0.00, 0, NULL, -9231);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9230, 0.00, -91, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99231, -991, 0.00, 0, NULL, -9230);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9665, -9904, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9229, 0.00, -90, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99230, -990, 0.00, 0, NULL, -9229);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9228, 0.00, -89, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99229, -989, 0.00, 0, NULL, -9228);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9227, 0.00, -88, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99228, -988, 0.00, 0, NULL, -9227);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9664, -9904, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9226, 0.00, -87, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99227, -987, 0.00, 0, NULL, -9226);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9225, 0.00, -86, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99226, -986, 0.00, 0, NULL, -9225);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9224, 0.00, -85, -9904, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99225, -985, 0.00, 0, NULL, -9224);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9663, -9903, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9223, 0.00, -92, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99224, -992, 0.00, 0, NULL, -9223);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9222, 0.00, -91, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99223, -991, 0.00, 0, NULL, -9222);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9662, -9903, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9221, 0.00, -90, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99222, -990, 0.00, 0, NULL, -9221);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9220, 0.00, -89, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99221, -989, 0.00, 0, NULL, -9220);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9219, 0.00, -88, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99220, -988, 0.00, 0, NULL, -9219);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9661, -9903, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9218, 0.00, -87, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99219, -987, 0.00, 0, NULL, -9218);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9217, 0.00, -86, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99218, -986, 0.00, 0, NULL, -9217);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9216, 0.00, -85, -9903, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99217, -985, 0.00, 0, NULL, -9216);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9660, -9902, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9215, 0.00, -92, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99216, -992, 0.00, 0, NULL, -9215);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9214, 0.00, -91, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99215, -991, 0.00, 0, NULL, -9214);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9659, -9902, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9213, 0.00, -90, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99214, -990, 0.00, 0, NULL, -9213);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9212, 0.00, -89, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99213, -989, 0.00, 0, NULL, -9212);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9211, 0.00, -88, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99212, -988, 0.00, 0, NULL, -9211);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9658, -9902, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9210, 0.00, -87, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99211, -987, 0.00, 0, NULL, -9210);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9209, 0.00, -86, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99210, -986, 0.00, 0, NULL, -9209);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9208, 0.00, -85, -9902, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99209, -985, 0.00, 0, NULL, -9208);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9657, -9901, -96, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9207, 0.00, -92, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99208, -992, 0.00, 0, NULL, -9207);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9206, 0.00, -91, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99207, -991, 0.00, 0, NULL, -9206);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9656, -9901, -95, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9205, 0.00, -90, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99206, -990, 0.00, 0, NULL, -9205);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9204, 0.00, -89, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99205, -989, 0.00, 0, NULL, -9204);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9203, 0.00, -88, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99204, -988, 0.00, 0, NULL, -9203);

INSERT INTO public."UnitEnrollments"("Id", "LearnerId", "KnowledgeUnitId", "Start", "Status") VALUES
	(-9655, -9901, -94, '9/28/2022 6:58:23 AM', 0);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9202, 0.00, -87, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99203, -987, 0.00, 0, NULL, -9202);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9201, 0.00, -86, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99202, -986, 0.00, 0, NULL, -9201);

INSERT INTO public."KcMasteries"("Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsStarted", "IsPassed", "IsSatisfied", "IsCompleted") VALUES
	(-9200, 0.00, -85, -9901, false, false, false, false);

INSERT INTO public."AssessmentItemMasteries"("Id", "AssessmentItemId", "Mastery", "SubmissionCount", "LastSubmissionTime", "KnowledgeComponentMasteryId") VALUES
	(-99201, -985, 0.00, 0, NULL, -9200);

