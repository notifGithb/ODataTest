using AutoMapper;
using ODataTest.DTOs;
using ODataTest.Models;

namespace ODataTest.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Sehir, SehirDTO>().ReverseMap();
            CreateMap<Ilce, IlceDTO>().ReverseMap();
        }
    }
}
