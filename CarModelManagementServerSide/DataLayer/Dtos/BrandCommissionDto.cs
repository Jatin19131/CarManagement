namespace CarManagement.DataLayer.Dtos
{
    public class BrandCommissionDto
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public string? FixedCommission { get; set; }
        public string? ClassACommissionPerc { get; set; }
        public string? ClassBCommissionPerc { get; set; }
        public string? ClassCCommissionPerc { get; set; }
        public DateTime? Created { get; set; }  
    }
}
