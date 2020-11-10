using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTG.Controllers
{
    public class CardsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}