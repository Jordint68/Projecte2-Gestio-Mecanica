using Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interficie_Persistencia
{
    public interface ICapaPersistencia
    {
        /// <summary>
        /// Mètode que cerca si existeix un usuari amb el usuari i clau introduides per l'usuari
        /// </summary>
        /// <param name="inputedUser"></param>
        /// <param name="inputedPassword"></param>
        /// <returns>
        ///     - 0 si no hi ha trobat cap dada.
        ///     - 1 si és un mecànic.
        ///     - 2 si és un recepcionista.
        /// </returns>
        public short ValidateLogin(String inputedUser, String inputedPassword);

        /// <summary>
        /// Obtenir tots els tickets
        /// </summary>
        /// <returns></returns>
        public List<Ticket> GetTickets();

        /// <summary>
        /// Obtenir els tickets segons l'estat indicat pel paràmetre estat
        /// </summary>
        /// <param name="estat"></param>
        /// <returns></returns>
        public List<Ticket> GetTicketsByEstat(String estat);

        /// <summary>
        /// Obtenir totes les linies corresponents a un ticket indicat
        /// per paràmetre ticketId
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>

        public List<Linies> GetLinies(ObjectId ticketId);


        /// <summary>
        /// Modificar l'estat pel valor corresponent al paràmetre newValue
        /// d'un ticket corresponent al paràmetre ticketId
        /// </summary>
        /// <param name="ticketId"></param>
        /// <param name="newValue"></param>

        public void modificarEstatTicket(ObjectId ticketId, String newValue);

        /// <summary>
        /// Modificar l'estat pel valor corresponent al paràmetre newValue
        /// d'una linia corresponent al paràmetre liniaId
        /// </summary>
        /// <param name="ticketId"></param>
        /// <param name="newValue"></param>
        public void modificarEstatLinia(ObjectId liniaId, String newValue);

        /// <summary>
        /// Obtenir una llista amb tots els clients
        /// </summary>
        /// <returns></returns>
        public List<Client> getClients();

        /// <summary>
        /// Obtenir una llista amb tots els vehicles
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> getVehicles();

        /// <summary>
        /// Obtenir una llista amb tots els vehicles d'un client corresponent
        /// al paràmetre NIF
        /// </summary>
        /// <param name="NIF"></param>
        /// <returns></returns>
        public List<Vehicle> getVehiclesByClient(String NIF);


        /// <summary>
        /// Esborrar un ticket corresponent al paràmetre ticketId
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        public Task<bool> esborrarTicket(ObjectId ticketId);


        /// <summary>
        /// Esborrar una linia corresponent al paràmetre liniaId
        /// </summary>
        /// <param name="liniaId"></param>
        /// <returns></returns>
        public Task<bool> esborrarLinia(ObjectId liniaId);

        /// <summary>
        /// Afegir un nou ticket rebut pel paràmetre 'ticket'
        /// </summary>
        /// <param name="ticket"></param>
        public void afegirNouTicket(Ticket ticket);

        /// <summary>
        /// Actualitzar un ticket rebut pel paràmetre 'ticket'
        /// </summary>
        /// <param name="ticket"></param>
        public void actualitarTicket(Ticket ticket);


        /// <summary>
        /// Actualitzar el preu d'un ticket rebut pel paràmetre 'ticket'
        /// on hem de restar el preu antic i sumar el preu nou
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="preuAntic"></param>
        /// <param name="preuNou"></param>
        public void actualitzarPreuTicket(Ticket ticket, Decimal preuAntic, Decimal preuNou);

        /// <summary>
        /// Afegir una nova linia rebuda mitjançant el paràmetre
        /// 'linia'
        /// </summary>
        /// <param name="linia"></param>
        public void afegirNovaLinia(Linies linia);

        /// <summary>
        /// Actualitzar una linia mitjaçant el paràmetre
        /// 'linia'
        /// </summary>
        /// <param name="linia"></param>
        public void actualitzarLinia(Linies linia);

        /// <summary>
        /// Obtenir una llista amb tots els serveis
        /// </summary>
        /// <returns></returns>
        public List<Serveis> obtenirServeis();

        /// <summary>
        /// Esborrar totes les linies d'un ticket
        /// especificat pel paràmetre 'ticketId'
        /// </summary>
        /// <param name="ticketId"></param>
        public void esborrarLiniesDeTicket(ObjectId ticketId);

    }
}
