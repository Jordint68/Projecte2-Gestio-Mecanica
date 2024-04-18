using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonIgnoreExtraElements]
    public class Serveis
    {
        [BsonId]
        private ObjectId id;

        [BsonElement("tipo")]
        private String tipus;

        [BsonElement("descripcio")]
        private String descripcio;

        [BsonElement("preu")]
        private double preu;

        [BsonElement("hores_realitzades")]
        private double hores_realitzades;

        public Serveis(ObjectId id, string tipus, string descripcio, double preu, double hores_realitzades)
        {
            this.Id = id;
            this.Tipus = tipus;
            this.Descripcio = descripcio;
            this.Preu = preu;
            this.Hores_realitzades = hores_realitzades;
        }

        public ObjectId Id { get => id; set => id = value; }
        public string Tipus { get => tipus; set => tipus = value; }
        public string Descripcio { get => descripcio; set => descripcio = value; }
        public double Preu { get => preu; set => preu = value; }
        public double Hores_realitzades { get => hores_realitzades; set => hores_realitzades = value; }
    }
}