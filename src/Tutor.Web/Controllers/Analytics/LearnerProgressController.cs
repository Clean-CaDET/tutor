using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.LearnerModel;

namespace Tutor.Web.Controllers.Analytics
{
    [Route("api/analytics/learner-progress")]
    [ApiController]
    public class LearnerProgressController : ControllerBase
    {
        private ILearnerRepository _learnerRepository;

        public LearnerProgressController(ILearnerRepository learnerRepository)
        {
            _learnerRepository = learnerRepository;
        }

        [HttpGet]
        public ActionResult<PagedResult<Learner>> GetEvents([FromQuery] int page, [FromQuery] int pageSize)
        {
            var task = _learnerRepository.GetLearnersWithMasteriesAsync(page, pageSize);
            Task.WaitAll(task);
            return Ok(task.Result);
        }
    }
}
