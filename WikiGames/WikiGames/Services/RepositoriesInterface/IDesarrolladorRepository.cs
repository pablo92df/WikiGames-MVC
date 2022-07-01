using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IDesarrolladorRepository
    {
      //  Task Create(Desarrollador desarrollador);
        //Task Delete(int desarrolladorId);
        //Task Edit(Desarrollador desarrollador);
        Task<IEnumerable<Desarrollador>> GetAll(string desarrolladorName);
        Task<Desarrollador> GetAllInfo(int desarrolladorId);
        Task<Desarrollador> GetById(int desarrolladorId);
    }
}
