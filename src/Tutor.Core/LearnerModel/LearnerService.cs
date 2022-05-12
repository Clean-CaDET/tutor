using System.Collections.Generic;
using FluentResults;
using Tutor.Core.LearnerModel.Workspaces;

namespace Tutor.Core.LearnerModel
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerRepository _learnerRepository;
        private readonly IWorkspaceCreator _workspaceCreator;

        public LearnerService(ILearnerRepository learnerRepository, IWorkspaceCreator workspaceCreator)
        {
            _learnerRepository = learnerRepository;
            _workspaceCreator = workspaceCreator;
        }

        public Result<Learner> GetLearnerProfile(int id)
        {
            var learner = _learnerRepository.GetByUserId(id);
            return learner == null ? Result.Fail("Learner tied to user id " + id + " does not exist.") : Result.Ok(learner);
        }

        public Result<List<LearnerGroup>> GetGroups(int instructorId)
        {
            // Instructor id can be used to retrieve active groups the instructor is responsible for.
            return Result.Ok(_learnerRepository.GetGroups());
        }

        private void CreateWorkspace(Learner learner)
        {
            learner.Workspace = _workspaceCreator.Create(learner.Index);
        }
    }
}