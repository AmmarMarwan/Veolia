using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Veolia.DataModel;

namespace Veolia.API.Controllers
{
    public class ClientsController : ApiController
    {

        OperationClient _repo = new OperationClient();

        // GET: api/Clients
        public List<Client> GetClients()
        {
            return _repo.FindClient();
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public Client GetClient(int id)
        {
            Client client = _repo.FindClientUsingID(id);
            return client;
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public void PutClient(int id, Client client)
        {
            _repo.SaveUpdateClient(client);
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public int PostClient(Client client)
        {
            client.clientDateCreation = DateTime.Now;
            client.clintDateModification = DateTime.Now;
            return _repo.SaveNewClient(client);

        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public void DeleteClient(int id)
        {
            _repo.DeleteClient(id);
        }
 
    }
}