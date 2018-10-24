using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.DAL
{
    // no update or save
    interface IGroceryRepository// : IDisposable
    {
        
        IEnumerable<Grocery> GetGroceries();
        Grocery FindGrocery(int id);

        void AddGrocery(Grocery grocery);
        void SaveGrocery();

        void DeleteGrocery(Grocery grocery);

        IEnumerable<int> SelectQuantity();
    }
}
