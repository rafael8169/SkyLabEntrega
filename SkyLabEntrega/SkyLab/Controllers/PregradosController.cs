#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - PregradosController.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 29/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="PregradosController.cs" Compañia="MetallRose">
//     Copyright (c) MetallRose All rights reserved.
// </copyright>
// ***********************************************************************

#endregion

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
    public class PregradosController : Controller
    {
        #region Fields

        private readonly SkyLabContext db = new SkyLabContext();

        #endregion

        #region Instance Methods

        // GET: Pregrados/Create
        public ActionResult Create()
        {
            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Descripcion");
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre");
            return View();
        }

        // POST: Pregrados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descripcion,UniversidadId,HorarioId")] Pregrados pregrados)
        {
            if (ModelState.IsValid)
            {
                db.Pregrados.Add(pregrados);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Descripcion", pregrados.HorarioId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", pregrados.UniversidadId);
            return View(pregrados);
        }

        // GET: Pregrados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pregrados = await db.Pregrados.FindAsync(id);
            if (pregrados == null)
            {
                return HttpNotFound();
            }
            return View(pregrados);
        }

        // POST: Pregrados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var pregrados = await db.Pregrados.FindAsync(id);
            db.Pregrados.Remove(pregrados);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Pregrados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pregrados = await db.Pregrados.FindAsync(id);
            if (pregrados == null)
            {
                return HttpNotFound();
            }
            return View(pregrados);
        }

        // GET: Pregrados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pregrados = await db.Pregrados.FindAsync(id);
            if (pregrados == null)
            {
                return HttpNotFound();
            }
            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Descripcion", pregrados.HorarioId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", pregrados.UniversidadId);
            return View(pregrados);
        }

        // POST: Pregrados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion,UniversidadId,HorarioId")] Pregrados pregrados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregrados).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HorarioId = new SelectList(db.Horarios, "Id", "Descripcion", pregrados.HorarioId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", pregrados.UniversidadId);
            return View(pregrados);
        }

        // GET: Pregrados
        public async Task<ActionResult> Index()
        {
            var pregrados = db.Pregrados.Include(p => p.Horarios).Include(p => p.Universidades);
            return View(await pregrados.ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
