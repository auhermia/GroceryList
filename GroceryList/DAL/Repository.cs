using GroceryList.Context;
using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GroceryList.DAL
{
    public class GroceryRepository : IGroceryRepository //, IDisposable
    {
        private GroceryContext _context;

        public GroceryRepository(GroceryContext context)
        {
            _context = context;
        }

        // Find

        public IEnumerable<Grocery> GetGroceries()
        {
            return _context.Groceries.ToList();
        }

        public IEnumerable<Market> GetMarkets()
        {
            return _context.Markets.ToList();
        }

        public IEnumerable<GroceryCategory> GetGroceryCategories()
        {
            return _context.GroceryCategories.ToList();
        }

        public Grocery FindGrocery(int Id)
        {
            return _context.Groceries.Find(Id);
        }


        // Create/Update

        public void AddGrocery(Grocery grocery)
        {
            _context.Groceries.Add(grocery);
        }

        public void SaveGrocery()
        {
            _context.SaveChanges();
        }

        // Delete
        public void DeleteGrocery(Grocery grocery)
        {
            _context.Groceries.Remove(grocery);
        }

        // select single column
        public IEnumerable<int> SelectQuantity()
        {
            return _context.Groceries.Select(x => x.Quantity).ToList();
        }
    }

/*
 * 
 * GENERIC - TODO
 * 
 */
 
//public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//{
//    protected readonly DbContext _context;

//    public Repository(DbContext context)
//    {
//        _context = context;
//    }

//    // GET - only operation used by all entities
//    public IEnumerable<TEntity> Get()
//    {
//        return _context.Set<TEntity>().ToList();
//    }

    //public TEntity Find(int id)
    //{
    //    return _context.Set<TEntity>().Find(id);
    //}

    //public void Add(TEntity entity)
    //{
    //     _context.Set<TEntity>().Add(entity);
    //}

    //public void Save()
    //{
    //    _context.SaveChanges();
    //}

    //public void Delete(TEntity entity)
    //{
    //    _context.Set<TEntity>().Remove(entity);
    //}

    //public IEnumerable<TEntity> SelectQuantity(Expression<Func<TEntity, bool>> predicate)
    //{
    //    // wtf
    //    return _context.Set<TEntity>().Where(predicate).ToList();
    //}
//}
}
 