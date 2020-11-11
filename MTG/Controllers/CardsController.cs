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
            Validate(ref model);

            return View(model);
        }

        public ActionResult CardPartial(SearchModel model, string search, string next, string prev)
        {
            if (!string.IsNullOrWhiteSpace(next))
            {
                model = Session["SearchModel"] as SearchModel;
                model.Page++;
            }
            if (!string.IsNullOrWhiteSpace(prev))
            {
                model = Session["SearchModel"] as SearchModel;
                model.Page--;
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                
            }

            Validate(ref model);

            model.Search();

            Session["SearchModel"] = model;

            SetImages(model.Data);

            return PartialView("CardPartial", model);
        }
        //public ActionResult CardPartialNext()
        //{
        //    SearchModel model = null;
        //    Validate(ref model);

        //    model.NextPage();

        //    Session["SearchModel"] = model;

        //    SetImages(model.Data);

        //    return PartialView("CardPartial", model);
        //}

        //public ActionResult CardPartialPrevious()
        //{
        //    SearchModel model = null;
        //    Validate(ref model);

        //    model.PreviousPage();

        //    Session["SearchModel"] = model;

        //    SetImages(model.Data);

        //    return PartialView("CardPartial", model);
        //}

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
            Dictionary<string, string> images = new Dictionary<string, string>();

            if (data != null)
            {
                foreach (var card in data.Data)
                {
                    MTGClient client = new MTGClient();
                    images.Add(card.OracleId, client.GetImageFromCard(card));
                }
            }

            ViewBag.CardImages = images;
        }
    }
}