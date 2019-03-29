using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.EF;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.Domain;

namespace SportsClubWeb.Controllers
{
    public class TournamentsController : Controller
    {
       // private readonly SportsClubContext _context;
        private readonly TournamentsRepository repo;

        public TournamentsController(TournamentsRepository tournamentRepo)
        {
           // _context = context;
            repo = tournamentRepo;
        }

        // GET: Tournaments
        public IActionResult Index()
        {
            var tournaments = repo.All();
            return View(tournaments);
        }

        // GET: Tournaments/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tournament = await _context.Tournament
            var tournament = repo.FindById(id.Value);
               
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // GET: Tournaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Start,End,Level,PrizeMoney,HasGadgets")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(tournament);
                // await _context.SaveChangesAsync();
                repo.Add(tournament);
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tournament = await _context.Tournament.FindAsync(id);
            var tournament = repo.FindById(id.Value);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Title,Start,End,Level,PrizeMoney,HasGadgets")] Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // _context.Update(tournament);
                    // await _context.SaveChangesAsync();
                    repo.Update(tournament);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentExists(tournament.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tournament = await _context.Tournament
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var tournament = repo.FindById(id.Value);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            // var tournament = await _context.Tournament.FindAsync(id);
           // var tournament = repo.FindById(id);
            repo.Delete(id);
           // _context.Tournament.Remove(tournament);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournamentExists(long id)
        {
            //return _context.Tournament.Any(e => e.Id == id);
            return repo.FindById(id) != null;
        }
    }
}
