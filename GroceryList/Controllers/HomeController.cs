using GroceryList.Context;
using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult SaveRecord(Grocery model)
        {
            if (ModelState.IsValid)
            {
                GroceryContext db = new GroceryContext();

                Grocery grocery = new Grocery();
                grocery.Store = model.Store;
                grocery.Item = model.Item;

                db.Groceries.Add(grocery);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}