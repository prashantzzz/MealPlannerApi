namespace MealPlannerApi.DTOs
{
    public class ReportDto
    {
        public string ReportType { get; set; }
        public string Data { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
