using AutoMapper;
using ProjectApi.Data.DTOs.JogadorDTO;
using ProjectApi.Models;

namespace BasicApi.Profiles
{
    public class JogadorProfile : Profile
    {
        public JogadorProfile()
        {
            CreateMap<CreateJogadorDTO, Jogador>();
            CreateMap<Jogador, ReadJogadorDTO>();
            CreateMap<Jogador, UpdateJogadorDTO>();
            CreateMap<ReadJogadorDTO, Jogador>();
        }
    }
}
