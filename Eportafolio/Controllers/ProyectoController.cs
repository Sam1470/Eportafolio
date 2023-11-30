using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eportafolio.Models;

namespace Eportafolio.Controllers
{
    public class ProyectoController : Controller
    {
        private jvalenzuelaEntities db = new jvalenzuelaEntities();

        // GET: Proyecto
        public ActionResult Index()
        {
            return View(db.Proyectos.ToList());
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos proyectos = db.Proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Imagen,Empresa,Fecha")] Proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                db.Proyectos.Add(proyectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proyectos);
        }

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos proyectos = db.Proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // POST: Proyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Imagen,Empresa,Fecha")] Proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proyectos);
        }

        // GET: Proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyectos proyectos = db.Proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // POST: Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyectos proyectos = db.Proyectos.Find(id);
            db.Proyectos.Remove(proyectos);
            db.SaveChanges();
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
