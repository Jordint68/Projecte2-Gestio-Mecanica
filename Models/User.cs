using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        private ObjectId id;
        private String user_name;
        private string password;
        private string type;
        private string name;

        [BsonId]
        public ObjectId Id { get => id; set => id = value; }

        [BsonElement("user")]
        public string User_name { get => user_name; set => user_name = value; }

        [BsonElement("password")]
        public string Password { get => password; set => password = value; }

        [BsonElement("tipus")]
        public string Type { get => type; set => type = value; }

        [BsonElement("name")]
        public string Name { get => name; set => name = value; }

        public User(ObjectId id, string user, string password, string type, string name)
        {
            this.id = id;
            this.user_name = user;
            this.password = password;
            this.type = type;
            this.name = name;
        }
    }

    public enum tipusUser
    {
        MECANIC  = 1,
        RECEPCIONISTA = 2
    }
}
 