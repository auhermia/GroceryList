//using GroceryList.Context;
//using GroceryList.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace GroceryList.DAL
//{
//    public class GroceryRepository
//    {
//        // TO DO!!!!!!!!

//        private GroceryContext _context;

//        public GroceryRepository(GroceryContext context)
//        {
//            _context = context;
//        }

//        // Find

//        //public IEnumerable<Grocery> Get()
//        //{
//        //    return _context.Groceries.ToList();
//        //}

//        //public IEnumerable<Market> GetMarkets()
//        //{
//        //    return _context.Markets.ToList();
//        //}

//        //public IEnumerable<GroceryCategory> GetGroceryCategories()
//        //{
//        //    return _context.GroceryCategories.ToList();
//        //}

//        //public Grocery FindGrocery(int Id)
//        //{
//        //    return _context.Groceries.Find(Id);
//        //}


//        // Create/Update

//        public void AddGrocery(Grocery grocery)
//        {
//            _context.Groceries.Add(grocery);
//        }

//        public void SaveGrocery()
//        {
//            _context.SaveChanges();
//        }

//        // Delete
//        public void DeleteGrocery(Grocery grocery)
//        {
//            _context.Groceries.Remove(grocery);
//        }

//        // select single column
//        public IEnumerable<int> SelectQuantity()
//        {
//            return _context.Groceries.Select(x => x.Quantity).ToList();
//        }
//    }
//}