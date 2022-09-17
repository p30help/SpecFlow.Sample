using Microsoft.EntityFrameworkCore;
using WepApp.Requests;
using WepApp.Tests.Features.Users;

namespace WepApp.Tests.StepDefinitions.Users
{
    [Binding]
    public class UpdateUserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserTestContext _testContext;
        private readonly TestFixture _testFixture;

        public UpdateUserStepDefinitions(ScenarioContext scenarioContext, UserTestContext testContext, TestFixture testFixture)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _testFixture = testFixture;
        }

        [When(@"create a request to update full name to '([^']*)' for user id '([^']*)'")]
        public void WhenCreateARequestToUpdateFullNameToForUserId(string fullname, Guid userId)
        {
            _testContext.HttpMethod = "PUT";

            _testContext.Url = $"Users/UpdateUser/{userId}";
            _testContext.RequestBody = new UpdateUserRequest()
            {
                FullName = fullname
            };
        }

        [Then(@"fullname changed to '([^']*)' for user id '([^']*)'")]
        public async Task ThenFullnameChangedToForUserIdAsync(string fullname, Guid userId)
        {
            var user = await _testFixture.Application.DbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            user.Should().NotBeNull();
            user.FullName.Should().Be(fullname);
        }

    }
}
