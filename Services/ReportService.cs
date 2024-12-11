using MealPlannerApi.Data;
using MealPlannerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerApi.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report> CreateReportAsync(string reportType, string data, string createdBy)
        {
            var report = new Report
            {
                ReportType = reportType,
                Data = data,
                CreatedBy = createdBy,
                GeneratedDate = DateTime.UtcNow
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return report;
        }

        public async Task DeleteAllReportsAsync()
        {
            _context.Reports.RemoveRange(_context.Reports);
            await _context.SaveChangesAsync();
        }

    }
}
