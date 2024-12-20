﻿using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class CourseDatabaseRepository : CrudDatabaseRepository<Course, CoursesContext>, ICourseRepository
{
    public CourseDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}

    public List<Course> GetActiveAndStarted()
    {
        return DbContext.Courses
            .Where(c => c.StartDate < DateTime.UtcNow && !c.IsArchived)
            .ToList();
    }

    public PagedResult<Course> GetPagedSortedByDate(int page, int pageSize)
    {
        var task = DbContext.Courses.OrderByDescending(c => c.StartDate).GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Course? GetWithUnits(int courseId)
    {
        return DbContext.Courses
            .Include(c => c.KnowledgeUnits)
            .FirstOrDefault(c => c.Id == courseId);
    }
}