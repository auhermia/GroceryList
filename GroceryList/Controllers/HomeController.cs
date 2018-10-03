﻿using GroceryList.Context;
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
        GroceryContext db = new GroceryContext();

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult SaveRecord(Grocery model)
        {
            if (ModelState.IsValid)
            {
                Grocery grocery = new Grocery();
                grocery.Store = model.Store;
                grocery.Item = model.Item;

                db.Groceries.Add(grocery);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                // TODO - WHAT DO
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
            //return RedirectToAction("LoadGroceryList");
            return RedirectToAction("Index");
        }

    }
}