using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IInstructionalItemRepository : ICrudRepository<InstructionalItem>
{
    List<InstructionalItem> GetByKc(int kcId);
}