using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningUtils.Core.UseCases;

namespace Tutor.LearningUtils.Infrastructure.Database;

public class LearningUtilsUnitOfWork : UnitOfWork<LearningUtilsContext>, ILearningUtilsUnitOfWork
{
    public LearningUtilsUnitOfWork(LearningUtilsContext dbContext) : base(dbContext) {}
}