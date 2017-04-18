using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Veolia;
using Veolia.DataModel;

namespace Veolia.ClientSide.Controllers
{
    public class ClientsController : Controller
    {
        VeoliaContext db = new VeoliaContext();


        // GET: Clients
        public ActionResult Index(string id)
        {
            List<RelationFormAdress> relations = new List<RelationFormAdress>();
            List<Client> clients = db.Clients.Include(c => c.user)
                .Include(n => n.adress).Include(a => a.formControlConform)
                .ToList();
            if (id != "Total")
                clients = clients.Where(s => (s.adress[0].commune == id) || (s.adress[1].commune == id)).ToList();
            foreach (Client client in clients)
            {
                foreach (AdressClient Adress in client.adress)
                {
                    relations = db.RelationFormAdresss
                        .Where(s => s.adressClientID == Adress.adressClientID)
                        .ToList();

                }
            }
            return View(clients);
        }


        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<RelationFormAdress> relations = new List<RelationFormAdress>();
            List<AdressClient> adress = new List<AdressClient>();
            Client client = db.Clients.Find(id);
            adress = db.AdressClients.Where(s => s.clientID == id).ToList();
            foreach(AdressClient adrr in adress)
            {
                relations = db.RelationFormAdresss.Where(n => n.adressClientID == adrr.adressClientID).ToList();
            }
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.Users, "userID", "email");
            return View();
        }

        // POST: Clients/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,userId,clientName,clientSurame,clientEmail,clientNumTel,clientDateCreation,clintDateModification,adress")] Client client)
        {
            if (ModelState.IsValid)
            {
                //Création Client
                client.clientDateCreation = DateTime.Now;
                Client addedclient = db.Clients.Add(client);

                //Création formulaire
                FormControlConform form = new FormControlConform();
                form.clientID = client.clientID;
                form.userID = client.userId;
                FormControlConform addedform = db.FormControlConforms.Add(form);

                //Création Première relation
                RelationFormAdress relation = new RelationFormAdress();
                relation.adress = addedclient.adress[0];
                RelationFormAdress addedrelation = db.RelationFormAdresss.Add(relation);
                if (true)
                {

                }
                //Création deuxième relation Facture
                RelationFormAdress relationfact = new RelationFormAdress();
                relationfact.adress = addedclient.adress[1];
                relationfact.adressFacture = true;

                //Création de recommandation
                RelationFormAdress addedrelationfact = db.RelationFormAdresss.Add(relationfact);
                Recommandation recom = new Recommandation();
                db.Recommandations.Add(recom);

                //save data
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.Users, "userID", "email", client.userId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = db.Clients.Find(id);
            client.adress = db.AdressClients.Where(n => n.clientID == id).Include(s => s.relationFormAdress).ToList();
            
            
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.Users, "userID", "email", client.userId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,userId,clientName,clientSurame,clientEmail,clientNumTel,clientDateCreation,clintDateModification,adress ")] Client client, [Bind(Include = "adress.adressClientID,clientID,adress, commune")]AdressClient adr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();

                for (int i = 0; i < client.adress.Count(); i++)
                {

                    // jib ell address elle bedak ta3ella modify ? men ID client.address[0].id
                    AdressClient old = db.AdressClients.Find(client.adress[i].adressClientID);

                    // update lall information hasab jded client.adress[0]
                    old = client.adress[i];



                    //   db.Entry(addressToModify).State = EntityState.Modified;
                    db.Entry(old).State = EntityState.Modified;
                    db.SaveChanges();
                }

                
                
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.Users, "userID", "email", client.userId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
