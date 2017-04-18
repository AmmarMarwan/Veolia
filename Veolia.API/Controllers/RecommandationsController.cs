using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Veolia.DataModel;

namespace Veolia.API.Controllers
{
    public class RecommandationsController : ApiController
    {
        OperationRecommandation _repo = new OperationRecommandation();

        

        // GET: api/Recommandations/5
        [ResponseType(typeof(Recommandation))]
        public Recommandation GetRecommandation(int id)
        {
            return _repo.FindRecommandationUsingID(id);
        }

        // PUT: api/Recommandations/5
        [ResponseType(typeof(void))]
        public void PutRecommandation( Recommandation recommandation)
        {
            _repo.SaveUpdateRecommandation(recommandation);
        }

        // POST: api/Recommandations
        [ResponseType(typeof(Recommandation))]
        public int PostRecommandation(Recommandation recommandation)
        {
            return _repo.SaveNewRecommandation(recommandation);
        }

        // DELETE: api/Recommandations/5
        [ResponseType(typeof(Recommandation))]
        public void DeleteRecommandation(int id)
        {
            _repo.DeleteRecommandation(id); 
        }

       
    }
}