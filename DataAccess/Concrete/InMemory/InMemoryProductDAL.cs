using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryProductDAL : IProductDAL
    {
        List<Product> _products;

        public InMemoryProductDAL()
        {
            _products = new List<Product>
            {
                new Product{ProductID = 1, CategoryID = 1, ProductName = "Bardak", UnitsInStock = 15, UnitPrice = 2 },
                new Product{ProductID = 1, CategoryID = 1, ProductName = "Mouse", UnitsInStock = 8, UnitPrice = 250 },
                new Product{ProductID = 1, CategoryID = 1, ProductName = "Klavye", UnitsInStock = 1, UnitPrice = 150 },
                new Product{ProductID = 1, CategoryID = 1, ProductName = "Kasa", UnitsInStock = 12, UnitPrice = 450 }
            };
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(x => x.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategoryID(int CategoryID)
        {
            return _products.Where(x => x.CategoryID == CategoryID).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
