using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Database.Repositories;

public class ConversationAttemptDatabaseRepository :
    CrudDatabaseRepository<ConversationAttempt, ElaborationsContext>, IConversationAttemptRepository
{
    public ConversationAttemptDatabaseRepository(ElaborationsContext dbContext) : base(dbContext) { }

    public new ConversationAttempt? Get(int id)
    {
        return DbContext.ConversationAttempts
            .Include(ca => ca.Turns.OrderBy(t => t.Order))
                .ThenInclude(t => t.Evaluation)
            .FirstOrDefault(ca => ca.Id == id);
    }

    public ConversationAttempt? GetActiveAttempt(int conceptElaborationTaskId, int learnerId)
    {
        return DbContext.ConversationAttempts
            .Include(ca => ca.Turns.OrderBy(t => t.Order))
                .ThenInclude(t => t.Evaluation)
            .FirstOrDefault(ca => ca.ConceptElaborationTaskId == conceptElaborationTaskId
                && ca.LearnerId == learnerId
                && (ca.Status == AttemptStatus.InProgress || ca.Status == AttemptStatus.InClosing));
    }

    public List<ConversationAttempt> GetByTaskAndLearner(int conceptElaborationTaskId, int learnerId)
    {
        return DbContext.ConversationAttempts
            .Include(ca => ca.Turns.OrderBy(t => t.Order))
            .Where(ca => ca.ConceptElaborationTaskId == conceptElaborationTaskId && ca.LearnerId == learnerId)
            .OrderByDescending(ca => ca.StartedAt)
            .ToList();
    }

    public int CountRecentAttempts(int conceptElaborationTaskId, int learnerId, DateTime since)
    {
        return DbContext.ConversationAttempts
            .Count(ca => ca.ConceptElaborationTaskId == conceptElaborationTaskId
                && ca.LearnerId == learnerId
                && ca.StartedAt >= since);
    }

    public HashSet<int> GetTaskIdsWithCompletedAttempts(List<int> taskIds, int learnerId)
    {
        return DbContext.ConversationAttempts
            .Where(ca => taskIds.Contains(ca.ConceptElaborationTaskId)
                && ca.LearnerId == learnerId
                && ca.Status == AttemptStatus.Completed)
            .Select(ca => ca.ConceptElaborationTaskId)
            .Distinct()
            .ToHashSet();
    }
}
