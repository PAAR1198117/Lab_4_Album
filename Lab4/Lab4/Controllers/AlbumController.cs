using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Clases;
using Lab4.Models;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab4.Controllers
{
    public class AlbumController : Controller
    {
        static Dictionary<string, Estampitas1> dictionary;
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
        [HttpPost]
        public ActionResult ImportarEstampas(HttpPostedFileBase postedFile)
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
                        dictionary = JsonConvert.DeserializeObject<Dictionary<string, Estampitas1>>(content);
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["uploadResult"] = "este no es el archivo correcto";

            }
            return View();
        }
        [HttpPost]
        public ActionResult ImportarEspeciales(HttpPostedFileBase postedFile)
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
                TempData["uploadResult"] = "este no es el archivo correcto";
            }
            return View();
        }
    }
}
