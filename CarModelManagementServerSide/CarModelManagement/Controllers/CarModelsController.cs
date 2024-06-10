using CarManagement.DataLayer.Dtos;
using CarManagement.ServiceLayer.Interface;
using CarManagement.ServiceLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly ICarModels _carModels;

        public CarModelsController(ICarModels carModels)
        {
            _carModels = carModels;
        }

        /// <summary>
        /// Get All CarModels
        /// </summary>
        /// <returns>CarModelsDto</returns>
        [HttpGet]
        public async Task<List<CarModelsDto>> GetAllAsync()
        {
            try
            {
                return await _carModels.GetAllCarModelsAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// Create Car Model
        /// </summary>
        /// <param name="carModelDto"></param>
        /// <returns>CarModelsDto</returns>
        [HttpPost("AddCarModel")]
        public async Task<bool> AddAsync([FromBody] CarModelsDto carModelDto)
        {
            try
            {
                return await _carModels.AddCarModelAsync(carModelDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return false; 
            }

        }
        /// <summary>
        /// Get car model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CarModelsDto</returns>

        [HttpGet("GetCarModelById/{id}")]
        public async Task<CarModelsDto> GetByIdAsync(int id)
        {
            try
            {
                return await _carModels.GetCarModelById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return null; 
            }
        }

        [HttpGet("DeletCarModelById/{id}")]
        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                return await _carModels.DeleteCarModelByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return false; 
            }
        }
    }
}
