using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories
{
    public class FeedbackCollection : IFeedback
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<MongoFeedback> Collection;

        public FeedbackCollection()
        {
            Collection = _repository.db.GetCollection<MongoFeedback>("Feedback");
        }

        public async Task<List<MongoFeedback>> GetAllFeedbacks()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task GetFeedback(MongoFeedback feedback)
        {
            throw new NotImplementedException();
        }

        public async Task<MongoFeedback> GetFeedbackById(string client_id)
        {
            /*return await Collection.FindAsync(
                new BsonDocument { { "client_id", new ObjectId(client_id) } }).Result.
                FirstAsync();*/
            FilterDefinition<MongoFeedback> email_filter = Builders<MongoFeedback>.Filter.Eq("client_id", client_id);

            return await Collection.FindAsync(new BsonDocument { { "client_id", client_id } }).Result.FirstAsync();

        }

        public async Task InsertFeedback(MongoFeedback feedback)
        {
            await Collection.InsertOneAsync(feedback);
            return;
        }
    }
}
