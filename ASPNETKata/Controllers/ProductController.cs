using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETKata.Models;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;

namespace ASPNETKata.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=Password;";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var list = conn.Query<Product>("SELECT * from Product ORDER BY ProductId DESC");
                return View(list);
            }

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=Password;";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var product = conn.Query<Product>("SELECT * FROM Product WHERE ProductId = @id", new { Id = id}).FirstOrDefault();
                return View(product);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var Name = collection["Name"];
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=Password;";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    conn.Execute("INSERT into Product (Name) Values (@Name)", new { Name = Name });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var Name = collection["Name"];
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=Password;";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    conn.Execute("update product set name = @name where ProductID = @id",new { id = id, name = Name });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var Name = collection["Name"];
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=Password;";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    conn.Execute("DELETE FROM Product WHERE ProductID = @id", new {id = id});
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
    }
}
