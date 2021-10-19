using System.Collections.Generic;
using Tutor.Core.ProgressModel.Progress;

namespace Tutor.Core.ProgressModel
{
    public interface IProgressService
    {
        List<NodeProgress> GetKnowledgeNodes(int lectureId, int? learnerId);
        NodeProgress GetNodeContent(int nodeId, int? learnerId);
    }
}