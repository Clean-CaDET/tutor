using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;

[JsonDiscriminator("mrqEvaluation", Policy = DiscriminatorPolicy.Always)]
public class MrqEvaluationDto : EvaluationDto
{
    public List<MrqItemEvaluationDto> ItemEvaluations { get; set; }
}