using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel;

public interface ICourseRepository
{
    Course GetCourse(int id);

    List<Course> GetCoursesByLearner(int learnerId);
}