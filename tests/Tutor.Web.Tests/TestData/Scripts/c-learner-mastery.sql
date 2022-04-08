INSERT INTO public."Learners"(
    "Id", "Name", "StudentIndex", "Password", "Salt") -- Password: 123
VALUES (-1, 'Unenrolled Student', 'SU-1-2021', 'SXQ0w0gW19OPoX3+jZ+tmcU6xl9uQFa5wRFcYbN8UKo=', '+ZcRExvqgCaST38r2oPT5A==');
INSERT INTO public."Learners"(
    "Id", "Name", "StudentIndex", "Password", "Salt") -- Password: 123
VALUES (-2, 'Enrolled Student for KCM', 'SU-2-2021', 'SXQ0w0gW19OPoX3+jZ+tmcU6xl9uQFa5wRFcYbN8UKo=', '+ZcRExvqgCaST38r2oPT5A==');
INSERT INTO public."Learners"(
    "Id", "Name", "StudentIndex", "Password", "Salt") -- Password: 123
VALUES (-3, 'Enrolled Student for Submissions', 'SU-3-2021', 'SXQ0w0gW19OPoX3+jZ+tmcU6xl9uQFa5wRFcYbN8UKo=', '+ZcRExvqgCaST38r2oPT5A==');

INSERT INTO public."UnitEnrollments"(
	"Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
	VALUES (-1, -2, -1, '2021-12-19 21:29:50.379749+01', 0);
INSERT INTO public."UnitEnrollments"(
	"Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
	VALUES (-2, -2, -2, '2021-12-19 21:29:50.379749+01', 0);
INSERT INTO public."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-3, -3, -1, '2021-12-19 21:29:50.379749+01', 0);
INSERT INTO public."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-4, -3, -2, '2021-12-19 21:29:50.379749+01', 0);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-1, 0.0, -10, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-2, 0.1, -11, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-3, 0.2, -12, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-4, 0.3, -13, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-5, 0.4, -14, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-6, 0.5, -15, -2, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-7, 0.0, -21, -2, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-8, 0.0, -211, -2, false, false, false);


INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-61, 0.0, -10, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-62, 0.0, -11, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-63, 0.0, -12, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-64, 0.0, -13, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-65, 0.0, -14, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-66, 0.0, -15, -3, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-67, 0.0, -21, -3, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "HasActiveSession")
VALUES (-68, 0.0, -211, -3, false, false, false);