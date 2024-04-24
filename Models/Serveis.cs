using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonIgnoreExtraElements]
    public class Serveis
    {
        private ObjectId id; 
        private String tipus;
        private String descripcio;

        public Serveis(ObjectId id, string tipus, string descripcio)
        {
            this.Id = id;
            this.Tipus = tipus;
            this.Descripcio = descripcio;
        }

        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get => id; set => id = value; }

        [BsonElement("tipo")]
        public string Tipus { get => tipus; set => tipus = value; }

        [BsonElement("descripcio")]
        public string Descripcio { get => descripcio; set => descripcio = value; }
    }
}