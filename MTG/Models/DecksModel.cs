using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTG.Models
{
    public class DecksModel
    {
        public List<DeckItemModel> Decks { get; set; }
    }

    public class DeckItemModel
    {
        public int DeckId { get; set; }
        public string DeckName { get; set; }
    }
}