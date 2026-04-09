using System.Net.Http;

namespace ProjectAgileBoard.API.Strategy
{
    public class FibonacciAPIStrategy : IEstimationStrategy
    {
        private readonly HttpClient _http;
        public FibonacciAPIStrategy(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("EstimationApi");
        }
        public async Task<int> GetEstimationAsync()
        {
            var response = await _http.GetFromJsonAsync<EstimationResponse>("api/estimation");
            return response?.Estimation ?? 0;
        }
        private sealed class EstimationResponse
        {
            public int Estimation { get; set; }
        }
    }
}
