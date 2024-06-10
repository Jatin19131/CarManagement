using CarManagement.DataLayer.Dtos;
using CarManagement.ServiceLayer.Interface;
using CarManagement.ServiceLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {
        private readonly ISalesReport _salesReport;
        public SalesReportController(ISalesReport salesReport)
        {
            _salesReport = salesReport;
        }

        /// <summary>
        /// Get Monthly Sales Report
        /// </summary>
        /// <returns>List of MonthlySalesmanSalesReportDto</returns>
        [HttpGet]
        public async Task<List<MonthlySalesmanSalesReportDto>> GetAllAsync()
        {
            try
            {
                return await _salesReport.GetAllSalesmanMontlyReportAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// Create Monthly Sales report
        /// </summary>
        /// <param name="monthlySalesReportDto"></param>
        /// <returns>bool</returns>
        [HttpPost("AddMonthlySalesReport")]
        public async Task<bool> AddMonthlyReportAsync([FromBody] MonthlySalesmanSalesReportDto monthlySalesReportDto)
        {
            try
            {
                return await _salesReport.AddMontlySalesReport(monthlySalesReportDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                throw null;
            }

        }

        /// <summary>
        /// Get yearly Sales Report
        /// </summary>
        /// <param name="year">The year for which the sales report is requested</param>
        /// <returns>List of YearlySalesmanSalesReportDto</returns>
        [HttpGet("GetOverAllSalesReportByYear/{year}")]
        public async Task<List<YearlySalesmanSalesReportDto>> GetOverAllSalesReportByYearAsync(int year)
        {
            try
            {
                return await _salesReport.GetOverAllSalesReportByYearAsync(year);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Add Yearly Sales report
        /// </summary>
        /// <param name="yearlySalesmanSalesReportDto"></param>
        /// <returns>bool</returns>
        [HttpPost("AddYearlySalesReport")]
        public async Task<bool> AddAsync([FromBody] YearlySalesmanSalesReportDto yearlySalesmanSalesReportDto)
        {
            try
            {
                return await _salesReport.AddYearlySalesmanSalesReport(yearlySalesmanSalesReportDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                throw null;
            }

        }

        /// <summary>
        /// Get yearly Sales Report
        /// </summary>
        /// <param name="year">The year for which the sales report is requested</param>
        /// <returns>List of YearlySalesmanSalesReportDto</returns>
        [HttpGet("GetSalesmanCommissionReport")]
        public async Task<List<SalesmanCommissionReportDto>> GetSalesmanCommissionReportAsync()
        {
            try
            {
                return await _salesReport.GetSalesmanCommissionReportAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return null;
            }
        }
    }
}
