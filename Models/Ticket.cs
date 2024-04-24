using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [BsonIgnoreExtraElements]
    public class Ticket
    {
        
        private ObjectId id;
        private Client client;
        private Vehicle vehicle;
        private string observacions;
        private String estat;
        private DateTime data_creacio; 
        private Decimal preu_final;
        

        public Ticket()
        {
        }

        // Constructor amb tots els camps de ticket
        public Ticket(ObjectId id, Client client, Vehicle vehicle, string observacions, string estat, DateTime data_creacio, Decimal preu_final)
        {
            this.id = id;
            this.client = client;
            this.vehicle = vehicle;
            this.observacions = observacions;
            this.estat = estat;
            this.data_creacio = data_creacio;
            this.preu_final = preu_final;
        }

        // Constructor sense els camps id i preu_final. Ja que al crear l'objecte a mongodb
        // el propi SGBD ens assignarà l'id automàticament. El preu_final ha de ser un camp calculat
        // amb la suma dels preus de la seves linies
        public Ticket(Client client, Vehicle vehicle, string observacions, string estat, DateTime data_creacio)
        {
            this.client = client;
            this.vehicle = vehicle;
            this.observacions = observacions;
            this.estat = estat;
            this.data_creacio = data_creacio;
            this.preu_final = 0;
        }

        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get => id; set => id = value; }

        [BsonElement("client")]
        public Client ClientProv { get => client; set => client = value; }

        [BsonElement("vehicle")]
        public Vehicle Vehicle { get => vehicle; set => vehicle = value; }

        [BsonElement("observacions")]
        public string Observacions { get => observacions; set => observacions = value; }

        [BsonElement("estat")]
        public string Estat { get => estat; set => estat = value; }

        [BsonElement("data_creacio")]
        public DateTime Data_creacio { get => data_creacio; set => data_creacio = value; }

        [BsonElement("preu_final")]
        public Decimal Preu_final { get => preu_final; set => preu_final = value; }

        public List<String> getEstatsDisponibles()
        {
            return new List<String>() {
                "tancat",
                "obert",
                "rebutjat"
            };
        }
        
        public List<String> getEstatsDisponiblesPerCreacio()
        {
            return new List<String>() {
                "tancat",
                "obert"
            };
        }
    }
}