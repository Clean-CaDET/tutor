using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            var lectures = _contentService.GetLectures();
            return Ok(lectures.Select(l => _mapper.Map<LectureDTO>(l)).ToList());
        }
    }
}
