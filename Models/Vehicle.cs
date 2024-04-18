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
        [BsonId]
        private String id;

        [BsonElement("kms")]
        private int kms;

        [BsonElement("client")]
        private Client client;

        [BsonElement("marca")]
        private Marca marca;

        public Vehicle(String id, int kms, Client client, Marca marca)
        {
            this.Id = id;
            this.Kms = kms;
            this.Client = client;
            this.Marca = marca;
        }

        public String Id { get => id; set => id = value; }
        public int Kms { get => kms; set => kms = value; }
        public Client Client { get => client; set => client = value; }
        public Marca Marca { get => marca; set => marca = value; }
    }
}
