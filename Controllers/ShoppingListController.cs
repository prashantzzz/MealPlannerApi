﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/shoppinglists")]
    public class ShoppingListController : ControllerBase
    {
        private readonly ShoppingListService _shoppingListService;

        public ShoppingListController(ShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetShoppingLists()
        {
            return Ok(new { data = _shoppingListService.GetAllShoppingLists() });
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetShoppingListById(int id)
        {
            var shoppingList = _shoppingListService.GetShoppingListById(id);
            return shoppingList != null
                ? Ok(new { data = shoppingList })
                : NotFound(new { message = "Shopping list not found" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateShoppingList(ShoppingListDto model)
        {
            var result = _shoppingListService.CreateShoppingList(model);
            return result
                ? Ok(new { message = "Shopping list created successfully" })
                : BadRequest(new { message = "Creation failed" });
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateShoppingList(int id, ShoppingListDto model)
        {
            var result = _shoppingListService.UpdateShoppingList(id, model);
            return result
                ? Ok(new { message = "Shopping list updated successfully" })
                : NotFound(new { message = "Shopping list not found" });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteShoppingList(int id)
        {
            var result = _shoppingListService.DeleteShoppingList(id);
            return result
                ? Ok(new { message = "Shopping list deleted successfully" })
                : NotFound(new { message = "Shopping list not found" });
        }
    }
}
