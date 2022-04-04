using System.Collections.Generic;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.Workspaces;

namespace Tutor.Core.LearnerModel
{
    public class Learner
    {
        public int Id { get; private set; }
        public string StudentIndex { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Workspace Workspace { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string IamId { get; set; }
        public List<KnowledgeComponentMastery> KnowledgeComponentMasteries { get; private set; } = new();
    }
}