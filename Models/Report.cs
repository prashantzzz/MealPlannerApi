using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ReportType { get; set; }
        [Required]
        public DateTime GeneratedDate { get; set; }
        public string Data { get; set; }
        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }
    }
}
