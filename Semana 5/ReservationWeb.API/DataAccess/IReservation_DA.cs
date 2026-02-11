namespace ReservationWeb.API.DataAccess
{
    public interface IReservation_DA
    {
        Task<List<Models.Reservation>> GetReservationsAsync();
        Task AddReservation(Models.Reservation reservation);
    }
}
