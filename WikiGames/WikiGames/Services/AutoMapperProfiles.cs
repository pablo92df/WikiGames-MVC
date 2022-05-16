using AutoMapper;
using WikiGames.Models.DTO;
using WikiGames.Models.DTO.Consola;
using WikiGames.Models.DTO.Juego;
using WikiGames.Models.DTO.JuegosConsola;
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
            CreateMap<JuegoCreacionDTO, Juego>()
                .ForMember(ent => ent.Generos, dto => dto.MapFrom(campo => campo.Generos.Select(id => new Genero() { GeneroId = id })));
                

            CreateMap<JuegoConsolaDTO, JuegoConsola>();
        }
    }
}
