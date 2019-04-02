using AutoMapper;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.ViewModels.Profiles
{
    public class ReservationCreateViewModelProfile: Profile
    {

        public ReservationCreateViewModelProfile()
        {
            this.CreateMap<ReservationCreateViewModel, Reservation>()
                .ForMember(r => r.Id,  conf => conf.Ignore())
                .ForMember(r => r.Owner,  conf => conf.Ignore())
                .ForMember(r => r.Court,  conf => conf.Ignore());     
        }
           
    }
}
