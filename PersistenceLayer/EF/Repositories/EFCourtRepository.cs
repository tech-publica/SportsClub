using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistenceLayer.EF.Repositories
{
    public class EFCourtRepository : CourtRepository
    {
        private SportsClubContext ctx;
        public EFCourtRepository(SportsClubContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(Court court)
        {
            ctx.Courts.Add(court);
        }

        public void Delete(Court court)
        {
            ctx.Courts.Remove(court);
        }

        public Court FindById(long id)
        {
            return ctx.Courts.Find(id);
        }

        public IEnumerable<Court> List()
        {
            return ctx.Courts.ToList();
        }

        public void Update(Court court)
        {
            ctx.Courts.Update(court);
        }
    }
}
