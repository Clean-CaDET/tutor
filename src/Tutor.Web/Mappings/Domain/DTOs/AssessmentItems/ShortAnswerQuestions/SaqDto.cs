﻿using Dahomey.Json.Attributes;

namespace Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.ShortAnswerQuestions
{
    [JsonDiscriminator("shortAnswerQuestion", Policy = DiscriminatorPolicy.Always)]
    public class SaqDto : AssessmentItemDto
    {
        public string Text { get; set; }
    }
}