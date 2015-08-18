using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENJobExchange.DAL;
using ENJobExchange.Areas.PartnerPortal.ViewModels;

namespace ENJobExchange.Areas.PartnerPortal.Controllers
{
    public class HomeController : Controller
    {
        #region "Index"
        //
        // GET: /PartnerPortal/Home/

        Entities db = new Entities();

        public ActionResult Index(string searchString, int SelectedStatusID = 0)
        {
            var model = new HomeIndexViewModel(3, searchString, SelectedStatusID);
            return View(model);
        }
        #endregion
    }
}
