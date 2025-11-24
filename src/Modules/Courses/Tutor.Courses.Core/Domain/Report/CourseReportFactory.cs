using Tutor.Courses.Core.Domain.Reflections;

namespace Tutor.Courses.Core.Domain.Report;

public class CourseReportFactory
{
    public static CourseReport CreateReport(int courseId, int learnerId,
        List<WeeklyFeedback> feedback,
        List<UnitEnrollment> enrollments,
        List<Reflection> reflections)
    {
        var unitReports = GenerateUnitReports(enrollments, reflections);
        var satisfiedUnitPercent =
            ToPercentage(unitReports.Count(a => a.IsSatisfied), unitReports.Count);
        var meaningfulReflectionAnswerPercent =
            ToPercentage(unitReports.Count(a => a.ContainsMeaningfulAnswer), unitReports.Count);

        return new CourseReport(
            courseId,
            learnerId,
            unitReports,
            satisfiedUnitPercent,
            meaningfulReflectionAnswerPercent,
            CreateFeedbackAggregates(feedback));
    }

    private static List<UnitReport> GenerateUnitReports(List<UnitEnrollment> enrollments, List<Reflection> reflections)
    {
        var meaningfulReflections = FindMeaningfulReflections(reflections, enrollments);
        var unitReports = new List<UnitReport>(enrollments.Count);

        foreach (var enrollment in enrollments)
        {
            var relatedReflections = meaningfulReflections[enrollment.Id];
            unitReports.Add(new UnitReport(
                enrollment.KnowledgeUnitId,
                enrollment.KnowledgeUnit.Name,
                enrollment.KnowledgeUnit.Order,
                enrollment.Status == EnrollmentStatus.Completed,
                relatedReflections,
                relatedReflections.Count > 0
            ));
        }

        return unitReports;
    }

    private static Dictionary<int, List<MeaningfulReflection>> FindMeaningfulReflections(
        List<Reflection> reflections, List<UnitEnrollment> enrollments)
    {
        var retVal = enrollments.ToDictionary(e => e.KnowledgeUnitId, _ => new List<MeaningfulReflection>());
        foreach (var reflection in reflections)
        {
            var openEndedQuestions = reflection.GetOpenEndedQuestions();
            foreach (var q in openEndedQuestions)
            {
                var answer = reflection.FindFirstMeaningfulAnswer(q);
                if (answer == null) continue;

                retVal[reflection.KnowledgeUnitId].Add(new MeaningfulReflection(
                    reflection.Id,
                    reflection.Submissions[0].Created,
                    q.Text,
                    answer.Answer
                ));
            }
        }

        return retVal;
    }

    private static int ToPercentage(int part, int total)
    {
        return (int)Math.Round(100.0 * part / total, 0);
    }

    private static List<FeedbackItemAggregate> CreateFeedbackAggregates(List<WeeklyFeedback> feedback)
    {
        var totalWeeks = feedback.Count;
        if (totalWeeks == 0) return new List<FeedbackItemAggregate>();

        var firstThird = totalWeeks / 3;
        var lastThirdStart = totalWeeks - totalWeeks / 3;
        
        var weekGroups = new[]
        {
            new { Weeks = Enumerable.Range(1, firstThird).ToArray(), Feedback = feedback.Take(firstThird).ToList() },
            new { Weeks = Enumerable.Range(firstThird + 1, lastThirdStart - firstThird).ToArray(), Feedback = feedback.Skip(firstThird).Take(lastThirdStart - firstThird).ToList() },
            new { Weeks = Enumerable.Range(lastThirdStart + 1, totalWeeks - lastThirdStart).ToArray(), Feedback = feedback.Skip(lastThirdStart).ToList() }
        };

        var questionCodes = new[]
        {
            "m-activity", "m-knowledge", "m-communication", "m-teamwork", 
            "m-emotion", "m-motivation", "t-learning", "t-effort", "t-tasks"
        };

        var feedbackItemAggregates = new List<FeedbackItemAggregate>();

        foreach (var group in weekGroups)
        {
            foreach (var code in questionCodes)
            {
                var values = GetFeedbackItemValues(group.Feedback, code);
                if (!values.Any()) continue;

                var hasData = CalculateHasData(code, values);
                var average = CalculateAverage(code, values, hasData);
                var valueCounts = CountValues(values);

                feedbackItemAggregates.Add(new FeedbackItemAggregate(
                    code, 
                    group.Weeks, 
                    hasData, 
                    average, 
                    valueCounts
                ));
            }
        }

        return feedbackItemAggregates;
    }

    private static List<int> GetFeedbackItemValues(List<WeeklyFeedback> feedback, string code)
    {
        var relevantOpinions = feedback
            .Where(f => f.Opinions != null)
            .SelectMany(f => f.Opinions!)
            .Where(o => o.Code == code)
            .ToList();

        if (!relevantOpinions.Any()) return new List<int>();

        var values = relevantOpinions.Select(o => o.Value).ToList();
        return values;
    }

    private static bool CalculateHasData(string code, List<int> values)
    {
        if (code == "m-activity" || code == "t-learning" || code == "t-effort" || code == "t-tasks")
            return true;

        if (code == "m-knowledge" || code == "m-communication" || code == "m-motivation")
        {
            var nonOneCount = values.Count(v => v != 1);
            return (double)nonOneCount / values.Count >= 0.6;
        }

        if (code == "m-teamwork" || code == "m-emotion")
        {
            var nonTwoCount = values.Count(v => v != 2);
            return (double)nonTwoCount / values.Count >= 0.6;
        }

        return true;
    }

    private static double CalculateAverage(string code, List<int> values, bool hasData)
    {
        if (!hasData) return -1;

        if (code == "m-knowledge" || code == "m-communication" || code == "m-motivation")
        {
            values = values.Where(v => v != 1).ToList();
        }
        else if (code == "m-teamwork" || code == "m-emotion")
        {
            values = values.Where(v => v != 2).ToList();
        }

        if (!values.Any()) return 0;
        return Math.Round(values.Average(), 1);
    }

    private static int[] CountValues(List<int> values)
    {
        var minValue = values.Min();
        var maxValue = values.Max();
        var valueCounts = new int[maxValue - minValue + 1];
        foreach (var value in values)
        {
            valueCounts[value - minValue]++;
        }

        return valueCounts;
    }
}