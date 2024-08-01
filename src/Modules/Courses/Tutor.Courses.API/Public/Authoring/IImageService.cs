using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Authoring;

public interface IImageService
{
    Result<string> Get(int courseId, string fileName, string uploadsFolder);
    Result<List<CourseImageDto>> GetAll(int courseId, int instructorId);
    Task<Result<CourseImageDto>> UploadAsync(int courseId, string imageFileName, byte[] imageBytes, string rootPath, int instructorId);
    Result Delete(int courseId, int id, int instructorId);
}