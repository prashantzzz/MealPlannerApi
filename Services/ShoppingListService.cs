﻿using MealPlannerApi.Data;
using MealPlannerApi.DTOs;
using MealPlannerApi.Models;

namespace MealPlannerApi.Services
{
    public class ShoppingListService
    {
        private readonly ApplicationDbContext _context;

        public ShoppingListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ShoppingList> GetAllShoppingLists()
        {
            return _context.ShoppingLists.ToList();
        }

        public ShoppingList GetShoppingListById(int id)
        {
            return _context.ShoppingLists.Find(id);
        }

        public bool CreateShoppingList(ShoppingListDto model)
        {
            var shoppingList = new ShoppingList
            {
                MealPlanId = model.MealPlanId, // Corrected property
                IngredientName = model.IngredientName, // Corrected property
                Quantity = model.Quantity, // No conversion needed as it's already double
                Status = model.Status
            };
            _context.ShoppingLists.Add(shoppingList);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateShoppingList(int id, ShoppingListDto model)
        {
            var shoppingList = _context.ShoppingLists.Find(id);
            if (shoppingList == null) return false;

            shoppingList.IngredientName = model.IngredientName;
            shoppingList.Quantity = model.Quantity; 
            shoppingList.Status = model.Status;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteShoppingList(int id)
        {
            var shoppingList = _context.ShoppingLists.Find(id);
            if (shoppingList == null) return false;

            _context.ShoppingLists.Remove(shoppingList);
            return _context.SaveChanges() > 0;
        }
    }
}
