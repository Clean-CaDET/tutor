using FluentResults;
using System;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Core.LearnerModel.Workspaces;

namespace Tutor.Core.LearnerModel
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerRepository _learnerRepository;
        private readonly IKcMasteryRepository _kcMasteryRepository;
        private readonly IWorkspaceCreator _workspaceCreator;

        public LearnerService(ILearnerRepository learnerRepository, IKcMasteryRepository kcMasteryRepository, IWorkspaceCreator workspaceCreator)
        {
            _learnerRepository = learnerRepository;
            _kcMasteryRepository = kcMasteryRepository;
            _workspaceCreator = workspaceCreator;
        }

        public Result Enroll(int learnerId, int unitId)
        {
            throw new NotImplementedException();
        }

        public Result<Learner> GetLearnerProfile(int id)
        {
            var learner = _learnerRepository.Get(id);
            return learner == null ? Result.Fail("Learner with id " + id + "does not exist.") : Result.Ok(learner);
        }

        private void CreateWorkspace(Learner learner)
        {
            learner.Workspace = _workspaceCreator.Create(learner.StudentIndex);
        }
    }
}