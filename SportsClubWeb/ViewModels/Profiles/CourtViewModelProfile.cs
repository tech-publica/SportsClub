using AutoMapper;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.ViewModels.Profiles
{
    public class CourtViewModelProfile : Profile
    {
        public CourtViewModelProfile()
        {
            this.CreateMap<Court, CourtViewModel>()
            .Include<TennisCourt, CourtViewModel>()
            .Include<PadelCourt, CourtViewModel>()
            .Include<SquashCourt, CourtViewModel>()
            .Include<SoccerCourt, CourtViewModel>()
            .ReverseMap()
            
            .ForMember(c => c.Width, conf => conf.Ignore())
            .ForMember(c => c.Length, conf => conf.Ignore());


            this.CreateMap<CourtViewModel, TennisCourt>()
                .ReverseMap()
                .ForMember( cvm => cvm.Sport, conf => conf.MapFrom( t =>CourtType.Tennis));
            this.CreateMap<CourtViewModel, PadelCourt>()
                .ReverseMap()
                .ForMember(cvm => cvm.Sport, conf => conf.MapFrom(t => CourtType.Padel)); 
            this.CreateMap<CourtViewModel, SquashCourt>()
                .ReverseMap()
                .ForMember(cvm => cvm.Sport, conf => conf.MapFrom(t => CourtType.Squash));
            this.CreateMap<CourtViewModel, SoccerCourt>()
                .ReverseMap()
                .ForMember(cvm => cvm.Sport, conf => conf.MapFrom(t => CourtType.Soccer));

        }
    }
}
