using MTG.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTG.Models
{
    public class SearchModel
    {
        [Display(Name = "Card Name")]
        [StringLength(100)]
        public string CardName { get; set; }
        [Display(Name = "Card Text")]
        [StringLength(100)]
        public string CardText { get; set; }
        [Display(Name = "Format")]
        [Required(ErrorMessage = "Please provide a format you want to search.")]
        public Format Format { get; set; }
        [Display(Name = "Colours")]
        public List<Colours> Colours { get; set; }
    }
}