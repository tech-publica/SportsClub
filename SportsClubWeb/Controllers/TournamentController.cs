using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersistenceLayer.EF.Repositories.Fakes;
using SportsClubModel.Domain;

namespace SportsClubWeb.Controllers
{
    public class TournamentController : Controller
    {
        private readonly FakeTournamentRepository repo = new FakeTournamentRepository();

        //private readonly IRepository repo;
        //public TournamentController(IRepository repo)
        //{
        //    this.repo = repo;
        //}

        public ActionResult Index()
        {
            var tournaments = repo.All();
            return View(tournaments);
        }

        public ActionResult Details(int id)
        {
            var tournament = repo.FindById(id);
            return View(tournament);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tournament tournament)
        {
            try
            {
                repo.Add(tournament);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tournament);
            }
        }

 
        public ActionResult Edit(int id)
        {
            var tournament = repo.FindById(id);
            return View(tournament);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tournament tournament)
        {
            try
            {
                repo.Update(tournament);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tournament);
            }
        }

       
        public ActionResult Delete(int id)
        {
            var tournament = repo.FindById(id);
            return View(tournament);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                repo.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}