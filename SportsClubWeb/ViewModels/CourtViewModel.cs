using AutoMapper;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.ViewModels
{
    public class CourtViewModel
    {
        public long Id { get; set; }
        [Required]
        [StringLength(12, ErrorMessage ="the name must not be longer than 12 characters")]
        public string Name { get; set; }
        [DisplayName("Cost")]
        [Range(5, 50, ErrorMessage = "this must be between 5 and 50")]
        public decimal HourlyCourtCost { get; set; }
        [DisplayName("Illumination Cost")]
        [Range(.5, 3.0, ErrorMessage = "this must be between 0.5 and 3")]
        public decimal HourlyIlluminationCost { get; set; }
        [DisplayName("Is Indoor")]
        public bool IsIndoor { get; set; }
        public Surface Surface { get; set; }
        public CourtType Sport { get; set; }


        public Court ToCourt(IMapper mapper)
        {
            switch(Sport)
            {
                case CourtType.Padel:
                    return mapper.Map<PadelCourt>(this);
                case CourtType.Soccer:
                    return mapper.Map<SoccerCourt>(this);
                case CourtType.Squash:
                    return mapper.Map<SquashCourt>(this);
                default: 
                    return mapper.Map<TennisCourt>(this);
            }
        }

        

    }
}
