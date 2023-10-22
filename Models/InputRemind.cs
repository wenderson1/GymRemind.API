using System.Reflection.PortableExecutable;

using MongoDB.Bson.Serialization.Attributes;

namespace GymRemid.API.Models
{
    [BsonIgnoreExtraElements]
    public class InputRemind
    {
        public string Exercise { get; set; }
        public string Type { get; set; }
        public double LastWeight { get; set; }
    }
}
