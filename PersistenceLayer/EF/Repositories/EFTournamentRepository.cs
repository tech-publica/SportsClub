using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistenceLayer.EF.Repositories
{
    public class EFTournamentRepository : TournamentsRepository
    {

        private readonly SportsClubContext ctx;
        public EFTournamentRepository(SportsClubContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(Tournament tournament)
        {
            this.ctx.Tournament.Add(tournament);
            this.ctx.SaveChanges();
        }

        public IEnumerable<Tournament> All()
        {
            return ctx.Tournament.ToList();
        }

        public void Delete(long id)
        {

            var tournament = ctx.Tournament.Find(id);
            ctx.Tournament.Remove(tournament);
            ctx.SaveChanges();
        }

        public Tournament FindById(long id)
        {
            return ctx.Tournament.Find(id);
        }

        public void Update(Tournament tournament)
        {
            ctx.Tournament.Update(tournament);
            ctx.SaveChanges();
        }
    }
}
