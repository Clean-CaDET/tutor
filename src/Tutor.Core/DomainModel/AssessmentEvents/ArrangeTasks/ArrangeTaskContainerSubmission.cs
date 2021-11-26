﻿using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTaskContainerSubmission
    {
        public int Id { get; private set; }
        public int SubmissionId { get; private set; }
        public int ArrangeTaskContainerId { get; private set; }
        public List<int> ElementIds { get; private set; }
    }
}