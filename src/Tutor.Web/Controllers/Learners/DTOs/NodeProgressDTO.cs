using System.Collections.Generic;
using Tutor.Web.Controllers.Domain.DTOs;

namespace Tutor.Web.Controllers.Learners.DTOs
{
    public class NodeProgressDTO
    {
        public int Id { get; set; }
        public List<AssessmentEventDTO> AssessmentEvents { get; set; }
        public List<InstructionalEventDTO> InstructionalEvents { get; set; }
    }
}