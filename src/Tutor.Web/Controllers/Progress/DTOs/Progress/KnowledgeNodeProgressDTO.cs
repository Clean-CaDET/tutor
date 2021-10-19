using System.Collections.Generic;
using Tutor.Core.ProgressModel.Progress;
using Tutor.Web.Controllers.Content.DTOs;

namespace Tutor.Web.Controllers.Progress.DTOs.Progress
{
    public class KnowledgeNodeProgressDTO
    {
        public int Id { get; set; }
        public string LearningObjective { get; set; }
        public List<LearningObjectDTO> LearningObjects { get; set; }
        public NodeStatus Status { get; set; }
    }
}