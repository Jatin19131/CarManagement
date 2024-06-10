namespace CarManagement.DataLayer.Dtos
{
    public class CarModelsDto
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public CarBrandsDto? CarBrands { get; set; }
        public int? ClassId { get; set; }
        public CarClassesDto? CarClasses { get; set; }
        public string? ModelName { get; set; }
        public string? ModelCode { get; set; }
        public string? Description { get; set; }
        public string? Features { get; set; }
        public int? Price { get; set; }
        public DateTime? DateOfManufacturing { get; set; }
        public bool? Active { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<string>? Images { get; set; }
    }
}
