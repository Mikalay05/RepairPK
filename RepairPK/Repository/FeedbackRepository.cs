using AutoMapper;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        private readonly IMapper _mapper;

        public FeedbackRepository(RepositoryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<FeedbackDto> GetAllFeedbacks(bool trachChanges)
        {
            var feedbacks = FindAll(trachChanges)
                .OrderBy(f => f.Id)
                .ToList();

            var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);

            return feedbacksDto;
        }
        public FeedbackDto GetFeedback(int id, bool trachChanges)
        {
            var feedback = FindByCondition(f => f.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
            return feedbackDto;
        }
        public FeedbackDto CreateFeedback(FeedbackForCreationDto feedbackDto)
        {
            var feedbackEntity = _mapper.Map<Feedback>(feedbackDto);
            Create(feedbackEntity);
            var feedbackToReturn = _mapper.Map<FeedbackDto>(feedbackEntity);
            return feedbackToReturn;
        }
    }
}
