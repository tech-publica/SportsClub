using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel.CoreAbstractions.Repositories
{
    public interface CourtRepository
    {
        void Add(Court court);
        void Delete(Court court);
        void Update(Court court);
        IEnumerable<Court> All();
        Court FindById(long id);
    }
}
