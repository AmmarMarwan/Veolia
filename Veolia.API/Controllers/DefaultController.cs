using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Veolia.DataModel;

namespace Veolia.API.Controllers
{
    public class DefaultController : ApiController
    {
        OperationClient _repo = new OperationClient();

        // POST: api/Default
        [ResponseType(typeof(Client))]
        public int PostClient(Client client)
        {
            // Create or Update Client

            // Create or Update Addresses

            // Create Formulair or Update

            // return result 

            client.clientDateCreation = DateTime.Now;
            client.clintDateModification = DateTime.Now;
            return _repo.SaveNewClient(client);
            //return CreatedAtRoute("DefaultApi", new { id = client.clientID }, client);
        }
    }
}
