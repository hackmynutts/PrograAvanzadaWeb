using Microsoft.Data.SqlClient;


namespace ReservationWeb.API.DataAccess
{
    public class Reservation_DA : IReservation_DA
    {
        private readonly string _connectionString;

        public Reservation_DA(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Models.Reservation>> GetReservationsAsync()
        {
            var reservations = new List<Models.Reservation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Reservas", connection);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    reservations.Add(new Models.Reservation
                    {
                        Id = reader.GetInt32(0),
                        Paciente = reader.GetString(1),
                        Medico = reader.GetString(2),
                        Especialidad = reader.GetString(3),
                        Fecha = reader.GetDateTime(4),
                        FechaCreacion = reader.GetDateTime(5)
                    });
                }
            }
            return reservations;
        }

        public async Task AddReservation(Models.Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                // Utiliza parámetros para evitar inyecciones SQL
                var command = new SqlCommand("INSERT INTO Reservas (Paciente, Medico, Especialidad, Fecha, FechaCreacion) VALUES (@Paciente, @Medico, @Especialidad, @Fecha, @FechaCreacion)", connection);
                command.Parameters.AddWithValue("@Paciente", reservation.Paciente);// Agrega el parámetro para el paciente
                command.Parameters.AddWithValue("@Medico", reservation.Medico);
                command.Parameters.AddWithValue("@Especialidad", reservation.Especialidad);
                command.Parameters.AddWithValue("@Fecha", reservation.Fecha);
                command.Parameters.AddWithValue("@FechaCreacion", reservation.FechaCreacion);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
