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
    public class RelationFormAdressesController : ApiController
    {
        OperationRelationAdressForm _repo = new OperationRelationAdressForm();

        // GET: api/RelationFormAdresses
        public List<RelationFormAdress> GetRelationFormAdresss()
        {
            return _repo.FindRelationFormAdress();
        }

        // GET: api/RelationFormAdresses/5
        [ResponseType(typeof(RelationFormAdress))]
        public void GetRelationFormAdress(int id)
        {

        }

        // PUT: api/RelationFormAdresses/5
        [ResponseType(typeof(void))]
        public void PutRelationFormAdress(int id, RelationFormAdress relationFormAdress)
        {
            _repo.SaveUpdateRelationFormAdress(relationFormAdress);

        }

        // POST: api/RelationFormAdresses
        [ResponseType(typeof(RelationFormAdress))]
        public int PostRelationFormAdress(RelationFormAdress relationFormAdress)
        {
           return _repo.SaveNewRelationFormAdress(relationFormAdress);
        }

        // DELETE: api/RelationFormAdresses/5
        [ResponseType(typeof(RelationFormAdress))]
        public void DeleteRelationFormAdress(int id)
        {
            _repo.DeleteRelationFormAdress(id);
        }

       
    }
}