using AutoMapper;
using WikiGames.Models.ViewModel;
using WikiGames.Models.ViewModel.ConsolaViewModel;
using WikiGames.Models.ViewModel.DesarrolladoresViewModel;
using WikiGames.Models.ViewModel.JuegoViewModel;
using WikiGames.Models.ViewModel.JuegosConsolaViewModel;
using WikiGames.Models.Entities;
using WikiGames.Models.ViewModel.JuegViewModel;

namespace WikiGames.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Consola, ConsolaViewModel>();
            // .ForMember(ent=>ent.JuegoConsola, dto=>dto.MapFrom(campo => campo.JuegoConsola.Select(prop=>prop.Juego)));
            CreateMap<Consola, ConsolaAllInfoViewModel>();

            CreateMap<Genero, GeneroViewModel>();
            CreateMap<GeneroViewModel, Genero>();


            CreateMap<MarcaCreacionViewModel, Marca>();
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<MarcaViewModel, Marca>();



            CreateMap<Juego, JuegosViewModel>();
            CreateMap<Juego, JuegoAllInfoViewModel>();

            CreateMap<ConsolaCreacionViewModel, Consola>();

            CreateMap<Juego, JuegoInfoJCViewModel>();

            CreateMap<JuegoConsola, JCJuegosListViewModel>();

            CreateMap<Consola, ConsolaAllInfoViewModel>();

            CreateMap<JuegoCreacionViewModel, Juego>();
                //.ForMember(ent => ent.Generos, dto => dto.MapFrom(campo => campo.Generos.Select(id => new Genero() { GeneroId = id })));

            CreateMap<DesarrolladorCreacionViewModel, Desarrollador>();
            CreateMap<Desarrollador, DesarrolladorCreacionViewModel>();
            CreateMap<Desarrollador, DesarrolladorViewModel>();
           


            CreateMap<JuegoConsolaViewModel, JuegoConsola>();
        }
    }
}
