namespace MVCPersonaWeb.API.Service
{
    using MVCPersonaWeb.API.Models;
    using MVCPersonaWeb.API.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repo;
        public PersonaService(IPersonaRepository repo) => _repo = repo;
        public Task<IEnumerable<Persona>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Persona> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(Persona persona) => _repo.CreateAsync(persona);
        public Task<bool> UpdateAsync(Persona persona) => _repo.UpdateAsync(persona);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }

}
