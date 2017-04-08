using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Veolia.DataModel
{
    public class OperationUser
    {
        public List<User> FindUser()
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.Users.ToList());
            }
        }

        public User FindUserUsingID(int ID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.Users.Find(ID));
            }
        }

        public List<User> FindUserUsingRelationID(int relationID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return db.Users.Where(z => z.userID == relationID).ToList();
            }
        }

        public int SaveNewUser(User user)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                User NewUser = db.Users.Add(user);
                db.SaveChanges();
                return NewUser.userID;
            }
        }

        public void DeleteUser(int userID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                User user = db.Users.Find(userID);
                db.Entry(user).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void SaveUpdateUser(User user)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
    }
}
