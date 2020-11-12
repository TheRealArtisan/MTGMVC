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
    public class DecksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(DeckModel model)
        {
            
            return View(model);
        }

        public ActionResult CardPartial(DeckModel model, string search, string next, string prev)
        {
            SearchModel searchModel = model.SearchModel;

            if (!string.IsNullOrWhiteSpace(next))
            {
                model = Session["DeckModel"] as DeckModel;
                searchModel.Page++;
            }
            if (!string.IsNullOrWhiteSpace(prev))
            {
                model = Session["DeckModel"] as DeckModel;
                searchModel.Page--;
            }
            if (!string.IsNullOrWhiteSpace(search))
            {

            }
            
            Validate(ref searchModel);

            searchModel.Search();

            Session["DeckModel"] = model;

            SetImages(searchModel.Data);

            return PartialView("CardPartial", model);
        }

        public SearchModel Validate(ref SearchModel model)
        {
            if (SearchModel.IsEmpty(model))
            {
                model = Session["SearchModel"] as SearchModel;
                if (SearchModel.IsEmpty(model))
                {
                    model = new SearchModel() { Format = Format.Standard, };
                }
            }

            return model;
        }

        public void SetImages(Search data)
        {
            Dictionary<string, Tuple<string, string>> images = new Dictionary<string, Tuple<string, string>>();

            if (data != null)
            {
                foreach (var card in data.Data)
                {
                    MTGClient client = new MTGClient();
                    images.Add(card.OracleId, new Tuple<string, string>(client.GetImageFromCard(card), card.ScryfallUri));
                }
            }
            ViewBag.CardImages = images;
        }
    }
}