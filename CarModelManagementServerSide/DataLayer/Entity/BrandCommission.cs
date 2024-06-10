using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagement.DataLayer.Entity
{
    public class BrandCommission
    {
        [Key]
        public int Id { get; set; }
        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public CarBrands? CarBrands { get; set; }
        public string? FixedCommission { get; set; }
        public string? ClassACommissionPerc { get; set; }
        public string? ClassBCommissionPerc { get; set; }
        public string? ClassCCommissionPerc { get; set; }
        public DateTime? Created { get; set; }
    }
}
