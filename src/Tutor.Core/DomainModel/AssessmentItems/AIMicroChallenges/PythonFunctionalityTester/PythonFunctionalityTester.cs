using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Tutor.Core.DomainModel.AssessmentItems.AIMicroChallenges.PythonFunctionalityTester
{
    public class PythonFunctionalityTester : IPythonFunctionalityTester
    {
        private readonly string _servicePath;
        private readonly IHttpClientFactory _httpClientFactory;

        public PythonFunctionalityTester(string servicePath, IHttpClientFactory httpClientFactory)
        {
            _servicePath = servicePath;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> IsPythonCodeFunctionallyCorrect(string sourceCode, string trainLocation, string testLocation, bool hasTransformer, List<AIMicroChallengeHint> hints)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var evaluationData = new Dictionary<string, object>
            {
                {"code", sourceCode},
                {"transformer", hasTransformer},
                {"train", trainLocation},
                {"test", testLocation},
                {"hints", hints }
            };
            var evaluationRequest = new StringContent(JsonSerializer.Serialize(evaluationData), Encoding.UTF8, Application.Json);

            using var evaluationResponse = await httpClient.PostAsync(_servicePath, evaluationRequest);

            return evaluationResponse;
        }
    }
}
