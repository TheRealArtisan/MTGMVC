using MTG.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTG.Models
{
    public class DeckDetailsModel
    {
        public int ID { get; set; }
        [Display(Name = "Deck Name")]
        [StringLength(100, ErrorMessage = "Text must be under 100 characters.")]
        public string DeckName { get; set; }
        [Display(Name = "Format")]
        [Required(ErrorMessage = "Please select a format.")]
        public Format Format { get; set; }
        [Display(Name = "Deck Description")]
        [StringLength(100, ErrorMessage = "Text must be under 100 characters.")]
        public string DeckDescription { get; set; }
        
        public List<CardItem> CardItems { get; set; }
    }

    public class CardItem
    {
        public int ID { get; set; }
        public string CardID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}