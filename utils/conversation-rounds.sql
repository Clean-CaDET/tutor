SELECT
    cr."Id" AS "ConversationRoundId",
    cr."ConversationAttemptId",
    cr."Order",
    cr."ElaborationContent",
    cr."SubmittedAt",
    cr."FeedbackContent",
    cr."Probes",

    re."Id" AS "RoundEvaluationId",
    re."Assessments",
    re."TriggeredMisconceptions"
FROM elaborations."ConversationRounds" cr
LEFT JOIN elaborations."RoundEvaluations" re
    ON re."ConversationRoundId" = cr."Id"
	
WHERE cr."ConversationAttemptId"=?
ORDER BY cr."Order";