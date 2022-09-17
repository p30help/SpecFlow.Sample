using Newtonsoft.Json;
using WepApp.Domain.Contracts;

namespace WepApp.Infra
{
    public class GenderizeService : IGenderizeService
    {
        IHttpClientFactory _httpClient;

        public GenderizeService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string name)
        {
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri("https://api.genderize.io/");
            var result = client.GetAsync($"?name={name}");
            if(result.Result.IsSuccessStatusCode)
            {
                var resText = await result.Result.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<GenderizeModel>(resText);

                return model.Gender;
            }

            return null;
        }
    }

    public class GenderizeModel
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public decimal Probability { get; set; }

        public int Count { get; set; }
    }
}
