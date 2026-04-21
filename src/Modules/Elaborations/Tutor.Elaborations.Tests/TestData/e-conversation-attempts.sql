-- Attempt -1: Learner -2, CET -1, Completed with 3 turns (for query tests)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-1, -1, -2, 1, '2024-06-01 10:00:00+00', '2024-06-01 10:15:00+00', 'Good understanding of encapsulation basics.');

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-1, -1, 0, 'Encapsulation bundles data and methods in a class.', 0, '2024-06-01 10:01:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-2, -1, 1, 'Good start! Can you tell me more about access modifiers?', 1, '2024-06-01 10:01:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-3, -1, 0, 'Access modifiers like public and private control visibility.', 2, '2024-06-01 10:02:00+00', 0);

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-1, -1, 2, 2, 2, null, 'Accurate basic description', null, '[-10]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-3, -3, 2, 2, 2, null, 'Good description of access modifiers', null, '[-10]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);

-- Attempt -2: Learner -2, CET -1, Abandoned (for query tests)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-2, -1, -2, 2, '2024-06-02 10:00:00+00', '2024-06-02 10:05:00+00', null);

-- Attempt -3: Learner -3, CET -1, InProgress with 2 turns (for abandon + follow-up tests)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-3, -1, -3, 0, '2024-06-03 10:00:00+00', null, null);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-4, -3, 0, 'Encapsulation is about data hiding.', 0, '2024-06-03 10:01:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-5, -3, 1, 'What else can you tell me about encapsulation?', 1, '2024-06-03 10:01:05+00', null);

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-4, -4, 1, 1, 1, null, 'Partially correct but incomplete', null, '[]'::jsonb, '[-210]'::jsonb, '[]'::jsonb, false);

-- Attempt -4: Learner -3, CET -2, InProgress (for completion test: KP -20 already covered, submit to cover -21)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-4, -2, -3, 0, '2024-06-04 10:00:00+00', null, null);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-6, -4, 0, 'Encapsulation bundles data and methods together.', 0, '2024-06-04 10:01:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-7, -4, 1, 'Good. What about access control?', 1, '2024-06-04 10:01:05+00', null);

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-6, -6, 2, 2, 2, null, 'Covers bundling proposition', null, '[-20]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);

-- Attempt -5: Learner -2, CET -2, InProgress with 9 learner + 9 system turns (for hard cap test)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-5, -2, -2, 0, '2024-06-05 10:00:00+00', null, null);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-50, -5, 0, 'Turn 1', 0, '2024-06-05 10:01:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-51, -5, 1, 'Response 1', 1, '2024-06-05 10:01:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-52, -5, 0, 'Turn 2', 2, '2024-06-05 10:02:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-53, -5, 1, 'Response 2', 3, '2024-06-05 10:02:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-54, -5, 0, 'Turn 3', 4, '2024-06-05 10:03:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-55, -5, 1, 'Response 3', 5, '2024-06-05 10:03:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-56, -5, 0, 'Turn 4', 6, '2024-06-05 10:04:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-57, -5, 1, 'Response 4', 7, '2024-06-05 10:04:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-58, -5, 0, 'Turn 5', 8, '2024-06-05 10:05:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-59, -5, 1, 'Response 5', 9, '2024-06-05 10:05:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-60, -5, 0, 'Turn 6', 10, '2024-06-05 10:06:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-61, -5, 1, 'Response 6', 11, '2024-06-05 10:06:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-62, -5, 0, 'Turn 7', 12, '2024-06-05 10:07:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-63, -5, 1, 'Response 7', 13, '2024-06-05 10:07:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-64, -5, 0, 'Turn 8', 14, '2024-06-05 10:08:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-65, -5, 1, 'Response 8', 15, '2024-06-05 10:08:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-66, -5, 0, 'Turn 9', 16, '2024-06-05 10:09:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-67, -5, 1, 'Response 9', 17, '2024-06-05 10:09:05+00', null);

-- Evaluations for the 9 learner turns (all with empty propositions - never completes)
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-50, -50, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-52, -52, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-54, -54, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-56, -56, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-58, -58, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-60, -60, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-62, -62, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-64, -64, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-66, -66, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);

-- Attempt -6: Learner -3, CET -3, InProgress with 5 substantive learner + 5 system turns (for soft cap test)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-6, -3, -3, 0, '2024-06-06 10:00:00+00', null, null);

INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-70, -6, 0, 'Turn 1', 0, '2024-06-06 10:01:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-71, -6, 1, 'Response 1', 1, '2024-06-06 10:01:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-72, -6, 0, 'Turn 2', 2, '2024-06-06 10:02:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-73, -6, 1, 'Response 2', 3, '2024-06-06 10:02:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-74, -6, 0, 'Turn 3', 4, '2024-06-06 10:03:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-75, -6, 1, 'Response 3', 5, '2024-06-06 10:03:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-76, -6, 0, 'Turn 4', 6, '2024-06-06 10:04:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-77, -6, 1, 'Response 4', 7, '2024-06-06 10:04:05+00', null);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-78, -6, 0, 'Turn 5', 8, '2024-06-06 10:05:00+00', 0);
INSERT INTO elaborations."ConversationTurns"("Id", "ConversationAttemptId", "Role", "Content", "Order", "Timestamp", "Intent")
VALUES (-79, -6, 1, 'Response 5', 9, '2024-06-06 10:05:05+00', null);

INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-70, -70, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-72, -72, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-74, -74, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-76, -76, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);
INSERT INTO elaborations."TurnEvaluations"("Id", "ConversationTurnId", "CorrectnessScore", "CompletenessScore", "DiscriminationScore", "IntegrationScore", "Justification", "NovelMisconceptions", "PropositionsCoveredIds", "MisconceptionsTriggeredIds", "RelationsArticulatedIds", "HasMultipleConcerns")
VALUES (-78, -78, 1, 1, 1, null, 'Vague', null, '[]'::jsonb, '[]'::jsonb, '[]'::jsonb, false);

-- Attempt -7: Learner -3, CET -5, InProgress (isolated for abandon test — no other test touches this)
INSERT INTO elaborations."ConversationAttempts"("Id", "ConceptElaborationTaskId", "LearnerId", "Status", "StartedAt", "CompletedAt", "Summary")
VALUES (-7, -5, -3, 0, '2024-06-07 10:00:00+00', null, null);
