using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryList.Models
{
    public class Market
    {
        [Key]
        public int Id { get; set; }
        public string MarketName { get; set; }
    }
}