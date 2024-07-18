using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleStore.Server.Data;
using PeopleStore.Server.Models;

namespace PeopleStore.Server.Services
{
    public class ProductsService
    {
        private readonly ApplicationDbContext _context;
        public ProductsService(ApplicationDbContext productDbContext) 
        { 
            _context = productDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return [.. _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)];
        }

        public Product? GetProduct(long id)
        {
            return _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(ActionResult<Product> product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
