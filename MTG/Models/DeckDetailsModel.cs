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
        public int ID { get; set; } = 0;
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

        internal static bool IsEmpty(DeckDetailsModel model)
        {
            try
            {
                if (model == null)
                {
                    return true;
                }
                if (string.IsNullOrWhiteSpace(model.DeckName) &&
                string.IsNullOrWhiteSpace(model.DeckDescription) &&
                (model.CardItems == null || model.CardItems.Count == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return true;
            }
        }
    }

    public class CardItem
    {
        public int ID { get; set; }
        public string CardID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}