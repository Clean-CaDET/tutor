using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Stakeholders.Core.UseCases;

namespace Tutor.Stakeholders.Infrastructure.Database;

public class StakeholdersUnitOfWork : UnitOfWork<StakeholdersContext>, IStakeholdersUnitOfWork
{
    public StakeholdersUnitOfWork(StakeholdersContext dbContext) : base(dbContext) {}
}