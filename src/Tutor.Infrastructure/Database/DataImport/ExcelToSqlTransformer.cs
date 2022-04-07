using System.IO;

namespace Tutor.Infrastructure.Database.DataImport;

public static class ExcelToSqlTransformer
{
    public static void Transform(string domainSource, string learnerSource, string destination)
    {
        var domainContent = DomainExcelImporter.Import(domainSource);
        var domainSql = DomainSqlExporter.BuildSql(domainContent);

        var learners = LearnerExcelImporter.Import(learnerSource, "simsoni");
        var learnerSql = LearnerSqlExporter.BuildSql(learners, domainContent.KnowledgeComponents, domainContent.Units);

        Save(DeleteCommands + domainSql + learnerSql, destination);
    }

    private const string DeleteCommands = @"DELETE FROM public.""Submissions"";
DELETE FROM public.""ArrangeTaskContainerSubmissions"";
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
DELETE FROM public.""ArrangeTaskElements"";
DELETE FROM public.""ArrangeTaskContainers"";
DELETE FROM public.""ArrangeTasks"";
DELETE FROM public.""ShortAnswerQuestions"";
DELETE FROM public.""AssessmentItems"";
DELETE FROM public.""InstructionalItems"";
DELETE FROM public.""KcMasteries"";
DELETE FROM public.""KnowledgeComponents"";
DELETE FROM public.""UnitEnrollments"";
DELETE FROM public.""KnowledgeUnits"";
DELETE FROM public.""Learners"";

";

    private static void Save(string sqlScript, string destination)
    {
        File.WriteAllText(destination, sqlScript);
    }
}