using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.CoreAbstractions.Repositories
{
    public interface TournamentsRepository
    {
        IEnumerable<Tournament> All();
        Tournament FindById(long id);
        void Add(Tournament tournament);
        void Update(Tournament tournament);
        void Delete(long id);
    }
}
