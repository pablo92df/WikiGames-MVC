using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IMarcaRepository
    {

        Task<IEnumerable<Marca>> GetAll();
 
    }
}
