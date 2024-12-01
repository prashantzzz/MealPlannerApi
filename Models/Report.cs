using System.ComponentModel.DataAnnotations;

namespace MealPlannerApi.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required, MaxLength(50)]
        public string ReportType { get; set; } // e.g., Adherence, Popularity

        [Required]
        public DateTime GeneratedDate { get; set; }

        [Required]
        public string Data { get; set; } // JSON or serialized data

        [Required, MaxLength(50)]
        public string CreatedBy { get; set; } // User or admin generating the report
    }
}
