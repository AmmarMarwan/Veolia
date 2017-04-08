using System.Data.Entity;

namespace Veolia.DataModel
{
    public class OperationFormDiagnosticANC
    {
        public FormDiagnosticANC FindFormDiagnosticmUsingID(int id)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return db.FormDiagnosticANCs.Find(id);
            }
        }

        public void SaveUpdateFormDiagnostic(FormDiagnosticANC formul)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(formul).State = EntityState.Modified;
                db.SaveChanges();

            }

        }

        public int SaveNewFormDiagnostic(FormDiagnosticANC formul)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                FormDiagnosticANC NewForm = db.FormDiagnosticANCs.Add(formul);
                db.SaveChanges();
                return NewForm.formDiagnosticANCID;
            }
        }

        public void DeleteFormDiagnostic(int ID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                FormDiagnosticANC formul = db.FormDiagnosticANCs.Find(ID);
                db.Entry(formul).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}

