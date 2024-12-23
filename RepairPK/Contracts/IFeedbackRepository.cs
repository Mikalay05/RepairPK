using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;

namespace RepairPK.Contracts
{
    public interface IFeedbackRepository
    {
        // CRUD => C
        FeedbackDto CreateFeedback(int customerId, FeedbackForCreationDto feedback, bool trackChanges);

        // CRUD => R
        IEnumerable<FeedbackDto> GetAllFeedbacks(bool trackChanges);
        FeedbackDto GetFeedback(int id, bool trackChanges);
        // CRUD => U
        void UpdateFeedback(int customerId, int id, FeedbackForUpdateDto feedbackForUpdate, bool trackChanges);
        // CRUD => D
        void DeleteFeedback(int customerId, int id, bool trackChanges);


    }
}
