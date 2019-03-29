using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using SportsClubModel.Domain;
using SportsClubWeb.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.Controllers
{
   // [Authorize]
    public class MemberController : Controller
    {
        private readonly MemberUnitOfWork memberWork;
        private readonly IMapper autoMapper;

        public MemberController(MemberUnitOfWork memberUnitOfWork, IMapper mapper)
        {
            memberWork = memberUnitOfWork;
            autoMapper = mapper;
        }

        public IActionResult Index()
        {
            var members = memberWork.MemberRepository.All();
            var memberViewModels = autoMapper.Map<MemberViewModel[]>(members);
            return View(memberViewModels);
        }


        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = memberWork.MemberRepository.FindById(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            var viewModel = autoMapper.Map<MemberViewModel>(member);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // public IActionResult Create([Bind("Id,FirstName,LastName,DateOfBirth,Phone")] MemberViewModel viewModel)
        public IActionResult Create (MemberViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var member = autoMapper.Map<Member>(viewModel);
            memberWork.MemberRepository.Add(member);
            memberWork.Save();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = memberWork.MemberRepository.FindById(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            var viewModel = autoMapper.Map<MemberViewModel>(member);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
       // public IActionResult Edit(long id, [Bind("Id,FirstName,LastName,DateOfBirth,Phone")] MemberViewModel viewModel)
        public IActionResult Edit(long id,  MemberViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var member = memberWork.MemberRepository.FindById(id);
                autoMapper.Map(viewModel, member);
                memberWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (memberWork.MemberRepository.FindById(id) == null)
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

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = memberWork.MemberRepository.FindById(id.Value);
            if (member == null)
            {
                return NotFound();
            }

            var viewModel = autoMapper.Map<MemberViewModel>(member);

            return View(viewModel);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var member = memberWork.MemberRepository.FindById(id);
            memberWork.MemberRepository.Remove(member);
            memberWork.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
