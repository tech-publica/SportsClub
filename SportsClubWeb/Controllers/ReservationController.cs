using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using SportsClubModel.Domain;
using SportsClubWeb.ViewModels;
using System;
using System.Linq;

namespace SportsClubWeb.Controllers
{
    public class ReservationController : Controller
    {
        private ReservationUnitOfWork reservationWork;
        private IMapper mapper;


        public ReservationController(ReservationUnitOfWork reservationUnitOfWork, IMapper automapper)
        {
            reservationWork = reservationUnitOfWork;
            mapper = automapper;

        }
        public IActionResult Index()
        {
            var res = reservationWork.ReservationRepository.ReservationsForDay(DateTime.Today);
            var reservationViewModel = new ReservationViewModel(res, DateTime.Today, DateTime.Today.AddHours(23));
            return View(reservationViewModel);
        }

        public IActionResult Create()
        {
            var members = reservationWork.MemberRepository.All();
            var courts = reservationWork.CourtRepository.All();
            ReservationCreateViewModel viewModel = new ReservationCreateViewModel(members, courts);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ReservationCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var members = reservationWork.MemberRepository.All();
                var courts = reservationWork.CourtRepository.All();
                viewModel.FillSelectLists(members, courts);
                return View(viewModel);
            }
            var existingReservation = reservationWork.ReservationRepository
                .ReservationsForCourtInDateInterval(viewModel.CourtId, viewModel.Start, viewModel.End).FirstOrDefault();
            if (existingReservation != null)
            {
                ModelState.AddModelError("", "Sorry, selected court isn't available at the time you requested");
                var members = reservationWork.MemberRepository.All();
                var courts = reservationWork.CourtRepository.All();
                viewModel.FillSelectLists(members, courts);
                return View(viewModel);
            }
            var reservation = mapper.Map<Reservation>(viewModel);
            reservationWork.ReservationRepository.Add(reservation);
            reservationWork.Save();
            return RedirectToAction(nameof(Index));
        }


    }
}