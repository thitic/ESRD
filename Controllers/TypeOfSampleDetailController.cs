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
    public class TypeOfSampleDetailController : Controller
    {
        private ESRDEntities db = new ESRDEntities();

        // GET: TypeOfSampleDetail
        public ActionResult Index()
        {
            return View(db.TypeOfSampleDetail.ToList());
        }

        // GET: TypeOfSampleDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSampleDetail typeOfSampleDetail = db.TypeOfSampleDetail.Find(id);
            if (typeOfSampleDetail == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSampleDetail);
        }

        // GET: TypeOfSampleDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfSampleDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeOfSampleDetailName,TypeOfSampleId")] TypeOfSampleDetail typeOfSampleDetail)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfSampleDetail.Add(typeOfSampleDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfSampleDetail);
        }

        // GET: TypeOfSampleDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSampleDetail typeOfSampleDetail = db.TypeOfSampleDetail.Find(id);
            if (typeOfSampleDetail == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSampleDetail);
        }

        // POST: TypeOfSampleDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeOfSampleDetailName,TypeOfSampleId")] TypeOfSampleDetail typeOfSampleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfSampleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfSampleDetail);
        }

        // GET: TypeOfSampleDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSampleDetail typeOfSampleDetail = db.TypeOfSampleDetail.Find(id);
            if (typeOfSampleDetail == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSampleDetail);
        }

        // POST: TypeOfSampleDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfSampleDetail typeOfSampleDetail = db.TypeOfSampleDetail.Find(id);
            db.TypeOfSampleDetail.Remove(typeOfSampleDetail);
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
