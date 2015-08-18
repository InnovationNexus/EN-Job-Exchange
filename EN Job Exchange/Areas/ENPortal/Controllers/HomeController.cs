using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENJobExchange.DAL;
using ENJobExchange.Areas.ENPortal.ViewModels;

namespace ENJobExchange.Areas.ENPortal.Controllers
{
    public class HomeController : Controller
    {

        Entities db = new Entities();
        private Repository _rep = new Repository();

        //
        // GET: /ENPortal/

        public ActionResult Index()
        {
            var model =  new HomeIndexViewModel(3);
            return View(model);
        }



        public ActionResult Details(long id)
        {
            return View(db.JobPostings.Where(m => m.JobPostingID == id).FirstOrDefault());
        }
    }
}
