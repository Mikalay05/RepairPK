﻿using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Repository;

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

    }
}
