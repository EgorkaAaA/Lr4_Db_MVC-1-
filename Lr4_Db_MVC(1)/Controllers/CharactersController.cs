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
    public class CharactersController : Controller
    {
        private Context db = new Context();
        private Proverki.Proverki proverki = new Proverki.Proverki();

        // GET: Characters
        public async Task<ActionResult> Index()
        {
            var character = db.Character.Include(c => c.VoiceActor);
            return View(await character.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Character.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.VoiceActorId = new SelectList(db.VoiceActor, "ID", "VoiceActorName");
            return View();
        }

        // POST: Characters/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CharacterName,CharactersId,VoiceActorId")] Character character)
        {
            if (ModelState.IsValid && proverki.charactersMoreThenOne(character.CharacterName))
            {
                db.Character.Add(character);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VoiceActorId = new SelectList(db.VoiceActor, "ID", "VoiceActorName", character.VoiceActorId);
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Character.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.VoiceActorId = new SelectList(db.VoiceActor, "ID", "VoiceActorName", character.VoiceActorId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CharacterName,CharactersId,VoiceActorId")] Character character)
        {
            if (ModelState.IsValid && proverki.charactersMoreThenOne(character.CharacterName))
            {
                db.Entry(character).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VoiceActorId = new SelectList(db.VoiceActor, "ID", "VoiceActorName", character.VoiceActorId);
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Character.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Character character = await db.Character.FindAsync(id);
            db.Character.Remove(character);
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
