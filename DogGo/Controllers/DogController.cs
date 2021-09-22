using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Repositories;
using DogGo.Models;

namespace DogGo.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRepo;

        public DogController(IDogRepository dogRepository)
        {
            _dogRepo = dogRepository;
        }
        // GET: DogController
        public ActionResult Index()
        {
            List<Dog> dogs = _dogRepo.Get();

            return View(dogs);
        }

        // GET: DogsControllers/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.Get(id);

            return View(dog);
        }

        // GET: DogsControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogsControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DogsControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DogsControllers/Edit/5
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

        // GET: DogsControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DogsControllers/Delete/5
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
