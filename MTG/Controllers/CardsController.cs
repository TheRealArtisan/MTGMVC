using MTG.Data;
using MTG.Data.Models;
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
            MTGClient client = new MTGClient();

            Search data = client.SearchCards("f:pioneer");

            Dictionary<string, string> images = new Dictionary<string, string>();

            foreach (var card in data.Data)
            {
                images.Add(card.OracleId, client.GetImageFromCard(card));
            }

            ViewBag.CardImages = images;

            return View();
        }
        
    }
}