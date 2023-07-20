using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningUtils.Core.UseCases;

namespace Tutor.LearningUtils.Infrastructure.Database;

public class LearningUtilitiesUnitOfWork : UnitOfWork<LearningUtilitiesContext>, ILearningUtilitiesUnitOfWork
{
    public LearningUtilitiesUnitOfWork(LearningUtilitiesContext dbContext) : base(dbContext) {}
}