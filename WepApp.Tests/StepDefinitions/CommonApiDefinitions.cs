using Newtonsoft.Json;
using WepApp.Tests.Features.Users;

namespace WepApp.Tests.StepDefinitions
{
    [Binding]
    public class CommonApiDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UserTestContext _testContext;
        private readonly TestFixture _testFixture;

        public CommonApiDefinitions(ScenarioContext scenarioContext, UserTestContext testContext, TestFixture testFixture)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _testFixture = testFixture;
        }

        [When(@"call api")]
        public async Task WhenCallApiAsync()
        {
            if (_testContext.HttpMethod == "GET")
            {
                _testContext.ResponseMessage = await _testFixture.Client.GetAsync(_testContext.Url);
            }
            else if (_testContext.HttpMethod == "PUT")
            {
                var bodyJson = JsonConvert.SerializeObject(_testContext.RequestBody);
                HttpContent httpContent = new StringContent(bodyJson, System.Text.Encoding.UTF8, "application/json");

                _testContext.ResponseMessage = await _testFixture.Client.PutAsync(_testContext.Url, httpContent);
            }
            else if (_testContext.HttpMethod == "DELETE")
            {
                _testContext.ResponseMessage = await _testFixture.Client.DeleteAsync(_testContext.Url);
            }
            else if (_testContext.HttpMethod == "POST")
            {
                var bodyJson = JsonConvert.SerializeObject(_testContext.RequestBody);
                HttpContent httpContent = new StringContent(bodyJson, System.Text.Encoding.UTF8, "application/json");

                _testContext.ResponseMessage = await _testFixture.Client.PostAsync(_testContext.Url, httpContent);
            }
        }

        [Then(@"status code is (.*)")]
        public async Task ThenStatusCodeIsAsync(int statusCode)
        {
            var content = await _testContext.ResponseMessage.Content.ReadAsStringAsync();

            ((int)_testContext.ResponseMessage.StatusCode).Should().Be(statusCode);
        }

        [Then(@"exception thrown contain '([^']*)' message")]
        public async void ThenExceptionThrownContainMessage(string exceptionMessage)
        {
            if (_testContext.ResponseMessage.IsSuccessStatusCode)
            {
                exceptionMessage.Should().BeNullOrEmpty();
            }
            else
            {
                var content = await _testContext.ResponseMessage.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(exceptionMessage))
                {
                    content.Should().BeNullOrEmpty();
                }
                else
                {
                    content.Should().ContainAny(exceptionMessage);
                }
            }

        }
    }
}
