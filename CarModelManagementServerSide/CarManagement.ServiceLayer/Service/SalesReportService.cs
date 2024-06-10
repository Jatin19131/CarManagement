using AutoMapper;
using CarManagement.DataLayer.DbContextOperation;
using CarManagement.DataLayer.Dtos;
using CarManagement.DataLayer.Entity;
using CarManagement.ServiceLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.ServiceLayer.Service
{
    public class SalesReportService : ISalesReport
    {
        private readonly DbAppContext _dbAppContext;
        private readonly IMapper _mapper;
        public SalesReportService(DbAppContext dbAppContext, IMapper mapper)
        {
            _dbAppContext = dbAppContext;
            _mapper = mapper;
        }
        public async Task<List<MonthlySalesmanSalesReportDto>> GetAllSalesmanMontlyReportAsync()
        {
            List<MonthlySalesmanSalesReport> entity = await _dbAppContext.MonthlySalesmanSalesReport.ToListAsync();
            return _mapper.Map<List<MonthlySalesmanSalesReportDto>>(entity);
        }
        public async Task<bool> AddMontlySalesReport(MonthlySalesmanSalesReportDto monthlySalesmanSalesReportDto)
        {
            if (monthlySalesmanSalesReportDto != null && monthlySalesmanSalesReportDto.Id == 0)
            {
                var mappedEntity = _mapper.Map<MonthlySalesmanSalesReport>(monthlySalesmanSalesReportDto);
                await _dbAppContext.MonthlySalesmanSalesReport.AddAsync(mappedEntity);
                await _dbAppContext.SaveChangesAsync();
                return true;
            }
            else
            {
                MonthlySalesmanSalesReport? monthlySalesmanSalesReportEntity = await _dbAppContext.MonthlySalesmanSalesReport.FirstOrDefaultAsync(report => report.Id == monthlySalesmanSalesReportDto.Id);
                if (monthlySalesmanSalesReportEntity != null)
                {
                    monthlySalesmanSalesReportEntity.Id = monthlySalesmanSalesReportDto.Id;
                    await _dbAppContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }

        }
        public async Task<List<YearlySalesmanSalesReportDto>> GetOverAllSalesReportByYearAsync(int year)
        {
            List<YearlySalesmanSalesReport> entity = await _dbAppContext.YearlySalesmanSalesReport
                                                                          .Where(report => report.Year == year)
                                                                          .ToListAsync();
            return _mapper.Map<List<YearlySalesmanSalesReportDto>>(entity);
        }
        public async Task<bool> AddYearlySalesmanSalesReport(YearlySalesmanSalesReportDto yearlySalesmanSalesReportDto)
        {
            if (yearlySalesmanSalesReportDto != null && yearlySalesmanSalesReportDto.Id == 0)
            {
                var mappedEntity = _mapper.Map<YearlySalesmanSalesReport>(yearlySalesmanSalesReportDto);
                await _dbAppContext.YearlySalesmanSalesReport.AddAsync(mappedEntity);
                await _dbAppContext.SaveChangesAsync();
                return true;
            }
            else
            {
                YearlySalesmanSalesReport? yearSalesmanSalesReportEntity = await _dbAppContext.YearlySalesmanSalesReport.FirstOrDefaultAsync(report => report.Id == yearlySalesmanSalesReportDto.Id);
                if (yearSalesmanSalesReportEntity != null)
                {
                    yearSalesmanSalesReportEntity.Id = yearlySalesmanSalesReportDto.Id;
                    await _dbAppContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }

        }
        public async Task<List<SalesmanCommissionReportDto>> GetSalesmanCommissionReportAsync()
        {
            var monthlySalesManSaleReport = await _dbAppContext.MonthlySalesmanSalesReport.ToListAsync();
            var commissionOnBrands = await _dbAppContext.BrandCommission.ToListAsync();
            var carModel = await _dbAppContext.CarModels.ToListAsync();
            var yearlySalesmanSales = await _dbAppContext.YearlySalesmanSalesReport.ToListAsync();

            var commissionReport = new List<SalesmanCommissionReportDto>();

            // Group salesmen by name
            var groupedSalesmen = monthlySalesManSaleReport.GroupBy(s => s.SalesmanName);

            foreach (var group in groupedSalesmen)
            {
                var salesmanName = group.Key;
                var salesRecords = group.ToList();

                var fixedCommissionAmount = 0;
                var classACommissionAmount = 0;
                var classBCommissionAmount = 0;
                var classCCommissionAmount = 0;
                var additionalCommission = 0;
                var overallCommission = 0;

                foreach (var salesman in salesRecords)
                {
                    //Audi logic
                    if (salesman.NumberOfCarsSoldForAUDI > 0)
                    {
                        var commissionCriteria = commissionOnBrands.FirstOrDefault(c => c.BrandId == 1);
                        var price = carModel.FirstOrDefault(m => m.ClassId == salesman.ClassId && m.BrandId == 1)?.Price ?? 0;

                        //Check class wise commission
                        if (salesman.ClassId == 1)
                        {
                            classACommissionAmount += (price * int.Parse(commissionCriteria.ClassACommissionPerc) / 100) * salesman.NumberOfCarsSoldForAUDI ?? 0;

                        }
                        else if (salesman.ClassId == 2)
                        {
                            classBCommissionAmount += (price * int.Parse(commissionCriteria.ClassBCommissionPerc) / 100) * salesman.NumberOfCarsSoldForAUDI ?? 0;
                        }
                        else if (salesman.ClassId == 3)
                        {
                            classCCommissionAmount += (price * int.Parse(commissionCriteria.ClassCCommissionPerc) / 100) * salesman.NumberOfCarsSoldForAUDI ?? 0;
                        }
                        //end

                        //Fixed commission 
                        if (price > 25000)
                        {
                            fixedCommissionAmount += 800;
                        }
                        //end
                    }
                    //Jaguar logic
                    if (salesman.NumberOfCarsSoldForJaguar > 0)
                    {
                        var commissionCriteria = commissionOnBrands.FirstOrDefault(c => c.BrandId == 2);
                        var price = carModel.FirstOrDefault(m => m.ClassId == salesman.ClassId && m.BrandId == 2)?.Price ?? 0;

                        //Check class wise commission
                        if (salesman.ClassId == 1)
                        {
                            classACommissionAmount += (price * int.Parse(commissionCriteria.ClassACommissionPerc) / 100) * salesman.NumberOfCarsSoldForJaguar ?? 0;
                        }
                        else if (salesman.ClassId == 2)
                        {
                            classBCommissionAmount += (price * int.Parse(commissionCriteria.ClassBCommissionPerc) / 100) * salesman.NumberOfCarsSoldForJaguar ?? 0;
                        }
                        else if (salesman.ClassId == 3)
                        {
                            classCCommissionAmount += (price * int.Parse(commissionCriteria.ClassCCommissionPerc) / 100) * salesman.NumberOfCarsSoldForJaguar ?? 0;
                        }
                        //end

                        //Fixed commission 
                        if (price > 35000)
                        {
                            fixedCommissionAmount += 750;
                        }
                        //end
                    }
                    //LandRover logic
                    if (salesman.NumberOfCarsSoldForLandRover > 0)
                    {
                        var commissionCriteria = commissionOnBrands.FirstOrDefault(c => c.BrandId == 3);
                        var price = carModel.FirstOrDefault(m => m.ClassId == salesman.ClassId && m.BrandId == 3)?.Price ?? 0;

                        //Check class wise commission
                        if (salesman.ClassId == 1)
                        {
                            classACommissionAmount += (price * int.Parse(commissionCriteria.ClassACommissionPerc) / 100) * salesman.NumberOfCarsSoldForLandRover ?? 0;
                        }
                        else if (salesman.ClassId == 2)
                        {
                            classBCommissionAmount += (price * int.Parse(commissionCriteria.ClassBCommissionPerc) / 100) * salesman.NumberOfCarsSoldForLandRover ?? 0;
                        }
                        else if (salesman.ClassId == 3)
                        {
                            classCCommissionAmount += (price * int.Parse(commissionCriteria.ClassCCommissionPerc) / 100) * salesman.NumberOfCarsSoldForLandRover ?? 0;
                        }
                        //end

                        //Fixed commission 
                        if (price > 30000)
                        {
                            fixedCommissionAmount += 850;
                        }
                        //end

                    }
                    //Renault logic
                    if (salesman.NumberOfCarsSoldForRenault > 0)
                    {
                        var commissionCriteria = commissionOnBrands.FirstOrDefault(c => c.BrandId == 4);
                        var price = carModel.FirstOrDefault(m => m.ClassId == salesman.ClassId && m.BrandId == 4)?.Price ?? 0;

                        //Check class wise commission
                        if (salesman.ClassId == 1)
                        {
                            classACommissionAmount += (price * int.Parse(commissionCriteria.ClassACommissionPerc) / 100) * salesman.NumberOfCarsSoldForRenault ?? 0;
                        }
                        else if (salesman.ClassId == 2)
                        {
                            classBCommissionAmount += (price * int.Parse(commissionCriteria.ClassBCommissionPerc) / 100) * salesman.NumberOfCarsSoldForRenault ?? 0;
                        }
                        else if (salesman.ClassId == 3)
                        {
                            classCCommissionAmount += (price * int.Parse(commissionCriteria.ClassCCommissionPerc) / 100) * salesman.NumberOfCarsSoldForRenault ?? 0;
                        }
                        //end

                        //Fixed commission 
                        if (price > 30000)
                        {
                            fixedCommissionAmount += 400;
                        }
                        //end
                    }

                }

                //Additional 2% commission logic
                if (yearlySalesmanSales.Count > 0)
                {
                    var previousSaleAmount = yearlySalesmanSales.Where(x => x.Salesman == salesmanName);
                    if (previousSaleAmount != null)
                    {
                        additionalCommission = classACommissionAmount * 2 / 100;
                    }
                }

                // Calculate overall commission
                overallCommission = fixedCommissionAmount + classACommissionAmount + classBCommissionAmount + classCCommissionAmount + additionalCommission;

                var commissionDto = new SalesmanCommissionReportDto
                {
                    SalesmanName = salesmanName,
                    FixedCommissionAmount = fixedCommissionAmount,
                    ClassACommissionAmount = classACommissionAmount,
                    ClassBCommissionAmount = classBCommissionAmount,
                    ClassCCommissionAmount = classCCommissionAmount,
                    AdditionalCommission = additionalCommission,
                    OverallCommission = overallCommission
                };

                commissionReport.Add(commissionDto);
            }

            return commissionReport;
        }
    }
}

