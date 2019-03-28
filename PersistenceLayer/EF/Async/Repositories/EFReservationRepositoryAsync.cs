using System;
using System.Threading.Tasks;
using SportsClubModel.CoreAbstractions.Async.Repositories;
using SportsClubModel.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PersistenceLayer.EF.Extensions;

namespace PersistenceLayer.EF.Async.Repositories
{
    public class EFReservationRepositoryAsync : ReservationRepositoryAsync
    {  
       private SportsClubContext ctx;
        public EFReservationRepositoryAsync(SportsClubContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(Reservation reservation)
        {
            ctx.Reservations.Add(reservation);
        }

        public async Task<Reservation[]> AllReservationsAsync()
        {
            return await ctx.Reservations.ToArrayAsync();
        }

        public async Task<Reservation> FindByIdAsync(long id)
        {
            return await ctx.Reservations.FindAsync(id);
        }

        public void Remove(Reservation reservation)
        {
            ctx.Reservations.Remove(reservation);
        }

        public async Task<Reservation[]> ReservationsForCourtAndDayAsync(long courtId, DateTime day)
        {
           var start = day.Date;
           var end = start.AddHours(23);
           return await ctx.Reservations.InDateInterval(start, end).ForCourt(courtId).ToArrayAsync();
        }

        public async Task<Reservation[]> ReservationsForCourtInDateIntervalAsync(long courtId, DateTime start, DateTime end)
        {
            return await ctx.Reservations.InDateInterval(start, end).ForCourt(courtId).ToArrayAsync();
        }

        public async Task<Reservation[]> ReservationsForDayAsync(DateTime day)
        {
            var start = day.Date;
            var end = start.AddHours(23);
            return await ctx.Reservations.InDateInterval(start, end).ToArrayAsync();
        }

        public async Task<Reservation[]> ReservationsInDateIntervalAsync(DateTime start, DateTime end)
        {
             return await ctx.Reservations.InDateInterval(start, end).ToArrayAsync();
        }    
    }
}