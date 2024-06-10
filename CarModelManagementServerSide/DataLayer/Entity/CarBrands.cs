using System.ComponentModel.DataAnnotations;

namespace CarManagement.DataLayer.Entity
{
    public class CarBrands
    {
        [Key]
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public DateTime? Created { get; set; }
    }
}
