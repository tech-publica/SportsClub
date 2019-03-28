using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.CoreAbstractions.Repositories
{
    public interface MemberRepository
    {
        IEnumerable<Member> All();
        void Add(Member member);
        void Remove(Member member);
        void Update(Member member);
        Member FindById(long id);

    }
}
