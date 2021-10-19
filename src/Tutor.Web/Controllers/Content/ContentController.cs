using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ContentModel;
using Tutor.Web.Controllers.Content.DTOs;

namespace Tutor.Web.Controllers.Content
{
    [Route("api/lectures/")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContentService _contentService;

        public ContentController(IMapper mapper, IContentService contentService)
        {
            _mapper = mapper;
            _contentService = contentService;
        }

        [HttpGet]
        public ActionResult<List<LectureDTO>> GetLectures()
        {
            var result = _contentService.GetLectures();
            return Ok(result.Value.Select(l => _mapper.Map<LectureDTO>(l)).ToList());
        }
    }
}
