using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;

[JsonDiscriminator("atEvaluation", Policy = DiscriminatorPolicy.Always)]
public class AtEvaluationDto : EvaluationDto
{
    public List<AtContainerEvaluationDto> ContainerEvaluations { get; set; }
}