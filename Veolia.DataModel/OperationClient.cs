using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Veolia.DataModel
{
    public class OperationClient
    {
        public List<Client> FindClient()
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.Clients.ToList());
            }
        }

        public Client FindClientUsingID(int id)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return db.Clients.Find(id);
            }
        }

        public List<Client> FindClientUsingUserID(int userID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return db.Clients.Where(n => n.userId == userID).ToList();
            }
        }

        public void SaveUpdateClient(Client client)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                
            }

        }

        public int SaveNewClient(Client client)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                Client addedone = db.Clients.Add(client);
                db.SaveChanges();
                return addedone.clientID;
            }
        }

        public void DeleteClient(int ID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                Client client = db.Clients.Find(ID);
                db.Entry(client).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
