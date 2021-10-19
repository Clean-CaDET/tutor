using System.Collections.Generic;
using Tutor.Core.ContentModel.Lectures;

namespace Tutor.Core.ContentModel
{
    public interface IContentService
    {
        List<Lecture> GetLectures();
    }
}