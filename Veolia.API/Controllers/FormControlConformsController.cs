using System.Web.Http;
using System.Web.Http.Description;
using Veolia.DataModel;

namespace Veolia.API.Controllers
{
    public class FormControlConformsController : ApiController
    {
        OperationFormContolConform _repo = new OperationFormContolConform();


        // GET: api/FormControlConforms/5
        [ResponseType(typeof(FormControlConform))]
        public FormControlConform GetFormControlConform(int id)
        {
            return _repo.FindFormulControlConformUsingID(id);

        }

        // PUT: api/FormControlConforms/5
        [ResponseType(typeof(void))]
        public void PutFormControlConform( FormControlConform formControlConform)
        {
            _repo.SaveUpdateFormControlConform(formControlConform);
        }

        // POST: api/FormControlConforms
        [ResponseType(typeof(FormControlConform))]
        public int PostFormControlConform(FormControlConform formControlConform)
        {
           return _repo.SaveNewFormControlConform(formControlConform); 
        }

        // DELETE: api/FormControlConforms/5
        [ResponseType(typeof(FormControlConform))]
        public void DeleteFormControlConform(int id)
        {
            _repo.DeleteFormulControlConform(id);
        }

       
    }
}