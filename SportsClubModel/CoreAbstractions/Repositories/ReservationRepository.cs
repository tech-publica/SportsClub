using System.Collections.Generic;
using SportsClubModel.Domain;
using System;
namespace SportsClubModel.CoreAbstractions.Repositories
{
    public interface ReservationRepository
    {
        IEnumerable<Reservation> AllReservations();
        IEnumerable<Reservation> ReservationsForDay(DateTime day);
        IEnumerable<Reservation> ReservationsInDateInterval(DateTime start, DateTime end);
        IEnumerable<Reservation> ReservationsForCourtInDateInterval(long courtId, DateTime start, DateTime end);
        IEnumerable<Reservation> ReservationsForCourtAndDay(long courtId, DateTime day);
        void Add(Reservation reservation);

    }
}