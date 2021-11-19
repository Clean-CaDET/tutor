// using FluentResults;
// using Moq;
// using Shouldly;
// using System.Collections.Generic;
// using Tutor.Core.ContentModel;
// using Tutor.Core.ContentModel.Lectures;
// using Tutor.Core.InstructorModel.Instructors;
// using Tutor.Core.LearnerModel.Learners;
// using Tutor.Core.ProgressModel.Progress;
// using Xunit;
//
// namespace Tutor.Core.Tests.Unit
// {
//     public class ProgressServiceTests
//     {
//         private readonly IProgressService _progressService;
//
//         public ProgressServiceTests()
//         {
//             _progressService = CreateService();
//         }
//
//         private static IProgressService CreateService()
//         {
//             var kn1 = new KnowledgeNode(1, null, 1);
//             var kn2 = new KnowledgeNode(2, null, 1);
//             var progress1 = new NodeProgress(1, 0, null, NodeStatus.Unlocked, null);
//
//             Mock<IProgressRepository> progressRepo = new Mock<IProgressRepository>();
//             progressRepo.Setup(repo => repo.GetNodeProgressForLearner(1, 1)).Returns(progress1);
//
//             Mock<ILectureRepository> lectureRepo = new Mock<ILectureRepository>();
//             lectureRepo.Setup(repo => repo.GetKnowledgeNodeWithSummaries(1)).Returns(kn1);
//             lectureRepo.Setup(repo => repo.GetKnowledgeNodeWithSummaries(2)).Returns(kn2);
//
//             Mock<IInstructor> instructor = new Mock<IInstructor>();
//             instructor.Setup(i => i.GatherLearningObjectsForLearner(1, null)).Returns(Result.Ok());
//
//             return new ProgressService(instructor.Object, lectureRepo.Object, progressRepo.Object);
//         }
//
//         [Theory]
//         [MemberData(nameof(LearnerTestData))]
//         public void Creates_node_content(int nodeId, int learnerId, int nodeProgressId)
//         {
//             var result = _progressService.GetNodeContent(nodeId, learnerId);
//             result.Value.Id.ShouldBe(nodeProgressId);
//         }
//
//         public static IEnumerable<object[]> LearnerTestData =>
//             new List<object[]>
//             {
//                 new object[]
//                 {
//                     1,
//                     1,
//                     1
//                 },
//                 new object[]
//                 {
//                     2,
//                     1,
//                     0
//                 }
//             };
//     }
// }