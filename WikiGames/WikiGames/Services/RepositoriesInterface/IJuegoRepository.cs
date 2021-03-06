using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IJuegoRepository
    {
        Task<IEnumerable<Juego>> GetAll(string juegoName, int GeneroId, int ConsolaId, int DesarrolladoraId, int ModoDeJuegoId);
        Task<Juego> GetById(int juegoId);
    }
}
