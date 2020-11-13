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
        
        public ActionResult EditDeck(DeckModel model, int id, string search, string next, string prev, string save)
        {
            SearchModel searchModel = model.SearchModel;
            DeckDetailsModel deckDetailsModel = model.DeckDetails;

            Validate(ref searchModel);
            Validate(ref deckDetailsModel);

            if (id == 0)
            {
                deckDetailsModel.CardItems = Session["CardItems"] as List<CardItem>;
            }
            else
            {
                //deckDetailsModel.CardItems;
            }

            if (!string.IsNullOrWhiteSpace(next))
            {
                searchModel = Session["SearchModel"] as SearchModel;

                if (searchModel.Data.HasMore.HasValue)
                {
                    if (searchModel.Data.HasMore.Value)
                    {
                        if (searchModel.Page <= 1)
                        {
                            searchModel.Page = 1;
                        }
                        searchModel.Page++;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(prev))
            {
                searchModel = Session["SearchModel"] as SearchModel;

                if (searchModel.Page <= 1)
                {
                    searchModel.Page = 1;
                }

                searchModel.Page--;
            }
            if (!string.IsNullOrWhiteSpace(search))
            {

            }
            if (!string.IsNullOrWhiteSpace(save))
            {
                if (id == 0)
                {
                    DataManager.CreateDeck(model.DeckDetails.DeckName, model.DeckDetails.DeckDescription, deckDetailsModel.CardItems);
                }
                else if (id >= 0)
                {

                }
            }
            
            searchModel.Search();

            Session["SearchModel"] = searchModel;
            Session["DeckDetailsModel"] = deckDetailsModel;
            Session["CardItems"] = deckDetailsModel.CardItems;

            SetImages(searchModel.Data);

            return View("Edit", model);
        }
        
        //public ActionResult EditDeck(int id)
        //{
        //    if (id == 0)
        //    {
        //        RedirectToAction("CreateDeck");
        //    }
        //    return View("Edit");
        //}

        [HttpPost]
        public ActionResult AddToDeck(int id, string card)
        {
            if (id == 0)
            {

            }
            string cardid = card;
            return View();
        }
        
        public SearchModel Validate(ref SearchModel model)
        {
            if (SearchModel.IsEmpty(model))
            {
                model = Session["SearchModel"] as SearchModel;
                if (SearchModel.IsEmpty(model))
                {
                    model = new SearchModel() { Format = Format.Standard };
                }
            }

            return model;
        }

        public DeckDetailsModel Validate(ref DeckDetailsModel model)
        {
            if (DeckDetailsModel.IsEmpty(model))
            {
                model = Session["DeckDetailsModel"] as DeckDetailsModel;
                if (DeckDetailsModel.IsEmpty(model))
                {
                    model = new DeckDetailsModel();
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