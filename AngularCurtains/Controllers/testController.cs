﻿
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularCurtains.Controllers
{
    public class testController : Controller
    {
        private readonly IProductServices _productServices;
        public testController()
        {
            _productServices = new ProductServices();
        }
        // GET: test
        public ActionResult Index()
        {
            var products = _productServices.GetAllProducts();
            return View(products);
        }

        // GET: test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: test/Create
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

        // GET: test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: test/Edit/5
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

        // GET: test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: test/Delete/5
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
