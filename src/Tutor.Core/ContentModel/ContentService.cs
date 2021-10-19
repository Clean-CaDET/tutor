using System.Collections.Generic;
using Tutor.Core.ContentModel.Lectures;

namespace Tutor.Core.ContentModel
{
    public class ContentService : IContentService
    {
        private readonly ILectureRepository _lectureRepository;

        public ContentService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }

        public List<Lecture> GetLectures()
        {
            return _lectureRepository.GetLectures();
        }
    }
}