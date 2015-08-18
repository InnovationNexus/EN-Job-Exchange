using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ENJobExchange.Areas.PartnerPortal.ViewModels;

namespace ENJobExchange.Areas.PartnerPortal.Controllers
{
    public class ReferralController : Controller
    {
        ENJobExchange.DAL.Entities db = new DAL.Entities();

        //ATTENTION!!! This has hardcoded PartnerID right now
        #region "Index"
        //
        // GET: /PartnerPortal/Referral/

        public ActionResult Index(string searchString, int SelectedStatusID = 0)
        {
            var model = new HomeIndexViewModel(3, searchString, SelectedStatusID);
            return View(model);
        }
        #endregion


        #region "Details"

        //
        // GET: /PartnerPortal/Referral/Details/5

        public ActionResult Details(long referralID)
        {
            var model = new ReferralViewModel(referralID);
            ViewBag.SelectStatus = model.Status;
            return View(model);
        }

        //
        // POST: /PartnerPortal/Referral/Part_ReferralNotes/5

        [HttpPost]
        //public ActionResult Details(ENJobExchange.DAL.ReferralNote refNote, ENJobExchange.Areas.PartnerPortal.Models.Referral referral = null )
        public ActionResult Details(ENJobExchange.DAL.ReferralNote refNote, int ReferralStatus = 0)
        {
            if (!(ReferralStatus == 0))
            {
                var ReferralRecordToUpdate =
                    (from r in db.Referrals
                     where r.ReferralID == refNote.ReferralID
                     select r).Single();
                ReferralRecordToUpdate.ReferralStatusID = ReferralStatus;
                UpdateModel(ReferralRecordToUpdate);
                db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                if (!(refNote.Note == "" || refNote.Note == null)) //Doesn't update is Note is empty  THIS PROBABLY NEEDS TO BE CHANGED FOR STATUS
                {
                    db.Entry(refNote).State = System.Data.Entity.EntityState.Added;
                    UpdateModel(refNote);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Referral", new { referralID = refNote.ReferralID });
                }
                return RedirectToAction("Details", "Referral", new { referralID = refNote.ReferralID });
            }
            return RedirectToAction("Details", "Referral", new { referralID = refNote.ReferralID });
        }

        #endregion

        //Not sure if this will be used...
        #region "Create"
        //
        // GET: /PartnerPortal/Referral/Create

        public ActionResult Create()
        {
            return View();
        }


        //
        // POST: /PartnerPortal/Referral/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        //Not sure if this will be used...
        #region "Edit"
        //
        // GET: /PartnerPortal/Referral/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }


        //
        // POST: /PartnerPortal/Referral/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion


        #region "Delete"
        //
        // GET: /PartnerPortal/Referral/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PartnerPortal/Referral/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

    }
}


//
// GET: /PartnerPortal/Referral/Part_ReferralNotes/5

//public ActionResult Part_ReferralNotes(long referralID)
//{
//    var refNote = from n in db.ReferralNotes
//                  where n.ReferralID == referralID
//                  select n;
//    return View(refNote);
//}