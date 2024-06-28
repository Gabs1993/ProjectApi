using AutoMapper;
using BasicApi.Data.DTOs.UserDTO;
using ProjectApi.Data.DTOs.UserDTO;
using ProjectApi.Models;


namespace BasicApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, CreateUserDTO>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<User, ReadUserDTO>();
        }
    }
}
