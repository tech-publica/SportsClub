using System.Collections.Generic;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;

namespace SportsClubModel.CoreAbstractions.UnitsOfWork
{
    public interface ReservationUnitOfWork
    {
        ReservationRepository ReservationRepository { get; set; }
        int Save();
    }
}