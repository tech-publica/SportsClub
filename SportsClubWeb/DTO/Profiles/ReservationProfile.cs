using AutoMapper;
using SportsClubModel.Domain;

namespace SportsClubWeb.DTO.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            this.CreateMap<Reservation, ReservationDTO>()
            .ForMember(dto => dto.MemberFirstname, conf => conf.MapFrom(r => r.Owner.FirstName))
            .ForMember(dto => dto.MemberLastname, conf => conf.MapFrom(r => r.Owner.LastName))
            .ForMember(dto => dto.CourtName, conf => conf.MapFrom(r => r.Court.Name))
            .ReverseMap()
            .ForMember(r => r.Court, conf => conf.Ignore())
            .ForMember(r => r.Court, conf => conf.Ignore());
        }
    }
}