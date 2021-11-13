using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ContentModel;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Questions;
using Tutor.Core.ProgressModel.Submissions;
using Xunit;

namespace Tutor.Core.Tests.Unit
{
    public class SubmissionTests
    {
        private readonly ISubmissionService _service;

        public SubmissionTests()
        {
            _service = new SubmissionService(CreateLearningObjectMockRepository(),
                new Mock<ISubmissionRepository>().Object);
        }

        private static ILearningObjectRepository CreateLearningObjectMockRepository()
        {
            Mock<ILearningObjectRepository> learningObjectRepo = new Mock<ILearningObjectRepository>();
            learningObjectRepo.Setup(repo => repo.GetQuestion(19))
                .Returns(new Question(19, 0, "", new List<QuestionAnswer>
                {
                    new(10, 19, "", false, ""),
                    new(11, 19, "", true, ""),
                    new(12, 19, "", true, ""),
                    new(13, 19, "", false, "")
                }));
            learningObjectRepo.Setup(repo => repo.GetArrangeTask(32))
                .Returns(new ArrangeTask(1, 0, "", new List<ArrangeTaskContainer>
                {
                    new(1, 1, "", new List<ArrangeTaskElement>
                    {
                        new(1, 1, "")
                    }),
                    new(2, 1, "", new List<ArrangeTaskElement>
                    {
                        new(2, 2, "")
                    }),
                    new(3, 1, "", new List<ArrangeTaskElement>
                    {
                        new(3, 3, "")
                    }),
                    new(4, 1, "", new List<ArrangeTaskElement>
                    {
                        new(4, 4, "")
                    }),
                    new(5, 1, "", new List<ArrangeTaskElement>
                    {
                        new(5, 5, "")
                    }),
                }));
            return learningObjectRepo.Object;
        }
        
        [Theory]
        [MemberData(nameof(AnswersTestData))]
        public void Evaluates_answer_submission(QuestionSubmission submission, List<bool> expectedCorrectness)
        {
            var results = _service.EvaluateAnswers(submission);

            var correctness = results.Select(a => a.SubmissionWasCorrect);
            correctness.ShouldBe(expectedCorrectness);
        }

        public static IEnumerable<object[]> AnswersTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new QuestionSubmission(19, new List<int> {10, 11, 12, 13}),
                    new List<bool> {false, true, true, false}
                },
                new object[]
                {
                    new QuestionSubmission(19, new List<int> {10, 13}),
                    new List<bool> {false, false, false, false}
                },
                new object[]
                {
                    new QuestionSubmission(19, new List<int> {11, 12}),
                    new List<bool> {true, true, true, true}
                }
            };

        [Theory]
        [MemberData(nameof(ArrangeTasksTestData))]
        public void Evaluates_arrange_task_submission(ArrangeTaskSubmission submission, List<bool> expectedCorrectness)
        {
            var results = _service.EvaluateArrangeTask(submission);

            var correctness = results.Select(a => a.SubmissionWasCorrect);
            correctness.ShouldBe(expectedCorrectness);
        }

        public static IEnumerable<object[]> ArrangeTasksTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new ArrangeTaskSubmission(32, new List<ArrangeTaskContainerSubmission>
                    {
                        new(1, 1, new List<int> {1, 5}),
                        new(2, 2, new List<int> {2}),
                        new(3, 3, new List<int> {3}),
                        new(4, 4, new List<int> { }),
                        new(5, 5, new List<int> {4}),
                    }),
                    new List<bool> {false, true, true, false, false}
                },
                new object[]
                {
                    new ArrangeTaskSubmission(32, new List<ArrangeTaskContainerSubmission>
                    {
                        new(1, 1, new List<int> {1, 2, 3, 4, 5}),
                        new(2, 2, new List<int> { }),
                        new(3, 3, new List<int> { }),
                        new(4, 4, new List<int> { }),
                        new(5, 5, new List<int> { }),
                    }),
                    new List<bool> {false, false, false, false, false}
                },
                new object[]
                {
                    new ArrangeTaskSubmission(32, new List<ArrangeTaskContainerSubmission>
                    {
                        new(1, 1, new List<int> {1}),
                        new(2, 2, new List<int> {2}),
                        new(3, 3, new List<int> {3}),
                        new(4, 4, new List<int> {4}),
                        new(5, 5, new List<int> {5}),
                    }),
                    new List<bool> {true, true, true, true, true}
                }
            };
    }
}