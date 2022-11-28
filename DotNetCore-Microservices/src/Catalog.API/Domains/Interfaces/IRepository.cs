namespace Catalog.API.Domains.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task<T> GetAsync(string id);
    }
}
