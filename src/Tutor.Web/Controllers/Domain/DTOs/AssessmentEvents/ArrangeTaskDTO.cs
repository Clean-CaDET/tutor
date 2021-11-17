﻿using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents
{
    public class ArrangeTaskDTO : LearningObjectDTO
    {
        public string Text { get; set; }
        public List<ArrangeTaskContainerDTO> Containers { get; set; }
        public List<ArrangeTaskElementDTO> UnarrangedElements { get; set; }
    }
}