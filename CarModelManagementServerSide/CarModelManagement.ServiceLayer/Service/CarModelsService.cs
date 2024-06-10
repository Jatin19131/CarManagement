using Microsoft.EntityFrameworkCore;
using CarManagement.DataLayer.DbContextOperation;
using CarManagement.DataLayer.Dtos;
using CarManagement.DataLayer.Entity;
using CarManagement.ServiceLayer.Interface;
using AutoMapper;

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
        public async Task<List<CarModelsDto>> GetAllGhlLocationsAsync()
        {
            List<CarModels> carModels = await _dbAppContext.CarModels.ToListAsync();
            return _mapper.Map<List<CarModelsDto>>(carModels);
        }

        //public async Task<CarModelsDto> AddGHLLocationAsync(CarModelsDto carModelDto)
        //{
        //    if (goHighLocation != null && goHighLocation.Id == null)
        //    {
        //        goHighLocation.Id = Guid.NewGuid();
        //        await _dbAppContext.GoHighLocation.AddAsync(goHighLocation);
        //        await _dbAppContext.SaveChangesAsync();
        //        return goHighLocation;
        //    }
        //    else
        //    {
        //        GoHighLocation? goHighLocationEntity = await _dbAppContext.GoHighLocation.FirstOrDefaultAsync(x => x.Id.Equals(goHighLocation.Id));
        //        if (goHighLocationEntity != null)
        //        {
        //            if (!string.IsNullOrEmpty(goHighLocation?.LocationId) && goHighLocationEntity?.LocationId == goHighLocation?.LocationId)
        //            {
        //                goHighLocationEntity.Id = goHighLocation?.Id;
        //                goHighLocationEntity.FriendlyName = goHighLocation?.FriendlyName;
        //                goHighLocationEntity.ClientId = goHighLocation?.ClientId;
        //                goHighLocationEntity.ClientSecret = goHighLocation?.ClientSecret;
        //                goHighLocationEntity.Code = goHighLocation?.Code;
        //                goHighLocationEntity.ApiKey = goHighLocation?.ApiKey;
        //                goHighLocationEntity.LocationId = goHighLocation?.LocationId;
        //                goHighLocationEntity.LocationName = goHighLocation?.LocationName;
        //                goHighLocationEntity.RefreshToken = goHighLocation?.RefreshToken;
        //                await _dbAppContext.SaveChangesAsync();
        //                return goHighLocationEntity;
        //            }
        //            else if (string.IsNullOrEmpty(goHighLocationEntity?.LocationId) && goHighLocation?.LocationId != null)
        //            {
        //                goHighLocationEntity.Id = goHighLocation?.Id;
        //                goHighLocationEntity.FriendlyName = goHighLocation?.FriendlyName;
        //                goHighLocationEntity.ClientId = goHighLocation?.ClientId;
        //                goHighLocationEntity.ClientSecret = goHighLocation?.ClientSecret;
        //                goHighLocationEntity.Code = goHighLocation?.Code;
        //                goHighLocationEntity.ApiKey = goHighLocation?.ApiKey;
        //                goHighLocationEntity.LocationId = goHighLocation?.LocationId;
        //                goHighLocationEntity.LocationName = goHighLocation?.LocationName;
        //                goHighLocationEntity.RefreshToken = goHighLocation?.RefreshToken;
        //                await _dbAppContext.SaveChangesAsync();
        //                return goHighLocationEntity;
        //            }
        //            else
        //            {
        //                goHighLocation.Id = Guid.NewGuid();
        //                await _dbAppContext.GoHighLocation.AddAsync(goHighLocation);
        //                await _dbAppContext.SaveChangesAsync();
        //                return goHighLocationEntity;
        //            }
        //        }
        //        return null;
        //    }
        //}

    }
}

