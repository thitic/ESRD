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
    public class TypeOfSampleController : Controller
    {
        private ESRDEntities db = new ESRDEntities();

        // GET: TypeOfSample
        public ActionResult Index()
        {
            var typeOfSample = db.TypeOfSample.Include(t => t.SampleMaster);
            return View(typeOfSample.ToList());
        }

        // GET: TypeOfSample/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSample typeOfSample = db.TypeOfSample.Find(id);
            if (typeOfSample == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSample);
        }

        // GET: TypeOfSample/Create
        public ActionResult Create()
        {
            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used");
            return View();
        }

        // POST: TypeOfSample/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ChemicalFertilizer,OrganicFertilizer,ChemicalOrganicFertilizer,Water,Soil,Ethanol,Other,SampleMasterId")] TypeOfSample typeOfSample)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfSample.Add(typeOfSample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used", typeOfSample.SampleMasterId);
            return View(typeOfSample);
        }

        // GET: TypeOfSample/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSample typeOfSample = db.TypeOfSample.Find(id);
            if (typeOfSample == null)
            {
                return HttpNotFound();
            }
            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used", typeOfSample.SampleMasterId);
            return View(typeOfSample);
        }

        // POST: TypeOfSample/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ChemicalFertilizer,OrganicFertilizer,ChemicalOrganicFertilizer,Water,Soil,Ethanol,Other,SampleMasterId")] TypeOfSample typeOfSample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfSample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used", typeOfSample.SampleMasterId);
            return View(typeOfSample);
        }

        // GET: TypeOfSample/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSample typeOfSample = db.TypeOfSample.Find(id);
            if (typeOfSample == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSample);
        }

        // POST: TypeOfSample/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfSample typeOfSample = db.TypeOfSample.Find(id);
            db.TypeOfSample.Remove(typeOfSample);
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
