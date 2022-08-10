using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESRD_Sample01;

namespace ESRD_Sample01.Controllers
{
    public class SampleMasterController : Controller
    {
        private ESRDEntities db = new ESRDEntities();

        // GET: SampleMaster
        public ActionResult Index()
        {
            var sampleMaster = db.SampleMaster.Include(s => s.ContactPerson);
            return View(sampleMaster.ToList());
        }

        // GET: SampleMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleMaster sampleMaster = db.SampleMaster.Find(id);
            if (sampleMaster == null)
            {
                return HttpNotFound();
            }
            return View(sampleMaster);
        }

        // GET: SampleMaster/Create
        public ActionResult Create()
        {
            ViewBag.ContactPersonId = new SelectList(db.ContactPerson, "Id", "PersonName");
            return View();
        }

        // POST: SampleMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Used,Temp,Uncertainty,Container,ContactPersonId")] SampleMaster sampleMaster)
        {
            if (ModelState.IsValid)
            {
                db.SampleMaster.Add(sampleMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactPersonId = new SelectList(db.ContactPerson, "Id", "PersonName", sampleMaster.ContactPersonId);
            return View(sampleMaster);
        }

        // GET: SampleMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleMaster sampleMaster = db.SampleMaster.Find(id);
            if (sampleMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactPersonId = new SelectList(db.ContactPerson, "Id", "PersonName", sampleMaster.ContactPersonId);
            return View(sampleMaster);
        }

        // POST: SampleMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Used,Temp,Uncertainty,Container,ContactPersonId")] SampleMaster sampleMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sampleMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactPersonId = new SelectList(db.ContactPerson, "Id", "PersonName", sampleMaster.ContactPersonId);
            return View(sampleMaster);
        }

        // GET: SampleMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleMaster sampleMaster = db.SampleMaster.Find(id);
            if (sampleMaster == null)
            {
                return HttpNotFound();
            }
            return View(sampleMaster);
        }

        // POST: SampleMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleMaster sampleMaster = db.SampleMaster.Find(id);
            db.SampleMaster.Remove(sampleMaster);
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
