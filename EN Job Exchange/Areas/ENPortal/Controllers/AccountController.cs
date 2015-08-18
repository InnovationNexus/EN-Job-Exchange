using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENJobExchange.DAL;

namespace ENJobExchange.Areas.ENPortal.Controllers
{
    public class AccountController : Controller
    {

        Entities db = new Entities();
        private Repository _rep = new Repository();

        //
        // GET: /ENAccount/

        public ActionResult Index()
        {
            var model = _rep.GetENAcctsByID(3);
            return View(model);
        }

        //
        // GET: /ENAccount/Details/5

        public ActionResult Details(int id)
        {
            var model = _rep.GetENAcctsByUser(id);
            return View(model);
        }

        //
        // GET: /ENAccount/Create

        public ActionResult Create()
        {
            var model = new Account_EN();
            return View(model);
        }

        //
        // POST: /ENAccount/Create

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

        //
        // GET: /ENAccount/Edit/5

        public ActionResult Edit(int id)
        {
            var model = _rep.GetENAcctsByUser(id);
            return View(model);
        }

        //
        // POST: /ENAccount/Edit/5

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

        //
        // GET: /ENAccount/Delete/5

        public ActionResult Delete(int id)
        {
            var model = _rep.GetENAcctsByUser(id);
            return View(model);
        }

        //
        // POST: /ENAccount/Delete/5

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
    }
}
