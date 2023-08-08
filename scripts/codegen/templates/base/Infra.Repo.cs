using Tutor.{{MODULE}}.Core.Domain;

namespace Tutor.{{MODULE}}.Infrastructure.Database.Repositories;

// CodeGen v1
public class {{NAME}}Repository : I{{NAME}}Repository
{
    private readonly {{MODULE}}Context _dbContext;

    public {{NAME}}Repository({{MODULE}}Context dbContext) {}

    public {{NAME}}? Get(int id)
    {
        return _dbContext.{{NAME}}s.FirstOrDefault(e => e.Id == id);
    }
}

// TODO: Expand the {{MODULE}}Context class to include a new DbSet.