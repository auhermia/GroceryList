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
        public IEnumerable<SelectListItem> Markets { get; set; }


        public Grocery Grocery { get; set; }
    }
}