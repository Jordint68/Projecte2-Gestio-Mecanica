using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonIgnoreExtraElements]
    public class Ticket
    {
        [BsonId]
        private ObjectId id;

        [BsonElement("client")]
        private Client client;

        [BsonElement("vehicle")]
        private Vehicle vehicle;

        [BsonElement("observacions")]
        private string observacions;

        [BsonElement("estat")]
        private String estat;

        [BsonElement("data_creacio")]
        private DateTime data_creacio;

        [BsonElement("preu_final")]
        private double preu_final;

        public Ticket(ObjectId id, Client client, Vehicle vehicle, string observacions, string estat, DateTime data_creacio, double preu_final)
        {
            this.id = id;
            this.client = client;
            this.vehicle = vehicle;
            this.observacions = observacions;
            this.estat = estat;
            this.data_creacio = data_creacio;
            this.preu_final = preu_final;
        }

        public ObjectId Id { get => id; set => id = value; }
        public Client ClientProv { get => client; set => client = value; }
        public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
        public string Observacions { get => observacions; set => observacions = value; }
        public string Estat { get => estat; set => estat = value; }
        public DateTime Data_creacio { get => data_creacio; set => data_creacio = value; }
        public double Preu_final { get => preu_final; set => preu_final = value; }

        public List<String> getEstatsDisponibles()
        {
            return new List<String>() {
                "tancat",
                "obert",
                "rebutjat"
            };
        }
    }
}