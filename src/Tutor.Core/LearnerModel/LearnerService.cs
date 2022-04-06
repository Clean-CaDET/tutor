using System;
using FluentResults;
using System.Linq;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
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

        public Result<Learner> Register(Learner learner)
        {
            if (_learnerRepository.GetByIndex(learner.StudentIndex) != null)
                return Result.Fail("Learner with index " + learner.StudentIndex + " is already registered.");

            var kcs = _kcMasteryRepository.GetAllKnowledgeComponents();
            learner.KnowledgeComponentMasteries.AddRange(
                kcs.Select(kc => new KnowledgeComponentMastery(kc)).ToList());

            var savedLearner = _learnerRepository.Save(learner);
            CreateWorkspace(savedLearner);

            return Result.Ok(savedLearner);
        }

        public Result<Learner> GetLearnerProfile(int id)
        {
            var learner = _learnerRepository.GetLearnerProfile(id);
            return learner == null ? Result.Fail("Learner with id " + id + "does not exist.") : Result.Ok(learner);
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