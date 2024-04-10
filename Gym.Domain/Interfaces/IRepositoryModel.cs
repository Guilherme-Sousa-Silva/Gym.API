namespace Gym.Domain.Interfaces
{
    public interface IRepositoryModel<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
