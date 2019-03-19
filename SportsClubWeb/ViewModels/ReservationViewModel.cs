using System.Collections.Generic;
using SportsClubModel.Domain;
using System;
namespace SportsClubWeb.ViewModels
{
    public class ReservationViewModel
    {
        public string Title { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        private IDictionary<long, CourtReservationViewModel> reservationsByCourt;
        private ISet<string> courtNames;
        public ReservationViewModel(IEnumerable<Reservation> reservations, DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            string format = "yyyy-MM-ddTHH:mm";
            Title = (end == DateTime.MinValue || end == Start) ? $"Court Reservations for {Start.ToString(format)}" :
            $"Court Reservations from {Start.ToString(format)} to  {End.ToString(format)}";
            reservationsByCourt = new Dictionary<long, CourtReservationViewModel>();
            courtNames = new HashSet<string>();
            foreach (var res in reservations)
            {
                courtNames.Add(res.Court.Name);
                CourtReservationViewModel model;
                if(!reservationsByCourt.TryGetValue(res.Court.Id, out model))
                {
                    model = new CourtReservationViewModel(res.Court.Id, res.Court.Name);
                    reservationsByCourt[res.Court.Id] = model;
                }
                model.Add(res);
            }
        }
        public ReservationViewModel(IEnumerable<Reservation> reservations, DateTime start) : this(reservations, start, DateTime.MinValue)
        { }

        public CourtReservationViewModel ReservationsForCourt(long courtId) => reservationsByCourt[courtId];
        public IEnumerable<long> CourtIds => reservationsByCourt.Keys;
        public IEnumerable<string> CourtNames => courtNames;

    }
}