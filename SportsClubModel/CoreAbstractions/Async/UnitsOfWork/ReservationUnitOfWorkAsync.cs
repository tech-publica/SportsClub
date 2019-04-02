using System.Threading.Tasks;
using SportsClubModel.CoreAbstractions.Async.Repositories;

namespace SportsClubModel.CoreAbstractions.Async.UnitsOfWork
{
    public interface ReservationUnitOfWorkAsync
    {
         ReservationRepositoryAsync ReservationRepository { get; set; }
         CourtRepositoryAsync CourtRepository { get; set; }
        Task<int> SaveAsync();
    }
}