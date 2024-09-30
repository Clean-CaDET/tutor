INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "MaxPoints", "Order")
	VALUES (-9999, -9998, 'Monitoring task 1', '', false, 5, 1);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-9999, 0, 1, 'M-9999', 'M-9999', '', '[{{"Code":"M-9999", "Url":""}}]', '{{"Type":0,"ValidationRule":"", "Guidelines":""}}', 2, -9999);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-9998, 0, 2, 'M-9998', 'M-9998', '', '[{{"Code":"M-9998", "Url":""}}]', '{{"Type":0,"ValidationRule":"", "Guidelines":""}}', 3, -9999);
INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "MaxPoints", "Order")
	VALUES (-9998, -9998, 'Monitoring task 2', '', false, 10, 1);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-9997, 0, 1, 'M-9997', 'M-9997', '', '[{{"Code":"M-9997", "Url":""}}]', '{{"Type":0,"ValidationRule":"", "Guidelines":""}}', 4, -9998);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-9996, 0, 1, 'M-9996', 'M-9996', '', '[{{"Code":"M-9996", "Url":""}}]', '{{"Type":0,"ValidationRule":"", "Guidelines":""}}', 6, -9998);
INSERT INTO "learningTasks"."LearningTasks"(
    "Id", "UnitId", "Name", "Description", "IsTemplate", "MaxPoints", "Order")
	VALUES (-9997, -9999, 'Monitoring task 3 - Nobody accessed it', '', false, 1, 1);
INSERT INTO "learningTasks"."Activities"(
    "Id", "ParentId", "Order", "Code",  "Name", "Guidance", "Examples", "SubmissionFormat", "MaxPoints", "LearningTaskId")
	VALUES (-9995, 0, 1, 'M-9999', 'M-9999', '', '[{{"Code":"M-9999", "Url":""}}]', '{{"Type":0,"ValidationRule":"", "Guidelines":""}}', 1, -9997);


INSERT INTO "learningTasks"."TaskProgresses" (
    "Id", "TotalScore", "Status", "LearningTaskId", "LearnerId")
	VALUES (-9999, 4, 3, -9999, -9999);
INSERT INTO "learningTasks"."TaskProgresses" (
    "Id", "TotalScore", "Status", "LearningTaskId", "LearnerId")
	VALUES (-9997, 2, 3, -9999, -9998);
-- No progress for learner 9997 (did not even open)

INSERT INTO "learningTasks"."TaskProgresses" (
    "Id", "TotalScore", "Status", "LearningTaskId", "LearnerId")
	VALUES (-9998, 4, 3, -9998, -9999);
INSERT INTO "learningTasks"."TaskProgresses" (
    "Id", "TotalScore", "Status", "LearningTaskId", "LearnerId")
	VALUES (-9996, 1, 3, -9998, -9998);
INSERT INTO "learningTasks"."TaskProgresses" (
    "Id", "TotalScore", "Status", "LearningTaskId", "LearnerId")
	VALUES (-9995, 0, 1, -9998, -9997);



-- Learner -9999 only interacted with Task -9999 (1 negative pattern)
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99900, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:36:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:36:27.1275783Z", "$discriminator": "TaskOpened"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99901, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:36:29.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:36:29.1275783Z", "$discriminator": "StepOpened", "StepId": -9999}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99902, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:36:33.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:36:33.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9999}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99903, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:56:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:56:27.1275783Z", "$discriminator": "StepSubmitted", "StepId": -9999, "Answer":"Neki tekst"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99904, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:56:29.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:56:29.1275783Z", "$discriminator": "StepOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99905, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:56:33.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:56:33.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99906, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:57:33.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:57:33.1275783Z", "$discriminator": "GuidanceOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99907, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 15:59:37.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T13:59:37.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99908, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 16:00:00.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T14:00:00.1275783Z", "$discriminator": "StepSubmitted", "StepId": -9998, "Answer":"Neki tekst"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99909, -9999, -9999, 'TaskProgress', -9999, '2023-10-24 16:00:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-24T14:00:27.1275783Z", "$discriminator": "TaskCompleted"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99910, -9999, -9999, 'TaskProgress', -9999, '2023-10-25 16:00:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9999, "TimeStamp": "2023-10-25T14:00:27.1275783Z", "$discriminator": "TaskGraded", "TotalScore": 4}}');


INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99911, -9999, -9998, 'TaskProgress', -9998, '2023-10-25 15:36:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9998, "TimeStamp": "2023-10-25T13:36:27.1275783Z", "$discriminator": "TaskOpened"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99912, -9999, -9998, 'TaskProgress', -9998, '2023-10-25 15:36:29.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9998, "TimeStamp": "2023-10-25T13:36:29.1275783Z", "$discriminator": "StepOpened", "StepId": -9997}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99913, -9999, -9998, 'TaskProgress', -9998, '2023-10-25 15:36:33.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9998, "TimeStamp": "2023-10-25T13:36:33.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9997}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99914, -9999, -9998, 'TaskProgress', -9998, '2023-10-25 15:56:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9998, "TimeStamp": "2023-10-25T13:56:27.1275783Z", "$discriminator": "StepSubmitted", "StepId": -9997, "Answer":"Neki tekst"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99915, -9999, -9998, 'TaskProgress', -9998, '2023-10-25 16:00:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9998, "TimeStamp": "2023-10-25T14:00:27.1275783Z", "$discriminator": "TaskCompleted"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99916, -9999, -9998, 'TaskProgress', -9998, '2023-10-26 16:00:27.127578+02',
        '{{"LearnerId": -9999, "TaskId": -9998, "TimeStamp": "2023-10-26T14:00:27.1275783Z", "$discriminator": "TaskGraded", "TotalScore": 4}}');



-- Learner -9998
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99920, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:36:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:36:27.1275783Z", "$discriminator": "TaskOpened"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99921, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:36:29.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:36:29.1275783Z", "$discriminator": "StepOpened", "StepId": -9999}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99922, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:36:33.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:36:33.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9999}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99923, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:37:33.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:37:33.1275783Z", "$discriminator": "GuidanceOpened", "StepId": -9999}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99926, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:56:29.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:56:29.1275783Z", "$discriminator": "StepOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99927, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:56:33.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:56:33.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99928, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:57:33.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:57:33.1275783Z", "$discriminator": "GuidanceOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99929, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 15:59:37.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T13:59:37.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9998}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99930, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 16:00:00.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T14:00:00.1275783Z", "$discriminator": "StepSubmitted", "StepId": -9998, "Answer":"Neki tekst"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99924, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 16:00:33.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T14:00:33.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9999}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99925, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 16:02:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T14:02:27.1275783Z", "$discriminator": "StepSubmitted", "StepId": -9999, "Answer":"Neki tekst"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99931, -9998, -9999, 'TaskProgress', -9997, '2023-10-24 16:00:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-24T14:00:27.1275783Z", "$discriminator": "TaskCompleted"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99932, -9998, -9999, 'TaskProgress', -9997, '2023-10-25 16:00:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9999, "TimeStamp": "2023-10-25T14:00:27.1275783Z", "$discriminator": "TaskGraded", "TotalScore": 2}}');


INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99933, -9998, -9998, 'TaskProgress', -9997, '2023-10-25 15:36:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9998, "TimeStamp": "2023-10-25T13:36:27.1275783Z", "$discriminator": "TaskOpened"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99934, -9998, -9998, 'TaskProgress', -9997, '2023-10-25 15:36:29.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9998, "TimeStamp": "2023-10-25T13:36:29.1275783Z", "$discriminator": "StepOpened", "StepId": -9997}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99935, -9998, -9998, 'TaskProgress', -9997, '2023-10-25 15:36:33.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9998, "TimeStamp": "2023-10-25T13:36:33.1275783Z", "$discriminator": "SubmissionOpened", "StepId": -9997}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99936, -9998, -9998, 'TaskProgress', -9997, '2023-10-25 15:56:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9998, "TimeStamp": "2023-10-25T13:56:27.1275783Z", "$discriminator": "StepSubmitted", "StepId": -9997, "Answer":"Neki tekst"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99937, -9998, -9998, 'TaskProgress', -9997, '2023-10-25 16:00:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9998, "TimeStamp": "2023-10-25T14:00:27.1275783Z", "$discriminator": "TaskCompleted"}}');
INSERT INTO "learningTasks"."Events"(
	"Id", "LearnerId", "TaskId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
	VALUES (-99938, -9998, -9998, 'TaskProgress', -9997, '2023-10-26 16:00:27.127578+02',
        '{{"LearnerId": -9998, "TaskId": -9998, "TimeStamp": "2023-10-26T14:00:27.1275783Z", "$discriminator": "TaskGraded", "TotalScore": 1}}');