using AutoMapper;
using CarManagement.DataLayer.Dtos;
using CarManagement.DataLayer.Entity;

namespace CarManagement.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //add other mapper 
            CreateMap<BrandCommission, BrandCommissionDto>();
            CreateMap<CarBrands, CarBrandsDto>();
            CreateMap<CarClasses, CarClassesDto>();
            CreateMap<CarModelImages, CarModelImagesDto>();
            CreateMap<CarModels, CarModelsDto>();
            CreateMap<MonthlySalesmanSalesReport, MonthlySalesmanSalesReportDto>();
            CreateMap<YearlySalesmanSalesReport, YearlySalesmanSalesReportDto>();
            //end
        }
    }
}
