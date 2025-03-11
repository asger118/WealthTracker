using WealthTracker.Models.DTOs;

namespace WealthTracker.Services
{
    public class FetchStockService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FetchStockService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(Rootobject? stockDTO, string? errorMessage)> GetStockAsync(string ticker)
        {
            // API URL
            string apiUrl = $"https://query1.finance.yahoo.com/v8/finance/chart/{ticker}";

            // Create request
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);


            // Get client from client factory
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");


            // Send request
            var response = await client.SendAsync(request);
        
            Rootobject? stockDTO = null;
            string? errorMessage = null;

            // Check if request was successful
            if (response.IsSuccessStatusCode)
            {
                stockDTO = await response.Content.ReadFromJsonAsync<Rootobject>();
                Console.WriteLine(stockDTO);
            }
            else
            {
                errorMessage = response.ReasonPhrase;
            }

            return (stockDTO, errorMessage);
        }
    }
}
