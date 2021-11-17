using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ContentModel;
using Tutor.Core.ContentModel.Lectures;
using Tutor.Core.InstructorModel.Instructors;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Core.ProgressModel.Progress
{
    public class ProgressService : IProgressService
    {
        private readonly IInstructor _instructor;
        private readonly ILectureRepository _lectureRepository;
        private readonly IProgressRepository _progressRepository;

        public ProgressService(IInstructor instructor, ILectureRepository lectureRepository,
            IProgressRepository progressRepository)
        {
            _instructor = instructor;
            _progressRepository = progressRepository;
            _lectureRepository = lectureRepository;
        }

        public Result<List<NodeProgress>> GetKnowledgeNodes(int lectureId, int? learnerId)
        {
            var nodes = _lectureRepository.GetKnowledgeNodes(lectureId);
            if (nodes == null) return Result.Fail("No existing nodes for lecture.");
            if (learnerId == null) return Result.Ok(ShowSampleNodes(nodes));

            //TODO: Check if prerequisites fulfilled.
            return Result.Fail("UNSUPPORTED CASE.");
        }

        private static List<NodeProgress> ShowSampleNodes(List<KnowledgeNode> nodes)
        {
            return nodes.Select(n => new NodeProgress(0, 0, n, NodeStatus.Unlocked, null)).ToList();
        }

        public Result<NodeProgress> GetNodeContent(int knowledgeNodeId, int? learnerId)
        {
            var knowledgeNode = _lectureRepository.GetKnowledgeNodeWithSummaries(knowledgeNodeId);
            if (knowledgeNode == null) return Result.Fail("The knowledge node with the id " + knowledgeNodeId + " does not exist.");

            if (learnerId == null)
            {
                var defaultLOs = _instructor.SelectSuitableKnowledgeNode(knowledgeNode.LearningObjectSummaries);
                return Result.Ok(new NodeProgress(0, 0, knowledgeNode, NodeStatus.Unlocked, defaultLOs.Value));
            }

            return Result.Ok(BuildNodeForLearner(knowledgeNode, (int) learnerId));
        }

        private NodeProgress BuildNodeForLearner(KnowledgeNode node, int learnerId)
        {
            var nodeProgress = _progressRepository.GetNodeProgressForLearner(learnerId, node.Id);

            if (nodeProgress == null)
            {
                var startingLOs = _instructor.GatherLearningObjectsForLearner(learnerId, node.LearningObjectSummaries);
                nodeProgress = new NodeProgress(0, learnerId, node, NodeStatus.Unlocked, startingLOs.Value);
            }

            //TODO: Create learning session and save.
            _progressRepository.SaveNodeProgress(nodeProgress);

            return nodeProgress;
        }
    }
}