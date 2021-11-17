using System.Linq;
using Tutor.Core.ProgressModel.Submissions;

namespace Tutor.Infrastructure.Database.Repositories.Progress
{
    public class SubmissionDatabaseRepository : ISubmissionRepository
    {
        private readonly TutorContext _dbContext;

        public SubmissionDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChallengeSubmission(ChallengeSubmission submission)
        {
            _dbContext.ChallengeSubmissions.Add(submission);
            _dbContext.SaveChanges();
        }

        public void SaveQuestionSubmission(QuestionSubmission submission)
        {
            _dbContext.QuestionSubmissions.Add(submission);
            _dbContext.SaveChanges();
        }

        public void SaveArrangeTaskSubmission(ArrangeTaskSubmission submission)
        {
            _dbContext.ArrangeTaskSubmissions.Add(submission);
            _dbContext.SaveChanges();
        }

        public string GetWorkspacePath(int learnerId)
        {
            return _dbContext.Learners.First(l => l.Id == learnerId).Workspace.Path;
        }
    }
}