using AutoMapper;
using CarManagement.DataLayer.DbContextOperation;
using CarManagement.DataLayer.Dtos;
using CarManagement.DataLayer.Entity;
using CarManagement.ServiceLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.ServiceLayer.Service
{
    public class CarModelsService : ICarModels
    {
        private readonly DbAppContext _dbAppContext;
        private readonly IMapper _mapper;
        public CarModelsService(DbAppContext dbAppContext, IMapper mapper)
        {
            _dbAppContext = dbAppContext;
            _mapper = mapper;
        }

        public async Task<List<CarModelsDto>> GetAllCarModelsAsync()
        {
            List<CarModels> entity = await _dbAppContext.CarModels.Include(x => x.CarBrands)
                .Include(x => x.CarClasses).OrderByDescending(x =>x.Created).Where(x => x.Active == true).ToListAsync();
            return _mapper.Map<List<CarModelsDto>>(entity);
        }

        public async Task<bool> AddCarModelAsync(CarModelsDto carModelDto)
        {
            if (carModelDto != null)
            {
                if (carModelDto.Id == 0)
                {
                    var mappedEntity = _mapper.Map<CarModels>(carModelDto);
                    mappedEntity.CarClasses = null;
                    mappedEntity.CarBrands = null;
                    mappedEntity.Created = DateTime.Now;
                    mappedEntity.Updated = DateTime.Now;
                    await _dbAppContext.CarModels.AddAsync(mappedEntity);
                    await _dbAppContext.SaveChangesAsync();

                    if (carModelDto?.Images?.Count > 0)
                    {
                        foreach (var image in carModelDto.Images)
                        {
                            var imageModel = new CarModelImages();
                            imageModel.ImageUrl = image;
                            imageModel.CarModelId = mappedEntity.Id;
                            imageModel.AddedOn = DateTime.Now;
                            await _dbAppContext.CarModelImages.AddAsync(imageModel);
                            await _dbAppContext.SaveChangesAsync();
                        }
                    }
                    return true;
                }
                else
                {
                    CarModels? carModelEntity = await _dbAppContext.CarModels.FirstOrDefaultAsync(x => x.Id == carModelDto.Id);
                    if (carModelEntity != null)
                    {
                        carModelEntity.CarClasses = null;
                        carModelEntity.CarBrands = null;
                        carModelEntity.Updated = DateTime.Now;
                        carModelEntity.BrandId = carModelDto.BrandId;
                        carModelEntity.ClassId = carModelDto.ClassId;
                        carModelEntity.ModelName = carModelDto.ModelName;
                        carModelEntity.ModelCode = carModelDto.ModelCode;
                        carModelEntity.DateOfManufacturing = carModelDto.DateOfManufacturing;
                        carModelEntity.Features = carModelDto.Features;
                        carModelEntity.Price = carModelDto.Price;
                        carModelEntity.Active = carModelDto.Active;
                        await _dbAppContext.SaveChangesAsync();
                        return true;
                    }

                    return false;
                }
            }
            return false;

        }

        public async Task<CarModelsDto> GetCarModelById(int carModelId)
        {
            if (carModelId <= 0)
                return null;

            var entity = await _dbAppContext.CarModels
                .Include(x => x.CarBrands)
                .Include(x => x.CarClasses)
                .FirstOrDefaultAsync(x => x.Active == true && x.Id == carModelId);

            if (entity == null)
                return null;

            var imageUrls = await _dbAppContext.CarModelImages
                .Where(x => x.CarModelId == carModelId)
                .Select(x => x.ImageUrl)
                .ToListAsync();

            var carModelDto = _mapper.Map<CarModelsDto>(entity);
            carModelDto.Images = imageUrls;

            return carModelDto;
        }


        public async Task<bool> DeleteCarModelByIdAsync(int carModelId)
        {
            if (carModelId <= 0)
                return false;

            var entity = await _dbAppContext.CarModels.FindAsync(carModelId);
            if (entity == null)
                return false;

            entity.Active = false;
            await _dbAppContext.SaveChangesAsync();

            return true;
        }
    }
}

