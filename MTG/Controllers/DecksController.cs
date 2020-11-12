using MTG.Data;
using MTG.Data.Models;
using MTG.DataManagement;
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
        
        public ActionResult CreateDeck(DeckModel model, string search, string next, string prev, string save)
        {
            if (!string.IsNullOrWhiteSpace(next))
            {
                model = Session["DeckModel"] as DeckModel;

                if (model.SearchModel.Data.HasMore.HasValue)
                {
                    if (model.SearchModel.Data.HasMore.Value)
                    {
                        if (model.SearchModel.Page <= 1)
                        {
                            model.SearchModel.Page = 1;
                        }
                        model.SearchModel.Page++;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(prev))
            {
                model = Session["DeckModel"] as DeckModel;

                if (model.SearchModel.Page <= 1)
                {
                    model.SearchModel.Page = 1;
                }

                model.SearchModel.Page--;
            }

            SearchModel searchModel = model.SearchModel;
            
            if (!string.IsNullOrWhiteSpace(search))
            {

            }
            if (!string.IsNullOrWhiteSpace(save))
            {
                List<CardItem> cardItems = new List<CardItem>()
                {
                    new CardItem()
                    {
                         CardID = "00001234",
                          Quantity = 4
                    },
                    new CardItem()
                    {
                         CardID = "00009876",
                          Quantity = 4
                    }
                };
                DataManager.CreateDeck(model.DeckDetails.DeckName, model.DeckDetails.DeckDescription, cardItems);
            }

            Validate(ref searchModel);

            searchModel.Search();

            Session["DeckModel"] = model;

            SetImages(searchModel.Data);

            return View("Edit", model);
        }
        
        public ActionResult EditDeck(int id)
        {
            return View("Edit");
        }

        //public ActionResult CardPartial(DeckModel model, string search, string next, string prev, string save)
        //{
        //    SearchModel searchModel = model.SearchModel;

        //    if (!string.IsNullOrWhiteSpace(next))
        //    {
        //        model = Session["DeckModel"] as DeckModel;
        //        searchModel.Page++;
        //    }
        //    if (!string.IsNullOrWhiteSpace(prev))
        //    {
        //        model = Session["DeckModel"] as DeckModel;
        //        searchModel.Page--;
        //    }
        //    if (!string.IsNullOrWhiteSpace(search))
        //    {

        //    }
        //    if (!string.IsNullOrWhiteSpace(save))
        //    {
        //        List<CardItem> cardItems = new List<CardItem>()
        //        {
        //            new CardItem()
        //            {
        //                 CardID = "00001234",
        //                  Quantity = 4
        //            },
        //            new CardItem()
        //            {
        //                 CardID = "00009876",
        //                  Quantity = 4
        //            }
        //        };
        //        DataManager.CreateDeck(model.DeckDetails.DeckName, model.DeckDetails.DeckDescription, cardItems);
        //    }

        //    Validate(ref searchModel);

        //    searchModel.Search();

        //    Session["DeckModel"] = model;

        //    SetImages(searchModel.Data);

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
                    images.Add(card.OracleId, new Tuple<string, string>(client.GetImageFromCard(card), card.ScryfallUri));
                }
            }
            ViewBag.CardImages = images;
        }
    }
}