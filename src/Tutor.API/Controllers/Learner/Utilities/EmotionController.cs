using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.UseCases;
using Tutor.LearningUtils.Infrastructure.Database;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Utilities
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/learning/emotions")]
    public class EmotionController : BaseApiController
	{
        protected readonly LearningUtilsContext DbContext;
        private readonly ILearningUtilsUnitOfWork _unitOfWOrk;

        public EmotionController(LearningUtilsContext dbContext, ILearningUtilsUnitOfWork unitOfWOrk)
        {
            DbContext = dbContext;
            _unitOfWOrk = unitOfWOrk;
        }

        [HttpPost]
        public ActionResult<Emotion> SaveChat([FromBody] string emotion)
        {
            Emotion newEmotion = new();
            newEmotion.LearnerId = User.LearnerId();
            newEmotion.EmotionValue = emotion;
            DbContext.Emotions.Attach(newEmotion);
            var result = _unitOfWOrk.Save();
            return CreateResponse(result);
        }
    }
}
