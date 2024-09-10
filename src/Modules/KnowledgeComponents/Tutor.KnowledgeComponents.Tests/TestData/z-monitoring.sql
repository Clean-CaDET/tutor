INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order", "ExpectedDurationInMinutes")
	VALUES (-9999, 'T-9999', '', -9999, '-9999', 1, 6);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order", "ExpectedDurationInMinutes")
	VALUES (-9998, 'T-9998', '', -9999, '-9998', 2, 4);

INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99900, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:24:26.127578+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:24:26.1275783Z", "$discriminator": "SessionLaunched", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99901, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:24:26.305084+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:24:26.3050849Z", "$discriminator": "InstructionalItemsSelected", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99902, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:25:16.276046+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:25:16.2760469Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99903, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:25:18.60629+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:25:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999, "AttemptCount": 1, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 0}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99904, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:25:23.276046+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:25:23.2760469Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99905, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:26:31.729124+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:26:31.7291247Z", "$discriminator": "SessionPaused", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99906, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:29:59.652288+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:29:59.652288Z", "$discriminator": "SessionContinued", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99907, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:31:05.262418+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:31:05.2624184Z",  "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999, "AttemptCount": 1, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 0}}, "FeedbackType": 3}}, "Submission": {{"Answer": "10", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99908, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:31:17.792253+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:31:17.7922531Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99909, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:31:47.713617+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:31:47.713617Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999, "AttemptCount": 1, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "MrqEvaluation", "CorrectnessLevel": 0.6}}, "FeedbackType": 3}}, "Submission": {{"$discriminator": "MrqSubmission", "ReattemptCount": 0, "SubmittedAnswers": ["1"]}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99910, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:31:48.127578+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:31:48.1275783Z", "$discriminator": "KnowledgeComponentCompleted", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99911, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:31:53.557335+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:31:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99912, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:33:18.60629+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:33:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999, "AttemptCount": 2, "IsFirstCorrect": true, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": true, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 1}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99913, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:34:53.557335+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:34:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99914, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:35:18.60629+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:35:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999, "AttemptCount": 2, "IsFirstCorrect": true, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": true, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 1}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99915, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:35:53.557335+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:35:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99916, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:36:18.60629+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:36:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999, "AttemptCount": 2, "IsFirstCorrect": true, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": true, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 1}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99917, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:36:26.127578+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:36:26.1275783Z", "$discriminator": "KnowledgeComponentPassed", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99918, -9999, -9999, 'KnowledgeComponentMastery', -9999, '2023-10-21 15:36:27.127578+02',
        '{{"LearnerId": -9999, "TimeStamp": "2023-10-21T13:36:27.1275783Z", "$discriminator": "KnowledgeComponentSatisfied", "KnowledgeComponentId": -9999, "MinutesToSatisfaction": 12.01}}');