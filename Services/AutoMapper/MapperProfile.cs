using AutoMapper;
using Domains;
using Services.Contracts.Dtos;


namespace Services.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Car, CarDto>();
        }
    }
}
