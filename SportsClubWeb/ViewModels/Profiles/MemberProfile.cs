using AutoMapper;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.ViewModels.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            this.CreateMap<Member, MemberViewModel>()
            .ForMember(mv => mv.StreetAddress, conf => conf.MapFrom(m => m.Address.StreetAddress))
            .ForMember(mv => mv.StreetNumber, conf => conf.MapFrom(m => m.Address.StreetNumber))
            .ForMember(mv => mv.ZIP, conf => conf.MapFrom(m => m.Address.ZIP))
            .ReverseMap()
           
            .ForMember(m => m.ChallengeRegistrations, conf => conf.Ignore())
            .ForMember(m => m.Reservations, conf => conf.Ignore())
            .ForMember(m => m.Skills, conf => conf.Ignore());

        }
    }
}
