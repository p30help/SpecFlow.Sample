using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Application.Users
{
    public interface IGetUsersService
    {
        public Task<List<User>> Execute();
    }

    public class GetUsersService : IGetUsersService
    {
        private IUsersRepository _usersRepository { get; set; }

        public GetUsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<User>> Execute()
        {
            var users = await _usersRepository.GetListAsync();
            return users;
        }
    }
}
