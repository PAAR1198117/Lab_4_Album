using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;


namespace WebApplication1.Controllers
{
    public class AlbumController : Controller
    {
        static Dictionary<string, Estampas> dictionary;
        static Dictionary<string, bool> Checking;
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
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

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Album/Edit/5
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

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
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
        public ActionResult ImportarEstampas()
        {
            TempData["uploadResult"] = "";
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                        file.SaveAs(path);
                        TempData["uploadResult"] = "Archivo subido con éxito";

                        var content = System.IO.File.ReadAllText(path);
                        dictionary = JsonConvert.DeserializeObject<Dictionary<string, Estampas>>(content);
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["uploadResult"] = "este archivo no es valido";

            }
            return View();
        }
        public ActionResult ImportarEspeciales()
        {
            TempData["uploadResult"] = "";
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                        file.SaveAs(path);
                        TempData["uploadResult"] = "Archivo subido con éxito";

                        var content = System.IO.File.ReadAllText(path);
                        Checking = JsonConvert.DeserializeObject<Dictionary<string, bool>>(content);

                    }
                }

            }
            catch (Exception ex)
            {
                TempData["uploadResult"] = "este archivo no es valido";

            }
            return View();
        }
    }
}
