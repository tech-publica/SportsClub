using System.Collections.Generic;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;

namespace SportsClubModel.CoreAbstractions.UnitsOfWork
{
    public interface ReservationUnitOfWork
    {
        ReservationRepository ReservationRepository { get; set; }
        MemberRepository MemberRepository { get; set; }
        CourtRepository CourtRepository { get; set; }
        int Save();
    }
}