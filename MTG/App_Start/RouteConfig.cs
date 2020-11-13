using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MTG
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Create Deck",
            //    url: "Decks/Edit",
            //    defaults: new { controller = "Decks", action = "CreateDeck" }
            //);

            routes.MapRoute(
                name: "Create Deck",
                url: "Decks/Edit",
                defaults: new { controller = "Decks", action = "EditDeck", id = 0 }
            );

            routes.MapRoute(
                name: "Edit Deck",
                url: "Decks/Edit/{id}",
                defaults: new { controller = "Decks", action = "EditDeck" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
