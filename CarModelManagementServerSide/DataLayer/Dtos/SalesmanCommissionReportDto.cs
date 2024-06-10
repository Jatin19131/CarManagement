namespace CarManagement.DataLayer.Dtos
{
    public class SalesmanCommissionReportDto
    {
        public string? SalesmanName { get; set; }
        public decimal? FixedCommissionAmount { get; set; }
        public decimal? ClassACommissionAmount { get; set; }
        public decimal? ClassBCommissionAmount { get; set; }
        public decimal? ClassCCommissionAmount { get; set; }
        public decimal? AdditionalCommission { get; set; }
        public decimal? OverallCommission { get; set; }
    }
}
