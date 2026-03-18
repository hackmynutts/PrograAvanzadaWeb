    namespace ProjectAgileBoard.API.Services
    {
        public class PokeClientApi
        {
            public readonly HttpClient httpClient;
            public PokeClientApi(IHttpClientFactory factory) 
            {
                    httpClient = factory.CreateClient("PokeApi");
            }

            public async Task<int?> GetPokeNumberAsync(CancellationToken ct = default)
            {
                try
                {
                    var response = await httpClient.GetFromJsonAsync<PokemonResponse>($"api/PokeNumber", ct);
                    return response?.pokeID;
                }
                catch (HttpRequestException)
                {
                    // Handle HTTP request errors (e.g., 404 Not Found)
                    return null;
                }
            }

            private sealed class PokemonResponse
            {
                public int pokeID { get; set; }
            }
        }
    }
