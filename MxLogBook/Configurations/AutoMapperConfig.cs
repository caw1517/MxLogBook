using AutoMapper;
using Backend.DTOs.LogItem;
using Backend.DTOs.Vehicles;
using Backend.Models;

namespace Backend.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Vehicle Maps
            CreateMap<Vehicle, AddVehicleDto>().ReverseMap();
            CreateMap<Vehicle, GetVehicleDto>().ReverseMap();
            CreateMap<Vehicle, GetVehicleDetailsDto>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleDto>().ReverseMap();

            //Log Item Maps
            CreateMap<LogItem, GetLogItemDto>().ReverseMap();
        }
    }
}
