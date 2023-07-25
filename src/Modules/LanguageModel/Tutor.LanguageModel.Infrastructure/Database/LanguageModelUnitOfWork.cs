using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LanguageModel.Core.UseCases;

namespace Tutor.LanguageModel.Infrastructure.Database;

public class LanguageModelUnitOfWork : UnitOfWork<LanguageModelContext>, ILanguageModelUnitOfWork 
{
    public LanguageModelUnitOfWork(LanguageModelContext dbContext) : base(dbContext) {}
}
