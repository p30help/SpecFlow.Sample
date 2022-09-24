using Microsoft.AspNetCore.Mvc;
using WepApp.Application.Users;
using WepApp.Domain.Entities;
using WepApp.Requests;

namespace SpecFlow.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ICreateNewUserService _createNewUserService;
        private readonly IGetUserService _getUserService;
        private readonly IGetUserByUsernameService _getUserByUsernameService;
        private readonly IGetUsersService _getUsersService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IDeleteUserService _deleteUserService;

        public UsersController(ILogger<UsersController> logger, ICreateNewUserService createNewUserService, IGetUserService getUserService, IGetUserByUsernameService getUserByUsernameService, IUpdateUserService updateUserService, IDeleteUserService deleteUserService, IGetUsersService getUsersService)
        {
            _logger = logger;
            _createNewUserService = createNewUserService;
            _getUserService = getUserService;
            _getUserByUsernameService = getUserByUsernameService;
            _updateUserService = updateUserService;
            _deleteUserService = deleteUserService;
            _getUsersService = getUsersService;
        }

        [HttpPost("CreateNewUser")]
        public async Task CreateUser(CreateUserRequest request)
        {
            await _createNewUserService.Execute(request.UserName, request.FullName);
        }

        [HttpGet("GetUser/{userId}")]
        public async Task<User> GetUser(Guid userId)
        {
            return await _getUserService.Execute(userId);
        }

        [HttpGet("GetUserByUsername/{username}")]
        public async Task<User> GetUser(string username)
        {
            return await _getUserByUsernameService.Execute(username);
        }

        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await _getUsersService.Execute();
        }

        [HttpPut("UpdateUser/{userId}")]
        public async Task UpdateUser(Guid userId, UpdateUserRequest request)
        {
            await _updateUserService.Execute(userId, request.FullName);
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task DeleteUser(Guid userId)
        {
            await _deleteUserService.Execute(userId);
        }
    }
}