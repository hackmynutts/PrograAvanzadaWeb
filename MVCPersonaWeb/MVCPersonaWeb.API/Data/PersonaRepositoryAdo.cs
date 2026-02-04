namespace MVCPersonaWeb.API.Data
{
    using Microsoft.Data.SqlClient;
    using MVCPersonaWeb.API.Models;
    using MVCPersonaWeb.API.Repositories;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public class PersonaRepositoryAdo : IPersonaRepository
    {
        private readonly string _connectionString;

        public PersonaRepositoryAdo(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            var list = new List<Persona>();
            using var conn = GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre, Apellido, Email, Telefono FROM Personas ORDER BY Nombre";
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Persona
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Telefono = reader.IsDBNull(4) ? null : reader.GetString(4)
                });
            }
            return list;
        }

        public async Task<Persona> GetByIdAsync(int id)
        {
            using var conn = GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre, Apellido, Email, Telefono FROM Personas WHERE Id = @Id";
            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Persona
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Telefono = reader.IsDBNull(4) ? null : reader.GetString(4)
                };
            }
            return null;
        }

        public async Task<int> CreateAsync(Persona persona)
        {
            using var conn = GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            INSERT INTO Personas (Nombre, Apellido, Email, Telefono)
            VALUES (@Nombre, @Apellido, @Email, @Telefono);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = persona.Nombre });
            cmd.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.NVarChar, 100) { Value = (object)persona.Apellido ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 256) { Value = (object)persona.Email ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.NVarChar, 50) { Value = (object)persona.Telefono ?? DBNull.Value });

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return (result != null) ? (int)result : 0;
        }

        public async Task<bool> UpdateAsync(Persona persona)
        {
            using var conn = GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            UPDATE Personas
            SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono
            WHERE Id = @Id";
            cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = persona.Nombre });
            cmd.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.NVarChar, 100) { Value = (object)persona.Apellido ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 256) { Value = (object)persona.Email ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.NVarChar, 50) { Value = (object)persona.Telefono ?? DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = persona.Id });

            await conn.OpenAsync();
            var rows = await cmd.ExecuteNonQueryAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Personas WHERE Id = @Id";
            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });
            await conn.OpenAsync();
            var rows = await cmd.ExecuteNonQueryAsync();
            return rows > 0;
        }
    }


}
