using ProjectAgileBoard.API.DTO;

namespace ProjectAgileBoard.API.Services
{
    public interface IUsuariosServices
    {
        public Task<List<UsuarioDTO>> GetAllUsersAsync();
        public Task<UsuarioDTO?> GetUserByIdAsync(int id);
        public Task<UsuarioDTO> CreateUserAsync(UsuarioDTO userDTO);
    }
}
