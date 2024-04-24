using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [BsonIgnoreExtraElements]
    public class Vehicle
    {
        private String id;
        private int kms;
        private String client; 
        private Marca marca;

        public Vehicle(String id, int kms, String client, Marca marca)
        {
            this.Id = id;
            this.Kms = kms;
            this.Client = client;
            this.Marca = marca;
        }


        [BsonId]
        [BsonElement("_id")]
        public String Id { get => id; set => id = value; }

        [BsonElement("kms")]
        public int Kms { get => kms; set => kms = value; }

        [BsonElement("client")]
        public String Client { get => client; set => client = value; }

        [BsonElement("marca")]
        public Marca Marca { get => marca; set => marca = value; }
    }
}
