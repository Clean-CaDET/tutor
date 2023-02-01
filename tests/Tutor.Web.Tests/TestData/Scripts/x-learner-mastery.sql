INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index", "Email")
VALUES (-1, -1, 'Unenrolled Student', 'SU-1-2021', NULL);
INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index", "Email")
VALUES (-2, -2, 'Enrolled Student for KCM', 'SU-2-2021', NULL);
INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index", "Email")
VALUES (-3, -3, 'Enrolled Student for Submissions', 'SU-3-2021', NULL);
INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index", "Email")
VALUES (-4, -4, 'Enrolled Student for Events', 'SU-4-2021', NULL);
INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index", "Email")
VALUES (-5, -5, 'Enrolled Student for Events', 'SU-5-2021', NULL);
INSERT INTO public."Learners"(
    "Id", "UserId", "Name", "Index", "Email")
VALUES (-6, -6, 'Empty student', 'SU-6-2021', NULL);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname", "Email") VALUES
    (-51, -51, 'TestInstructor1', 'TestInstructor1', NULL);

INSERT INTO public."Instructors"("Id", "UserId", "Name", "Surname", "Email") VALUES
    (-52, -52, 'TestInstructor2', 'TestInstructor2', NULL);

INSERT INTO public."LearnerGroups"(
	"Id", "Name", "CourseId")
VALUES (-1, 'Test Group 1', -1);
INSERT INTO public."LearnerGroups"(
	"Id", "Name", "CourseId")
VALUES (-11, 'Test Group 2', -1);
INSERT INTO public."LearnerGroups"(
	"Id", "Name", "CourseId")
VALUES (-12, 'Test Group 3', -1);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
    VALUES (-102, -1, -11);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
	VALUES (-3, -2, -1);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
	VALUES (-4, -3, -1);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
	VALUES (-5, -4, -1);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
	VALUES (-6, -5, -1);

INSERT INTO public."LearnerGroups"(
    "Id", "Name", "CourseId")
VALUES (-2, 'Test Group', -2);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-8, -1, -2);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-9, -2, -2);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-10, -3, -2);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-11, -4, -2);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-12, -5, -2);

INSERT INTO public."LearnerGroups"(
    "Id", "Name", "CourseId")
VALUES (-3, 'Test Group', -2);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-14, -1, -3);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-15, -2, -3);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-16, -3, -3);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-17, -4, -3);
INSERT INTO public."GroupMemberships"(
    "Id", "MemberId", "LearnerGroupId")
VALUES (-18, -5, -3);

INSERT INTO public."UnitEnrollments"(
	"Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
	VALUES (-1, -2, -1, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO public."UnitEnrollments"(
	"Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
	VALUES (-2, -2, -2, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO public."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-3, -3, -1, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO public."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-4, -3, -2, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO public."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-5, -4, -1, '2021-12-19 21:29:50.379749+01', 1);
INSERT INTO public."UnitEnrollments"(
    "Id", "LearnerId", "KnowledgeUnitId", "Start", "Status")
VALUES (-6, -5, -1, '2021-12-19 21:29:50.379749+01', 1);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-1, 0.0, -10, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-2, 0.1, -11, -2, false, false, false, true);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-3, 0.2, -12, -2, false, false, false, true);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-4, 0.3, -13, -2, false, false, false, true);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-5, 0.4, -14, -2, false, false, false, true);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-6, 0.5, -15, -2, false, false, false, true);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-7, 0.0, -21, -2, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-8, 0.0, -211, -2, false, false, false, false);


INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-61, 0.0, -10, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-62, 0.0, -11, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-63, 0.0, -12, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-64, 0.0, -13, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-65, 0.0, -14, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-66, 0.0, -15, -3, false, false, false, false);

INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
VALUES (-67, 0.0, -21, -3, false, false, false, false);
INSERT INTO public."KcMasteries"(
    "Id", "Mastery", "KnowledgeComponentId", "LearnerId", "IsPassed", "IsSatisfied", "IsCompleted", "IsStarted")
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

INSERT INTO public."AssessmentItemMasteries"(
	"Id", "AssessmentItemId", "Mastery", "SubmissionCount", "KnowledgeComponentMasteryId", "LastSubmissionTime")
	VALUES (-29, -10001, 0.0, 0, -67, null);

INSERT INTO public."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-1, -1, -51);

INSERT INTO public."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-2, -1, -52);

INSERT INTO public."CourseOwnerships"(
    "Id", "CourseId", "InstructorId")
VALUES (-3, -2, -52);