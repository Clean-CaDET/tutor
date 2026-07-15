using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Elaborations.Core.UseCases;

namespace Tutor.Elaborations.Infrastructure.Database;

public class ElaborationsUnitOfWork : UnitOfWork<ElaborationsContext>, IElaborationsUnitOfWork
{
    public ElaborationsUnitOfWork(ElaborationsContext dbContext) : base(dbContext) { }
}
