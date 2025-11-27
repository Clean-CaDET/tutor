using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Report;

public class CourseReport : Entity
{
    public int CourseId { get; private set; }
    public int LearnerId { get; private set; }
    public string Report { get; private set; } = string.Empty;

    public int SatisfiedUnitPercent { get; private set; }
    public List<UnitReport>? UnitReports { get; private set; }
    public List<FeedbackItemAggregate>? FeedbackItemAggregates { get; private set; }
    public int MeaningfulReflectionAnswerPercent { get; private set; }

    private CourseReport() {}
    public CourseReport(int courseId, int learnerId)
    {
        CourseId = courseId;
        LearnerId = learnerId;
    }

    public CourseReport(int courseId, int learnerId, List<UnitReport> unitReports, int satisfiedUnitPercent, int meaningfulReflectionAnswerPercent, List<FeedbackItemAggregate> feedbackAggregates)
    {
        CourseId = courseId;
        LearnerId = learnerId;
        UnitReports = unitReports;
        SatisfiedUnitPercent = satisfiedUnitPercent;
        MeaningfulReflectionAnswerPercent = meaningfulReflectionAnswerPercent;
        FeedbackItemAggregates = feedbackAggregates;
    }
}