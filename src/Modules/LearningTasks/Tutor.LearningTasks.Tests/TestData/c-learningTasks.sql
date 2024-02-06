INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "DomainModel", "CaseStudies", "MaxPoints")
	VALUES (-1, -1, 'FirstTask', 'FirstDescription', false, '{{"Description":"Description1"}}', '[{{"Name":"FirstCaseStudy", "Description":"Description1"}}]', 10);
INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "DomainModel", "CaseStudies", "MaxPoints")
	VALUES (-2, -1, 'SecondTask', 'SecondDescription', false, '{{"Description":"Description2"}}', null, 5);
INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "DomainModel", "CaseStudies", "MaxPoints")
	VALUES (-3, -2, 'ThirdTask', 'ThirdDescription', false, '{{"Description":"Description3"}}', '[{{"Name":"FirstCaseStudy", "Description":"Description1"}}, {{"Name":"SecondCaseStudy", "Description":"Description2"}}]', 15);
INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "DomainModel", "CaseStudies", "MaxPoints")
	VALUES (-4, -2, 'FourthTask', 'FourthDescription', false, '{{"Description":"Description4"}}', null, 10);
INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "DomainModel", "CaseStudies", "MaxPoints")
	VALUES (-5, -3, 'FifthTask', 'FifthDescription', false, '{{"Description":"Description5"}}', '[{{"Name":"FirstCaseStudy", "Description":"Description1"}}]', 0);