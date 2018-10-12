using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryList.ViewModel
{
    public class GroceryViewModel
    {
        public IEnumerable<SelectListItem> MarketList { get; set; }

        public int Id { get; set; }
        public string Item { get; set; }
        public string MarketName { get; set; }
        public int Quantity { get; set; }

        public Grocery Grocery { get; set; }
        public Market Market { get; set; }
    }
}