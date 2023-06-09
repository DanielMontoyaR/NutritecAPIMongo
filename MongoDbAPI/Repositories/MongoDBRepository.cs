using MongoDB.Driver;

namespace MongoDbAPI.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://Kendall2300:Chocolate@nutritecp2.0mapdar.mongodb.net/?retryWrites=true&w=majority");

            db = client.GetDatabase("NutriTECP2");
        }
    }
}
