using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagement.DataLayer.Entity
{
    public class CarModelImages
    {
        [Key]
        public int Id { get; set; }
        public int? CarModelId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
