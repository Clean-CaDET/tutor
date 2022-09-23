using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges
{
    public interface IPythonFunctionalityTester
    {
        public Task<HttpResponseMessage> IsPythonCodeFunctionallyCorrect(string sourceCode, string trainLocation, string testLocation, bool hasTransformer, List<AIMicroChallengeHint> hints);
    }
}
