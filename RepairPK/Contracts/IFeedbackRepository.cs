using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IFeedbackRepository
    {
        // CRUD => C
        // CRUD => R
        // CRUD => U
        // CRUD => D
        IEnumerable<FeedbackDto> GetAllFeedbacks(bool trackChanges);
        FeedbackDto GetFeedback(int id, bool trackChanges);
        FeedbackDto CreateFeedback(int customerId, FeedbackForCreationDto feedback, bool trackChanges);

    }
}
