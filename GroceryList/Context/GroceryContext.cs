using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GroceryList.Models;

namespace GroceryList.Context
{
    public class GroceryContext : DbContext
    {
        public DbSet<Grocery> Groceries { get; set; }
    }
}