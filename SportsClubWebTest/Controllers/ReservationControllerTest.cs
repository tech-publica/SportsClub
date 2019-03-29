using AutoMapper;
using Moq;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using SportsClubModel.Domain;
using SportsClubWeb.Controllers;
using SportsClubWeb.ViewModels;
using SportsClubWeb.ViewModels.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace SportsClubWebTest.Controllers
{
    public class ReservationControllerTest
    {
        private IMapper mapper;
        private Mock<ReservationUnitOfWork> mockReservationUW;
        private Mock<ReservationRepository> mockReservationRepo;
        private Mock<MemberRepository> mockMemberRepo;
        private Mock<CourtRepository> mockCourtRepo;

        public ReservationControllerTest()
        {
            mapper = new MapperConfiguration(c =>
                c.AddProfile<ReservationCreateViewModelProfile>()).CreateMapper();
            mockReservationUW = new Mock<ReservationUnitOfWork>();
            mockReservationRepo = new Mock<ReservationRepository>();
            mockMemberRepo = new Mock<MemberRepository>();
            mockCourtRepo = new Mock<CourtRepository>();
            mockReservationUW.SetupGet(u => u.ReservationRepository).Returns(mockReservationRepo.Object);
            mockReservationUW.SetupGet(u => u.MemberRepository).Returns(mockMemberRepo.Object);
            mockReservationUW.SetupGet(u => u.CourtRepository).Returns(mockCourtRepo.Object);
        }

        [Fact]
        public void Create()
        {
           
            var viewModel = new ReservationCreateViewModel
            {
                CourtId = 1,
                NumPlayers = 2,
                MemberId = 1,
                Start = DateTime.Today.AddDays(1).AddHours(12),
                End = DateTime.Today.AddDays(1).AddHours(13)   
            };
            mockReservationRepo.Setup(r =>
                 r.ReservationsForCourtInDateInterval(viewModel.CourtId, viewModel.Start, viewModel.End))
                 .Returns(Enumerable.Empty<Reservation>());
            var controller = new ReservationController(mockReservationUW.Object, mapper);
            var result = controller.Create(viewModel);
            result.Should().BeOfType<RedirectToActionResult>();
            RedirectToActionResult red = result as RedirectToActionResult;
            red.ActionName.Should().Be(nameof(ReservationController.Index));
        }


        [Fact]
        public void CreateShoulFailIfCourtNotAvailable()
        {

            var viewModel = new ReservationCreateViewModel
            {
                CourtId = 1,
                NumPlayers = 2,
                MemberId = 1,
                Start = DateTime.Today.AddDays(1).AddHours(12),
                End = DateTime.Today.AddDays(1).AddHours(13)
            };
            mockReservationRepo.Setup(r =>
                 r.ReservationsForCourtInDateInterval(viewModel.CourtId, viewModel.Start, viewModel.End))
                 .Returns(Enumerable.Repeat(new Reservation(), 1));
            mockMemberRepo.Setup(mr => mr.All()).Returns(Enumerable.Repeat(new Member(), 3));
            mockCourtRepo.Setup(cr => cr.All()).Returns(Enumerable.Repeat(new TennisCourt(), 2));
            var controller = new ReservationController(mockReservationUW.Object, mapper);
            var result = controller.Create(viewModel);
            result.Should().BeOfType<ViewResult>();
            ViewResult view = result as ViewResult;
            view.Model.Should().BeOfType<ReservationCreateViewModel>();
            ReservationCreateViewModel model = view.Model as ReservationCreateViewModel;
            model.Members.Should().NotBeEmpty();
            model.Courts.Should().NotBeEmpty();
        }

    }
}
