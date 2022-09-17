using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Application.Users
{
    public interface IUpdateUserService
    {
        public Task Execute(Guid userId, string fullname);
    }

    public class UpdateUserService : IUpdateUserService
    {
        private IUsersRepository _usersRepository { get; set; }
        private IGenderizeService _genderizeService { get; set; }

        public UpdateUserService(IUsersRepository usersRepository, IGenderizeService genderizeService)
        {
            _usersRepository = usersRepository;
            _genderizeService = genderizeService;
        }

        public async Task Execute(Guid userId, string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
            {
                throw new Exception("Full Name must be filled");
            }

            var user = await _usersRepository.GetAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var gender = await _genderizeService.GetAsync(fullname);

            user.FullName = fullname;
            user.Gender = gender;

            await _usersRepository.UpdateAsync(user);
        }
    }
}
