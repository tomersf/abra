
using api.Models;
using MongoDB.Driver;

namespace api.Data
{
    public class ApplicationDBContext
    {

        private readonly IMongoCollection<Pet> _petCollection;

        public ApplicationDBContext(DatabaseSettings settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(settings.DatabaseName);
            _petCollection = mongoDb.GetCollection<Pet>(settings.PetCollectionName);
        }

        public IMongoCollection<Pet> PetCollection => _petCollection;

    }
}