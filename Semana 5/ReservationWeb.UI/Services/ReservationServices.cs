using ReservationWeb.UI.Models;

namespace ReservationWeb.UI.Services
{
    public class ReservationServices
    {
        private readonly HttpClient _httpClient;// Inyectamos HttpClient para realizar solicitudes HTTP a la API

        public ReservationServices(HttpClient httpClient)
        {// El constructor recibe una instancia de HttpClient,
         // que se inyecta a través de la configuración de servicios en Program.cs
            _httpClient = httpClient;
        }

        public async Task<List<ReservationListModel>> GetReservationsAsync()
        {
            var reservations = await _httpClient.GetAsync("Reservation");// Realizamos una solicitud GET a la API para obtener la lista de reservas
            reservations.EnsureSuccessStatusCode();// Verificamos que la respuesta sea exitosa
            return await reservations.Content.ReadFromJsonAsync<List<ReservationListModel>>();// Leemos el contenido de la respuesta
                                                                                              // y lo deserializamos a una lista de ReservationListModel
        }

        public async Task CreateReservationAsync(CreateReservationModel reservation)
        {
            var response = await _httpClient.PostAsJsonAsync("Reservation", reservation);// Realizamos una solicitud POST a la API para crear una nueva reserva
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear la reserva {errorMessage}");// Si la respuesta no es exitosa, lanzamos una excepción con mensaje de error
            }
        }


    }
}
