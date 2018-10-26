#region MetallRose

// ***********************************************************************
// Ensamblado         		: SkyLab - SkyLab - PersonasController.cs
// Autor					: Alex Mauricio Palacios Caicedo
// Creado          			: 28/06/2016
// 
// Ultima Modificación por 	: Alex Mauricio Palacios Caicedo
// Ultima Modificación en 	: 29/06/2016
// ***********************************************************************
// <copyright file="PersonasController.cs" Compañia="MetallRose">
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
    public class PersonasController : Controller
    {
        #region Fields

        private readonly SkyLabContext db = new SkyLabContext();

        #endregion

        #region Instance Methods

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "Descripcion");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TipoDocumentoId,NumeroDocumento,Nombres,Apellidos,Sexo,FechaNacimiento,Direccion,CorreoElectronico")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(personas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "Descripcion", personas.TipoDocumentoId);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personas = await db.Personas.FindAsync(id);

            var tipoDocumento = await db.TipoDocumento.FindAsync(personas.TipoDocumentoId);

            personas.TipoDocumento = tipoDocumento;

            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var personas = await db.Personas.FindAsync(id);
            db.Personas.Remove(personas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Personas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personas = await db.Personas.FindAsync(id);

            var tipoDocumento = await db.TipoDocumento.FindAsync(personas.TipoDocumentoId);

            personas.TipoDocumento = tipoDocumento;

            return View(personas);
        }

        // GET: Personas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personas = await db.Personas.FindAsync(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "Descripcion", personas.TipoDocumentoId);
            return View(personas);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TipoDocumentoId,NumeroDocumento,Nombres,Apellidos,Sexo,FechaNacimiento,Direccion,CorreoElectronico")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "Descripcion", personas.TipoDocumentoId);
            return View(personas);
        }

        // GET: Personas
        public async Task<ActionResult> Index()
        {
            var personas = db.Personas.Include(p => p.TipoDocumento);
            return View(await personas.ToListAsync());
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
