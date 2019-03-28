using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceLayer.EF.UnitsOfWork
{
    public class EFMemberUnitOfWork : MemberUnitOfWork
    {
        private readonly SportsClubContext ctx;
        public MemberRepository MemberRepository { get; set; }
        public EFMemberUnitOfWork(SportsClubContext ctx, MemberRepository memberRepository)
        {
            this.ctx = ctx;
            MemberRepository = memberRepository;
        }

        

        public int Save()
        {
            return ctx.SaveChanges(); ;
        }
    }
}
