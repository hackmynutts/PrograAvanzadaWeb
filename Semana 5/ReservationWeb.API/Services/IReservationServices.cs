namespace ReservationWeb.API.Services
{
    public interface IReservationServices
    {
       Task<List<DTO.ListReservationDTO>> GetReservationsAsync();
        Task AddReservation(DTO.AddReservationDTO reservation);
    }
}
