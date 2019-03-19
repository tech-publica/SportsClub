using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.Domain
{
    public class Member
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set;}       
        public string Phone { get; set; }
        public virtual Address Address { get; set; }
        public virtual ISet<Skill> Skills { get; set; }
        public virtual ISet<Reservation> Reservations { get; set; }
        public virtual ISet<ChallengeRegistration> ChallengeRegistrations { get; set; }
    }
}
