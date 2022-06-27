using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IPublicadoraRepository
    {
        Task<IEnumerable<Publicadora>> GetAll();
    }
}
