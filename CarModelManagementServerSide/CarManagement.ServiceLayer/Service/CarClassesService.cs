using AutoMapper;
using CarManagement.DataLayer.DbContextOperation;
using CarManagement.DataLayer.Dtos;
using CarManagement.DataLayer.Entity;
using CarManagement.ServiceLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.ServiceLayer.Service
{
    public class CarClassesService : ICarClasses
    {
        private readonly DbAppContext _dbAppContext;
        private readonly IMapper _mapper;
        public CarClassesService(DbAppContext dbAppContext, IMapper mapper)
        {
            _dbAppContext = dbAppContext;
            _mapper = mapper;
        }
        public async Task<List<CarClassesDto>> GetAllCarClassesAsync()
        {
            List<CarClasses> entity = await _dbAppContext.CarClasses.ToListAsync();
            return _mapper.Map<List<CarClassesDto>>(entity);
        }
        public async Task<bool> AddCarClassAsync(CarClassesDto carClassDto)
        {
            if (carClassDto != null && carClassDto.ClassId == 0)
            {
                var mappedEntity = _mapper.Map<CarClasses>(carClassDto);
                await _dbAppContext.CarClasses.AddAsync(mappedEntity);
                await _dbAppContext.SaveChangesAsync();
                return true;
            }
            else
            {
                CarClasses? carClassEntity = await _dbAppContext.CarClasses.FirstOrDefaultAsync(x => x.ClassId == carClassDto.ClassId);
                if (carClassEntity != null)
                {
                    carClassEntity.ClassId = carClassDto.ClassId;
                    await _dbAppContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }

        }

    }
}

