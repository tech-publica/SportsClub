using System.Collections.Generic;
using SportsClubModel.Domain;

namespace SportsClubWeb.ViewModels
{
    public class CourtReservationViewModel
    {
        public List<Reservation> Reservations { get; private set; }
        public long CourtId { get; private set; }
        public string CourtName { get; private set; }
        public CourtReservationViewModel(long courtId, string courtName)
        {
            Reservations = new List<Reservation>();
            CourtId = courtId;
            CourtName = courtName;
        }
        public void Add(Reservation res) 
        {
           Reservations.Add(res);
        }
    }
}