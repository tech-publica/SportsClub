using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.Domain
{
    public class Skill
    {
        public long Id { get; set; }
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
        public string Sport  { get; set; }
        public string Ranking { get; set; }
    }
}
