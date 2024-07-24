INSERT INTO "knowledgeComponents"."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
    (-10001, -21, 12);
INSERT INTO "knowledgeComponents"."MultiChoiceQuestions"("Id", "Text", "PossibleAnswers", "CorrectAnswer", "Feedback") VALUES
    (-10001, 'Ovo pitanje ima 5 ponuđenih odgovora i jedno je tačno.', '{{"1", "2", "3", "4", "5"}}', '5', 'Feedback');

INSERT INTO "knowledgeComponents"."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
    (-10002, -41, 12);
INSERT INTO "knowledgeComponents"."MultiChoiceQuestions"("Id", "Text", "PossibleAnswers", "CorrectAnswer", "Feedback") VALUES
    (-10002, 'Ovo pitanje ima 2 ponuđenih odgovora i jedno je tačno.', '{{"1", "2"}}', '2', 'Feedback 2');