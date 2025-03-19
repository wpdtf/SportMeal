

namespace Booking.UI.Client
{
    public class ApiClient<T>
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseUrl;

        public ApiClient(Uri baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<T> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{endpoint}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(jsonResponse);
            }

            var error = JsonSerializer.Deserialize<Error>(jsonResponse);

            MessageBox.Show(error.Detail, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return default;
        }

        public async Task<T> PostAsync(string endpoint, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/{endpoint}", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(jsonResponse);
            }

            var error = JsonSerializer.Deserialize<Error>(jsonResponse);

            MessageBox.Show(error.Detail, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return default;
        }

        public async Task<bool> PutAsync(string endpoint, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/{endpoint}", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(jsonResponse);

                MessageBox.Show(error.Detail, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        public async Task<bool> PutNotBodyAsync(string endpoint)
        {

            var response = await _httpClient.PutAsync($"{_baseUrl}/{endpoint}", null);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(jsonResponse);

                MessageBox.Show(error.Detail, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
    }
}
