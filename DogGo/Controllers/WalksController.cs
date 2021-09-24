using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Repositories;
using DogGo.Models;
using DogGo.Models.ViewModels;

namespace DogGo.Controllers
{
    public class WalksController : Controller
    {
        private readonly IDogRepository _dogRepo;
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;

        //ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalksController(
            IDogRepository dogRepository,
            IWalkerRepository walkerRepository,
            IWalkRepository walkRepository)
        {
            _dogRepo = dogRepository;
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepository;
        }
        // GET: WalksController
        public ActionResult Index()
        {
            List<Walk> walks = _walkRepo.Get();

            return View(walks);
        }

        // GET: WalksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalksController/Create
        public ActionResult Create()
        {
            WalkFormViewModel vm = new WalkFormViewModel
            {
                Dogs = _dogRepo.Get(),
                Walkers = _walkerRepo.GetAllWalkers(),
                Walk = new Walk(),
                SelectedDogIds = new List<int>()
            };
            return View(vm);
        }

        // POST: WalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WalkFormViewModel walkFormViewModel)
        {
            foreach(int dogId in walkFormViewModel.SelectedDogIds)
            {
                    _walkRepo.Add(walkFormViewModel.Walk, dogId);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: WalksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
