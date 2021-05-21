using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lr4_Db_MVC_1_.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Lr4_Db_MVC_1_.Controllers
{
    public class AnimesController : Controller
    {
        private Context db = new Context();
        private Proverki.Proverki proverki = new Proverki.Proverki();

        // GET: Animes
        public async Task<ActionResult> Index()
        {
            var anime = db.Anime.Include(a => a.Studio);
            return View(await anime.ToListAsync());
        }

        // GET: Animes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = await db.Anime.FindAsync(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // GET: Animes/Create
        public ActionResult Create()
        {
            ViewBag.StudioId = new SelectList(db.Studio, "Id", "StudioName");
            return View();
        }

        // POST: Animes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,AinmeName,Rating,views,StudioId")] Anime anime, string s)
        {
            if (ModelState.IsValid && 
                proverki.charactersMoreThenOne(anime.AinmeName) && 
                proverki.digitsPositiv(anime.views) && 
                proverki.rating(anime.Rating))
            {
                List<string> characters = s.Split(' ', ',').ToList();
                var b = db.Character.Where(p => p.CharacterName.ToLower() == "Наруто".ToLower());
                await b.ForEachAsync(p => Console.WriteLine(p));
                characters.ForEach(a => anime.Characters.Add(db.Character.Find(int.Parse(a))));
                db.Anime.Add(anime);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StudioId = new SelectList(db.Studio, "Id", "StudioName", anime.StudioId);
            return View(anime);
        }

        // GET: Animes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = await db.Anime.FindAsync(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudioId = new SelectList(db.Studio, "Id", "StudioName", anime.StudioId);
            return View(anime);
        }

        // POST: Animes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,AinmeName,Rating,views,StudioId")] Anime anime)
        {
            if (ModelState.IsValid &&
                proverki.charactersMoreThenOne(anime.AinmeName) &&
                proverki.digitsPositiv(anime.views) &&
                proverki.rating(anime.Rating))
            {
                db.Entry(anime).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StudioId = new SelectList(db.Studio, "Id", "StudioName", anime.StudioId);
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = await db.Anime.FindAsync(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Anime anime = await db.Anime.FindAsync(id);
            db.Anime.Remove(anime);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
