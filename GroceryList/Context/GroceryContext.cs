using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GroceryList.Models;
using GroceryList.ViewModel;

namespace GroceryList.Context
{
    public class GroceryContext : DbContext
    {
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<GroceryCategory> GroceryCategories { get; set; }


    }

}