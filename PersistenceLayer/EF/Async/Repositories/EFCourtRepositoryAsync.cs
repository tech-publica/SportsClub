using SportsClubModel.CoreAbstractions.Async.Repositories;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.EF.Async.Repositories
{
    public class EFCourtRepositoryAsync : CourtRepositoryAsync
    {
        private SportsClubContext ctx;
        public EFCourtRepositoryAsync(SportsClubContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Court> FindByIdAsync(long id)
        {
            return await ctx.Courts.FindAsync(id);
        }
    }
}
