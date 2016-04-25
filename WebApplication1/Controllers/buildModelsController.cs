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
    public class buildModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: buildModels
        public ActionResult List(string searchString)
        {
            var Builds = from m in db.Builds
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Builds = Builds.Where(s => s.Hero.Contains(searchString));
            }
            return View(Builds);
        }
        public ActionResult MoonShardEaten()
        {
            var Builds = from m in db.Builds
                         select m;


            Builds = Builds.Where(s => s.MoonShardEaten == true);
            return View(Builds);
        }
        public ActionResult MoonshardNotEaten()
        {
            var Builds = from m in db.Builds
                         select m;


            Builds = Builds.Where(s =>  s.MoonShardEaten== false);
            return View(Builds);
        }
  
        public ActionResult Index(string searchString)
        {
            var Builds = from m in db.Builds
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Builds = Builds.Where(s => s.Hero.Contains(searchString));
            }
            return View(Builds);
        }

        // GET: buildModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            buildModel buildModel = db.Builds.Find(id);
            if (buildModel == null)
            {
                return HttpNotFound();
            }
            return View(buildModel);
        }

        // GET: buildModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: buildModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hero,Item1,Item2,Item3,Item4,Item5,Item6,MoonShardEaten,level")] buildModel buildModel)
        {
            if (ModelState.IsValid)
            {
                db.Builds.Add(buildModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildModel);
        }

        // GET: buildModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            buildModel buildModel = db.Builds.Find(id);
            if (buildModel == null)
            {
                return HttpNotFound();
            }
            return View(buildModel);
        }
        public ActionResult listOfBuildsByHero(int ID)
        {
            var heroBuilds = db.Builds.Where(a => a.HeroID == ID).ToList();

            var Hero = db.Heroes.Find(ID);
            ViewBag.HeroName = Hero.heroName;
            return View(heroBuilds);
        }
        [HttpGet]
        public ActionResult UserCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserCreate(buildModel build)
        {
            if (ModelState.IsValid)
            {
                db.Builds.Add(build);
                db.SaveChanges();
                return RedirectToAction("listOfBuildsByHero", new { id = build.HeroID });
            }
            return View(build);
        }
        // POST: buildModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hero,Item1,Item2,Item3,Item4,Item5,Item6,MoonShardEaten,level")] buildModel buildModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildModel);
        }

        // GET: buildModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            buildModel buildModel = db.Builds.Find(id);
            if (buildModel == null)
            {
                return HttpNotFound();
            }
            return View(buildModel);
        }
        //public ActionResult listOfBuildsByHero (int ID)
        //{
        //var heroBuilds = db.Builds.Where(a => a.Hero == )
        //}

        // POST: buildModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            buildModel buildModel = db.Builds.Find(id);
            db.Builds.Remove(buildModel);
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
