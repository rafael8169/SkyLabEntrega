#region Using

using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using SkyLab.DAL;
using SkyLab.Models;

#endregion

namespace SkyLab.Controllers
{
    public class UniversidadesController : Controller
    {
        #region Readonly & Static Fields

        private readonly SkyLabContext _db = new SkyLabContext();

        #endregion

        #region Instance Methods

        // GET: Universidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Direccion")] Universidades universidades)
        {
            if (ModelState.IsValid)
            {
                _db.Universidades.Add(universidades);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(universidades);
        }

        // GET: Universidades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var universidades = await _db.Universidades.FindAsync(id);
            if (universidades == null)
            {
                return HttpNotFound();
            }
            return View(universidades);
        }

        // POST: Universidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var universidades = await _db.Universidades.FindAsync(id);
            _db.Universidades.Remove(universidades);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Universidades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var universidades = await _db.Universidades.FindAsync(id);
            if (universidades == null)
            {
                return HttpNotFound();
            }
            return View(universidades);
        }

        // GET: Universidades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var universidades = await _db.Universidades.FindAsync(id);
            if (universidades == null)
            {
                return HttpNotFound();
            }
            return View(universidades);
        }

        // POST: Universidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Direccion")] Universidades universidades)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(universidades).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(universidades);
        }

        // GET: Universidades
        public async Task<ActionResult> Index()
        {
            return View(await _db.Universidades.ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
