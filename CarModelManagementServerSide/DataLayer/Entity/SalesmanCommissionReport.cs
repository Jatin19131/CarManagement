using System.ComponentModel.DataAnnotations;
namespace CarManagement.DataLayer.Entity
{
    public class SalesmanCommissionReport
    {
        [Key]
        public int Id { get; set; }
        public string? SalesmanName { get; set; }
        public int? FixedCommissionAmount { get; set; }
        public int? ClassACommissionAmount { get; set; }
        public int? ClassBCommissionAmount { get; set; }
        public int? ClassCCommissionAmount { get; set; }
        public int? AdditionalCommission { get; set; }
        public int? OverallCommission { get; set; }
        public int? Month { get; set; }
        public DateTime? Created { get; set; }
    }
}
