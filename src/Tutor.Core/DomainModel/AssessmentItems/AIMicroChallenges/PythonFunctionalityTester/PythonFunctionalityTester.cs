using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges.PythonFunctionalityTester
{
    public class PythonFunctionalityTester : IPythonFunctionalityTester
    {
        private readonly string _servicePath;

        public PythonFunctionalityTester(string servicePath)
        {
            _servicePath = servicePath;
        }

        public AIMicroChallengeEvaluation IsPythonCodeFunctionallyCorrect(string sourceCode, string trainLocation, string testLocation, bool hasTransformer)
        {
            throw new NotImplementedException();
        }
    }
}
