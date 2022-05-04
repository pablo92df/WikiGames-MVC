using AutoMapper;
using WikiGames.Models.DTO;
using WikiGames.Models.DTO.Consola;
using WikiGames.Models.DTO.Juego;
using WikiGames.Models.Entities;

namespace WikiGames.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Consola, ConsolaDTO>();
            CreateMap<MarcaCreacionDTO, Marca>();

            CreateMap<Juego, JuegosDTO>();
            
            CreateMap<ConsolaCreacionDTO, Consola>();
        

        }
    }
}
