using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    public class ArrangeTaskContainerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ArrangeTaskElementDto> Elements { get; set; }
    }
}