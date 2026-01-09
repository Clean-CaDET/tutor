using FluentResults;

namespace Tutor.KnowledgeComponents.API.Public.Authoring;

public interface IKnowledgeComponentIndexingService
{
    Task<Result> IndexAsync(int kcId, int instructorId, CancellationToken cancellationToken = default);
    Task<Result> DeindexAsync(int kcId, int instructorId, CancellationToken cancellationToken = default);
}
