using Models;
using Models.Entities;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AddAsync(UserDto userDto);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int userId);
        Task<UserDto> GetUserByEmail(string email);
        Task LockUser(int userId);
        Task<bool> Login(string email, string password);
        Task UnlockUser(int userId);
        Task<UserDto> Update(UserDto user);
        Task<UserDto?> AuthenticateAsync(string email, string pa);
        Task<IEnumerable<UserDto>> SearchUsersAsync(string name);

    }
}
