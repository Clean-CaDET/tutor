using System.Collections.Immutable;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

namespace Tutor.LearningTasks.Infrastructure.Database.EventStore;

public static class EventSerializationConfiguration
{
    public static readonly IImmutableDictionary<Type, string> EventRelatedTypes = new Dictionary<Type, string>
    {
        { typeof(TaskOpened), "TaskOpened" },
        { typeof(StepOpened), "StepOpened" },
        { typeof(SubmissionOpened), "SubmissionOpened" },
        { typeof(GuidanceOpened), "GuidanceOpened" },
        { typeof(ExampleOpened), "ExampleOpened" },
        { typeof(ExampleVideoPlayed), "ExampleVideoPlayed" },
        { typeof(ExampleVideoPaused), "ExampleVideoPaused" },
        { typeof(ExampleVideoFinished), "ExampleVideoFinished" },
        { typeof(StepSubmitted), "StepSubmitted" },
        { typeof(TaskCompleted), "TaskCompleted" },
        { typeof(StepGraded), "StepGraded" },
        { typeof(TaskGraded), "TaskGraded" }
    }.ToImmutableDictionary();
}