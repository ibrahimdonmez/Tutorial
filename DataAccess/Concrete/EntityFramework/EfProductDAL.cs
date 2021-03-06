﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDAL : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDAL
    {
        public List<ProductDetailDTO> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                                on p.CategoryID equals c.CategoryID
                             select new ProductDetailDTO { ProductId = p.ProductID, ProductName = p.ProductName, UnitsInStock = p.UnitsInStock, CategoryName = c.CategoryName };
                return result.ToList();
            }
        }
    }
}
