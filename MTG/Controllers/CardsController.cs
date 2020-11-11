using MTG.Data;
using MTG.Data.Models;
using MTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTG.Controllers
{
    public class CardsController : Controller
    {
        public ActionResult Index(SearchModel model)
        {
            if (SearchModel.IsEmpty(model))
            {
                model = ViewBag.SearchModel;
                if (SearchModel.IsEmpty(model))
                {
                    model = new SearchModel() { Format = Format.Standard };
                }
            }

            ViewBag.SearchModel = model;

            ViewBag.SearchModel = model;

            return View(model);
        }

        public ActionResult CardPartial(SearchModel model)
        {
            if (SearchModel.IsEmpty(model))
            {
                model = ViewBag.SearchModel;
                if (SearchModel.IsEmpty(model))
                {
                    model = new SearchModel() { Format = Format.Standard };
                }
            }

            ViewBag.SearchModel = model;

            MTGClient client = new MTGClient();

            List<string> querys = new List<string>();

            querys.Add($"f:{model.Format}");
            if (!string.IsNullOrWhiteSpace(model.CardName))
            {
                querys.Add(model.CardName);
            }
            if (!string.IsNullOrWhiteSpace(model.CardText))
            {
                querys.Add($"o:'{model.CardText}'");
            }

            string q = string.Join(" ", querys);

            Search data = client.SearchCards(q);

            Dictionary<string, string> images = new Dictionary<string, string>();

            if (data != null)
            {
                foreach (var card in data.Data)
                {
                    images.Add(card.OracleId, client.GetImageFromCard(card));
                }
            }

            ViewBag.CardImages = images;

            return PartialView("CardPartial");
        }
    }
}