using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges
{
    public class AIMicroChallengeSubmission : Submission
    {
        public string SourceCode { get; private set; }
    }
}
