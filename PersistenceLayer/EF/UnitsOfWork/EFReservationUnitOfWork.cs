using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using SportsClubModel.Domain;

namespace PersistenceLayer.EF.UnitsOfWork
{
    public class EFReservationUnitOfWork : ReservationUnitOfWork
    {
        private readonly SportsClubContext ctx;
        public EFReservationUnitOfWork(SportsClubContext ctx, ReservationRepository reservationRepository)
        {
            this.ctx = ctx;
            ReservationRepository = reservationRepository;
        }

        public ReservationRepository ReservationRepository { get; set; }

        public int Save()
        {
            return ctx.SaveChanges();
        }
    }
}