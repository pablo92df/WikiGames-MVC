using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IGeneroRepository
    {
        Task Delete(int generoId);
        Task<IEnumerable<Genero>> GetAll();
        Task<Genero> GetById(int id);
        Task Create(Genero genero);
        Task Update(Genero genero);
    }
}
