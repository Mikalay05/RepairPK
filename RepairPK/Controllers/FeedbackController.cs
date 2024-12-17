using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/feedback")]
    public class FeedbackController: ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        [HttpGet]
        public IActionResult GetFeedbacks()
        {
            var feedbacks = _feedbackRepository.GetAllFeedbacks(trackChanges: true);

            return Ok(feedbacks);
        }

    }
}
