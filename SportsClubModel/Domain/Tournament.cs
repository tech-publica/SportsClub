using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsClubModel.Domain
{
    public class Tournament
    {
        public long Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime End{ get; set; }
        public string Level { get; set; }
        public decimal? PrizeMoney { get; set; }
        public bool HasGadgets { get; set; }
    }
}
