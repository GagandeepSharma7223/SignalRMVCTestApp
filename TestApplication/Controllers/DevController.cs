using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestApplication.Data;
using TestApplication.Service;
using TestApplication.Service.Models;

namespace TestApplication.Controllers
{
    public class DevController : Controller
    {
        private IDevService service;
        public DevController(IDevService _service)
        {
            service = _service;
        }
        // GET: /Dev/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var model = service.GetData();
            return PartialView("_PartialList", model);
        }

        // GET: /Dev/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Dev/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestAppModel model)
        {
            if (ModelState.IsValid)
            {
                service.Save(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Dev/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var devtest = service.Get(id);
            if (devtest == null)
            {
                return HttpNotFound();
            }
            return View(devtest);
        }

        // POST: /Dev/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestAppModel model)
        {
            if (ModelState.IsValid)
            {
                service.Save(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Dev/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var devtest = service.Get((int)id);
            if (devtest == null)
            {
                return HttpNotFound();
            }
            return View(devtest);
        }

        // POST: /Dev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
