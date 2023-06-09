using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories
{
    public interface IFeedback
    {
        Task InsertFeedback(MongoFeedback feedback);
        Task GetFeedback(MongoFeedback feedback);
        Task<List<MongoFeedback>> GetAllFeedbacks();
        Task<MongoFeedback> GetFeedbackById(string client_id);
    }
}
