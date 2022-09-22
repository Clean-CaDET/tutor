using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges
{
    public interface IPythonFunctionalityTester
    {
        public AIMicroChallengeEvaluation IsPythonCodeFunctionallyCorrect(string sourceCode, string trainLocation, string testLocation, bool hasTransformer);
    }
}
