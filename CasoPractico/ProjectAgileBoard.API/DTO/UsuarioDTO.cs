namespace ProjectAgileBoard.API.DTO
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PokeNumber { get; set; }
    }
}
