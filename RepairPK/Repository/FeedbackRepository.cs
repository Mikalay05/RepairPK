using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<FeedbackDto> GetAllFeedbacks(bool trachChanges)
        {
            var feedbacks = FindAll(trachChanges)
                .OrderBy(f => f.Id)
                .ToList();

            var feedbacksDto = feedbacks.Select(f =>

                new FeedbackDto(f.Id, f.CustomerId, f.Rating, f.Comment, f.Date))
                .ToList();

            return feedbacksDto;
        }
        public FeedbackDto GetFeedback(int id, bool trachChanges)
        {
            var feedback = FindByCondition(f => f.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var feedbackDto = new FeedbackDto(feedback.Id, feedback.CustomerId, feedback.Rating, feedback.Comment, feedback.Date);
            return feedbackDto;
        }
    }
}
