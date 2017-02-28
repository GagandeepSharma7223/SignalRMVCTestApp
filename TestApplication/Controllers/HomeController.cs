using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Service;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        private IDevService service;
        public HomeController(IDevService _service)
        {
            service = _service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var model = service.GetList();
            return PartialView("_PartialList", model);
        }

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
    }
}