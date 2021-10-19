using System.Linq;
using Tutor.Core.ProgressModel;
using Tutor.Core.ProgressModel.Progress;

namespace Tutor.Infrastructure.Database.Repositories
{
    public class ProgressDatabaseRepository : IProgressRepository
    {
        private readonly SmartTutorContext _dbContext;

        public ProgressDatabaseRepository(SmartTutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveNodeProgress(NodeProgress nodeProgress)
        {
            _dbContext.NodeProgresses.Add(nodeProgress);
            _dbContext.SaveChanges();
        }
        public NodeProgress GetNodeProgressForLearner(int learnerId, int nodeId)
        {
            return _dbContext.NodeProgresses.FirstOrDefault(nodeProgress =>
                nodeProgress.LearnerId == learnerId && nodeProgress.Node.Id == nodeId);
        }
    }
}