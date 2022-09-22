using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges
{
    public class AIMicroChallenge : AssessmentItem
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string TrainDatasetLocation { get; private set; }
        public string TestDatasetLocation { get; private set; }
        public string StarterSourceCode { get; private set; }
        public bool HasTransformer { get; private set; }

        public override Evaluation Evaluate(Submission submission)
        {
            if (submission is AIMicroChallengeSubmission aIMicroChallengeSubmission) return EvaluateChallenge(aIMicroChallengeSubmission.SourceCode);
            throw new ArgumentException("Incorrect submission supplied to challenge with ID " + Id);
        }

        public AIMicroChallengeEvaluation EvaluateChallenge(string sourceCode)
        {
            return null;
        }
    }
}
