using System.Text;
using System.Text.Json;

namespace ChatBotProject.Services
{
    public class OllamaService
    {
        private readonly HttpClient _httpClient;

        public OllamaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:11434");
        }

        public async Task<string> Ask(string message)
        {
            var request = new
            {
                model = "llama3.2:3b",
                prompt = message,
                stream = false
            };

            var json = JsonSerializer.Serialize(request);

            var response = await _httpClient.PostAsync(
                "/api/generate",
                new StringContent(json, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                return $"Ollama Error: {await response.Content.ReadAsStringAsync()}";
            }

            var responseJson = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(responseJson);

            return document.RootElement
                .GetProperty("response")
                .GetString() ?? "No response";
        }
    }
}