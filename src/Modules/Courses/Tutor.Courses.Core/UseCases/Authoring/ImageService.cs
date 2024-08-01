using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Authoring;

public class ImageService : IImageService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IImageRepository _imageRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ImageService(IOwnedCourseRepository ownedCourseRepository, IImageRepository imageRepository, ICoursesUnitOfWork unitOfWork, IMapper mapper)
    {
        _ownedCourseRepository = ownedCourseRepository;
        _imageRepository = imageRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<string> Get(int courseId, string fileName, string uploadsFolder)
    {
        var filePath = Path.Combine(GetBaseFolder(courseId, uploadsFolder), fileName);

        if (!File.Exists(filePath)) return Result.Fail(FailureCode.NotFound);
        return filePath;
    }

    private static string GetBaseFolder(int courseId, string rootPath)
    {
        return Path.Combine(rootPath, "courses", courseId.ToString());
    }

    public Result<List<CourseImageDto>> GetAll(int courseId, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var images = _imageRepository.GetByCourse(courseId);
        return images.Select(_mapper.Map<CourseImageDto>).ToList();
    }

    public async Task<Result<CourseImageDto>> UploadAsync(int courseId, string imageFileName, byte[] imageBytes, string rootPath, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        imageFileName = SanitizeFileName(imageFileName);

        var filePath = CreateUploadPath(imageFileName, GetBaseFolder(courseId, rootPath));
        await File.WriteAllBytesAsync(filePath, imageBytes);

        var image = new CourseImage(courseId, imageFileName, filePath);

        var savedImage = _imageRepository.Create(image);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;
        return _mapper.Map<CourseImageDto>(savedImage);
    }

    private static string SanitizeFileName(string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        var sanitizedFileName = new string(fileName.Where(ch => !invalidChars.Contains(ch)).ToArray());

        sanitizedFileName = sanitizedFileName.Replace(' ', '_');

        if (sanitizedFileName.Length > 40)
        {
            sanitizedFileName = sanitizedFileName[..40];
        }

        var extension = Path.GetExtension(fileName);
        if (!string.IsNullOrEmpty(extension) && !sanitizedFileName.EndsWith(extension))
        {
            sanitizedFileName += extension;
        }

        return sanitizedFileName;
    }

    private static string CreateUploadPath(string fileName, string baseFolder)
    {
        Directory.CreateDirectory(baseFolder);
        var filePath = Path.Combine(baseFolder, fileName);
        return filePath;
    }

    public Result Delete(int courseId, int id, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var image = _imageRepository.Get(id);
        if(image == null || image.CourseId != courseId)
            return Result.Fail(FailureCode.InvalidArgument);

        File.Delete(image.FilePath);

        _imageRepository.Delete(image);
        return _unitOfWork.Save();
    }
}