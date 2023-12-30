﻿using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningTasks.Core.Domain.Activites;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Infrastructure.Database.Repositories;

public class ExampleDatabaseRepository : CrudDatabaseRepository<Example, LearningTasksContext>, IExampleRepository
{
    public ExampleDatabaseRepository(LearningTasksContext dbContext) : base(dbContext) { }
}
