using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public class FeedbackNotFoundException : NotFoundException
    {
        public FeedbackNotFoundException(int feedbackId) : base($"feedback id = {feedbackId} not foubd")
        {

        }

    }
}
