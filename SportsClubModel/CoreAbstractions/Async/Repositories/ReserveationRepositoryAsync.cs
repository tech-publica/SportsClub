using System.Threading.Tasks;
using SportsClubModel.Domain;
using System;
namespace SportsClubModel.CoreAbstractions.Async.Repositories
{
    public interface ReservationRepositoryAsync
    {
        void Add(Reservation reservation);
        Task<Reservation[]> ReservationsForDayAsync(DateTime day);
        Task<Reservation[]> ReservationsInDateIntervalAsync(DateTime start, DateTime end);
        Task<Reservation[]> ReservationsForCourtInDateIntervalAsync(long courtId, DateTime start, DateTime end);
        Task<Reservation[]> ReservationsForCourtAndDayAsync(long courtId, DateTime day);
    }
}