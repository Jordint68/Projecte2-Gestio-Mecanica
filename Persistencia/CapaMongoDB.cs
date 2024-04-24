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

        public List<Vehicle> getVehicles()
        {
            var colVehicles = db.GetCollection<Vehicle>("vehicle");
            return colVehicles.Find(FilterDefinition<Vehicle>.Empty).ToList();
        }

        public List<Vehicle> getVehiclesByClient(string NIF)
        {
            var colVehicles = db.GetCollection<Vehicle>("vehicle");
            var filtre = Builders<Vehicle>.Filter.Eq("client", NIF);
            return colVehicles.Find(filtre).ToList();
        }

        public async Task<bool> esborrarTicket(ObjectId ticketId)
        {
            esborrarLiniesDeTicket(ticketId);

            var colTickets = db.GetCollection<Ticket>("ticket");
            var filter = Builders<Ticket>.Filter.Eq("_id", ticketId);

            var result = await colTickets.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<bool> esborrarLinia(ObjectId liniaId)
        {
            var colLinies = db.GetCollection<Linies>("linies");
            var filtre = Builders<Linies>.Filter.Eq("_id", liniaId);

            var result = await colLinies.DeleteOneAsync(filtre);
            return result.IsAcknowledged && result.DeletedCount > 0;

        }

        public void afegirNouTicket(Ticket ticket)
        {
            if(ticket == null)
            {
                throw new GestorException("El ticket és nul");
            }
            var colTickets = db.GetCollection<Ticket>("ticket");
            colTickets.InsertOne(ticket);
        }

        public void afegirNovaLinia(Linies linia)
        {
            if(linia == null)
            {
                throw new GestorException("La linia és nul·la");
            }
            var colLinies = db.GetCollection<Linies>("linies");
            colLinies.InsertOne(linia);
        }

        /*
         *  Considero que en un ticket no s'ha de poder modificar el client
         *  ni el vehicle. A més, el preu final és un camp a que amb la creació
         *  o eliminació de linies s'autocalcula. Per tant, els camps que s'han de 
         *  poder modificar són les observacions i l'estat.
         */
        public void actualitarTicket(Ticket ticket)
        {
            if(ticket == null)
            {
                throw new GestorException("El ticket és nul");
            }
            try
            {
                var colTickets = db.GetCollection<Ticket>("ticket");
                var filtro = Builders<Ticket>.Filter.Eq("_id", ticket.Id);
                var update = Builders<Ticket>.Update
                    .Set("observacions", ticket.Observacions)
                    .Set("estat", ticket.Estat);

                var result = colTickets.UpdateOne(filtro, update);

                if (result.ModifiedCount > 0)
                {
                    return;
                }
                else
                {
                    throw new GestorException($"No s'ha trobat cap ticket amb l'id {ticket.Id}");
                }
            }
            catch (Exception ex)
            {
                throw new GestorException("No s'ha pogut modificar el ticket." + ex);
            }
        }

        public void actualitzarLinia(Linies linia)
        {
            if(linia == null)
            {
                throw new GestorException("La linia és nul·la");
            }
            try
            {
                var colLinies = db.GetCollection<Linies>("linies");
                var filtre = Builders<Linies>.Filter.Eq("_id", linia.Id);
                var update = Builders<Linies>.Update
                    .Set("descripcio", linia.Descripcio)
                    .Set("preu", linia.Preu)
                    .Set("estat", linia.Estat)
                    .Set("descompte", linia.Descompte)
                    .Set("servei", linia.Servei);

                var result = colLinies.UpdateOne(filtre, update);

                if(result.ModifiedCount > 0)
                {
                    return;
                } else
                {
                    throw new GestorException($"No s'ha trobat cap linia amb l'id {linia.Id}");
                }
                    
            } catch(Exception ex)
            {
                throw new GestorException("No s'ha pogut modificar la linia." + ex);
            }
        }

        public List<Serveis> obtenirServeis()
        {
            var colServeis = db.GetCollection<Serveis>("serveis");
            return colServeis.Find(FilterDefinition<Serveis>.Empty).ToList();
        }

        public void actualitzarPreuTicket(Ticket ticket, decimal preuAntic, decimal preuNou)
        {
            Decimal preu = ticket.Preu_final;
            preu = preu - preuAntic + preuNou;
            if(preu < 0)
            {
                throw new GestorException("El nou preu final del ticket no pot ser inferior a 0.");
            }
            try
            {
                var colTickets = db.GetCollection<Ticket>("ticket");
                var filtro = Builders<Ticket>.Filter.Eq("_id", ticket.Id);
                var update = Builders<Ticket>.Update
                    .Set("preu_final", preu);

                var result = colTickets.UpdateOne(filtro, update);

                if (result.ModifiedCount > 0)
                {
                    return;
                }
                else
                {
                    throw new GestorException($"No s'ha trobat cap ticket amb l'id {ticket.Id}");
                }
            }
            catch (Exception ex)
            {
                throw new GestorException("No s'ha pogut modificar el ticket." + ex);
            }

        }

        public void esborrarLiniesDeTicket(ObjectId ticketId)
        {
            var colLinies = db.GetCollection<Linies>("linies");
            var filter = Builders<Linies>.Filter.Eq("ticket", ticketId);
            colLinies.DeleteMany(filter);
        }
    }

    
}