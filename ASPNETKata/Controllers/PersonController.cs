﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETKata.Models;

namespace ASPNETKata.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var list = new List<Person>();
            list.Add(new Person { Age = 14, IsMinor = true, Name = "Harry" });
            list.Add(new Person { Age = 24, IsMinor = false, Name = "John" });
            list.Add(new Person { Age = 17, IsMinor = true, Name = "Doe" });
            list.Add(new Person { Age = 12, IsMinor = true, Name = "Smith" });
            list.Add(new Person { Age = 21, IsMinor = false, Name = "Rakam" });
            list.Add(new Person { Age = 4, IsMinor = true, Name = "Sahith" });
            list.Add(new Person { Age = 25, IsMinor = false, Name = "Mani" });
            list.Add(new Person { Age = 15, IsMinor = true, Name = "Tommy" });
            list.Add(new Person { Age = 19, IsMinor = false, Name = "Sam" });
            return View(list);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
