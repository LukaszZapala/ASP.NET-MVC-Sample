using DatabaseRepository.Models;
using DatabaseRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkSample.Controllers
{
    public class CatController : Controller
    {
        private IPetsRepository petsRepository;

        public CatController()
        {
            petsRepository = new PetsRepository();
        }

        // GET: Cat
        public ActionResult Index()
        {
            var pets = petsRepository.GetAll().Take(1 * 10).ToList();
            return View(pets);
        }

        // GET: Cat
        public ActionResult Details(int id)
        {
            var pet = petsRepository.GetById(id);
            return View(pet);
        }

        // GET: Cat
        public ActionResult Remove(int id)
        {
            petsRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Cat
        public ActionResult Add()
        {
            return View();
        }

        // POST: Cat
        [HttpPost]
        public ActionResult Add(Pet pet)
        {
            petsRepository.Insert(pet);
            return RedirectToAction("Index");
        }

        // GET: Cat
        public ActionResult Update(int id)
        {
            var pet = petsRepository.GetById(id);
            return View(pet);
        }

        // POST: Cat
        [HttpPost]
        public ActionResult UpdatePet(int id, Pet pet)
        {
            this.petsRepository.Update(id, pet);
            return RedirectToAction("Index");
        }
    }
}