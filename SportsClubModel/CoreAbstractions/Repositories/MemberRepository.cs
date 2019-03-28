using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.CoreAbstractions.Repositories
{
    public interface MemberRepository
    {
        IEnumerable<Member> All();
    }
}
