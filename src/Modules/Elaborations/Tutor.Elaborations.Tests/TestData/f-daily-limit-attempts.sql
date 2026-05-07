-- 3 recent attempts for Learner -2 on CET -3 (triggers MaxAttemptsPerDay=3 limit)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-10, -3, -2, 1, NOW() - INTERVAL '3 hours', NOW() - INTERVAL '2 hours', 1.0, 1, 4, 1);
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-11, -3, -2, 1, NOW() - INTERVAL '2 hours', NOW() - INTERVAL '1 hour', 1.0, 1, 4, 1);
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "FinalGrade", "TotalTargets", "MaxRounds", "RoundCount")
VALUES (-12, -3, -2, 2, NOW() - INTERVAL '1 hour', NOW() - INTERVAL '30 minutes', 0.0, 1, 4, 0);
