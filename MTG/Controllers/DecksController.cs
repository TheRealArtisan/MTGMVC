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
                    //DataManager.CreateDeck(model.DeckDetails.DeckName, model.DeckDetails.DeckDescription, deckDetailsModel.CardItems);
                }
                else if (id >= 0)
                {

                }
            }

            var temp = Session["CardItems"] as List<CardItem>;
            deckDetailsModel.CardItems = temp;

            searchModel.Search();

            Session["SearchModel"] = searchModel;
            Session["DeckDetailsModel"] = deckDetailsModel;
            Session["CardItems"] = deckDetailsModel.CardItems;

            model.DeckDetails = deckDetailsModel;
            model.SearchModel = searchModel;

            SetImages(searchModel.Data);

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult AddToDeck(string add)
        {
            List<CardItem> cards = Session["CardItems"] as List<CardItem>;

            if (cards == null)
            {
                cards = new List<CardItem>();
            }

            CardItem temp = cards.FirstOrDefault(x => x.CardID == add);
            if (temp == null)
            {
                MTGClient client = new MTGClient();

                Card card = client.GetCard(add);

                cards.Add(new CardItem() { CardID = card.Id, Name = card.Name, Quantity = 1 });
            }
            else
            {
                temp.Quantity++;
            }

            Session["CardItems"] = cards;

            return RedirectToAction("Edit");
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
            Dictionary<string, ImageItem> images = new Dictionary<string, ImageItem>();

            if (data != null)
            {
                foreach (var card in data.Data)
                {
                    MTGClient client = new MTGClient();
                    images.Add(card.Id, new ImageItem(card.Id, card.Name, client.GetImageFromCard(card)));
                }
            }
            ViewBag.CardImages = images;
        }
    }

    public class ImageItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }

        public ImageItem(string id, string name, string image)
        {
            Id = id;
            Name = name;
            ImageUri = image;
        }
    }
}