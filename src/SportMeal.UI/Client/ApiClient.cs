using SportMeal.UI.Domain.Models;
using SportMeal.UI.StaticModel;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace SportMeal.UI.Client;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiClient()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000/api/") };
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<object> AuthenticateAsync(AuthDTO request)
    {
        var json = JsonSerializer.Serialize(request, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
        var response = await _httpClient.PostAsync("Auth/auth", content);

        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();

            // Используем JsonDocument для анализа JSON
            using JsonDocument document = JsonDocument.Parse(responseJson);
            // Проверяем наличие свойства "position"
            if (document.RootElement.TryGetProperty("position", out _))
            {
                // Десериализуем как Employee
                try
                {
                    var employee = JsonSerializer.Deserialize<Employee>(responseJson, _jsonOptions);
                    if (employee != null)
                    {
                        UpdateCurrentUser(employee);
                        return employee;
                    }
                }
                catch { }
            }
            else
            {
                // Десериализуем как Client
                try
                {
                    var client = JsonSerializer.Deserialize<Clients>(responseJson, _jsonOptions);
                    if (client != null)
                    {
                        UpdateCurrentUser(client);
                        return client;
                    }
                }
                catch { }
            }

            throw new Exception("Не удалось определить тип пользователя");
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new Exception("Неверный логин или пароль");
        }

        var errorJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        var error = JsonSerializer.Deserialize<Error>(errorJson, _jsonOptions) ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        MessageBox.Show(error.Detail, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception(error.Detail);
    }

    public async Task<Clients> RegisterAsync(RegisterRequest request)
    {
        var json = JsonSerializer.Serialize(request, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
        var response = await _httpClient.PostAsync("Client", content);

        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            var client = JsonSerializer.Deserialize<Clients>(responseJson, _jsonOptions) ?? throw new Exception("Не удалось получить данные клиента");
            return client;
        }

        var errorJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        var error = JsonSerializer.Deserialize<Error>(errorJson, _jsonOptions) ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        MessageBox.Show(error.Detail, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception(error.Detail);
    }

    private void UpdateCurrentUser(dynamic user)
    {
        if (user is Clients client)
        {
            CurrentUser.Id = client.Id;

            CurrentUser.FirstName = client.FirstName;
            CurrentUser.LastName = client.LastName;
            CurrentUser.Email = client.Email;
            CurrentUser.Phone = client.Phone;
        }
        else if (user is Employee employee)
        {
            CurrentUser.Id = employee.Id;

            CurrentUser.FirstName = employee.FirstName;
            CurrentUser.LastName = employee.LastName;
            CurrentUser.Email = employee.Email;
            CurrentUser.Phone = employee.Phone;
            CurrentUser.Position = employee.Position;
        }
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetAsync("Category");
        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Category>>(responseJson) ?? throw new Exception("Не удалось получить список категорий");
        }

        var errorJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        var error = JsonSerializer.Deserialize<Error>(errorJson) ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        MessageBox.Show(error.Detail, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception(error.Detail);
    }

    public async Task<List<Product>> GetProductsAsync(int? categoryId = null)
    {
        var url = categoryId.HasValue
            ? $"Product/category/{categoryId}"
            : "Product";

        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Product>>(responseJson) ?? throw new Exception("Не удалось получить список продуктов");
        }

        var errorJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        var error = JsonSerializer.Deserialize<Error>(errorJson) ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        MessageBox.Show(error.Detail, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception(error.Detail);
    }

    public async Task<List<Order>> GetClientOrdersAsync(int? clientId = null)
    {
        var url = clientId.HasValue
            ? $"Order/client/{clientId}"
            : "Order";

        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Order>>(responseJson) ?? throw new Exception("Не удалось получить список заказов");
        }

        var errorJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        var error = JsonSerializer.Deserialize<Error>(errorJson) ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        MessageBox.Show(error.Detail, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception(error.Detail);
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        var json = JsonSerializer.Serialize(order);
        var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
        var response = await _httpClient.PostAsync("Order", content);

        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
            return JsonSerializer.Deserialize<Order>(responseJson) ?? throw new Exception("Не удалось создать заказ");
        }

        var errorJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        var error = JsonSerializer.Deserialize<Error>(errorJson) ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        MessageBox.Show(error.Detail, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception(error.Detail);
    }

    public async Task AddItemInOrderAsync(int idOrder, OrderItem orderItem)
    {
        var json = JsonSerializer.Serialize(orderItem);
        var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
        var response = await _httpClient.PostAsync($"Order/{idOrder}/items", content);

        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
            return;
        }

        var errorJson = await response.Content.ReadAsStringAsync() ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        var error = JsonSerializer.Deserialize<Error>(errorJson) ?? throw new Exception("Не удалось обработать ответ с ошибкой");
        MessageBox.Show(error.Detail, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception(error.Detail);
    }
}
