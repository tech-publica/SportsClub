using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistenceLayer.EF.Repositories
{
    public class EFMemberRepository : MemberRepository
    {
        private SportsClubContext ctx;
        public EFMemberRepository(SportsClubContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<Member> All()
        {
            return ctx.Members.ToList();
        }
    }
}
