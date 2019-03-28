using System.Collections.Generic;
using SportsClubModel.Domain;

namespace SportsClubWeb.ViewModels
{
    public class CourtReservationViewModel
    {
        public List<Reservation> Reservations { get; private set; }
        public long CourtId { get; private set; }
        public string CourtName { get; private set; }
        public Surface Surface { get; private set; }
        public CourtReservationViewModel(long courtId, string courtName, Surface surface)
        {
            Reservations = new List<Reservation>();
            CourtId = courtId;
            CourtName = courtName;
            Surface = surface;
        }
        public void Add(Reservation res) 
        {
           Reservations.Add(res);
        }
        public string BackGroundColorClass
        {
            get
            {
                switch (Surface)
                {
                    case Surface.Grass: return "bg-success";
                    case Surface.Clay: return "bg-danger";
                    default: return "bg-info";
                }
            }
        }
    }
}