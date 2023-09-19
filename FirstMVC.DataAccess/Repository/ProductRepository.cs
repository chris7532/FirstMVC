using FirstMVC.DataAccess.Data;
using FirstMVC.DataAccess.Repository.IRepository;
using FirstMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            
        }
        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.ISBN = product.ISBN;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.Price100 = product.Price100;
                objFromDb.Author = product.Author;
                objFromDb.Description = product.Description;
                objFromDb.CategoryID = product.CategoryID;
                if(objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
            }

            

        }
    }
}
