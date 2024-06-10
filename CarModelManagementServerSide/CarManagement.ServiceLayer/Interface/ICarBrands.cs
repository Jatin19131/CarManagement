using CarManagement.DataLayer.Dtos;

namespace CarManagement.ServiceLayer.Interface
{
    public interface ICarBrands
    {
        Task<List<CarBrandsDto>> GetAllCarBrandsAsync();
        Task<bool> AddCarBrandsAsync(CarBrandsDto carBrandDto);
    }
}
