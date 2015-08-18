using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENJobExchange.DAL;
using ENJobExchange.Areas.ENPortal;

namespace ENJobExchange.Areas.ENPortal.Controllers
{
    public class ReferralController : Controller
    {

        Entities db = new Entities();
        private Repository _rep = new Repository();

        //
        // GET: /ENPortal/Details/5

        public ActionResult Details(long id)
        {
            ViewModels.Referral model = _rep.GetReferralByID(id);
            model.ReferralNotes = (from r in db.ReferralNotes where r.ReferralID == id && r.ProvideAsFeedback_YN == true select r);
            return View(model);
        }

        //
        // GET: /ENPortal/Create

        [HttpGet]
        public ActionResult Show(long id)
        {
            ViewModels.ReferralHistory model = new ViewModels.ReferralHistory(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Show(long id, short SelectedReferralStatusID, short CreatedLastX)
        {
            ViewModels.ReferralHistory model = new ViewModels.ReferralHistory(id, SelectedReferralStatusID, CreatedLastX);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ENPortal/Create


        [HttpPost]
        public ActionResult Create(ENJobExchange.Areas.ENPortal.ViewModels.Referral rfl)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    rfl.SaveToDB();

                    return RedirectToAction("Index", "Jobs", new { id = 0 });
                }
            }
            catch (Exception er1)
            {

                ModelState.AddModelError("", er1.Message);

                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, contact your system administrator.");
            }
            return View();
           // return View(rfl);


        }

        //
        // GET: /ENPortal/Delete/5

        public ActionResult Delete(int id)
        {
            return View(db.Referrals.Where(m => m.ReferralID == id).FirstOrDefault());
        }

        //
        // POST: /ENPortal/Delete/5

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

        //[HttpGet]
        //public ActionResult Show(int id)
        //{
        //    //var model = _rep.GetENReferrals(id);
        //    ViewModels.ReferralHistory model = new ViewModels.ReferralHistory(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Show(int id, Int16 SelectedReferralStatusID, Int16 CreatedLastX) 
        //{
        //    ViewModels.ReferralHistory model = new ViewModels.ReferralHistory(id, SelectedReferralStatusID, CreatedLastX);
        //    return View(model);
        //}


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
           {

             if (ModelState.IsValid)
               {
                    if (file == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                    }
                        else if (file.ContentLength > 0)
                    {
                            int MaxContentLength = 1024 * 1024 * 3; 
                            //3 MB13. 
                            string[] AllowedFileExtensions = new string[] { ".docx", ".pdf" };
             
                            if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                            {
                                ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                            }
             
                            else if (file.ContentLength > MaxContentLength)
                            {
                                ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                            }
                            else
                            { 
                                //TO:DO27. 
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                                file.SaveAs(path);
                                ModelState.Clear();
                                ViewBag.Message = "File uploaded successfully";
                            }
                        }
                }
                return View();
                }


    }
}
