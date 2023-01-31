using Dahomey.Json.Attributes;
using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions;

[JsonDiscriminator("shortAnswerQuestion", Policy = DiscriminatorPolicy.Always)]
public class SaqDto : AssessmentItemDto
{
    public string Text { get; set; }
    public List<string> AcceptableAnswers { get; set; }
    public string Feedback { get; set; }
    public int Tolerance { get; set; }
}