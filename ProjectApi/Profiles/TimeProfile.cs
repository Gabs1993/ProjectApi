using AutoMapper;
using BasicApi.Data.DTOs.TimeDTO;
using ProjectApi.Models;


namespace BasicApi.Profiles
{
    public class TimeProfile : Profile
    {
        public TimeProfile()
        {
            CreateMap<CreateTimeDTO, Time>();
            CreateMap<Time, CreateTimeDTO>();
            CreateMap<UpdateTimeDTO, Time>();
            CreateMap<Time, ReadTimeDTO>();
        }
    }
}
