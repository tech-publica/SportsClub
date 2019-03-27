using SportsClubModel.CoreAbstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.CoreAbstractions.UnitsOfWork
{
    public interface CourtUnitOfWork
    {
        CourtRepository CourtRepository { get; set; }
        int Save();
    }
}
