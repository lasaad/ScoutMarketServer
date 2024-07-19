using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutMarket.Repository.Repository
{
    public class ProductRepository(ApplicationDbContext db) : IProductRepository 
    {
        public int GetData()
        {
                 return db.Product.Count();
           
        }
    }
}
