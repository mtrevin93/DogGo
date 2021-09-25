using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Repositories;
using DogGo.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(ownerId);

            return View(dogs);
        }

        // GET: DogsControllers/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.Get(id);

            return View(dog);
        }

        // GET: DogsControllers/Create
        [Authorize]
        public ActionResult Create()
        {
            Dog dog = new Dog();

            return View(dog);
        }

        // POST: DogsControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            try
            {
                dog.OwnerId = GetCurrentUserId();

                _dogRepo.Add(dog);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        // GET: DogsControllers/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            int ownerId = GetCurrentUserId();

            Dog dog = _dogRepo.Get(id);

            if (dog == null || dog.Owner.Id != ownerId)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: DogsControllers/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            if (dog.OwnerId == GetCurrentUserId())
            {
                try
                {
                    _dogRepo.Update(dog);
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    return View(dog);
                }
            }
            else return StatusCode(403);
        }

        // GET: DogsControllers/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            int ownerId = GetCurrentUserId();

            Dog dog = _dogRepo.Get(id);

            if (dog == null || dog.Owner.Id != ownerId)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: DogsControllers/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            if (dog.OwnerId == GetCurrentUserId())
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
            else return StatusCode(403);
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
