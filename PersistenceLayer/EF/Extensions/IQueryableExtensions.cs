using System;
using System.Linq;
using SportsClubModel.Domain;

namespace PersistenceLayer.EF.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Reservation> InDateInterval(this IQueryable<Reservation> source, DateTime start, DateTime end)
        {
            return source.Where(r => (r.Start >= start && r.Start < end) ||
                 (r.End > start && r.End <= end));
        }

        public static IQueryable<Reservation> ForCourt(this IQueryable<Reservation> source, long courtId)
        {
            return source.Where(r => r.CourtId == courtId);
        }
    }
}