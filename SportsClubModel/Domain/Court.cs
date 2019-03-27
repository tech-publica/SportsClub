using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.Domain
{
    public abstract class Court
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public decimal HourlyCourtCost { get; set; }
        public decimal HourlyIlluminationCost { get; set; }
        public bool IsIndoor { get; set; }
        public Surface Surface { get; set; }

    }
}
