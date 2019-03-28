using SportsClubModel.CoreAbstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.CoreAbstractions.UnitsOfWork
{
    public interface MemberUnitOfWork
    {
        MemberRepository MemberRepository { get; set; }
        int Save();
    }
}
