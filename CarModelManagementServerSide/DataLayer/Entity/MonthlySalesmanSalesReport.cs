using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagement.DataLayer.Entity
{
    public class MonthlySalesmanSalesReport
    {
        [Key]
        public int Id { get; set; }
        public string? SalesmanName { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public CarClasses? CarClasses { get; set; }
        public int? NumberOfCarsSoldForAUDI { get; set; }
        public int? NumberOfCarsSoldForJaguar { get; set; }
        public int? NumberOfCarsSoldForLandRover { get; set; }
        public int? NumberOfCarsSoldForRenault { get; set; }
        public string? MonthName { get; set; }
        public int? MonthNumber { get; set; }
        public DateTime? Created { get; set; }
    }
}
