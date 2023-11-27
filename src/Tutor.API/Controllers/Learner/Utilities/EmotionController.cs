using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILearningUtilsUnitOfWork _unitOfWork;

        public EmotionController(LearningUtilsContext dbContext, ILearningUtilsUnitOfWork unitOfWOrk)
        {
            DbContext = dbContext;
            _unitOfWork = unitOfWOrk;
        }

        [HttpPost]
        public ActionResult<Emotion> SaveChat([FromBody] string emotion)
        {
            Emotion newEmotion = new()
            {
                LearnerId = User.LearnerId(),
                Value = emotion
            };
            DbContext.Emotions.Attach(newEmotion);
            var result = _unitOfWork.Save();
            return CreateResponse(result);
        }
    }
}
