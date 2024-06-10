using CarManagement.DataLayer.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagement.DataLayer.Entity
{
    public class CarModels
    {
        [Key]
        public int Id { get; set; }

        // Foreign key for CarBrand
        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public CarBrands? CarBrands { get; set; }

        // Foreign key for CarClasses
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public CarClasses? CarClasses { get; set; }
        public string? ModelName { get; set; }
        public string? ModelCode { get; set; }
        public string? Description { get; set; }
        public string? Features { get; set; }
        public int? Price { get; set; }
        public DateTime? DateOfManufacturing { get; set; }
        public bool? Active { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
