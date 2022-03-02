using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Screamplay_simple.Models;


namespace Screamplay_simple.Controllers
{
    public class CharacterController : Controller
    {
        public readonly Screamplay_simpleContext _db;

        public CharacterController(Screamplay_simpleContext db)
        {
            _db = db;
        }
        // GET: CharacterController
        public ActionResult Index()
        {
            ViewData["Title"] = "Character list";
            IEnumerable<Character> characters = _db.Characters;
            return View(characters);
        }

        // GET: CharacterController/Details/5
        public ActionResult Detail(int id)
        {
            if(id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            var character = _db.Characters.Find(id);
            ViewData["Title"] = "Detail: " + character.Name;
            return View(character);
        }

        // GET: CharacterController/Create
        public ActionResult Create()
        {
            ViewData["Title"] = "Create new character: ";
            ViewBag.Screenplays = GetScreenplays();
            return View();
        }

        // POST: CharacterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Character character)
        {
            
            if (ModelState.IsValid)
            {
                _db.Characters.Add(character);
                _db.SaveChanges();
                TempData["Success"] = "Character " + character.Name + " created !";
                return RedirectToAction("Index", "Character");
            }
                return View();
        }

        public IEnumerable<Screenplay> GetScreenplays()
        {
            var screenplayList = _db.Screenplays.ToList();
            return screenplayList;
        }

        // GET: CharacterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CharacterController/Edit/5
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

        // GET: CharacterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CharacterController/Delete/5
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

        public IActionResult DetailModal(int id)
        {
            var character = _db.Characters.Find(id);
            return PartialView("_DetailModalPartial", character);
        }
    }
}
