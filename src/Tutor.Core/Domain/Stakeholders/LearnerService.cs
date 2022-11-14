using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Core.Domain.Stakeholders
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerRepository _learnerRepository;

        public LearnerService(ILearnerRepository learnerRepository)
        {
            _learnerRepository = learnerRepository;
        }

        public Result<Learner> GetLearnerProfile(int id)
        {
            var learner = _learnerRepository.GetByUserId(id);
            return learner == null ? Result.Fail("Learner tied to user id " + id + " does not exist.") : Result.Ok(learner);
        }

        public Result<List<LearnerGroup>> GetGroups()
        {
            return Result.Ok(_learnerRepository.GetGroups());
        }
    }
}