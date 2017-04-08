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
        public IHttpActionResult GetClient(int id)
        {
            Client client = _repo.FindClientUsingID(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.clientID)
            {
                return BadRequest();
            }

            _repo.SaveUpdateClient(client);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public int PostClient(Client client)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */

            client.clientDateCreation = DateTime.Now;
            client.clintDateModification = DateTime.Now;
            return _repo.SaveNewClient(client);
            //return CreatedAtRoute("DefaultApi", new { id = client.clientID }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public void DeleteClient(int id)
        {
            _repo.DeleteClient(id);
        }
 
    }
}