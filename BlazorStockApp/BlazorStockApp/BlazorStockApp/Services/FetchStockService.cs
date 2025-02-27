using BlazorStockApp.Shared.Models;
using BlazorStockApp.Shared.DTOs;
using BlazorStockApp.Shared.Mappers;

namespace BlazorStockApp.Services
{
    public class FetchStockService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IStockMapper _stockMapper;

        public FetchStockService(IHttpClientFactory httpClientFactory, IStockMapper stockMapper)
        {
            _httpClientFactory = httpClientFactory;
            _stockMapper = stockMapper;
        }

        public async Task<(Stock? stock, string? errorMessage)> GetStockAsync(string ticker)
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
        
            Stock? stock = null;
            string? errorMessage = null;

            // Check if request was successful
            if (response.IsSuccessStatusCode)
            {
                var stockDTO = await response.Content.ReadFromJsonAsync<Rootobject>();
                stock = _stockMapper.Mapper(stockDTO);
            }
            else
            {
                errorMessage = response.ReasonPhrase;
            }

            return (stock, errorMessage);
        }
    }
}
