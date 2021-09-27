using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Windows.Media.Imaging;
using DayPilot.Web.Mvc.Events.Gantt;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using Microsoft.Win32;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Crypto.Digests;
using PagedList;
using Quartz;
using reserverProf.Model;


namespace reserverProf.Controllers
{
    public class HomeController : Controller
    {

        private Model.Entities db = new Model.Entities();
        private object _repository;






        #region Page d'accueil
        //GET: /Home/
        public ActionResult Index()
        {
            return View();

        }
        #endregion

        #region Connexion


        [HttpGet]
        public ActionResult Inscription()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Inscription([Bind(Include = "Id,identifiant,password")] Model.gestionCompte gestCompte)
        {
            if (ModelState.IsValid)
            {
                using (db = new Model.Entities())
                {
                    db.gestionCompte.Add(gestCompte);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(gestCompte);
        }

        [HttpGet]
        public ActionResult InscriptionEdit()
        {
            /*reserverProf.Models.gestionCompte personne = new Models.gestionCompte();*/
            reserverProf.Model.gestionCompte identifiant = new Model.gestionCompte();

            return View();
        }
        [HttpPost]
        public ActionResult InscriptionEdit(gestionCompte gc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gc);
        }
        //[HttpGet]
        //public ActionResult inscriptionUtilisateur()
        //{
        //    return View(db.gestionCompte);

        //}
        //[HttpPost]
        //public ActionResult inscriptionUtilisateur(Models.gestionCompte gc)
        //{
        //    /* user user = db.user.FirstOrDefault(m => m.Id == id);*/
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(gc).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(gc);
        //}



        /*[HttpPost]
        public ActionResult Inscription2(Models.gestionCompte personne)
        {
            using (db = new Models.maBaseEntities3())
            {
                db.gestionCompte.Add(personne);
                db.SaveChanges();
            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Enregistrement à compléter.";
            return View(personne);
        }*/
        #endregion


        #region Appel des pages de connexion
        /* public ActionResult Inscription2()
         {
             return View();

         }

         [HttpPost]
         public ActionResult Inscription2([Bind(Include = "email")] Models.user mail)
         {
             var email = " ";
             email = Request.Form["mail"];

             return View();
         }*/
        [HttpGet]
        public ActionResult Login2()
        {
            Model.gestionCompte monObjet = new Model.gestionCompte();
            return View("Login", monObjet);
        }

        [HttpPost]
        public ActionResult Login2(Model.gestionCompte monObjet)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", monObjet);
            }

            return Content("Saisie ok");
            /*username = db.gestionCompte.FirstOrDefault().identifiant;
             password = db.gestionCompte.FirstOrDefault().password;
             switch (username) {
                 case 1:
                     username.Equals(password);
                     Response.Redirect("detailsProfs");
                     return Content("Bienvenue" + db.gestionCompte.FirstOrDefault().user.prenom);
                     break;
                 case 2:
                     return Content("Désolé" + db.gestionCompte.FirstOrDefault().identifiant + "vous n'avez pas accès à cette page.");
                     break;

                 default:
                     Response.Redirect("Index");
                     break;*/
        }




        #endregion

        #region Listes des Profs
        public ActionResult Grid()
        {
            //var toto = db.user.ToList().FindAll(p => p.gestionCompte.role.Trim() == "utilisateur") ;
            //var tata = db.user.ToList().FirstOrDefault().gestionCompte.role;
            //var titi = db.user.ToList();


            //var toto = db.user.ToList().Where(p => p.gestionCompte.FirstOrDefault().role == "utilisateur");

            /*return View(db.user.ToList().FindAll(p => p.gestionCompte.FirstOrDefault().role == "administrateur")); //.FindAll(p => p.gestionCompte.role.Trim() == "administrateur"));*/
            return View(db.user.ToList().FindAll(p => p.gestionCompte.SingleOrDefault().role == "utilisateur"));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(db.user.FirstOrDefault(m => m.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Model.user user)
        {
             /*user user = db.user.FirstOrDefault(m => m.Id == id);*/
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Grid");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,nom,prenom,telephone,adresse,codePostal,ville,email,photo")] Model.user user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();

                return RedirectToAction("Grid");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Delete1(int id)
        {
            Model.user user = db.user.Find(id);
            db.user.Remove(user);
            db.SaveChanges();
            return Json(new { Suppression = "Ok" });
        }
        #endregion

        #region Gros plan Professeur
        public ActionResult detailsProfs(int? id)
        {

            return View(db.user.FirstOrDefault(m => m.Id == id));
        }

        #endregion

        #region Liste des utilisateurs
        public ActionResult ListeUtilisateurs()
        {
            // db.user.ToList();

            return View(db.user.ToList().Where(p => p.gestionCompte.FirstOrDefault().role == "utilisateur"));
        }
        #endregion

        //public ViewResult ListeProfs(int? page)
        //{
        //    var user = db.user;
        //    int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    return View(user.ToPagedList(pageNumber, pageSize));
        //}

        #region Créer Compte
        // GET: /Home/Create
        public ActionResult CreateCompte()
        {

            return View();
        }


        [HttpPost]
        public ActionResult CreateCompte([Bind(Include = "Id, nom, prenom, telephone, adresse, codePostal, ville, email, <i photo")] Model.user user)
        {

            if (ModelState.IsValid)
            {
                //string fileName = Path.GetFileNameWithoutExtension(user.imageFile.FileName);
                //user.photo = fileName;
                //string chemin = Server.MapPath("~/images/User") + fileName;
                //user.imageFile.SaveAs(chemin);

                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }


        #endregion
        #region
        [HttpPost]
        public ActionResult AddImage(int? id)
        {
            string FilePath = db.user.FirstOrDefault().photo;
            return View(db.user.FirstOrDefault(m => m.Id == id));
        }

        #endregion

        /* #region Update Compte
         public ActionResult Update(int id)
     {
         Models.user user = db.user.Find(id);
         if (user == null)
         {
             return HttpNotFound();
         }
         return View(user);
     }

     [HttpPost]
     public ActionResult Update(Models.user user)
     {
         if (ModelState.IsValid) 
         { 
         db.Entry(user).State = System.Data.Entity.EntityState.Modified;
         db.SaveChanges();
          return RedirectToAction("CreateCompte");
         }
         return View(user);
     }

     #endregion*/

        /*#region Supprimer Compte
        public ActionResult Delete(int id)
        {
            Models.user user = db.user.Find(id);
            db.user.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ListeUtilisateurs");
        }
        #endregion*/



        #region Gros plan Utilisateur
        public ActionResult detailsUtilisateur(int? id)
        {

            return View(db.user.FirstOrDefault(m => m.Id == id));
        }
        #endregion

        #region Evenementielle

        public delegate void MySignature(int data);

        public static event MySignature OnInscriptionCalendrier;

        //public virtual void OnInscriptionCalendrier(EventArgs e)
        //{
        //    EventHandler handler = InscriptionCalendrier;
        //    handler?.Invoke(this, e);
        //}
        #endregion

        #region Calendrier
       /* public ActionResult Calendar()
        {
            var sched = new DHXScheduler(this);
            sched.Skin = DHXScheduler.Skins.Terrace;
            sched.LoadData = true;
            sched.EnableDataprocessor = true;
            sched.InitialDate = new DateTime(2020, 3, 17);
            return PartialView(sched);
            
        }
        public ContentResult CustomData()
        {
            return new SchedulerAjaxData(db.reservation.Select(r => new { r.Id, r.dateCours, r.horaireDebut, r.horaireFin, r.commentaires }));

        }
        [HttpPost]
        public ActionResult Save2(FormCollection actionValues, [Bind(Include = "Id, dateCours, horaireDebut, horaireFin, commentaires")] Model.reservation changedEvent)
        {
            
            var action = new DataAction(actionValues);
            changedEvent = DHXEventsHelper.Bind<Model.reservation>(actionValues);
            var entities = new ModelState();

            if (ModelState.IsValid)
            {
                db.reservation.Add(changedEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(changedEvent);
        }

        public ActionResult Save(int ? id, FormCollection actionValues)
        {
            //var action = new DataAction(actionValues);
            //var changedEvent = DHXEventsHelper.Bind<Event>(actionValues);
            var entities = new SchedulerContext();
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Model.reservation>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        var eventToInsert = db.reservation.SingleOrDefault(r => r.Id == action.TargetId);
                        action.TargetId = changedEvent.Id;
                        action.Message = changedEvent.commentaires;
                        //eventToInsert.commentaires = changedEvent.commentaires;
                        //eventToInsert.horaireDebut = changedEvent.horaireDebut;
                        //eventToInsert.horaireFin = changedEvent.horaireFin;
                        //eventToInsert.jours = changedEvent.jours;
                        //eventToInsert.dateCours = changedEvent.dateCours;
                        db.reservation.Add(eventToInsert);
                        db.SaveChanges();
                        
                        break;
                    case DataActionTypes.Update:
                       var eventToUpdate = db.reservation.SingleOrDefault(r => r.Id == action.SourceId);
                        eventToUpdate.commentaires = changedEvent.commentaires;
                        eventToUpdate.horaireDebut = changedEvent.horaireDebut;
                        eventToUpdate.horaireFin = changedEvent.horaireFin;
                        eventToUpdate.jours = changedEvent.jours;
                        eventToUpdate.dateCours = changedEvent.dateCours;
                        db.reservation.Add(changedEvent);
                        db.SaveChanges();
                        break;
                    case DataActionTypes.Delete:
                        changedEvent = db.reservation.FirstOrDefault(r => r.Id == action.SourceId);
                        db.reservation.Remove(changedEvent);
                        db.SaveChanges();
                        break;
                    default:// "update"
                        var target = db.reservation.Single(r => r.Id == changedEvent.Id);
                        DHXEventsHelper.Update(target, changedEvent, new List<string> { "Id" });
                        db.SaveChanges();
                        break;
                }
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));
        }*/
       public JsonResult GetEvents()
        {
            var events = db.reservation.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        #endregion

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Cours
        public ActionResult Cours()
        {

            return View(db.matiere.ToList());
        }

        public ActionResult CoursDetail()
        {
            return View(db.user.ToList().FirstOrDefault().matiere.domaine);
        }
        #endregion


    }
}

