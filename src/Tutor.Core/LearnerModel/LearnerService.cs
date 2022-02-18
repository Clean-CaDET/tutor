using System.Linq;
using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Core.LearnerModel.Workspaces;

namespace Tutor.Core.LearnerModel
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerRepository _learnerRepository;
        private readonly IKCRepository _kcRepository;
        private readonly IWorkspaceCreator _workspaceCreator;

        public LearnerService(ILearnerRepository learnerRepository, IKCRepository kcRepository, IWorkspaceCreator workspaceCreator)
        {
            _learnerRepository = learnerRepository;
            _kcRepository = kcRepository;
            _workspaceCreator = workspaceCreator;
        }

        public Result<Learner> Register(Learner learner)
        {
            if (_learnerRepository.GetByIndex(learner.StudentIndex) != null)
                return Result.Fail("Learner with index " + learner.StudentIndex + " is already registered.");

            var kcs = _kcRepository.GetAllKnowledgeComponents();
            learner.KnowledgeComponentMasteries.AddRange(
                kcs.Select(kc => new KnowledgeComponentMastery(kc)).ToList());

            var savedLearner = _learnerRepository.Save(learner);
            CreateWorkspace(savedLearner);

            return Result.Ok(savedLearner);
        }

        public Result<Learner> Login(string studentIndex)
        {
            var learner = _learnerRepository.GetByIndex(studentIndex);
            return learner == null ? Result.Fail("The username or password is incorrect!") : Result.Ok(learner);
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