using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents
{
    public class ArrangeTaskContainerDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ArrangeTaskElementDTO> Elements { get; set; }
    }
}