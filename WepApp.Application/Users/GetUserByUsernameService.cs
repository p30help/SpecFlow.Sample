using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Application.Users
{
    public interface IGetUserByUsernameService
    {
        public Task<User> Execute(string username);
    }

    public class GetUserByUsernameService : IGetUserByUsernameService
    {
        private IUsersRepository _usersRepository { get; set; }

        public GetUserByUsernameService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> Execute(string username)
        {
            var user = await _usersRepository.GetAsync(username);
            return user;
        }
    }
}
