using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace QualifoodRestApiExample
{
    class QualifoodHttpClient
    {
        private const string BaseAddress = "https://testapi.qualifood.de/api/1/";
        private const string ApiKey = "Ihr persoenlicher Api Key";
        readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        private static string _jwtToken;

        public async Task LogIn(string qualifoodBenutzername, string qualifoodPasswort)
        {
            var benutzer = new BenutzerModel() {Benutzername = qualifoodBenutzername, Passwort = qualifoodPasswort};
            var content = new StringContent(JsonSerializer.Serialize(benutzer), Encoding.UTF8, MediaTypeNames.Application.Json);

            var client = GetClient();
            var response = (await client.PostAsync("benutzer/login", content));
            response.EnsureSuccessStatusCode();

            var resultcontent = await response.Content.ReadAsStringAsync();
            LoginResponseModel result = JsonSerializer.Deserialize<LoginResponseModel>(resultcontent, _jsonOptions);
            _jwtToken = result.Token;
        }
        
        public async Task<IEnumerable<QualiDocDokumentenBereichModel>> GetDokumentenbereiche()
        {
            var client = GetClient();
            var response = await client.GetAsync("qualidoc/dokumentenbereich");
            response.EnsureSuccessStatusCode();

            var resultcontent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<QualiDocDokumentenBereichModel>>(resultcontent, _jsonOptions);
            return result;
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
            client.DefaultRequestHeaders.Add("accept", "*/*");
            client.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);

            if (_jwtToken != null)
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _jwtToken);
            }

            return client;
        }
    }
}
