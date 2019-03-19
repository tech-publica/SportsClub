using Microsoft.AspNetCore.Mvc;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using SportsClubWeb.ViewModels;
using System;
namespace SportsClubWeb.Controllers
{
    public class ReservationController : Controller
    {
        private ReservationUnitOfWork reservationWork;

        public ReservationController(ReservationUnitOfWork reservationUnitOfWork)
        {
            reservationWork = reservationUnitOfWork;
        }
        public IActionResult Index(DateTime dateOfReservation)
        {
            var res = reservationWork.ReservationRepository.ReservationsForDay (dateOfReservation);
            var reservationViewModel= new ReservationViewModel(res, dateOfReservation, DateTime.MinValue);    
            return View(reservationViewModel);
        }
    }
}