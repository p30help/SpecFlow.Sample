using Microsoft.AspNetCore.Mvc.Testing;

namespace WepApp.Tests
{
    public class HttpClientBiulder
    {
        private TestWebApplication App { get; }

        public HttpClientBiulder(TestWebApplication app)
        {
            App = app;
        }

        public HttpClientBiulder ApplyToken()
        {
            // apply authorazation token on http client
            // ...

            return this;
        }

        public HttpClient Build()
        {
            // create instance
            return App.CreateClient(new WebApplicationFactoryClientOptions()
            {

            });
        }
    }
}
