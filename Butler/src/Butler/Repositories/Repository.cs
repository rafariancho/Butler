using Butler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Butler.Models;
using Microsoft.EntityFrameworkCore;

namespace Butler.Repositories
{
    public class Repository : IRepository
    {
        private ButlerContext _context;
        public Repository(ButlerContext context)
        {
            _context = context;
        }

        public void AddDish(Dish dish)
        {
            _context.Dishes.Add(dish);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteDish(int dishId)
        {
            Dish dish = _context.Dishes.SingleOrDefault(x => x.Id == dishId);
            _context.Dishes.Remove(dish);
        }

        public void DeleteIngredient(int ingredientId)
        {
            Ingredient ingredient = _context.Ingredients.SingleOrDefault(x => x.Id == ingredientId);
            _context.Ingredients.Remove(ingredient);
        }

        public void DeleteProduct(int productId)
        {
            Product product = _context.Products.SingleOrDefault(x => x.Id == productId);
            product.IsDeleted = true;
            _context.Products.Update(product);
        }

        public IEnumerable<Dish> GetDishes()
        {
           return _context.Dishes;
        }

        public IEnumerable<Dish> GetDishes(int start, int pagesize)
        {
            return _context.Dishes.Skip(start).Take(pagesize);
        }

        public IEnumerable<Dish> GetDishes(string search, int start, int pagesize)
        {
            return _context.Dishes.Where(x => x.Name.Contains(search)).Skip(start).Take(pagesize);
        }
        
        public Dish GetDish(int id)
        {
            return _context.Dishes.Where(x => x.Id == id).FirstOrDefault();
        }

        public int GetDishesCount()
        {
            return _context.Dishes.Count();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        public void UpdateDish(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            _context.Entry(ingredient).State = EntityState.Modified;
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }                

                disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
