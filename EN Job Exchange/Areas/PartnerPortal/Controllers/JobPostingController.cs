using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENJobExchange.DAL;
using ENJobExchange.Areas.PartnerPortal.ViewModels;

namespace ENJobExchange.Areas.PartnerPortal.Controllers
{
    public class JobPostingController : Controller
    {


        #region "Index"
        //
        // GET: /PartnerPortal/JobPosting/

        public ActionResult Index(long partnerID)
        {
            var model = new HomeIndexViewModel(partnerID);
            return View(model);
        }
        #endregion


        #region "Details"
        //
        // GET: /PartnerPortal/JobPosting/Details/5

        public ActionResult Details(long jobPostingID)
        {
            var model = new JobPostingViewModel(jobPostingID);
            return View(model);
        }
        #endregion

        //ATTENTION Post not finished
        #region "Create"

        //
        // GET: /PartnerPortal/JobPosting/Create

        public ActionResult Create()
        {
            return View();
        }


        //
        // POST: /PartnerPortal/JobPosting/Create

        [HttpPost]
        public ActionResult Create(JobPostingViewModel jpvm)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    //LOGIC HERE
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ModelState.AddModelError("", "Unable to save changes.  Try again, and if the problem persist, contact your system administrator.");
            }
            return View(jpvm);
        }

        #endregion

        //Not in use
        #region "Edit"

        //
        // GET: /PartnerPortal/JobPosting/Edit/5

        public ActionResult Edit(long JobPostingID)
        {
            var model = new JobPostingViewModel(JobPostingID);
            return View(model);
        }

        //
        // POST: /PartnerPortal/JobPosting/Edit/5

        [HttpPost]
        public ActionResult Edit(ENJobExchange.Areas.PartnerPortal.ViewModels.JobPostingViewModel jpvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    jpvm.EditReferral(jpvm);
                }
                return RedirectToAction("Index", new { PartnerID = jpvm.jobPosting.PartnerID });
            }
            catch
            {
                return View();
            }
        }

        #endregion

        //Not in use
        #region "Delete"

        //
        // GET: /PartnerPortal/JobPosting/Delete/5

        public ActionResult Delete(long JobPostingID)
        {
            var model = new JobPostingViewModel(JobPostingID);
            return View(model);
        }

        //
        // POST: /PartnerPortal/JobPosting/Delete/5

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
