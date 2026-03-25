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

    public ConversationAttempt? GetActiveAttempt(int elaborationTaskId, int learnerId)
    {
        return DbContext.ConversationAttempts
            .Include(ca => ca.Turns.OrderBy(t => t.Order))
                .ThenInclude(t => t.Evaluation)
            .FirstOrDefault(ca => ca.ElaborationTaskId == elaborationTaskId
                && ca.LearnerId == learnerId
                && ca.Status == AttemptStatus.InProgress);
    }

    public List<ConversationAttempt> GetByTaskAndLearner(int elaborationTaskId, int learnerId)
    {
        return DbContext.ConversationAttempts
            .Include(ca => ca.Turns.OrderBy(t => t.Order))
            .Where(ca => ca.ElaborationTaskId == elaborationTaskId && ca.LearnerId == learnerId)
            .OrderByDescending(ca => ca.StartedAt)
            .ToList();
    }

    public int CountRecentAttempts(int elaborationTaskId, int learnerId, DateTime since)
    {
        return DbContext.ConversationAttempts
            .Count(ca => ca.ElaborationTaskId == elaborationTaskId
                && ca.LearnerId == learnerId
                && ca.StartedAt >= since);
    }
}
