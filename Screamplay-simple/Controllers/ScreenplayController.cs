using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screamplay_simple.Models;

namespace Screamplay_simple.Controllers
{
    public class ScreenplayController : Controller
    {
        private readonly Screamplay_simpleContext _db;
        public ScreenplayController(Screamplay_simpleContext db)
        {
            _db = db;
        }
        // GET: ScreenplayController
        public ActionResult Index()
        {
            ViewData["Title"] = "Screenplays list";
            IEnumerable<Screenplay> screenplays = _db.Screenplays;
            return View(screenplays);
        }

        // GET: ScreenplayController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScreenplayController/Create
        public ActionResult Create()
        {
            ViewData["Title"] = "Add a new Screenplay";
            ViewData["Subtitle"] = "Content to be added later";
            return View();
        }

        // POST: ScreenplayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Screenplay screenplay)
        {
            if (ModelState.IsValid)
            {
                _db.Screenplays.Add(screenplay);
                _db.SaveChanges();
                TempData["Success"] = "Screenplay " + screenplay.Title + " created !";
                return RedirectToAction("Index", "Screenplay");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScreenplayController/Edit/5
        public ActionResult Edit(int id)
        {
            Screenplay screenplay = _db.Screenplays.Find(id);
            if(id != null && id > 0)
            {
                ViewBag.Characters = _db.Characters.Where(x=> x.IdScreenplay == id);
                ViewBag.Locations = _db.Locations.Where(l => l.IdScreenplay == id);
                return View(screenplay);
            }
            return RedirectToAction("Index");
        }

        // POST: ScreenplayController/Edit/5
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

        // GET: ScreenplayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScreenplayController/Delete/5
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
