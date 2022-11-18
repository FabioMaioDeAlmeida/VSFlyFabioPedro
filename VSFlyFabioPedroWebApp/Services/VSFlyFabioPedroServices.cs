using Newtonsoft.Json;

namespace VSFlyFabioPedroWebApp.Services
{
    public class VSFlyFabioPedroServices: IVSFlyFabioPedroServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURI;

        private VSFlyFabioPedroServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
             _baseURI = "https://localhost:7268/api/";
        }

        public async Task<IEnumerable<VSFlyFabioPedroWebApp.Models.Passager>> GetPassagers()
        {
            var uri = _baseURI + "Passagers";

            var respJSON = await _httpClient.GetAsync(uri);
            respJSON.EnsureSuccessStatusCode();

            var data = await respJSON.Content.ReadAsStringAsync();

            var passagerListe = JsonConvert.DeserializeObject<IEnumerable<VSFlyFabioPedroWebApp.Models.Passager>>(data);
            return passagerListe;
        }
    }
}
