using System.Collections.Generic;
using Tutor.Core.ContentModel.LearningObjects;
using Tutor.Core.ContentModel.Lectures;

namespace Tutor.Core.ProgressModel.Progress
{
    public class NodeProgress
    {
        public int Id { get; private set; }
        public int LearnerId { get; private set; }
        public KnowledgeNode Node { get; private set; }
        public List<LearningObject> LearningObjects { get; private set; }
        public NodeStatus Status { get; private set; }

        private NodeProgress() {}
        public NodeProgress(int id, int learnerId, KnowledgeNode node, NodeStatus status, List<LearningObject> learningObjects): this()
        {
            Id = id;
            LearnerId = learnerId;
            Node = node;
            Status = status;
            LearningObjects = learningObjects;
        }
    }

    public enum NodeStatus
    {
        Locked,
        Unlocked,
        Started,
        Finished
    }
}