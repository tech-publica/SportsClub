using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.Domain
{
    public class Address
    {
        public long Id { get; set; }
        public string StreetAddress { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZIP  { get; set; }
        public long MemberId { get; set; }

    }
}
