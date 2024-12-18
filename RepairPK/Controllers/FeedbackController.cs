using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Repository;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/user/{customerId}/feedback")]
    public class FeedbackController: ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        [HttpGet]
        public IActionResult GetAllFeedbacks()
        {
            var feedbacks = _feedbackRepository.GetAllFeedbacks(trackChanges: true);

            return Ok(feedbacks);
        }
        [HttpGet("{id}", Name = "GetFeedbackById")]
        public IActionResult GetFeedbackById(int id)
        {
            var feedback = _feedbackRepository.GetFeedback(id, true);

            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }
        [HttpPost]
        public IActionResult CreateFeedback(int customerId, [FromBody] FeedbackForCreationDto feedbackForCreationDto)
        {
            if(feedbackForCreationDto is null)
            {
                return BadRequest("FeedbackForCreationDto object is nul");
            }

            try
            {
                var feedbackToReturn = _feedbackRepository.CreateFeedback(customerId, feedbackForCreationDto, false);
                return CreatedAtRoute("GetFeedbackById", new { customerId = customerId, id = feedbackToReturn.Id }, feedbackToReturn);
            }
            catch (CustomerNotFound ex)
            {
                // Логируем исключение, если нужно, или добавляем дополнительную информацию
                return NotFound($"Customer with ID {customerId} not found.");
            }
        }
    }
}
