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
    public class FormControlConformsController : Controller
    {
        private VeoliaContext db = new VeoliaContext();

        // GET: FormControlConforms
        public ActionResult Index()
        {
            List<AdressClient> addresses = new List<AdressClient>();
            List< FormControlConform> formControlConforms = db.FormControlConforms.Include(f => f.client).Include(f => f.user).Include(s => s.relationFormAdress).ToList();
            foreach (FormControlConform form in formControlConforms)
            {
                foreach (RelationFormAdress relation in form.relationFormAdress)
                {
                    addresses =  db.AdressClients.Where(s => s.adressClientID == relation.adressClientID).ToList();
                   
                }
            }

            

            return View(formControlConforms);
        }

        // GET: FormControlConforms/Details/5
        public ActionResult Details(int? id)
        {
            List<AdressClient> addresses = new List<AdressClient>();
            List<FormControlConform> formControlConforms = db.FormControlConforms.Include(f => f.client).Include(f => f.user).Include(s => s.relationFormAdress).ToList();
            foreach (FormControlConform form in formControlConforms)
            {
                foreach (RelationFormAdress relation in form.relationFormAdress)
                {
                    addresses = db.AdressClients.Where(s => s.adressClientID == relation.adressClientID).ToList();

                }
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormControlConform formControlConform = db.FormControlConforms.Find(id);
            if (formControlConform == null)
            {
                return HttpNotFound();
            }
            return View(formControlConform);
        }
        // GET: FormControlConforms/DetailsUsingClient/5
        public ActionResult DetailsUsingClient(int? id)
        {
            List<AdressClient> addresses = new List<AdressClient>();
            var formControlConforms = db.FormControlConforms.Include(f => f.client).Include(f => f.user).Include(s => s.relationFormAdress).ToList();
            foreach (FormControlConform form in formControlConforms)
            {
                foreach (RelationFormAdress relation in form.relationFormAdress)
                {
                    addresses = db.AdressClients.Where(s => s.adressClientID == relation.adressClientID).ToList();

                }
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formu = db.FormControlConforms.Where(n => n.clientID == id).ToList();
            int a = formu.FirstOrDefault().formControlConformID;
            FormControlConform formControlConform = db.FormControlConforms.Find(a) ;
            if (formControlConform == null)
            {
                return HttpNotFound();
            }
            return View(formControlConform);
        }

        // GET: FormControlConforms/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientName");
            ViewBag.userID = new SelectList(db.Users, "userID", "email");
            return View();
        }

        // POST: FormControlConforms/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "formControlConformID,clientID,userID,presenceRegardEU,regardEUAccessible,presenceRegardEP,regardEPAccessible,natureEffluent,typeBranchement,dispositifAntiReflux,wc,salleDeBain,evier,laveLinge,laveVaisselle,systemeRelevage,fosseSeptique,nombreGouttieres,regardPiedGouttiere,evacuationEauPluies,dateControle,constatEnquete,anomaliesConstatees,recommendationTraveauxMiseConformite")] FormControlConform formControlConform)
        {
            if (ModelState.IsValid)
            {
                db.FormControlConforms.Add(formControlConform);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientName", formControlConform.clientID);
            ViewBag.userID = new SelectList(db.Users, "userID", "email", formControlConform.userID);
            return View(formControlConform);
        }

        // GET: FormControlConforms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormControlConform formControlConform = db.FormControlConforms.Find(id);
            if (formControlConform == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientName", formControlConform.clientID);
            ViewBag.userID = new SelectList(db.Users, "userID", "email", formControlConform.userID);
            ViewBag.adressID = new SelectList(db.AdressClients, "clientID", "adress", formControlConform.clientID);
            ViewBag.adressID = new SelectList(db.RelationFormAdresss, "clientID", "adress", formControlConform.clientID);
            return View(formControlConform);
        }

        // POST: FormControlConforms/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "formControlConformID,clientID,userID,presenceRegardEU,regardEUAccessible,presenceRegardEP,regardEPAccessible,natureEffluent,typeBranchement,dispositifAntiReflux,wc,salleDeBain,evier,laveLinge,laveVaisselle,systemeRelevage,fosseSeptique,nombreGouttieres,regardPiedGouttiere,evacuationEauPluies,dateControle,constatEnquete,anomaliesConstatees,recommendationTraveauxMiseConformite")] FormControlConform formControlConform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formControlConform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new {id =formControlConform.formControlConformID  });
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientName", formControlConform.clientID);
            ViewBag.userID = new SelectList(db.Users, "userID", "email", formControlConform.userID);
            return View(formControlConform);
        }

        // GET: FormControlConforms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormControlConform formControlConform = db.FormControlConforms.Find(id);
            if (formControlConform == null)
            {
                return HttpNotFound();
            }
            return View(formControlConform);
        }

        // POST: FormControlConforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormControlConform formControlConform = db.FormControlConforms.Find(id);
            db.FormControlConforms.Remove(formControlConform);
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
