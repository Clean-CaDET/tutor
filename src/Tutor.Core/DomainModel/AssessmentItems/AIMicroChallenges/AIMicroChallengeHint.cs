using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges
{
    public class AIMicroChallengeHint
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public string Condition { get; private set; }
        public int AIMicroChallengeId { get; private set; }
    }
}
