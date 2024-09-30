INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order", "ExpectedDurationInMinutes")
	VALUES (-9999, 'T-9999', '', -9999, '-9999', 1, 6);
INSERT INTO "knowledgeComponents"."KnowledgeComponents"(
    "Id", "Name", "Description", "KnowledgeUnitId", "Code", "Order", "ExpectedDurationInMinutes")
	VALUES (-9998, 'T-9998', '', -9999, '-9998', 2, 8);

-- Learner -9999 only interacted with KC -9999 (2 negative patterns should be exhibited)
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


-- Learner -9998 interacted with KC -9999 (no negative patterns) and -9998 (2 negative patterns)
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99950, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:24:26.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:24:26.1275783Z", "$discriminator": "SessionLaunched", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99951, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:24:26.305084+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:24:26.3050849Z", "$discriminator": "InstructionalItemsSelected", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99952, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:25:00.276046+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:25:00.2760469Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99953, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:25:31.60629+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:25:31.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999, "AttemptCount": 1, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 0}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99954, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:25:32.276046+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:25:32.2760469Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99955, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:26:35.729124+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:26:35.7291247Z", "$discriminator": "SessionPaused", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99956, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:29:59.652288+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:29:59.652288Z", "$discriminator": "SessionContinued", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99957, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:31:05.262418+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:31:05.2624184Z",  "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999, "AttemptCount": 1, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 0}}, "FeedbackType": 3}}, "Submission": {{"Answer": "10", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99958, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:31:17.792253+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:31:17.7922531Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99959, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:31:47.713617+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:31:47.713617Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999, "AttemptCount": 1, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "MrqEvaluation", "CorrectnessLevel": 0.6}}, "FeedbackType": 3}}, "Submission": {{"$discriminator": "MrqSubmission", "ReattemptCount": 0, "SubmittedAnswers": ["1"]}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99960, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:31:48.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:31:48.1275783Z", "$discriminator": "KnowledgeComponentCompleted", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99961, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:31:53.557335+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:31:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99962, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:33:18.60629+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:33:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9999, "KnowledgeComponentId": -9999, "AttemptCount": 2, "IsFirstCorrect": true, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": true, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 1}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99963, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:34:53.557335+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:34:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99964, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:35:18.60629+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:35:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9998, "KnowledgeComponentId": -9999, "AttemptCount": 2, "IsFirstCorrect": true, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": true, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 1}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99965, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:35:26.305084+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:35:26.3050849Z", "$discriminator": "InstructionalItemsSelected", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99966, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:36:53.557335+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:36:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99967, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:37:18.60629+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:37:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9997, "KnowledgeComponentId": -9999, "AttemptCount": 2, "IsFirstCorrect": true, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": true, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 1}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99968, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:37:26.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:37:26.1275783Z", "$discriminator": "KnowledgeComponentPassed", "KnowledgeComponentId": -9999}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99969, -9999, -9998, 'KnowledgeComponentMastery', -9998, '2023-10-21 15:37:27.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-21T13:37:27.1275783Z", "$discriminator": "KnowledgeComponentSatisfied", "KnowledgeComponentId": -9999, "MinutesToSatisfaction": 12.01}}');


INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99970, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:34:26.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:34:26.1275783Z", "$discriminator": "SessionLaunched", "KnowledgeComponentId": -9998}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99971, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:35:26.305084+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:35:26.3050849Z", "$discriminator": "InstructionalItemsSelected", "KnowledgeComponentId": -9998}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99972, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:37:43.557335+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:37:43.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9996, "KnowledgeComponentId": -9998}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99973, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:38:18.60629+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:38:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9996, "KnowledgeComponentId": -9998, "AttemptCount": 1, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 0.3}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 0}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99974, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:38:48.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:38:48.1275783Z", "$discriminator": "KnowledgeComponentCompleted", "KnowledgeComponentId": -9998}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99975, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:38:53.557335+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:38:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9996, "KnowledgeComponentId": -9998}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99976, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:39:18.60629+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:39:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9996, "KnowledgeComponentId": -9998, "AttemptCount": 2, "IsFirstCorrect": false, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": false, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 0.5}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 1}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99977, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:39:53.557335+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:39:53.5573358Z", "$discriminator": "AssessmentItemSelected", "AssessmentItemId": -9996, "KnowledgeComponentId": -9998}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99978, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:40:18.60629+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:40:18.6062906Z", "$discriminator": "AssessmentItemAnswered", "AssessmentItemId": -9996, "KnowledgeComponentId": -9998, "AttemptCount": 3, "IsFirstCorrect": true, "Feedback": {{"Hint": null, "Evaluation": {{"Correct": true, "$discriminator": "SaqEvaluation", "CorrectnessLevel": 1}}, "FeedbackType": 3}}, "Submission": {{"Answer": "4", "$discriminator": "SaqSubmission", "ReattemptCount": 2}}}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99979, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:40:26.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:40:26.1275783Z", "$discriminator": "KnowledgeComponentPassed", "KnowledgeComponentId": -9998}}');
INSERT INTO "knowledgeComponents"."Events"(
    "Id", "KnowledgeComponentId", "LearnerId", "AggregateType", "AggregateId", "TimeStamp", "DomainEvent")
    VALUES (-99980, -9998, -9998, 'KnowledgeComponentMastery', -9997, '2023-10-22 15:40:27.127578+02',
        '{{"LearnerId": -9998, "TimeStamp": "2023-10-22T13:40:27.1275783Z", "$discriminator": "KnowledgeComponentSatisfied", "KnowledgeComponentId": -9998, "MinutesToSatisfaction": 6.01}}');