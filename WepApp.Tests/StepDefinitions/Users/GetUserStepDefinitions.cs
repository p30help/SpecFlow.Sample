using Newtonsoft.Json;
using WepApp.Domain.Entities;
using WepApp.Tests.Features.Users;

namespace WepApp.Tests.StepDefinitions.Users
{
    [Binding]
    public class GetUserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserTestContext _testContext;
        private readonly TestFixture _testFixture;

        public GetUserStepDefinitions(ScenarioContext scenarioContext, UserTestContext testContext, TestFixture testFixture)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _testFixture = testFixture;
        }

        [When(@"get user with id '([^']*)'")]
        public void WhenWeWantToGetUserWithId(Guid userId)
        {
            _testContext.HttpMethod = "GET";
            _testContext.Url = $"Users/GetUser/{userId}";
        }

        [When(@"get user with username '([^']*)'")]
        public void WhenWeWantToGetUserWithUsername(string username)
        {
            _testContext.HttpMethod = "GET";
            _testContext.Url = $"Users/GetUserByUsername/{username}";
        }

        [Then(@"user id is '([^']*)'")]
        public async Task ThenUserIdIs(Guid userId)
        {
            var content = await _testContext.ResponseMessage.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);
            user.Should().NotBeNull();
            user.Id.Should().Be(userId);
        }

        [Then(@"user name is '([^']*)'")]
        public async Task ThenUserIdIs(string username)
        {
            var content = await _testContext.ResponseMessage.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);
            user.Should().NotBeNull();
            user.UserName.Should().Be(username);
        }
    }
}
