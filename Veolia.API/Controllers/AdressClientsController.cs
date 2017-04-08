using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Veolia;
using Veolia.DataModel;

namespace Veolia.API.Controllers
{
    public class AdressClientsController : ApiController
    {

        OperationAdressClient _repo = new OperationAdressClient();

        // GET: api/AdressClients
        public List<AdressClient> GetAdressClients()
        {
            return _repo.FindAdressClient();
        }

        // GET: api/AdressClients/5
        [ResponseType(typeof(AdressClient))]
        public AdressClient GetAdressClient(int id)
        {
            return (_repo.FindAdressClientUsingID(id));
        }

        // PUT: api/AdressClients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdressClient(int id, AdressClient adressClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adressClient.clientID)
            {
                return BadRequest();
            }

            _repo.SaveUpdateAdress(adressClient);
            return StatusCode(HttpStatusCode.NoContent);

        }

        // POST: api/AdressClients
        [ResponseType(typeof(AdressClient))]
        public int PostAdressClient(AdressClient adressClient)
        {
            return (_repo.SaveNewAdress(adressClient));
        }

        // DELETE: api/AdressClients/5
        [ResponseType(typeof(AdressClient))]
        public void DeleteAdressClient(int id)
        {
            _repo.DeleteAdress(id);
        }

       
    }
}