using WepApp.Tests.Features.Users;

namespace WepApp.Tests.StepDefinitions.Users
{
    [Binding]
    public class CreateNewUserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserTestContext _testContext;
        private readonly TestFixture _testFixture;

        public CreateNewUserStepDefinitions(ScenarioContext scenarioContext, UserTestContext testContext, TestFixture testFixture)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _testFixture = testFixture;
        }

        [When(@"create a request for user with '([^']*)' as username and '([^']*)' as fullname")]
        public void WhenCreateARequestForUserWithAsUsernameAndAsFullname(string username, string fullname)
        {
            _testContext.HttpMethod = "POST";
            _testContext.Url = "Users/CreateNewUser";

            _testContext.RequestBody = new Requests.CreateUserRequest()
            {
                UserName = username,
                FullName = fullname
            };
        }

    }
}
