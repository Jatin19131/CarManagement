using CarManagement.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.DataLayer.Dtos
{
    public class CarModelImagesDto
    {
        public int Id { get; set; }
        public int? CarModelId { get; set; }
        public CarModels? CarModels { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
