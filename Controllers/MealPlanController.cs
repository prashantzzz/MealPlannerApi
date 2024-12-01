﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MealPlannerApi.Services;
using MealPlannerApi.DTOs;

namespace MealPlannerApi.Controllers
{
    [ApiController]
    [Route("api/mealplans")]
    public class MealPlanController : ControllerBase
    {
        private readonly MealPlanService _mealPlanService;

        public MealPlanController(MealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetMealPlans()
        {
            var userId = User.Identity.Name; // Assumes User.Identity.Name is the UserId
            return Ok(_mealPlanService.GetMealPlansForUser(userId));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetMealPlanById(int id)
        {
            var mealPlan = _mealPlanService.GetMealPlanById(id);
            return mealPlan != null ? Ok(mealPlan) : NotFound("Meal plan not found");
        }

        [Authorize(Roles = "Customer,MealPlanner")]
        [HttpPost]
        public IActionResult CreateMealPlan(MealPlanDto model)
        {
            var result = _mealPlanService.CreateMealPlan(model);
            return result ? Ok("Meal plan created successfully") : BadRequest("Creation failed");
        }

        [Authorize(Roles = "Customer,MealPlanner")]
        [HttpPut("{id}")]
        public IActionResult UpdateMealPlan(int id, MealPlanDto model)
        {
            var result = _mealPlanService.UpdateMealPlan(id, model);
            return result ? Ok("Meal plan updated successfully") : NotFound("Meal plan not found");
        }

        [Authorize(Roles = "Customer,MealPlanner")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMealPlan(int id)
        {
            var result = _mealPlanService.DeleteMealPlan(id);
            return result ? Ok("Meal plan deleted successfully") : NotFound("Meal plan not found");
        }
    }
}
