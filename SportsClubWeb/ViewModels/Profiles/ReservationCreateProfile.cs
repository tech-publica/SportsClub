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
            this.CreateMap<ViewModels.ReservationCreateViewModel, Reservation>()
                .ForMember(r => r.Id, (IMemberConfigurationExpression<ViewModels.ReservationCreateViewModel, Reservation, long> conf) => conf.Ignore())
                .ForMember(r => r.Owner, (IMemberConfigurationExpression<ViewModels.ReservationCreateViewModel, Reservation, Member> conf) => conf.Ignore())
                .ForMember(r => r.Court, (IMemberConfigurationExpression<ViewModels.ReservationCreateViewModel, Reservation, Court> conf) => conf.Ignore());     
        }
           
    }
}
