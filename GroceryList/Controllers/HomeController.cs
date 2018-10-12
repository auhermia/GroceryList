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
            // load list of markets
            var viewmodel = new GroceryViewModel();
            viewmodel.MarketList = db.Markets.ToList()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.MarketName
                });
            return View(viewmodel);
            
        }

        public ActionResult SaveRecord(GroceryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Grocery grocery = new Grocery
                {
                    MarketId = viewModel.Grocery.MarketId,
                    Quantity = viewModel.Grocery.Quantity,
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
            // populating list of items
            List<GroceryViewModel> groceryList = new List<GroceryViewModel>();

            var query = (from g in db.Groceries
                         join m in db.Markets
                         on g.MarketId equals m.Id
                         select new
                         {
                             g.Id,
                             g.Item,
                             g.Quantity,
                             m.MarketName
                         }).ToList();

            foreach (var item in query)
            {
                GroceryViewModel gvm = new GroceryViewModel();
                gvm.MarketName = item.MarketName;
                gvm.Id = item.Id;
                gvm.Item = item.Item;
                gvm.Quantity = item.Quantity;
                
                groceryList.Add(gvm);
            }

            // calculating quantity


            return PartialView("_Groceries", groceryList);
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