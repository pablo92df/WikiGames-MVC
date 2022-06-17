using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IMarcaRepository
    {
        Task Create(Marca marca);
        Task Delete(Marca marca);
        Task<IEnumerable<Marca>> GetAll();
        Task<Marca> GetById(int id);
    }
}
