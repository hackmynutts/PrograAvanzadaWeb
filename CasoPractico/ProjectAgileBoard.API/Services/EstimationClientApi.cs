using System.Net.Http.Json;
namespace ProjectAgileBoard.API.Services
{
    public class EstimationClientApi
    {
        private readonly HttpClient _http;

        public EstimationClientApi(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("EstimationApi");
        }

        public async Task<int> GetEstimationAsync(CancellationToken ct = default)
        {
            var resp = await _http.GetFromJsonAsync<EstimationResponse>("api/estimation", ct);
            return resp?.Estimation ?? 5; // fallback
        }

        private sealed class EstimationResponse
        {
            public int Estimation { get; set; }
        }
    }
}
