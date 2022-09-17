using WepApp.Domain.Entities;
using WepApp.Tests.Features.Users;

namespace WepApp.Tests.StepDefinitions.Users
{
    [Binding]
    public class CommonUserDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserTestContext _testContext;
        private readonly TestFixture _testFixture;

        public CommonUserDefinitions(ScenarioContext scenarioContext, UserTestContext testContext, TestFixture testFixture)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _testFixture = testFixture;
        }

        [Given(@"a user with '([^']*)' as Id and '([^']*)' as username and '([^']*)' as fullname")]
        public async Task GivenAUserWithAsIdAndAsUsernameAndAsFullname(Guid userId, string username, string fullname)
        {
            _testFixture.Application.DbContext.Users.Add(new User()
            {
                Id = userId,
                FullName = fullname,
                UserName = username,
                Gender = "male"
            });

            await _testFixture.Application.DbContext.SaveChangesAsync();
        }
    }
}
