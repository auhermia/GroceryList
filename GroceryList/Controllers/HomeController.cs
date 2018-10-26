#region using 
using GroceryList.Context;
using GroceryList.Models;
using GroceryList.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryList.DAL;
using System.Data.Entity;

#endregion

namespace GroceryList.Controllers
{
    public class HomeController : Controller
    {
        private GroceryRepository groceryRepository;
        
        public HomeController()
        {
            groceryRepository = new GroceryRepository(new GroceryContext());
        }

        /* -------------------- Main -------------------- */

        public ActionResult Index()
        {
            // load list of markets and grocery categories to dropdowns
            GroceryViewModel gvm = new GroceryViewModel();


            gvm.MarketList = groceryRepository.GetMarkets()
                .OrderBy(x => x.MarketName)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.MarketName
                });

            gvm.CategoryList = groceryRepository.GetGroceryCategories()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Category
                });
            return View(gvm);
        }

        /* -------------------- Save -------------------- */

        public ActionResult SaveRecord(GroceryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Grocery grocery = new Grocery
                {
                    MarketId = viewModel.Grocery.MarketId,
                    CategoryId = viewModel.Grocery.CategoryId,
                    Item = viewModel.Grocery.Item,
                    Quantity = viewModel.Grocery.Quantity,
                };

                groceryRepository.AddGrocery(grocery);
                groceryRepository.SaveGrocery();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        /* -------------------- Populate list of items -------------------- */

        public PartialViewResult LoadGroceryList()
        {
            List<GroceryViewModel> groceryList = new List<GroceryViewModel>();

            // get data from db, query desired data, send to viewmodel
            var groceries = groceryRepository.GetGroceries();
            var markets = groceryRepository.GetMarkets();
            var categories = groceryRepository.GetGroceryCategories();

            var query = (from g in groceries
                         join m in markets
                         on g.MarketId equals m.Id
                         join c in categories
                         on g.CategoryId equals c.Id
                         select new
                         {
                             g.Id,
                             g.Item,
                             g.Quantity,
                             m.MarketName,
                             c.Category
                         }).ToList();

            // loop through each record in db and store in vm
            foreach (var item in query)
            {
                GroceryViewModel gvm = new GroceryViewModel();
                gvm.MarketName = item.MarketName;
                gvm.Category = item.Category;
                gvm.Id = item.Id;
                gvm.Item = item.Item;
                gvm.Quantity = item.Quantity;
                groceryList.Add(gvm);
            }

            return PartialView("_Groceries", groceryList);
        }

        public JsonResult GetTotal()
        {
            var quantities = groceryRepository.SelectQuantity();

            int totalCount = quantities.Sum(x => x);

            return Json(totalCount, JsonRequestBehavior.AllowGet);
        }

        /* -------------------- DELETE -------------------- */

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var removeItem = groceryRepository.FindGrocery(Id);
            groceryRepository.DeleteGrocery(removeItem);
            groceryRepository.SaveGrocery();

            return RedirectToAction("Index");
        }
    }
}

/* 10/26 TODO
 * 
 *  - db.Market & db.GroceryCategories - x
 *  - db references in linq queries - x
 *  - generics - for repository
 *  - Service Layer
 *  - Unit of work
 */

/* OLD CODE

        GroceryContext db = new GroceryContext();
            //var query = (from g in db.Groceries
    //             select new { g.Quantity }
    //             ).ToList();

    // var quantities = db.Groceries.Select(x => x.Quantity).ToList();

    */
