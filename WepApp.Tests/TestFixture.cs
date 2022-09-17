using Microsoft.Extensions.Configuration;

namespace WepApp.Tests
{
    public class TestFixture
    {
        public TestWebApplication Application { get; }

        public HttpClient Client { get; }

        public IConfiguration Configuration { get; set; }

        public TestFixture()
        {

            Configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .Build();

            Application =  new TestWebApplication(Configuration);

            Client = new HttpClientBiulder(Application)
                .ApplyToken()
                .Build();

        }   
    }
}
