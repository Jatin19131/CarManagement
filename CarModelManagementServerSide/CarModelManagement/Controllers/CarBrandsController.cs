using CarManagement.DataLayer.Dtos;
using CarManagement.ServiceLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : ControllerBase
    {
        private readonly ICarBrands _carBrands;
        public CarBrandsController(ICarBrands carBrands)
        {
            _carBrands = carBrands;
        }

        /// <summary>
        /// Get All CarModels
        /// </summary>
        /// <returns>CarModelsDto</returns>
        [HttpGet]
        public async Task<List<CarBrandsDto>> GetAllAsync()
        {
            try
            {
                return await _carBrands.GetAllCarBrandsAsync();
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
        /// <returns>bool</returns>
        [HttpPost("AddCarBrands")]
        public async Task<bool> AddAsync([FromBody] CarBrandsDto carBrandsDto)
        {
            try
            {
                return await _carBrands.AddCarBrandsAsync(carBrandsDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                throw null;
            }

        }
    }
}
