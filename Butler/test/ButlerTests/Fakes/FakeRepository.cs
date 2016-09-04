using System;
using System.Collections.Generic;
using Butler.Interfaces;
using Butler.Models;

namespace ButlerTests
{
    internal class FakeRepository : IRepository
    {
        private List<Dish> _list;

        public void AddDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(int dishId)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredient(int ingredientId)
        {
            throw new NotImplementedException();
        }

        internal void InMemoryDishes(List<Dish> list)
        {
            _list = list;
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Dish GetDish(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> GetDishes()
        {
            return _list;
        }

        public IEnumerable<Dish> GetDishes(int start, int pagesize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> GetDishes(string search, int start, int pagesize)
        {
            throw new NotImplementedException();
        }

        public int GetDishesCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}