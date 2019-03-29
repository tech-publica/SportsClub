using Microsoft.EntityFrameworkCore;
using PersistenceLayer.EF;
using PersistenceLayer.EF.Repositories;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;
using System;
using Xunit;
using FluentAssertions;

namespace SportsClubWebTest.Repositories
{
    public class ReservationRepositoryTest
    {
        private readonly SportsClubContext ctx;
        private readonly ReservationRepository repo;

        public ReservationRepositoryTest()
        {

            var options = new DbContextOptionsBuilder<SportsClubContext>()
                    .UseInMemoryDatabase("InMemory")
                    .Options;
            ctx = new SportsClubContext(options);
            repo = new EFReservationRepository(ctx);
        }


        [Fact]
        public void ReservationsForCourtInDateInterval_Should_Find_Existing_Reservations()
        {
            DateTime Today12 = DateTime.Today.AddHours(12);
            DateTime Today13_30 = Today12.AddHours(1).AddMinutes(30);
            DateTime Today15 = Today12.AddHours(3);

            // 2 reservations: 12-13:30 and 13:30 14:30
            Reservation[] reservations =
            {
                new Reservation
                {
                    //Id = 1,
                    CourtId = 1,
                    MemberId = 2,
                    NumPlayers = 2,
                    Start = Today12,
                    End = Today13_30
                },
                new Reservation
                {
                    //Id = 1,
                    CourtId = 1,
                    MemberId = 3,
                    NumPlayers = 2,
                    Start = Today13_30,
                    End = Today15
                }
             };
            ctx.Reservations.AddRange(reservations);
            ctx.SaveChanges();


            var res = repo.ReservationsForCourtInDateInterval(1, Today12, Today15);
            res.Should().HaveCount(2);

            res = repo.ReservationsForCourtInDateInterval(1, Today12.AddHours(-2), Today13_30);
            res.Should().HaveCount(1);

            res = repo.ReservationsForCourtInDateInterval(1, Today12.AddHours(-2), Today13_30.AddMinutes(1));
            res.Should().HaveCount(2);

            res = repo.ReservationsForCourtInDateInterval(1, Today13_30, Today15);
            res.Should().HaveCount(1);

            res = repo.ReservationsForCourtInDateInterval(1, Today13_30.AddMinutes(-5), Today15);
            res.Should().HaveCount(2);
        }
    }
}
