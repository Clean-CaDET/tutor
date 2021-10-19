using System.Collections.Generic;
using Tutor.Core.ContentModel.LearningObjects;
using Tutor.Core.ContentModel.Lectures;

namespace Tutor.Core.InstructorModel.Instructors
{
    public interface IInstructor
    {
        List<LearningObject> GatherLearningObjectsForLearner(int learnerId, List<LearningObjectSummary> learningObjectSummaries);
        List<LearningObject> GatherDefaultLearningObjects(List<LearningObjectSummary> learningObjectSummaries);
    }
}