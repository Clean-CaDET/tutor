using FluentResults;
using System.Collections.Generic;

namespace Tutor.Core.ProgressModel.Progress
{
    public interface IProgressService
    {
        Result<List<NodeProgress>> GetKnowledgeNodes(int lectureId, int? learnerId);
        Result<NodeProgress> GetNodeContent(int nodeId, int? learnerId);
    }
}