using System.Collections.Generic;
using Tutor.Core.ContentModel.Lectures;

namespace Tutor.Core.ContentModel
{
    public interface ILectureRepository
    {
        Course GetCourse(int id);
        int GetCourseIdByLOId(int learningObjectSummaryId);
        Lecture GetLecture(int id);
        List<Lecture> GetLectures();
        List<KnowledgeNode> GetKnowledgeNodes(int id);
        KnowledgeNode GetKnowledgeNodeWithSummaries(int id);
        KnowledgeNode GetKnowledgeNodeBySummary(int id);
    }
}