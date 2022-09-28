using System.IO;
using Tutor.Infrastructure.Database.DataImport.Domain;
using Tutor.Infrastructure.Database.DataImport.Enrollment;
using Tutor.Infrastructure.Database.DataImport.Learner;

namespace Tutor.Infrastructure.Database.DataImport;

public static class ExcelToSqlTransformer
{
    public static void Transform(string domainSource, string learnerSource, string enrollmentSource, string destination)
    {
        var domainSheets = ExcelImporter.ImportWorkSheets(domainSource);
        var learnerSheets = ExcelImporter.ImportWorkSheets(learnerSource);
        var enrollmentSheets = ExcelImporter.ImportWorkSheets(enrollmentSource);

        var domainContent = ExcelToDomainTransformer.Transform(domainSheets);
        var domainSql = DomainToSqlTransformer.Transform(domainContent);

        var learners = ExcelToLearnerTransformer.Transform(learnerSheets);
        var learnerSql = LearnerToSqlTransformer.Transform(learners);

        var enrollmentContent = ExcelToEnrollmentTransformer.Transform(enrollmentSheets);
        var enrollmentSql = EnrollmentToSqlTransformer.Transform(enrollmentContent, domainContent, learners);

        Save(DeleteCommands + domainSql + learnerSql + enrollmentSql, destination);
    }

    private const string DeleteCommands = @"
DELETE FROM public.""EmotionsFeedbacks"";
DELETE FROM public.""TutorImprovementFeedbacks"";
DELETE FROM public.""Notes"";

DELETE FROM public.""AssessmentItemMasteries"";
DELETE FROM public.""KcMasteries"";
DELETE FROM public.""UnitEnrollments"";
DELETE FROM public.""GroupMemberships"";
DELETE FROM public.""LearnerGroups"";
DELETE FROM public.""CourseOwnerships"";
DELETE FROM public.""Events"";

DELETE FROM public.""Texts"";
DELETE FROM public.""Images"";
DELETE FROM public.""Videos"";
DELETE FROM public.""BasicMetricCheckers"";
DELETE FROM public.""BannedWordsCheckers"";
DELETE FROM public.""RequiredWordsCheckers"";
DELETE FROM public.""ChallengeHints"";
DELETE FROM public.""ChallengeFulfillmentStrategies"";
DELETE FROM public.""Challenges"";
DELETE FROM public.""MrqItems"";
DELETE FROM public.""MultiResponseQuestions"";
DELETE FROM public.""MultiChoiceQuestions"";
DELETE FROM public.""ArrangeTaskElements"";
DELETE FROM public.""ArrangeTaskContainers"";
DELETE FROM public.""ArrangeTasks"";
DELETE FROM public.""ShortAnswerQuestions"";
DELETE FROM public.""AssessmentItems"";
DELETE FROM public.""InstructionalItems"";
DELETE FROM public.""KnowledgeComponents"";
DELETE FROM public.""KnowledgeUnits"";
DELETE FROM public.""Courses"";

DELETE FROM public.""Learners"";
DELETE FROM public.""Instructors"";
DELETE FROM public.""Users"";

";

    private static void Save(string sqlScript, string destination)
    {
        File.WriteAllText(destination, sqlScript);
    }
}