﻿using System;
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
    public class ItemModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemModels
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: ItemModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        // GET: ItemModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,cost,damage,strength,intelligence,agility,armor,hpRegen,attackSpeed,health,mana,bootSpeed,SpeedIncrease,ArmorReduction,spellResistance,percentEvasion,percentManaRegen,percentLifeSteal,percentCleave,percentMoveSpeedIncrease,dropsOnDeath,UAM")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(itemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemModel);
        }

        // GET: ItemModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        // POST: ItemModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,cost,damage,strength,intelligence,agility,armor,hpRegen,attackSpeed,health,mana,bootSpeed,SpeedIncrease,ArmorReduction,spellResistance,percentEvasion,percentManaRegen,percentLifeSteal,percentCleave,percentMoveSpeedIncrease,dropsOnDeath,UAM")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemModel);
        }

        // GET: ItemModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        // POST: ItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemModel itemModel = db.Items.Find(id);
            db.Items.Remove(itemModel);
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
