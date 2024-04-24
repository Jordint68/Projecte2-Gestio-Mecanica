
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
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
        private ObjectId id;
        private ObjectId ticket;
        private ObjectId servei;
        private String descripcio;
        private Decimal preu;
        private String estat;
        private Decimal descompte;
        private String tipus;
        private Decimal import;

        public Linies() {}

        public Linies(ObjectId ticket, ObjectId servei, string descripcio, Decimal preu, string estat, Decimal descompte, string tipus)
        {
            this.ticket = ticket;
            this.servei = servei;
            this.descripcio = descripcio;
            this.preu = preu;
            this.estat = estat;
            this.descompte = descompte;
            this.tipus = tipus;
            this.import = calcularImport(preu, descompte);
        }

        public Linies(ObjectId id, ObjectId ticket, ObjectId servei, string descripcio, Decimal preu, string estat, Decimal descompte, string tipus)
        {
            this.id = id;
            this.ticket = ticket;
            this.servei = servei;
            this.descripcio = descripcio;
            this.preu = preu;
            this.estat = estat;
            this.descompte = descompte;
            this.Tipus = tipus;
            this.import = calcularImport(preu, descompte);
            
        }

        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get => id; set => id = value; }

        [BsonElement("ticket")]
        public ObjectId Ticket { get => ticket; set => ticket = value; }

        [BsonElement("descripcio")]
        public string Descripcio { get => descripcio; set => descripcio = value; }

        [BsonElement("preu")]
        public Decimal Preu { get => preu; set => preu = value; }

        [BsonElement("estat")]
        public string Estat { get => estat; set => estat = value; }

        [BsonElement("descompte")]
        public Decimal Descompte { get => descompte; set => descompte = value; }

        [BsonElement("tipus")]
        public string Tipus { get => tipus; set => tipus = value; }

        [BsonElement("servei")]
        public ObjectId Servei { get => servei; set => servei = value; }

        [BsonElement("import")]
        public Decimal Import { get => import; set => import = value; }


        public List<String> getEstatsDisponibles()
        {
            return new List<String>() { 
                "tancada",
                "oberta",
                "rebutjada"
            };
        }

        public List<String> getEstatsDisponiblesPerCreacio()
        {
            return new List<String>() {
                "tancada",
                "oberta"
            };
        }


        private Decimal calcularImport(Decimal p, Decimal d)
        {
            return (p - (p * (d / 100)));
        }


    }
}
