using ProjectAgile.UI.Models;

namespace ProjectAgile.UI.Services
{
    public interface IUserApiClient
    {
        public Task<List<UserViewModel>> GetUsersAsync(CancellationToken cancellationToken = default);
        public Task AddUserAsync(string nombre, string apellido, string email, int pokeNumber, CancellationToken cancellationToken = default);
    }
}
