using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;



namespace Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContextRecipe context)
           : base(context)
        {
        }
        public async Task LockUserAsync(int userId/*, bool stats*/) // Mudar para o Update.
        {
            var user = await _context.FindAsync<User>(userId);
            if (user != null)
            {
                user.IsRegistered = false;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UnlockUserAsync(int userId)
        {
            var user = await _context.FindAsync<User>(userId);
            if (user != null)
            {
                user.IsRegistered = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<User> GetByEmailIncluded(string email)
        {
            return await _context.Set<User>()
                 .Include(x => x.Recipes)
                 .Include(x => x.Favorites)
                 .FirstOrDefaultAsync(e => e.Email == email);
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _context.Set<User>()
                 .FirstOrDefaultAsync(e => e.Email == email);
        }

      
    }

}

