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
        [BsonId]
        private String NIF;

        [BsonElement("nom")]
        private String name;

        [BsonElement("cognoms")]
        private String cognoms;

        [BsonElement("correu")]
        private String eMail;

        [BsonElement("telefon")]
        private String telefon;

        [BsonElement("adreca")]
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

        public String NIF1 { get => NIF; set => NIF = value; }
        public String Name { get => name; set => name = value; }
        public string Cognoms { get => cognoms; set => cognoms = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Adreca { get => adreca; set => adreca = value; }
        public string FullName { get => this.Cognoms + " " + this.Name; }

    }
}
