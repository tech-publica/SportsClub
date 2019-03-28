using System.Collections.Generic;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;
using System;
using System.Linq;
using PersistenceLayer.EF.Extensions;

namespace PersistenceLayer.EF.Repositories
{
    public class EFReservationRepository : ReservationRepository
    {
        private SportsClubContext ctx;
        public EFReservationRepository(SportsClubContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Reservation> AllReservations()
        {
            return ctx.Reservations.ToList();
        }


        public IEnumerable<Reservation> ReservationsForDay(DateTime day)
        {
            var start = day.Date;
            var end = start.AddHours(23);
            return ctx.Reservations.InDateInterval(start, end);
        }

        public IEnumerable<Reservation> ReservationsInDateInterval(DateTime start, DateTime end)
        {
            return ctx.Reservations.InDateInterval(start, end);
        }

        public IEnumerable<Reservation> ReservationsForCourtAndDay(long courtId, DateTime day)
        {
            var start = day.Date;
            var end = start.AddHours(23);
            return ctx.Reservations.InDateInterval(start, end).ForCourt(courtId);
        }

        public IEnumerable<Reservation> ReservationsForCourtInDateInterval(long courtId, DateTime start, DateTime end)
        {
            return ctx.Reservations.InDateInterval(start, end).ForCourt(courtId);
        }

        public void Add(Reservation reservation)
        {
            ctx.Reservations.Add(reservation);
        }

       
    }
}