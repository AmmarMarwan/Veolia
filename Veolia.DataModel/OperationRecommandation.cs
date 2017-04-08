using System.Data.Entity;

namespace Veolia.DataModel
{
    public class OperationRecommandation
    {
        public Recommandation FindRecommandationUsingID(int id)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return db.Recommandations.Find(id);
            }
        }

        public void SaveUpdateRecommandation(Recommandation recom)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(recom).State = EntityState.Modified;
                db.SaveChanges();

            }

        }

        public int SaveNewRecommandation(Recommandation recom)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                Recommandation NewRecom = db.Recommandations.Add(recom);
                db.SaveChanges();
                return recom.recommandationID;
            }
        }

        public void DeleteRecommandation(int ID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                Recommandation recom = db.Recommandations.Find(ID);
                db.Entry(recom).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
