using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db;
        public SuperheroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Superhero
        public ActionResult Index()
        {
            List<Superhero> hero = db.Superheroes.ToList();
            return View(hero);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = db.Superheroes.Where(s => s.Id == id).Select(s => s).SingleOrDefault();
            return View(superhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                db.Superheroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = db.Superheroes.Where(s => s.Id == id).Select(s => s).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(Superhero superhero)
        {
            try
            {
                Superhero newSupe = db.Superheroes.Where(s => s.Id == superhero.Id).Select(s => s).SingleOrDefault();
                newSupe.FirstName = superhero.FirstName;
                newSupe.LastName = superhero.LastName;
                newSupe.AlterEgo = superhero.AlterEgo;
                newSupe.Ability = superhero.Ability;
                newSupe.SecondaryAbility = superhero.SecondaryAbility;
                newSupe.Catchphrase = superhero.Catchphrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = db.Superheroes.Where(s => s.Id == id).Select(s => s).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        public ActionResult Delete(Superhero superhero)
        {
            try
            {
                Superhero newSupe = db.Superheroes.Where(s => s.Id == superhero.Id).Select(s => s).SingleOrDefault();
                db.Superheroes.Remove(newSupe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
