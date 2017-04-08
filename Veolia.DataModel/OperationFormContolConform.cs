using System.Data.Entity;

namespace Veolia.DataModel
{
    public class OperationFormContolConform
    {
        public FormControlConform FindFormulControlConformUsingID(int id)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return db.FormControlConforms.Find(id);
            }
        }

        public void SaveUpdateFormControlConform(FormControlConform formul)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(formul).State = EntityState.Modified;
                db.SaveChanges();

            }

        }

        public int SaveNewFormControlConform(FormControlConform formul)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                FormControlConform NewForm = db.FormControlConforms.Add(formul);
                db.SaveChanges();
                return  NewForm.formControlConformID;
            }
        }

        public void DeleteFormulControlConform(int ID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                FormControlConform formul = db.FormControlConforms.Find(ID);
                db.Entry(formul).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
