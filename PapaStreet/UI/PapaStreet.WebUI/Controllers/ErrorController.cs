using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapaStreet.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [Route("error")]
        public ActionResult Index()
        {
            return View();
        }
    }
}