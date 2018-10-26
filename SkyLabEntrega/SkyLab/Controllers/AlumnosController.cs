#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - AlumnosController.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 29/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="AlumnosController.cs" Compañia="MetallRose">
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
    public class AlumnosController : Controller
    {
        #region Fields

        private readonly SkyLabContext db = new SkyLabContext();

        #endregion

        #region Instance Methods

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona");
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion");
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre");
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PersonaId,PregradoId,UniversidadId,FechaIngreso")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Alumnos.Add(alumnos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", alumnos.PersonaId);
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion", alumnos.PregradoId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", alumnos.UniversidadId);
            return View(alumnos);
        }

        // GET: Alumnos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var alumnos = await db.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var alumnos = await db.Alumnos.FindAsync(id);
            db.Alumnos.Remove(alumnos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Alumnos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var alumnos = await db.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: Alumnos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var alumnos = await db.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", alumnos.PersonaId);
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion", alumnos.PregradoId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", alumnos.UniversidadId);
            return View(alumnos);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PersonaId,PregradoId,UniversidadId,FechaIngreso")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", alumnos.PersonaId);
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion", alumnos.PregradoId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", alumnos.UniversidadId);
            return View(alumnos);
        }

        // GET: Alumnos
        public async Task<ActionResult> Index()
        {
            var alumnos = db.Alumnos.Include(a => a.Personas).Include(a => a.Pregrados).Include(a => a.Universidades);
            return View(await alumnos.ToListAsync());
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
