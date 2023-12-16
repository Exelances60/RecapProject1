using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecapProject1.Entities;

namespace RecapProject1
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Products.ToList();
            }
        }
        public List<Product> GetByCategory(int Id)
        {

            using (NorthWindContext context = new NorthWindContext())
            {
                return  context.Products.Where(p => p.CategoryID == Id).ToList();
            }
        }

        public List<Product> GetByName(string name,int categoryId)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                if (categoryId == 0)
                {
                    return context.Products.Where(p => p.ProductName.Contains(name)).ToList();

                }
                else
                {
                    return context.Products.Where(p => p.ProductName.Contains(name) && p.CategoryID == categoryId).ToList();

                }


            }
        }

    }
}
