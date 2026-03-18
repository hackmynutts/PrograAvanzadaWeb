using Microsoft.EntityFrameworkCore;
using ProjectAgileBoard.API.Data;
using ProjectAgileBoard.API.Models;

namespace ProjectAgileBoard.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext db) => _context = db;

        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario?> GetUserByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddUserAsync(Usuario user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
