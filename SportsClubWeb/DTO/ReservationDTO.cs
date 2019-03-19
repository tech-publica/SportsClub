using System;

namespace SportsClubWeb.DTO
{
    public class ReservationDTO
    {
        public long Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public long CourtId { get; set; }
        public string CourtName {get; set;}
        public long MemberId { get; set; }
        public string MemberFirstname { get; set; }
        public string MemberLastname {get; set;}      
        public int NumPlayers { get; set; }
    }
}