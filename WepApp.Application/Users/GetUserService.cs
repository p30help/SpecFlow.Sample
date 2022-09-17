using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Application.Users
{
    public interface IGetUserService
    {
        public Task<User> Execute(Guid userId);
    }

    public class GetUserService : IGetUserService
    {
        private IUsersRepository _usersRepository { get; set; }

        public GetUserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> Execute(Guid userId)
        {
            var user = await _usersRepository.GetAsync(userId);
            return user;
        }
    }
}
