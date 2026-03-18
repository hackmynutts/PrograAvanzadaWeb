using ProjectAgileBoard.API.Models;

namespace ProjectAgileBoard.API.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsersAsync();
        Task<Usuario?> GetUserByIdAsync(int id);
        Task AddUserAsync(Usuario user);
    }
}
