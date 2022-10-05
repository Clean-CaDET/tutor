using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiChoiceQuestions
{
    [JsonDiscriminator("multiChoiceQuestion", Policy = DiscriminatorPolicy.Always)]
    public class McqDto : AssessmentItemDto
    {
        public string Text { get; set; }
        public List<string> PossibleAnswers { get; set; }
    }
}