INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index")
VALUES (-1, -1, 'Unenrolled Student', 'SU-1-2021');
INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index")
VALUES (-2, -2, 'Enrolled Student for KCM', 'SU-2-2021');
INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index")
VALUES (-3, -3, 'Enrolled Student for Submissions', 'SU-3-2021');

INSERT INTO public."LearnerGroups"(
	"Id", "Name")
VALUES (-1, 'Test Group');
INSERT INTO public."GroupMemberships"(
	"Id", "LearnerId", "LearnerGroupId")
	VALUES (-1, -1, -1);
INSERT INTO public."GroupMemberships"(
	"Id", "LearnerId", "LearnerGroupId")
	VALUES (-2, -2, -1);
INSERT INTO public."GroupMemberships"(
	"Id", "LearnerId", "LearnerGroupId")
	VALUES (-3, -3, -1);

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
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-1, 0.0, -10, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-2, 0.1, -11, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-3, 0.2, -12, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-4, 0.3, -13, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-5, 0.4, -14, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-6, 0.5, -15, -2, false, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-7, 0.0, -21, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-8, 0.0, -211, -2, false, false, false, false);


INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-61, 0.0, -10, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-62, 0.0, -11, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-63, 0.0, -12, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-64, 0.0, -13, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-65, 0.0, -14, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-66, 0.0, -15, -3, false, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-67, 0.0, -21, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "HasActiveSession")
VALUES (-68, 0.0, -211, -3, false, false, false, false);


INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-1, -106, 0.0, 0, -1, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-2, -106, 0.0, 0, -61, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-3, -107, 0.0, 0, -1, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-4, -107, 0.0, 0, -61, null);

INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-5, -134, 0.75, 0, -4, '2021-12-19 21:25:50.379749+01');
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-6, -134, 0.0, 0, -64, null);

INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-7, -143, 1.0, 0, -5, '2021-12-19 21:25:50.379749+01');
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-8, -143, 0.0, 0, -65, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-9, -144, 0.0, 0, -5, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-10, -144, 0.0, 0, -65, null);

INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-11, -153, 0.6, 1, -6, '2021-12-19 21:28:50.379749+01');
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-12, -153, 0.0, 0, -66, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-13, -154, 0.7, 1, -6, '2021-12-19 21:29:50.379749+01');
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-14, -154, 0.0, 0, -66, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-15, -155, 0.75, 2, -6, '2021-12-19 21:27:50.379749+01');
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-16, -155, 0.0, 0, -66, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-17, -156, 0.4, 1, -6, '2021-12-19 21:30:50.379749+01');
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-18, -156, 0.0, 0, -66, null);

INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-19, -211, 0.0, 0, -7, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-20, -211, 0.0, 0, -67, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-21, -212, 0.0, 0, -7, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-22, -212, 0.0, 0, -67, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-23, -995, 0.0, 0, -7, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-24, -995, 0.0, 0, -67, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-25, -956, 0.0, 0, -7, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-26, -956, 0.0, 0, -67, null);

INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-27, -2111, 0.0, 0, -8, null);
INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-28, -2111, 0.0, 0, -68, null);