using System.Collections.Generic;

namespace SportsClubModel.Domain
{
    public class Challenge
    {
        public long Id { get; set; }
        public long ReservationId { get; set; }
        public string Result { get; set; }
        public virtual ISet<ChallengeRegistration> ChallengeRegistrations{ get; set; }
    }
}