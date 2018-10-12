using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryList.Models
{
    public class Grocery
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a store")]
        public int MarketId { get; set; }

        [Required(ErrorMessage = "Please enter an item")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a quantity")]
        public int Quantity { get; set; }
                
    }


}