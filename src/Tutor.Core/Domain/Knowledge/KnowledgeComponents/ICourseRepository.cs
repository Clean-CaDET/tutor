using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.KnowledgeComponents;

public interface ICourseRepository
{
    Course GetCourse(int id);
}