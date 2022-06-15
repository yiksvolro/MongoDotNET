using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDotNET.Settings;

namespace MongoDotNET.Models
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;
        public MongoContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<Book> Books
        {
            get { return _database.GetCollection<Book>("Books"); }
        }
    }
}
