using ProjectAgileBoard.API.DTO;
using ProjectAgileBoard.API.Repository;

namespace ProjectAgileBoard.API.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IUsuarioRepository _repository;
        private readonly PokeClientApi _pokeClient;

        public UsuariosServices(IUsuarioRepository repository, PokeClientApi pokeClient)
        {
            _repository = repository;
            _pokeClient = pokeClient;
        }

        public async Task<List<UsuarioDTO>> GetAllUsersAsync()
        {
            var usuarios = await _repository.GetAllUsersAsync();
            return usuarios.Select(u => new UsuarioDTO
            {
                ID = u.ID,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                PokeNumber = u.PokeNumber
            }).ToList();
        }

        //usuario por id
        public async Task<UsuarioDTO?> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null) return null;
            return new UsuarioDTO
            {
                ID = user.ID,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Email = user.Email,
                PokeNumber = user.PokeNumber
            };
        }

        //CREAR USUARIO
        public async Task<UsuarioDTO> CreateUserAsync(UsuarioDTO userDTO)
        {
            var newUser = new Models.Usuario
            {
                Nombre = userDTO.Nombre,
                Apellido = userDTO.Apellido,
                Email = userDTO.Email,
                PokeNumber = await _pokeClient.GetPokeNumberAsync() ?? 1
            };
            await _repository.AddUserAsync(newUser);
            return new UsuarioDTO
            {
                ID = newUser.ID,
                Nombre = newUser.Nombre,
                Apellido = newUser.Apellido,
                Email = newUser.Email,
                PokeNumber = newUser.PokeNumber
            };
        }
    }
}
