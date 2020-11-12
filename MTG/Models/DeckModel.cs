using MTG.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTG.Models
{
    public class DeckModel
    {
        public DeckDetailsModel DeckDetails { get; set; }

        public SearchModel SearchModel { get; set; }
    }
}