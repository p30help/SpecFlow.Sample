using WepApp.Domain.Entities;

namespace WepApp.Domain.Contracts
{
    public interface IUsersRepository
    {

        public Task<bool> ExistAsync(string username);

        Task<User> GetAsync(Guid userId);

        Task<User> GetAsync(string username);

        public Task InsertAsync(User user);

        public Task UpdateAsync(User user);

        Task DeleteAsync(User user);

        Task<List<User>> GetListAsync();
    }
}
