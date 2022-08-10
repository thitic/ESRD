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
    public class SampleDetailController : Controller
    {
        private ESRDEntities db = new ESRDEntities();

        // GET: SampleDetail
        public ActionResult Index()
        {
            var sampleDetail = db.SampleDetail.Include(s => s.SampleMaster).Include(s => s.TypeOfSampleDetail);
            return View(sampleDetail.ToList());
        }

        // GET: SampleDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleDetail sampleDetail = db.SampleDetail.Find(id);
            if (sampleDetail == null)
            {
                return HttpNotFound();
            }
            return View(sampleDetail);
        }

        // GET: SampleDetail/Create
        public ActionResult Create()
        {
            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used");
            ViewBag.TypeOfSampleDetailId = new SelectList(db.TypeOfSampleDetail, "Id", "TypeOfSampleDetailName");
            return View();
        }

        // POST: SampleDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,No,SampleCodeNames,QuantityPerContainer,TotalContainer,ParameterTested,UnitOfTesting,LabNo,SampleCondition,Price,TypeOfSampleDetailId,SampleMasterId")] SampleDetail sampleDetail)
        {
            if (ModelState.IsValid)
            {
                db.SampleDetail.Add(sampleDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used", sampleDetail.SampleMasterId);
            ViewBag.TypeOfSampleDetailId = new SelectList(db.TypeOfSampleDetail, "Id", "TypeOfSampleDetailName", sampleDetail.TypeOfSampleDetailId);
            return View(sampleDetail);
        }

        // GET: SampleDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleDetail sampleDetail = db.SampleDetail.Find(id);
            if (sampleDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used", sampleDetail.SampleMasterId);
            ViewBag.TypeOfSampleDetailId = new SelectList(db.TypeOfSampleDetail, "Id", "TypeOfSampleDetailName", sampleDetail.TypeOfSampleDetailId);
            return View(sampleDetail);
        }

        // POST: SampleDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,No,SampleCodeNames,QuantityPerContainer,TotalContainer,ParameterTested,UnitOfTesting,LabNo,SampleCondition,Price,TypeOfSampleDetailId,SampleMasterId")] SampleDetail sampleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sampleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SampleMasterId = new SelectList(db.SampleMaster, "Id", "Used", sampleDetail.SampleMasterId);
            ViewBag.TypeOfSampleDetailId = new SelectList(db.TypeOfSampleDetail, "Id", "TypeOfSampleDetailName", sampleDetail.TypeOfSampleDetailId);
            return View(sampleDetail);
        }

        // GET: SampleDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleDetail sampleDetail = db.SampleDetail.Find(id);
            if (sampleDetail == null)
            {
                return HttpNotFound();
            }
            return View(sampleDetail);
        }

        // POST: SampleDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleDetail sampleDetail = db.SampleDetail.Find(id);
            db.SampleDetail.Remove(sampleDetail);
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
