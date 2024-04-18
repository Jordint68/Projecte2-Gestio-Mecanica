
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    [BsonIgnoreExtraElements]
    public class Linies
    {
        [BsonId]
        private ObjectId id;

        [BsonElement("ticket")]
        private ObjectId ticket;

        [BsonElement("servei")]
        private ObjectId servei;

        [BsonElement("descripcio")]
        private String descripcio;

        [BsonElement("preu")]
        private double preu;

        [BsonElement("estat")]
        private String estat;

        [BsonElement("descompte")]
        private double descompte;

        [BsonElement("tipus")]
        private String tipus;

        public Linies(ObjectId id, ObjectId ticket, ObjectId servei, string descripcio, double preu, string estat, double descompte, string tipus)
        {
            this.id = id;
            this.ticket = ticket;
            this.servei = servei;
            this.descripcio = descripcio;
            this.preu = preu;
            this.estat = estat;
            this.descompte = descompte;
            this.Tipus = tipus;
        }

        public ObjectId Id { get => id; set => id = value; }
        public ObjectId Ticket { get => ticket; set => ticket = value; }
        public string Descripcio { get => descripcio; set => descripcio = value; }
        public double Preu { get => preu; set => preu = value; }
        public string Estat { get => estat; set => estat = value; }
        public double Descompte { get => descompte; set => descompte = value; }
        public string Tipus { get => tipus; set => tipus = value; }
        public ObjectId Servei { get => servei; set => servei = value; }


        public List<String> getEstatsDisponibles()
        {
            return new List<String>() { 
                "tancada",
                "oberta",
                "rebutjada"
            };
        }


    }
}
