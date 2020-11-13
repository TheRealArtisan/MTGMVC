using MTG.Data;
using MTG.Data.Models;
using MTG.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MTG.Controllers
{
    public class CardsController : Controller
    {
        public ActionResult Index(SearchModel model, string search, string next, string prev)
        {
            if (!string.IsNullOrWhiteSpace(next))
            {
                model = Session["SearchModel"] as SearchModel;
                
                if (model.Data.HasMore.HasValue)
                {
                    if (model.Data.HasMore.Value)
                    {
                        if (model.Page <= 1)
                        {
                            model.Page = 1;
                        }
                        model.Page++;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(prev))
            {
                model = Session["SearchModel"] as SearchModel;

                if (model.Page <= 1)
                {
                    model.Page = 1;
                }

                model.Page--;
            }
            if (!string.IsNullOrWhiteSpace(search))
            {

            }

            Validate(ref model);

            model.Search();

            Session["SearchModel"] = model;

            SetImages(model.Data);

            return View(model);
        }

        //public ActionResult CardPartial(SearchModel model, string search, string next, string prev)
        //{
        //    if (!string.IsNullOrWhiteSpace(next))
        //    {
        //        model = Session["SearchModel"] as SearchModel;
        //        model.Page++;
        //    }
        //    if (!string.IsNullOrWhiteSpace(prev))
        //    {
        //        model = Session["SearchModel"] as SearchModel;
        //        model.Page--;
        //    }
        //    if (!string.IsNullOrWhiteSpace(search))
        //    {
                
        //    }

        //    Validate(ref model);

        //    model.Search();

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
            Dictionary<string, Tuple<string, string>> images = new Dictionary<string, Tuple<string, string>>();

            if (data != null)
            {
                foreach (var card in data.Data)
                {
                    MTGClient client = new MTGClient();
                    images.Add(card.Id, new Tuple<string, string>(client.GetImageFromCard(card), card.ScryfallUri));
                }
            }
            ViewBag.CardImages = images;
        }
    }
}