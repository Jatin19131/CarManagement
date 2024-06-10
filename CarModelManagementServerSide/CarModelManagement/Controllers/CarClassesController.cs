using CarManagement.DataLayer.Dtos;
using CarManagement.ServiceLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassesController : ControllerBase
    {
        private readonly ICarClasses _carClasses;
        public CarClassesController(ICarClasses carClasses)
        {
            _carClasses = carClasses;
        }

        /// <summary>
        /// Get All Car Classes
        /// </summary>
        /// <returns>CarClassesDto</returns>
        [HttpGet]
        public async Task<List<CarClassesDto>> GetAllAsync()
        {
            try
            {
                return await _carClasses.GetAllCarClassesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// Create Car Class
        /// </summary>
        /// <param name="carClassDto"></param>
        /// <returns>bool</returns>
        [HttpPost("AddCarClasses")]
        public async Task<bool> AddAsync([FromBody] CarClassesDto carClassDto)
        {
            try
            {
                return await _carClasses.AddCarClassAsync(carClassDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                throw null;
            }

        }
    }
}
