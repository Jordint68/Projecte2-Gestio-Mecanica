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
    public class Client
    {
        private String NIF;
        private String name;
        private String cognoms;
        private String eMail; 
        private String telefon;
        private String adreca;

        private String fullName;
        public Client(String nIF, string name, string cognoms, string eMail, string telefon, string adreca)
        {
            this.NIF = nIF;
            this.Name = name;
            this.Cognoms = cognoms;
            this.EMail = eMail;
            this.Telefon = telefon;
            this.Adreca = adreca;
        }

        [BsonId]
        [BsonElement("_id")]
        public String NIF1 { get => NIF; set => NIF = value; }

        [BsonElement("nom")]
        public String Name { get => name; set => name = value; }

        [BsonElement("cognoms")]
        public string Cognoms { get => cognoms; set => cognoms = value; }

        [BsonElement("correu")]
        public string EMail { get => eMail; set => eMail = value; }

        [BsonElement("telefon")]
        public string Telefon { get => telefon; set => telefon = value; }

        [BsonElement("adreca")]
        public string Adreca { get => adreca; set => adreca = value; }
        public string FullName { get => this.Cognoms + " " + this.Name; }

    }
}
