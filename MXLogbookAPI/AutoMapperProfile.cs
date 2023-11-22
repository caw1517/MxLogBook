namespace MXLogbookAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, GetVehicleDto>();
            CreateMap<AddVehicleDto, Vehicle>();
            CreateMap<UpdateVehicleDto, Vehicle>();
        }
    }
}
