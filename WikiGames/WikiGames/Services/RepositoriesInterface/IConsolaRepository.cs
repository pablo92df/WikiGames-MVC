using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IConsolaRepository
    {
        Task<Consola> GetConsolaById(int id);
    }
}
