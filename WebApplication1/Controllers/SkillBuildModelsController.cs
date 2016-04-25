using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SkillBuildModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SkillBuildModels
        public ActionResult Index()
        {
            return View(db.SkillBuildModels.ToList());
        }

        // GET: SkillBuildModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillBuildModel skillBuildModel = db.SkillBuildModels.Find(id);
            if (skillBuildModel == null)
            {
                return HttpNotFound();
            }
            return View(skillBuildModel);
        }

        // GET: SkillBuildModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillBuildModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Skill1Prio,Skill2Prio,Skill3Prio,UltiPrio")] SkillBuildModel skillBuildModel)
        {
            if (ModelState.IsValid)
            {
                db.SkillBuildModels.Add(skillBuildModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillBuildModel);
        }

        // GET: SkillBuildModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillBuildModel skillBuildModel = db.SkillBuildModels.Find(id);
            if (skillBuildModel == null)
            {
                return HttpNotFound();
            }
            return View(skillBuildModel);
        }

        // POST: SkillBuildModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Skill1Prio,Skill2Prio,Skill3Prio,UltiPrio")] SkillBuildModel skillBuildModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillBuildModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillBuildModel);
        }

        // GET: SkillBuildModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillBuildModel skillBuildModel = db.SkillBuildModels.Find(id);
            if (skillBuildModel == null)
            {
                return HttpNotFound();
            }
            return View(skillBuildModel);
        }

        // POST: SkillBuildModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkillBuildModel skillBuildModel = db.SkillBuildModels.Find(id);
            db.SkillBuildModels.Remove(skillBuildModel);
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
