namespace MVCPersonaWeb.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using MVCPersonaWeb.Models;

    public class PersonaApiClient : IPersonaService
    {
        private readonly HttpClient _http;
        public PersonaApiClient(HttpClient http) => _http = http;

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<Persona>>("api/personas");
            return result ?? Array.Empty<Persona>();
        }

        public Task<Persona> GetByIdAsync(int id) =>
           _http.GetFromJsonAsync<Persona>($"api/personas/{id}");

        public async Task<int> CreateAsync(Persona p)
        {
            var r = await _http.PostAsJsonAsync("api/personas", p);
            if (!r.IsSuccessStatusCode) return 0;
            var created = await r.Content.ReadFromJsonAsync<Persona>();
            return created?.Id ?? 0;
        }

        public async Task<bool> UpdateAsync(Persona p)
        {
            var r = await _http.PutAsJsonAsync($"api/personas/{p.Id}", p);
            return r.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var r = await _http.DeleteAsync($"api/personas/{id}");
            return r.IsSuccessStatusCode;
        }
    }
}