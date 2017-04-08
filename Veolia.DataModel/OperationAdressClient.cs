using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veolia.DataModel
{
    public class OperationAdressClient
    {
        public List<AdressClient> FindAdressClient()
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.AdressClients.ToList());
            }
        }

        public AdressClient FindAdressClientUsingID(int ID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.AdressClients.Find(ID));
            }
        }

        public List<AdressClient> FindAdressClientUsingClientID(int ClientID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return db.AdressClients.Where(z => z.clientID == ClientID).ToList();
            }
        }
        //enlever List<>
        public List<AdressClient> FindAdressClientUsingClientIDRelationID(int ClientID, int RelationID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {   //enlever .ToList()
                return db.AdressClients.Where(n => n.clientID == ClientID).ToList();//.Where(n => n.relationFormAdress.Find(RelationID));
            }
        }

        public int SaveNewAdress(AdressClient adress)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                AdressClient addAdress = db.AdressClients.Add(adress);
                db.SaveChanges();
                return addAdress.clientID;
            }
        }

        public void DeleteAdress(int adressID)
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                AdressClient adress = db.AdressClients.Find(adressID);
                db.Entry(adress).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void SaveUpdateAdress(AdressClient adress)
        {
            using (VeoliaContext db = new VeoliaContext())
            {

                db.Entry(adress).State = EntityState.Modified;
                db.SaveChanges();
            }

        }

    }
}
