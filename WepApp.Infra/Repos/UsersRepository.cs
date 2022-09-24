using Microsoft.EntityFrameworkCore;
using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Infra.Repos
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MainContext _context;

        public UsersRepository(MainContext context)
        {
            _context = context;
        }


        public async Task<bool> ExistAsync(string username)
        {
            try
            {
                return await _context.Users.AnyAsync(x => x.UserName == username);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        public Task<User> GetAsync(Guid userId)
        {
            return _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public Task<User> GetAsync(string username)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public Task<List<User>> GetListAsync()
        {
            return _context.Users.ToListAsync();
        }
    }
}
