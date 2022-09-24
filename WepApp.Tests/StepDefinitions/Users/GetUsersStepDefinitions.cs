using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Linq;
using System.Reflection;
using TechTalk.SpecFlow.Assist;
using WepApp.Domain.Entities;
using WepApp.Tests.Features.Users;

namespace WepApp.Tests.StepDefinitions.Users
{
    [Binding]
    public class GetUsersStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserTestContext _testContext;
        private readonly TestFixture _testFixture;

        public GetUsersStepDefinitions(ScenarioContext scenarioContext, UserTestContext testContext, TestFixture testFixture)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _testFixture = testFixture;
        }

        [Given(@"list of users:")]
        public async Task ListOfUsers(Table table)
        {
            var users = table.CreateSet<UserTableRecord>();

            foreach (var user in users)
            {
                _testFixture.Application.DbContext.Users.Add(new User()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.Username,
                    Gender = user.Gender
                });
            }

            await _testFixture.Application.DbContext.SaveChangesAsync();

            //// or
            //var expectedRows = new List<List<string>>();
            //foreach (var row in table.Rows)
            //{
            //    var newRow = new List<string>();
            //    expectedRows.Add(newRow);
            //    foreach (var value in row.Values)
            //    {
            //        newRow.Add(value);
            //    }
            //}
        }

        [When(@"get users")]
        public void WhenGetUsers()
        {
            _testContext.HttpMethod = "GET";
            _testContext.Url = $"Users/GetUsers";
        }

        [Then(@"response body is like '([^']*)'")]
        public async Task ThenResponseBodyIsLike(string expectedJsonFile)
        {
            var apiResponseJson = await _testContext.ResponseMessage.Content.ReadAsStringAsync();

            var expectedJson = await ReadJsonFile(expectedJsonFile);

            JToken.DeepEquals(JArray.Parse(expectedJson),
                JArray.Parse(apiResponseJson))
                .Should()
                .BeTrue();
        }

        public async Task<string> ReadJsonFile(string expectedJsonFile)
        {
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetAssembly(typeof(TestFixture)));

            using (var stream = embeddedProvider.GetFileInfo("Files/" + expectedJsonFile).CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        public class UserTableRecord
        {
            public Guid Id { get; set; }

            public string Username { get; set; }

            public string FullName { get; set; }

            public string Gender { get; set; }
        }

    }
}
