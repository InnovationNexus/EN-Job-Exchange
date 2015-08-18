using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENJobExchange.Controllers
{
    public class ReferralWithNotesController : Controller
    {
        public ActionResult Index()
        {
            return View(new ENJobExchange.DAL.Referral());
        }
    }
}
