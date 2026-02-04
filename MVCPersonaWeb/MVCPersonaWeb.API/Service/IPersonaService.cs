namespace MVCPersonaWeb.API.Service
{
    using MVCPersonaWeb.API.Models;
    using MVCPersonaWeb.API.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona> GetByIdAsync(int id);
        Task<int> CreateAsync(Persona persona);
        Task<bool> UpdateAsync(Persona persona);
        Task<bool> DeleteAsync(int id);
    }
}
