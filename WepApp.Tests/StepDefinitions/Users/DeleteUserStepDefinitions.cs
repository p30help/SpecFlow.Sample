using Microsoft.EntityFrameworkCore;
using WepApp.Tests.Features.Users;

namespace WepApp.Tests.StepDefinitions.Users
{
    [Binding]
    public class DeleteUserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserTestContext _testContext;
        private readonly TestFixture _testFixture;

        public DeleteUserStepDefinitions(ScenarioContext scenarioContext, UserTestContext testContext, TestFixture testFixture)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _testFixture = testFixture;
        }

        [When(@"create a request to delete user id '([^']*)'")]
        public void WhenCreateARequestToDeleteUserId(Guid userId)
        {
            _testContext.HttpMethod = "DELETE";
            _testContext.Url = $"Users/DeleteUser/{userId}";
        }

        [Then(@"user id '([^']*)' is not found")]
        public async Task ThenUserIdIsNotFoundAsync(Guid userId)
        {
            var user = await _testFixture.Application.DbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            user.Should().BeNull();
        }
    }
}
