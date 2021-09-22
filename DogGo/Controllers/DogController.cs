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
        public ActionResult Create(Dog dog)
        {
            try
            {
                _dogRepo.Add(dog);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        // GET: DogsControllers/Edit/5
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepo.Get(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: DogsControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            //try
            //{
            _dogRepo.Update(dog);

            return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{
            //    return View(dog);
            //}
        }

        // GET: DogsControllers/Delete/5
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRepo.Get(id);

            return View(dog);
        }

        // POST: DogsControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepo.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }
    }
}
