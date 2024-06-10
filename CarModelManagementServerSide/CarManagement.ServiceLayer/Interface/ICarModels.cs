using CarManagement.DataLayer.Dtos;

namespace CarManagement.ServiceLayer.Interface
{
    public interface ICarModels
    {
        Task<List<CarModelsDto>> GetAllCarModelsAsync();
        Task<bool> AddCarModelAsync(CarModelsDto carModelDto);
        Task<CarModelsDto> GetCarModelById(int carModelId);
        Task<bool> DeleteCarModelByIdAsync(int carModelId);

    }
}
