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
    public class Factura
    {
        private ObjectId _id;
        private DateTime dataCreacio;
        private Decimal IVA;
        private Decimal quota;
        private Decimal import_total;
        private String estat;
        private ObjectId ticket;

        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get => _id; set => _id = value; }

        [BsonElement("data_creacio")]
        public DateTime DataCreacio { get => dataCreacio; set => dataCreacio = value; }

        [BsonElement("IVA")]
        public decimal IVA1 { get => IVA; set => IVA = value; }

        [BsonElement("Quota")]
        public decimal Quota { get => quota; set => quota = value; }

        [BsonElement("Total")]
        public decimal Import_total { get => import_total; set => import_total = value; }

        [BsonElement("estat")]
        public string Estat { get => estat; set => estat = value; }

        [BsonElement("ticket")]
        public ObjectId Ticket { get => ticket; set => ticket = value; }
    }
}
