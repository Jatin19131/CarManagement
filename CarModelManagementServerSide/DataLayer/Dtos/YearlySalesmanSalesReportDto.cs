namespace CarManagement.DataLayer.Dtos 
{
    public class YearlySalesmanSalesReportDto
    {
        public int Id { get; set; }
        public string? Salesman { get; set; }
        public int? TotalSaleAmount { get; set; }
        public int? Year { get; set; }
        public DateTime? Created { get; set;}
    }
}
