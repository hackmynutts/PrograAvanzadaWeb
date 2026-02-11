using ReservationWeb.API.DataAccess;
using ReservationWeb.API.DTO;
using ReservationWeb.API.Exceptions;

namespace ReservationWeb.API.Services
{
    public class ReservationServices : IReservationServices
    {
        private readonly IReservation_DA _reservationDA;
        public ReservationServices(IReservation_DA reservationDA)
        {
            _reservationDA = reservationDA;
        }
        public async Task<List<ListReservationDTO>> GetReservationsAsync()
        {
            var reservations = await _reservationDA.GetReservationsAsync();
            return reservations.Select(r => new ListReservationDTO
            {
                Id = r.Id,
                Paciente = r.Paciente,
                Medico = r.Medico,
                Especialidad = r.Especialidad,
                Fecha = r.Fecha
            }).ToList();
        }
        public async Task AddReservation(AddReservationDTO reservation)
        {
            DateValidation(reservation.Fecha);
            var newReservation = new Models.Reservation
            {
                Paciente = reservation.Paciente,
                Medico = reservation.Medico,
                Especialidad = reservation.Especialidad,
                Fecha = reservation.Fecha,
                FechaCreacion = DateTime.Now
            };
            await _reservationDA.AddReservation(newReservation);
        }

        public void DateValidation(DateTime _dateTime)
        {
            if (_dateTime < DateTime.Now)
            {
                throw new BusinessExceptions("La fecha de la reserva no puede ser anterior a la fecha actual.");
                //Exception("La fecha de la reserva no puede ser anterior a la fecha actual.");
            }
        }
    }
}
