-- 3 recent attempts for Learner -2 on CET -3 (triggers MaxAttemptsPerDay=3 limit)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-10, -3, -2, 1, NOW() - INTERVAL '3 hours', NOW() - INTERVAL '2 hours', 'Daily limit attempt 1');
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-11, -3, -2, 1, NOW() - INTERVAL '2 hours', NOW() - INTERVAL '1 hour', 'Daily limit attempt 2');
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-12, -3, -2, 2, NOW() - INTERVAL '1 hour', NOW() - INTERVAL '30 minutes', null);
