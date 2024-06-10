using CarManagement.DataLayer.Dtos;

namespace CarManagement.ServiceLayer.Interface
{
    public interface ICarClasses
    {
        Task<List<CarClassesDto>> GetAllCarClassesAsync();
        Task<bool> AddCarClassAsync(CarClassesDto carClassDto);
    }
}
