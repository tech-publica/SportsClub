using System;

namespace SportsClubModel.Domain
{
    public class Reservation
    {
        public long Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual Court Court { get; set; }
        public long CourtId {get; set;}
        public long MemberId { get; set; }
        public virtual Member Owner { get; set; }      
        public int NumPlayers { get; set; }

    }
}
