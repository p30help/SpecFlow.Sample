using WepApp.Domain.Contracts;
using WepApp.Domain.Entities;

namespace WepApp.Application.Users
{
    public interface ICreateNewUserService
    {
        public Task<Guid> Execute(string username, string fullname);
    }

    public class CreateNewUserService : ICreateNewUserService
    {
        private IUsersRepository _usersRepository { get; set; }
        private IGenderizeService _genderizeService { get; set; }

        public CreateNewUserService(IUsersRepository usersRepository, IGenderizeService genderizeService)
        {
            _usersRepository = usersRepository;
            _genderizeService = genderizeService;
        }

        public async Task<Guid> Execute(string username, string fullname)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username must be filled");
            }

            if (string.IsNullOrWhiteSpace(fullname))
            {
                throw new Exception("Full Name must be filled");
            }

            if (await _usersRepository.ExistAsync(username) == true)
            {
                throw new Exception("Username is duplicated");
            }

            var gender = await _genderizeService.GetAsync(fullname);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                FullName = fullname,
                Gender = gender,
                UserName = username
            };

            await _usersRepository.InsertAsync(user);

            return user.Id;
        }
    }
}
