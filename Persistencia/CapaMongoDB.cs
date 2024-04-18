using Interficie_Persistencia;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistencia.Models;

namespace Persistencia
{
    public class CapaMongoDB : ICapaPersistencia
    {
        private MongoClient client;
        private IMongoDatabase db;

        public CapaMongoDB(String connectionString, String dbName)
        {
            this.client = new MongoClient(connectionString);
            this.db = client.GetDatabase(dbName);
        }


        public List<Linies> GetLinies(ObjectId ticketId)
        {
            var colLinies = db.GetCollection<Linies>("linies");
            var filtro = Builders<Linies>.Filter.Eq("ticket", ticketId);
            return colLinies.Find(filtro).ToList();
        }

        public List<Ticket> GetTickets()
        {
            var colTickets = db.GetCollection<Ticket>("ticket");
            return colTickets.Find(FilterDefinition<Ticket>.Empty).ToList();
        }

        public List<Ticket> GetTicketsByEstat(String estat)
        {
            var colTickets = db.GetCollection<Ticket>("ticket");
            var filtre = Builders<Ticket>.Filter.Eq("estat", estat);
            return colTickets.Find(filtre).ToList();
        }

        public short ValidateLogin(String inputedUser, String inputedPassword)
        {
            var colUsuari = db.GetCollection<User>("usuari");
            User foundUser = colUsuari.Find(u => u.User_name.Equals(inputedUser) ).FirstOrDefault();      
 
            if (foundUser != null)
            {
                if (foundUser.Password.Equals(inputedPassword))
                {
                    if (foundUser.Type.Equals("mecànic"))
                    {
                        return (short)tipusUser.MECANIC;
                    }
                    else
                    {
                        return (short)tipusUser.RECEPCIONISTA;
                    }
                }
            }

            return 0;
            
        }

        public void modificarEstatTicket(ObjectId ticketId, string newValue)
        {
            var colTickets = db.GetCollection<Ticket>("ticket");
            var filter = Builders<Ticket>.Filter.Eq("_id", ticketId);
            var update = Builders<Ticket>.Update.Set("estat", newValue);
            colTickets.UpdateOne(filter, update);
        }

        public void modificarEstatLinia(ObjectId liniaId, string newValue)
        {
            var colLinies = db.GetCollection<Linies>("linies");
            var filtro = Builders<Linies>.Filter.Eq("_id", liniaId);
            var update = Builders<Linies>.Update.Set("estat", newValue);
            colLinies.UpdateOne(filtro, update);
        }

        public List<Client> getClients()
        {
            var colClients = db.GetCollection<Client>("client");
            return colClients.Find(FilterDefinition<Client>.Empty).ToList();
        }
    }

    
}