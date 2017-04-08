using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veolia.DataModel
{
    public class OperationRelationAdressForm
    {
        public List<RelationFormAdress> FindRelationFormAdress()
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.RelationFormAdresss.ToList());
            }
        }

        public int SaveNewRelationFormAdress(RelationFormAdress relation)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                RelationFormAdress Relation = db.RelationFormAdresss.Add(relation);
                db.SaveChanges();
                return Relation.relationFormAdressID;
            }
        }

        public void DeleteRelationFormAdress(int relationID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                RelationFormAdress Relation = db.RelationFormAdresss.Find(relationID);
                db.Entry(Relation).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void SaveUpdateRelationFormAdress(RelationFormAdress relation)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(relation).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
    }
}
