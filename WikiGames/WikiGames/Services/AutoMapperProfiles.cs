using AutoMapper;
using WikiGames.Models.ViewModel;
using WikiGames.Models.ViewModel.ConsolaViewModel;
using WikiGames.Models.ViewModel.DesarrolladoresViewModel;
using WikiGames.Models.ViewModel.JuegoViewModel;
using WikiGames.Models.ViewModel.JuegosConsolaViewModel;
using WikiGames.Models.Entities;
using WikiGames.Models.ViewModel.JuegViewModel;
using WikiGames.Models.ViewModel.PublicadoraViewModel;

namespace WikiGames.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Consola, ConsolaViewModel>();
            // .ForMember(ent=>ent.JuegoConsola, dto=>dto.MapFrom(campo => campo.JuegoConsola.Select(prop=>prop.Juego)));
            CreateMap<Consola, ConsolaAllInfoViewModel>();
            CreateMap<Consola, ConsolaAllInfoViewModel>();
            CreateMap<ConsolaCreacionViewModel, Consola>();
            CreateMap<Consola, ConsolaCreacionViewModel>();


            CreateMap<Genero, GeneroViewModel>();
            CreateMap<GeneroViewModel, Genero>();


            CreateMap<MarcaCreacionViewModel, Marca>();
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<MarcaViewModel, Marca>();


            CreateMap<Juego, JuegoInfoJCViewModel>();
            CreateMap<Juego, JuegosViewModel>();
            CreateMap<Juego, JuegoAllInfoViewModel>();
            CreateMap<JuegoCreacionViewModel, Juego>();



            CreateMap<JuegoConsola, JCJuegosListViewModel>();
            CreateMap<JuegoConsolaViewModel, JuegoConsola>();


            CreateMap<PublicadoraEditViewModel, Publicadora>();
            CreateMap<Publicadora, PublicadoraEditViewModel>();


            //.ForMember(ent => ent.Generos, dto => dto.MapFrom(campo => campo.Generos.Select(id => new Genero() { GeneroId = id })));

            CreateMap<DesarrolladorCreacionViewModel, Desarrollador>();
            CreateMap<Desarrollador, DesarrolladorCreacionViewModel>();
            CreateMap<Desarrollador, DesarrolladorViewModel>();
            CreateMap<Desarrollador, DesarrolladorEditViewModel>();
            CreateMap<DesarrolladorEditViewModel, Desarrollador>();
            CreateMap<DesarrolladorAllInfoViewModel, Desarrollador>();
            CreateMap<Desarrollador, DesarrolladorAllInfoViewModel>();





        }
    }
}
