using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonIgnoreExtraElements]
    public class Marca
    {
        [BsonId]
        private ObjectId id;

        [BsonElement("Modelo")] 
        private string model;

        public Marca(ObjectId id, string model)
        {
            this.id = id;
            this.model = model;
        }

        public ObjectId Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
    }
}