using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using SportsClubModel.Domain;
using SportsClubWeb.ViewModels;

namespace SportsClubWeb.Controllers
{
    public class CourtController : Controller
    {
        private readonly CourtUnitOfWork courtWork;
        private readonly IMapper mapper;
        public CourtController(CourtUnitOfWork courtWork, IMapper mapper)
        {
            this.courtWork = courtWork;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            var courts = courtWork.CourtRepository.List();
            var courtViewModels = mapper.Map<CourtViewModel[]>(courts);
            return View(courtViewModels);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = courtWork.CourtRepository.FindById(id.Value);
            if (court == null)
            {
                return NotFound();
            }
            var courtViewModel = mapper.Map<CourtViewModel>(court);

            return View(courtViewModel);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,HourlyCourtCost, Sport, HourlyIlluminationCost,HasRoof,Surface")] CourtViewModel courtViewModel)
        {
            if (ModelState.IsValid)
            {

                var court = courtViewModel.ToCourt(mapper);
                courtWork.CourtRepository.Add(court);
                courtWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(courtViewModel);
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = courtWork.CourtRepository.FindById(id.Value);
            if (court == null)
            {
                return NotFound();
            }
            var courtViewModel = mapper.Map<CourtViewModel>(court);
            return View(courtViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,HourlyCourtCost,HourlyIlluminationCost,HasRoof,Surface")] CourtViewModel courtViewModel)
        {
            if (id != courtViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(courtViewModel);
            }

            var court = courtViewModel.ToCourt(mapper);
            courtWork.CourtRepository.Update(court);
            courtWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = courtWork.CourtRepository.FindById(id.Value);
            if (court == null)
            {
                return NotFound();
            }
            var courtVewModel = mapper.Map<CourtViewModel>(court);

            return View(courtVewModel);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var court = courtWork.CourtRepository.FindById(id);
            courtWork.CourtRepository.Delete(court);
            courtWork.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
