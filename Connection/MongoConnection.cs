using MongoDB.Driver;

namespace GymRemid.API.Connection
{
    public class MongoConnection
    {
        public IMongoDatabase DB { get; }

        public MongoConnection(IConfiguration configuration)
        {
            try
            {
                var client = new MongoClient(configuration["ConnectionString:GymRemindDB"]);
                DB = client.GetDatabase("GymRemindDB");
            }
            catch (Exception ex)
            {
                throw new MongoException("Unable to connect to MongoDb.",ex);
            }
        }
    }
}
