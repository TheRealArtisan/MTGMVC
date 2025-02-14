﻿using MTG.Data;
using MTG.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTG.Models
{
    public class SearchModel
    {
        [Display(Name = "Card Name")]
        [StringLength(100, ErrorMessage = "Text must be under 100 characters.")]
        public string CardName { get; set; }
        [Display(Name = "Card Text")]
        [StringLength(100, ErrorMessage = "Text must be under 100 characters.")]
        public string CardText { get; set; }
        [Display(Name = "Format")]
        [Required(ErrorMessage = "Please select a format you want to search.")]
        public Format? Format { get; set; }
        [Display(Name = "Colours")]
        public Dictionary<Colours, bool> Colours { get; set; }

        public int Page { get; set; } = 1;

        public Search Data { get; set; }
        
        public Search Search()
        {
            MTGClient client = new MTGClient();

            List<string> querys = new List<string>();

            querys.Add($"f:{Format}");
            if (!string.IsNullOrWhiteSpace(CardName))
            {
                querys.Add(CardName);
            }
            if (!string.IsNullOrWhiteSpace(CardText))
            {
                querys.Add($"o:'{CardText}'");
            }

            string q = string.Join(" ", querys);

            Data = client.SearchCards(q, Page);

            return Data;
        }
        
        public static bool IsEmpty(SearchModel model)
        {
            try
            {
                if (model == null)
                {
                    return true;
                }
                if (string.IsNullOrWhiteSpace(model.CardName) &&
                string.IsNullOrWhiteSpace(model.CardText) &&
                !model.Format.HasValue &&
                (model.Colours == null || model.Colours.Count == 0))
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
}