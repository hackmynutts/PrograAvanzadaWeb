namespace ProjectAgileBoard.API.Strategy
{
    public class RandomAPIStrategy : IEstimationStrategy
    {
        private readonly HttpClient _http;
        public RandomAPIStrategy(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("EstimationApi");
        }
        public async Task<int> GetEstimationAsync()
        {
            var response = await _http.GetFromJsonAsync<EstimationResponse>("api/estimationRandom");
            return response?.Estimation ?? 0;
        }

        private sealed class EstimationResponse
        {
            public int Estimation { get; set; }
        }
    }
}
