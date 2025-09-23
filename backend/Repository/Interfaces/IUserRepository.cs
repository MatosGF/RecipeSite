using Models.Entities;


namespace Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task LockUserAsync(int userId);
        Task UnlockUserAsync(int userId);
        Task<User> GetByEmailIncluded(string email);
        Task<List<User>> SearchByNameAsync(string name);

    }
}
