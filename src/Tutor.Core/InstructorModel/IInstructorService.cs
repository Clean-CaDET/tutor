using System.Collections.Generic;
using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Core.InstructorModel;

public interface IInstructorService
{
    Result<List<Course>> GetCourses(int userId);

    Result<List<LearnerGroup>> GetGroups(int userId, int courseId);
}