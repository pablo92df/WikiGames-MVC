namespace WikiGames.Services.RepositoriesInterface
{
    public interface ICRUD
    {

        Task Create<T>(T objectForDb) where T : class;
        Task<T> GetByID<T>(int entityId) where T : class;
        Task<List<T>> GetAll<T>() where T : class;
        Task Update<T>(T objectToUpdate) where T : class;
        Task Delete<T>(int entityId) where T : class;
    }
}
