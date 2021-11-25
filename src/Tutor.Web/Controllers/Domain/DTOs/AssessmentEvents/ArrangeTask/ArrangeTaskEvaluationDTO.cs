using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    public class ArrangeTaskEvaluationDTO
    {
        public List<ArrangeTaskContainerEvaluationDTO> ContainerEvaluations { get; private set; }
    }
}