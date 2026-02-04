namespace MVCPersonaWeb.API.Repositories
{
    using MVCPersonaWeb.API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona> GetByIdAsync(int id);
        Task<int> CreateAsync(Persona persona);
        Task<bool> UpdateAsync(Persona persona);
        Task<bool> DeleteAsync(int id);
    }

}
