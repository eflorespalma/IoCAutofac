using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class InitController : Controller
    {
        readonly IService service;

        public InitController(IService _service)
        {
            service = _service;
        }

        public ActionResult Index()
        {
            ViewBag.Title = service.RetornarCadena();
            return View();
        }
    }
}
