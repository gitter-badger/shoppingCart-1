﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.Models.Shopping;
using ShoppingCart.Models.Repositories.Interface;

namespace ShoppingCart.BackOffice.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<Product> ProductRepository { get; set; }

        public HomeController(IGenericRepository<Product> productRepository)
        {
            ProductRepository = productRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(ProductRepository.GetAll());
        }

        // GET: Home/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetSingle(p => p.Id == id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,DateCreated,DateModified,CreatedBy,ModifiedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                ProductRepository.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetSingle(p => p.Id == id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,DateCreated,DateModified,CreatedBy,ModifiedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductRepository.GetSingle(p => p.Id == id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = ProductRepository.GetSingle(p => p.Id == id);
            ProductRepository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
