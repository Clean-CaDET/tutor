using FluentResults;
using System.Collections.Generic;
using Tutor.Core.ContentModel.Lectures;

namespace Tutor.Core.ContentModel
{
    public interface IContentService
    {
        Result<List<Lecture>> GetLectures();
    }
}