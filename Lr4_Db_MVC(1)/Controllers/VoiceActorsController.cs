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

namespace Lr4_Db_MVC_1_.Controllers
{
    public class VoiceActorsController : Controller
    {
        private Context db = new Context();

        // GET: VoiceActors
        public async Task<ActionResult> Index()
        {
            return View(await db.VoiceActor.ToListAsync());
        }

        // GET: VoiceActors/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoiceActor voiceActor = await db.VoiceActor.FindAsync(id);
            if (voiceActor == null)
            {
                return HttpNotFound();
            }
            return View(voiceActor);
        }

        // GET: VoiceActors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoiceActors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,VoiceActorName")] VoiceActor voiceActor)
        {
            if (ModelState.IsValid)
            {
                db.VoiceActor.Add(voiceActor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(voiceActor);
        }

        // GET: VoiceActors/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoiceActor voiceActor = await db.VoiceActor.FindAsync(id);
            if (voiceActor == null)
            {
                return HttpNotFound();
            }
            return View(voiceActor);
        }

        // POST: VoiceActors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,VoiceActorName")] VoiceActor voiceActor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiceActor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(voiceActor);
        }

        // GET: VoiceActors/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoiceActor voiceActor = await db.VoiceActor.FindAsync(id);
            if (voiceActor == null)
            {
                return HttpNotFound();
            }
            return View(voiceActor);
        }

        // POST: VoiceActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            VoiceActor voiceActor = await db.VoiceActor.FindAsync(id);
            db.VoiceActor.Remove(voiceActor);
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
