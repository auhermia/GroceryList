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

#endregion

namespace GroceryList.Controllers
{
    public class HomeController : Controller
    {
        // leave for now, for db.Markets and db.GroceryCategories
        GroceryContext db = new GroceryContext();

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

            // db -- KEEP FOR NOW BECAUSE reference to other tables
            gvm.MarketList = db.Markets.ToList()
                .OrderBy(x => x.MarketName)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.MarketName
                });

            gvm.CategoryList = db.GroceryCategories.ToList()
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

            // get data from db
            var query = (from g in db.Groceries
                         join m in db.Markets
                         on g.MarketId equals m.Id
                         join c in db.GroceryCategories
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

            //var query = (from g in db.Groceries
            //             select new { g.Quantity }
            //             ).ToList();

            // var quantities = db.Groceries.Select(x => x.Quantity).ToList();

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