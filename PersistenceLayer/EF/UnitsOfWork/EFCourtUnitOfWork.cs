using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceLayer.EF.UnitsOfWork
{
    public class EFCourtUnitOfWork : CourtUnitOfWork
    {
        private readonly SportsClubContext ctx;
        public EFCourtUnitOfWork(SportsClubContext ctx, CourtRepository courtRepository)
        {
            this.ctx = ctx;
            CourtRepository = courtRepository;
        }
        public CourtRepository CourtRepository { get; set; }

        public int Save()
        {
            return ctx.SaveChanges();
        }
    }
}
