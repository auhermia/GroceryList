using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.DAL
{
    interface IGroceryRepository// : IDisposable
    {
        IEnumerable<Grocery> GetGroceries();
        IEnumerable<Market> GetMarkets();
        IEnumerable<GroceryCategory> GetGroceryCategories();
        Grocery FindGrocery(int id);
        void AddGrocery(Grocery grocery);
        void SaveGrocery();
        void DeleteGrocery(Grocery grocery);
        IEnumerable<int> SelectQuantity();
    }

    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        //TEntity Find(int id);
        ////TEntity Find2(Expression<Func<TEntity, bool>> predicate); //enable linq usage
        //void Add(TEntity entity);
        //void Save();
        //void Delete(TEntity entity);
        ////IEnumerable<int> SelectQuantity(Expression<Func<TEntity, bool>> predicate);
        //IEnumerable<TEntity> SelectQuantity(Expression<Func<TEntity, bool>> predicate);
    }
}
