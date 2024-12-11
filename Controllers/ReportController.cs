using MealPlannerApi.DTOs;
using MealPlannerApi.Models;
using MealPlannerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MealPlannerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GenerateReport([FromBody] ReportDto reportDto)
        {
            if (string.IsNullOrEmpty(reportDto.ReportType))
                return BadRequest("Report type is required.");

            // Fetch 'CreatedBy' from JWT token using the correct claim URI
            var jwtToken = HttpContext.User.Identity as ClaimsIdentity;
            var createdBy = jwtToken?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;

            if (string.IsNullOrEmpty(createdBy))
                return Unauthorized("Invalid token.");

            var report = await _reportService.CreateReportAsync(
                reportDto.ReportType,
                reportDto.Data,
                createdBy
            );

            return CreatedAtAction(nameof(GetReports), new { id = report.ReportId }, report);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAllReports()
        {
            await _reportService.DeleteAllReportsAsync();
            return NoContent(); // Return 204 No Content to indicate successful deletion
        }


    }
}
