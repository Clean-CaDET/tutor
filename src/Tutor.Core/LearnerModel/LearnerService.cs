using FluentResults;
using Tutor.Core.LearnerModel.Learners;
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

        public Result<Learner> Register(Learner learner)
        {
            if (_learnerRepository.GetByIndex(learner.StudentIndex) != null)
                return Result.Fail("Learner with index " + learner.StudentIndex + " is already registered.");
            
            var savedLearner = _learnerRepository.Save(learner);
            CreateWorkspace(savedLearner);

            return Result.Ok(savedLearner);
        }

        public Result<Learner> Login(string studentIndex)
        {
            var learner = _learnerRepository.GetByIndex(studentIndex);
            if (learner == null) return Result.Fail("No learner with index: " + studentIndex);
            return Result.Ok(learner);
        }

        private void CreateWorkspace(Learner learner)
        {
            var workspace = _workspaceCreator.Create(learner.Id);
            if (workspace == null) return;

            learner.Workspace = workspace;
            _learnerRepository.Save(learner);
        }
    }
}