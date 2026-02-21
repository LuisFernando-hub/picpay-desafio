using System.Text.Json;

namespace picpay_desafio.Services.Auth
{
    public class AuthorizedService : IAuthorizedService
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://util.devi.tools/api/v2/authorize";

        public AuthorizedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AuthorizeAsync()
        {
            string content = string.Empty;

            var response = await _httpClient.GetAsync(URL);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse>(content);

            return result?.status == "success";
        }

        private class ApiResponse
        {
            public string status {  get; set; }
            public DataResponse data { get; set; }
        }

        private class DataResponse
        {
            public bool authorization { get; set; }
        }
    }
}
