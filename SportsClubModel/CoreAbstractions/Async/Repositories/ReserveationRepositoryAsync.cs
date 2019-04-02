using System.Threading.Tasks;
using SportsClubModel.Domain;
using System;
namespace SportsClubModel.CoreAbstractions.Async.Repositories
{
    public interface ReservationRepositoryAsync
    {
        void Add(Reservation reservation);
        void Remove(Reservation reservation);
        void LoadRelationships(Reservation reservation);
        Task<Reservation> FindByIdAsync(long id);
        Task<Reservation[]> AllReservationsAsync();
        Task<Reservation[]> ReservationsForDayAsync(DateTime day);
        Task<Reservation[]> ReservationsInDateIntervalAsync(DateTime start, DateTime end);
        Task<Reservation[]> ReservationsForCourtInDateIntervalAsync(long courtId, DateTime start, DateTime end);
        Task<Reservation[]> ReservationsForCourtAndDayAsync(long courtId, DateTime day);
    }
}