using System.ComponentModel.DataAnnotations;

namespace CarManagement.DataLayer.Entity
{
    public class CarClasses
    {
        [Key]
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public DateTime? Created { get; set; }
    }
}
