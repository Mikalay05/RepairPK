using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IFeedbackRepository
    {
        IEnumerable<FeedbackDto> GetAllFeedbacks(bool trackChanges);
        FeedbackDto GetFeedback(int id, bool trackChanges);
        FeedbackDto CreateFeedback(int customerId, FeedbackForCreationDto feedback);

    }
}
