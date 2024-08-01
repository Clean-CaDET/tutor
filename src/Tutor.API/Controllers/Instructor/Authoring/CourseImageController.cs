using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Instructor.Authoring;

[Route("api/authoring/courses/{courseId:int}/images")]
[Authorize(Policy = "instructorPolicy")]
public class CourseImageController : BaseApiController
{
    private readonly IWebHostEnvironment _env;
    private readonly IImageService _imageService;

    public CourseImageController(IWebHostEnvironment env, IImageService imageService)
    {
        _env = env;
        _imageService = imageService;
    }

    [HttpGet]
    public ActionResult<List<CourseImageDto>> Get(int courseId)
    {
        var result = _imageService.Get(courseId, User.InstructorId());
        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<ActionResult<CourseImageDto>> Upload(int courseId, IFormFile? image)
    {
        var error = ValidateFile(image);
        if (error != 0)
            return CreateResponse(new Error("Invalid image supplied.").WithMetadata("code", error));

        var imageBytes = await ConvertToByteArrayAsync(image!);

        var result = await _imageService.UploadAsync(courseId, image.FileName, imageBytes, _env.WebRootPath, User.InstructorId());
        return CreateResponse(result);
    }

    private static int ValidateFile(IFormFile? image)
    {
        if(image == null || image.Length == 0) return 1;

        const long maxFileSize = 10 * 1024 * 1024; // 10 MB
        if (image.Length > maxFileSize) return 2;

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(fileExtension)) return 3;

        return 0;
    }

    private static async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int courseId, int id)
    {
        var result = _imageService.Delete(courseId, id, User.InstructorId());
        return CreateResponse(result);
    }
}