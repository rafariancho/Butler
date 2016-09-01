using Butler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.Interfaces
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Dish> GetDishes();
        IEnumerable<Product> GetProducts();
        void AddDish(Dish dish);
        void UpdateDish(Dish dish);
        void DeleteDish(int dishId);
        void AddIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient ingredient);
        void DeleteIngredient(int ingredientId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        void Save();
    }
}
