﻿using RecapProject1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapProject1
{
    public class CategoriesDal
    {
        public List<Category> GetAllCategory()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var categories = context.Categories.ToList();
                categories.Insert(0, new Category { CategoryName = "Select", CategoryID = 0 });

                return categories;
            }
        }
    
    }
}
