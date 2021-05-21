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
using Lr4_Db_MVC_1_.Proverki;
using EntityState = System.Data.Entity.EntityState;

namespace Lr4_Db_MVC_1_.Controllers
{
    public class StudiosController : Controller
    {
        private Context db = new Context();
        private Proverki.Proverki proverki = new Proverki.Proverki(); 

        // GET: Studios
        public async Task<ActionResult> Index()
        {
            return View(await db.Studio.ToListAsync());
        }

        // GET: Studios/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = await db.Studio.FindAsync(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // GET: Studios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studios/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudioName")] Studio studio)
        {
            if (ModelState.IsValid && proverki.charactersMoreThenOne(studio.StudioName))
            {
                db.Studio.Add(studio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(studio);
        }

        // GET: Studios/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = await db.Studio.FindAsync(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudioName")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studio);
        }

        // GET: Studios/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = await db.Studio.FindAsync(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Studio studio = await db.Studio.FindAsync(id);
            db.Studio.Remove(studio);
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
