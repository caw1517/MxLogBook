using AutoMapper;
using Backend.DTOs.Auth;
using Backend.DTOs.LogItem;
using Backend.DTOs.SignOff;
using Backend.DTOs.Vehicles;
using Backend.Models;
using System.Configuration;

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
            CreateMap<LogItem, GetAllLogsDto>().ReverseMap();
            CreateMap<LogItem, CreateLogItemDto>().ReverseMap();
            CreateMap<LogItem, UpdateLogItemDto>().ReverseMap();

            //User Maps
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<ApplicationUser, GetUserBasicDto>().ReverseMap();

            //Sign Off Maps
            CreateMap<SignOff, NewSignOffDto>().ReverseMap();
            CreateMap<SignOff, GetSignOffDto>().ReverseMap();
            CreateMap<SignOff, GetSignOffDetailsDto>().ReverseMap();
        }
    }
}
