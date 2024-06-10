using AutoMapper;
using CarManagement.DataLayer.DbContextOperation;
using CarManagement.DataLayer.Dtos;
using CarManagement.DataLayer.Entity;
using CarManagement.ServiceLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.ServiceLayer.Service
{
    public class CarBrandsService : ICarBrands
    {
        private readonly DbAppContext _dbAppContext;
        private readonly IMapper _mapper;
        public CarBrandsService(DbAppContext dbAppContext, IMapper mapper)
        {
            _dbAppContext = dbAppContext;
            _mapper = mapper;
        }
        public async Task<List<CarBrandsDto>> GetAllCarBrandsAsync()
        {
            List<CarBrands> entity = await _dbAppContext.CarBrands.ToListAsync();
            return _mapper.Map<List<CarBrandsDto>>(entity);
        }
        public async Task<bool> AddCarBrandsAsync(CarBrandsDto carBrandDto)
        {
            if (carBrandDto != null && carBrandDto.BrandId == 0)
            {
                var mappedEntity = _mapper.Map<CarBrands>(carBrandDto);
                await _dbAppContext.CarBrands.AddAsync(mappedEntity);
                await _dbAppContext.SaveChangesAsync();
                return true;
            }
            else
            {
                CarBrands? carBrandEntity = await _dbAppContext.CarBrands.FirstOrDefaultAsync(x => x.BrandId == carBrandDto.BrandId);
                if (carBrandEntity != null)
                {
                    carBrandEntity.BrandId = carBrandDto.BrandId;
                    await _dbAppContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }

        }

    }
}

