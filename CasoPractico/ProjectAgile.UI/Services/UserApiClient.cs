using ProjectAgile.UI.Models;

namespace ProjectAgile.UI.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient) => _httpClient = httpClient;

        //List Users
        public async Task<List<UserViewModel>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetFromJsonAsync<List<UserViewModel>>("api/Usuario", cancellationToken)
                ?? new List<UserViewModel>();
        }

        //add user
        public async Task AddUserAsync(string nombre, string apellido, string email, int pokeNumber, CancellationToken cancellationToken = default)
        {
            var user = new UserViewModel
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                PokeNumber = pokeNumber
            };
            var response = await _httpClient.PostAsJsonAsync("api/Usuario", user, cancellationToken);
            response.EnsureSuccessStatusCode();
        }
    }
}
