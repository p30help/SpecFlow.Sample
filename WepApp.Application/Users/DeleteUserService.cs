using WepApp.Domain.Contracts;

namespace WepApp.Application.Users
{
    public interface IDeleteUserService
    {
        public Task Execute(Guid userId);
    }

    public class DeleteUserService : IDeleteUserService
    {
        private IUsersRepository _usersRepository { get; set; }

        public DeleteUserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task Execute(Guid userId)
        {
            var user = await _usersRepository.GetAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            await _usersRepository.DeleteAsync(user);
        }
    }
}
