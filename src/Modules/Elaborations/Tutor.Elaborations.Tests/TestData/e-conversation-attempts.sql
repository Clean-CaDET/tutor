-- Attempt -1: Learner -2, CET -1, Completed (for query tests and cannot-submit tests)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-1, -1, -2, 1, '2024-06-01 10:00:00+00', '2024-06-01 10:15:00+00', 1.0, 1, 4, 1);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-1, -1, 0, 'Encapsulation bundles data and methods in a class, hiding implementation details.', 0, '2024-06-01 10:01:00+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-2, -1, 1, '1.00', 1, '2024-06-01 10:01:05+00');

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "Assessments", "MisconceptionsTriggeredKeys")
VALUES (-1, -1, '[{{"Key":"P1","Type":0,"Grade":2}}]'::jsonb, '[]'::jsonb);

-- Attempt -2: Learner -2, CET -1, Abandoned (for query tests)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-2, -1, -2, 2, '2024-06-02 10:00:00+00', '2024-06-02 10:05:00+00', 0.0, 1, 4, 0);

-- Attempt -3: Learner -3, CET -1, InProgress, RoundCount=1 (conflict + eval failure tests)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-3, -1, -3, 0, '2024-06-03 10:00:00+00', null, 0.0, 1, 4, 1);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-4, -3, 0, 'Encapsulation is about data hiding.', 0, '2024-06-03 10:01:00+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-5, -3, 1, 'What else can you tell me about encapsulation?', 1, '2024-06-03 10:01:05+00');

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "Assessments", "MisconceptionsTriggeredKeys")
VALUES (-4, -4, '[{{"Key":"P1","Type":0,"Grade":0}}]'::jsonb, '["M1"]'::jsonb);

-- Attempt -4: Learner -3, CET -2, InProgress, RoundCount=1 (completion test: submit all grade 2 → Completed)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-4, -2, -3, 0, '2024-06-04 10:00:00+00', null, 0.0, 2, 4, 1);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-6, -4, 0, 'Encapsulation bundles data and methods, but access control is unclear.', 0, '2024-06-04 10:01:00+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-7, -4, 1, 'Consider elaborating on how access modifiers enforce encapsulation.', 1, '2024-06-04 10:01:05+00');

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "Assessments", "MisconceptionsTriggeredKeys")
VALUES (-6, -6, '[{{"Key":"P1","Type":0,"Grade":1}},{{"Key":"P2","Type":0,"Grade":0}}]'::jsonb, '[]'::jsonb);

-- Attempt -5: Learner -2, CET -2, InProgress, RoundCount=3, MaxRounds=4 (hard cap test: next submission expires)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-5, -2, -2, 0, '2024-06-05 10:00:00+00', null, 0.0, 2, 4, 3);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-50, -5, 0, 'Round 1 elaboration.', 0, '2024-06-05 10:01:00+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-51, -5, 1, 'Feedback 1.', 1, '2024-06-05 10:01:05+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-52, -5, 0, 'Round 2 elaboration.', 2, '2024-06-05 10:02:00+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-53, -5, 1, 'Feedback 2.', 3, '2024-06-05 10:02:05+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-54, -5, 0, 'Round 3 elaboration.', 4, '2024-06-05 10:03:00+00');
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp")
VALUES (-55, -5, 1, 'Feedback 3.', 5, '2024-06-05 10:03:05+00');

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "Assessments", "MisconceptionsTriggeredKeys")
VALUES (-50, -50, '[{{"Key":"P1","Type":0,"Grade":0}},{{"Key":"P2","Type":0,"Grade":0}}]'::jsonb, '[]'::jsonb);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "Assessments", "MisconceptionsTriggeredKeys")
VALUES (-52, -52, '[{{"Key":"P1","Type":0,"Grade":0}},{{"Key":"P2","Type":0,"Grade":0}}]'::jsonb, '[]'::jsonb);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "Assessments", "MisconceptionsTriggeredKeys")
VALUES (-54, -54, '[{{"Key":"P1","Type":0,"Grade":0}},{{"Key":"P2","Type":0,"Grade":0}}]'::jsonb, '[]'::jsonb);

-- Attempt -6: Learner -3, CET -3, InProgress, RoundCount=0 (isolated for Start+Submit flow test)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-6, -3, -3, 0, '2024-06-06 10:00:00+00', null, 0.0, 1, 4, 0);

-- Attempt -7: Learner -3, CET -5, InProgress, RoundCount=0 (isolated for abandon test)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-7, -5, -3, 0, '2024-06-07 10:00:00+00', null, 0.0, 2, 4, 0);
