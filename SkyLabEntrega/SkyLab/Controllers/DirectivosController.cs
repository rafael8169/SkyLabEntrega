#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - DirectivosController.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 29/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="DirectivosController.cs" Compañia="MetallRose">
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
    public class DirectivosController : Controller
    {
        #region Fields

        private readonly SkyLabContext db = new SkyLabContext();

        #endregion

        #region Instance Methods

        // GET: Directivos/Create
        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona");
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre");
            return View();
        }

        // POST: Directivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PersonaId,UniversidadId")] Directivos directivos)
        {
            if (ModelState.IsValid)
            {
                db.Directivos.Add(directivos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", directivos.PersonaId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", directivos.UniversidadId);
            return View(directivos);
        }

        // GET: Directivos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var directivos = await db.Directivos.FindAsync(id);
            if (directivos == null)
            {
                return HttpNotFound();
            }
            return View(directivos);
        }

        // POST: Directivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var directivos = await db.Directivos.FindAsync(id);
            db.Directivos.Remove(directivos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Directivos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var directivos = await db.Directivos.FindAsync(id);
            if (directivos == null)
            {
                return HttpNotFound();
            }
            return View(directivos);
        }

        // GET: Directivos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var directivos = await db.Directivos.FindAsync(id);
            if (directivos == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", directivos.PersonaId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", directivos.UniversidadId);
            return View(directivos);
        }

        // POST: Directivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PersonaId,UniversidadId")] Directivos directivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directivos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", directivos.PersonaId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", directivos.UniversidadId);
            return View(directivos);
        }

        // GET: Directivos
        public async Task<ActionResult> Index()
        {
            var directivos = db.Directivos.Include(d => d.Personas).Include(d => d.Universidades);
            return View(await directivos.ToListAsync());
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
