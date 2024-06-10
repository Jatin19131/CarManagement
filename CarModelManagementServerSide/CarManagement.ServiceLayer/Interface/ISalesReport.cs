using CarManagement.DataLayer.Dtos;

namespace CarManagement.ServiceLayer.Interface
{
    public interface ISalesReport
    {
        Task<List<MonthlySalesmanSalesReportDto>> GetAllSalesmanMontlyReportAsync();
        Task<bool> AddMontlySalesReport(MonthlySalesmanSalesReportDto monthlySalesmanSalesReportDto);
        Task<List<YearlySalesmanSalesReportDto>> GetOverAllSalesReportByYearAsync(int year);
        Task<bool> AddYearlySalesmanSalesReport(YearlySalesmanSalesReportDto yearlySalesmanSalesReportDto);
        Task<List<SalesmanCommissionReportDto>> GetSalesmanCommissionReportAsync();
    }
}
