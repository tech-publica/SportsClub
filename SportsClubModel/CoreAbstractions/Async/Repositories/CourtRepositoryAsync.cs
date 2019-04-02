using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubModel.CoreAbstractions.Async.Repositories
{
    public interface CourtRepositoryAsync
    {
        Task<Court> FindByIdAsync(long id);
    }
}
