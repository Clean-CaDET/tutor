using System.Collections.Generic;
using Tutor.Core.ContentModel.LearningObjects;
using Tutor.Core.ContentModel.Lectures;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Questions;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.ContentModel
{
    public interface ILearningObjectRepository
    {
        List<LearningObject> GetLearningObjectsForSummary(int summaryId);
        List<LearningObject> GetFirstLearningObjectsForSummaries(List<int> summaries);
        Challenge GetChallenge(int challengeId);
        Question GetQuestion(int questionId);
        ArrangeTask GetArrangeTask(int arrangeTaskId);
        Image GetImageForSummary(int summaryId);
        LearningObject GetInteractiveLOForSummary(int summaryId);
        Text GetTextForSummary(int summaryId);
        Video GetVideoForSummary(int summaryId);
        LearningObject GetLearningObjectForSummary(int summaryId);
        LearningObjectSummary GetLearningObjectSummary(int summaryId);
    }
}