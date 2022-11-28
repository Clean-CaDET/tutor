using System.Collections.Generic;
using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;

[JsonDiscriminator("multiChoiceQuestion", Policy = DiscriminatorPolicy.Always)]
public class McqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public List<string> PossibleAnswers { get; set; }
}