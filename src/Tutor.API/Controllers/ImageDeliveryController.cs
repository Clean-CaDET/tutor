using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Courses.API.Public.Authoring;

namespace Tutor.API.Controllers;

[Route("api/courses/{courseId:int}/images/{fileName}")]
[Authorize]
public class ImageDeliveryController : BaseApiController
{
    private readonly IImageService _imageService;
    private readonly string _uploadsFolder;

    public ImageDeliveryController(IImageService imageService, IConfiguration configuration)
    {
        _imageService = imageService;
        _uploadsFolder = configuration.GetValue<string>("ImageUploadFolder") ?? "";
    }

    [HttpGet]
    public ActionResult Get(int courseId, string fileName)
    {
        var result = _imageService.Get(courseId, fileName, _uploadsFolder);
        if (result.IsFailed) return CreateResponse(result);

        var mimeType = "image/png"; // Adjust the MIME type as needed
        return PhysicalFile(result.Value, mimeType);
    }
}