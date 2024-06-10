using CarManagement.DataLayer.Dtos;

namespace CarManagement.ServiceLayer.Interface
{
    public interface ICarModels
    {
        Task<List<CarModelsDto>> GetAllGhlLocationsAsync();
        //Task<CarModelsDto> AddGHLLocationAsync(CarModelsDto carModelDto);
    }
}
