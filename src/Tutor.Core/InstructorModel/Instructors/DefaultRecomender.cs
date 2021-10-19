using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ContentModel;
using Tutor.Core.ContentModel.LearningObjects;
using Tutor.Core.ContentModel.Lectures;

namespace Tutor.Core.InstructorModel.Instructors
{
    public class DefaultInstructor : IInstructor
    {
        private readonly ILearningObjectRepository _learningObjectRepository;

        public DefaultInstructor(ILearningObjectRepository learningObjectRepository)
        {
            _learningObjectRepository = learningObjectRepository;
        }

        public Result<List<LearningObject>> GatherLearningObjectsForLearner(int learnerId, List<LearningObjectSummary> loSummaries)
        {
            return GatherDefaultLearningObjects(loSummaries);
        }

        public Result<List<LearningObject>> GatherDefaultLearningObjects(List<LearningObjectSummary> loSummaries)
        {
            var los = _learningObjectRepository.GetFirstLearningObjectsForSummaries(
                loSummaries.Select(s => s.Id).ToList());
            return Result.Ok(los);
        }
    }
}