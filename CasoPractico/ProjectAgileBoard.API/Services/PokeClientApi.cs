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
            var response = await httpClient.GetFromJsonAsync<PokemonResponse>("PokeNumber", ct);
            return response?.pokeID;
        }

        private sealed class PokemonResponse
            {
                public int pokeID { get; set; }
            }
        }
    }
