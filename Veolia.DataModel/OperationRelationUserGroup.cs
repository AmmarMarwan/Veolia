using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veolia.DataModel
{
    public class OperationRelationUserGroup
    {
        public List<RelationUserGroupAccess> FindRelationUserGroup()
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.RelationGroupAccesss.ToList());
            }
        }

        public List<RelationUserGroupAccess> FindRelationUserGroupUsingUserID(int userId)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.RelationGroupAccesss.Where(n => n.userID == userId).ToList());
            }
        }

        public List<RelationUserGroupAccess> FindRelationUserGroupUsingGroupID(int groupId)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.RelationGroupAccesss.Where(n => n.groupAccessID == groupId).ToList());
            }
        }

        public int SaveNewRelationUserGroup(RelationUserGroupAccess relation)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                RelationUserGroupAccess Relation = db.RelationGroupAccesss.Add(relation);
                db.SaveChanges();
                return Relation.relationUserGroupAccessID;
            }
        }

        public void DeleteRelationUserGroup(int relationID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                RelationUserGroupAccess Relation = db.RelationGroupAccesss.Find(relationID);
                db.Entry(Relation).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void SaveUpdateRelationUserGroup(RelationUserGroupAccess relation)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(relation).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
    }
}
