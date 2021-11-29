using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion
{
    public class MRQEvaluationDTO
    {
        public List<MRQItemEvaluationDTO> ItemEvaluations { get; set; }
    }
}