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
        public EFReservationUnitOfWork(SportsClubContext ctx, 
                                       ReservationRepository reservationRepository,
                                       MemberRepository memberRepository,
                                       CourtRepository courtRepository)
        {
            this.ctx = ctx;
            ReservationRepository = reservationRepository;
            MemberRepository = memberRepository;
            CourtRepository = courtRepository;
        }

        public ReservationRepository ReservationRepository { get; set; }
        public MemberRepository MemberRepository { get; set; }
        public CourtRepository CourtRepository { get; set; }

        public int Save()
        {
            return ctx.SaveChanges();
        }
    }
}