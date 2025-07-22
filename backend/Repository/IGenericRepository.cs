namespace Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<int> SaveAsync();
        Task AddListAsync(List<T> listEntity);

    }
}
