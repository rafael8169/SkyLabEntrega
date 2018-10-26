#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - DocentesController.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 29/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="DocentesController.cs" Compañia="MetallRose">
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
    public class DocentesController : Controller
    {
        #region Fields

        private readonly SkyLabContext db = new SkyLabContext();

        #endregion

        #region Instance Methods

        // GET: Docentes/Create
        public ActionResult Create()
        {
            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Descripcion");
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona");
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion");
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre");
            return View();
        }

        // POST: Docentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ContratoId,FechaIngreso,PersonaId,PregradoId,UniversidadId")] Docentes docentes)
        {
            if (ModelState.IsValid)
            {
                db.Docentes.Add(docentes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Descripcion", docentes.ContratoId);
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", docentes.PersonaId);
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion", docentes.PregradoId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", docentes.UniversidadId);
            return View(docentes);
        }

        // GET: Docentes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var docentes = await db.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            return View(docentes);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var docentes = await db.Docentes.FindAsync(id);
            db.Docentes.Remove(docentes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Docentes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var docentes = await db.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            return View(docentes);
        }

        // GET: Docentes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var docentes = await db.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Descripcion", docentes.ContratoId);
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", docentes.PersonaId);
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion", docentes.PregradoId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", docentes.UniversidadId);
            return View(docentes);
        }

        // POST: Docentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ContratoId,FechaIngreso,PersonaId,PregradoId,UniversidadId")] Docentes docentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docentes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Descripcion", docentes.ContratoId);
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Persona", docentes.PersonaId);
            ViewBag.PregradoId = new SelectList(db.Pregrados, "Id", "Descripcion", docentes.PregradoId);
            ViewBag.UniversidadId = new SelectList(db.Universidades, "Id", "Nombre", docentes.UniversidadId);
            return View(docentes);
        }

        // GET: Docentes
        public async Task<ActionResult> Index()
        {
            var docentes = db.Docentes.Include(d => d.Contratos).Include(d => d.Personas).Include(d => d.Pregrados).Include(d => d.Universidades);
            return View(await docentes.ToListAsync());
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
