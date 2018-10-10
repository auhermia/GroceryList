using GroceryList.Context;
using GroceryList.Models;
using GroceryList.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GroceryList.Controllers
{
    public class HomeController : Controller
    {
        GroceryContext db = new GroceryContext();

        public ActionResult Index()
        {
            //var viewmodel = new GroceryViewModel();
            //viewmodel.Markets = db.Markets.ToList()
            //    .Select(x => new SelectListItem
            //    {
            //        Value = x.MarketId,
            //        Text = x.Market
            //    });
            //return View(viewmodel);
            //var markets = db.Markets.ToList();

            return View();
        }

        public ActionResult SaveRecord(GroceryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Grocery grocery = new Grocery
                {
                    Store = viewModel.Grocery.Store,
                    Item = viewModel.Grocery.Item
                };

                db.Groceries.Add(grocery);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public PartialViewResult LoadGroceryList()
        {
            return PartialView("_Groceries", db.Groceries.ToList());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var removeItem = db.Groceries.Find(Id);
            db.Groceries.Remove(removeItem);
            db.SaveChanges();
            
            // const
            return RedirectToAction("Index");

        }

    }
}