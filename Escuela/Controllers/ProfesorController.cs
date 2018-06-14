using Escuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;

namespace Escuela.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Profesor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profesor/Create
        public ActionResult Create(string usu)
        {
            Session["proxprof"] = usu;
            ProfesorFormModel modeloform = new ProfesorFormModel();
            IList<String> deportes = new List<String>();
            deportes.Add("Kitesurf");
            deportes.Add("Windsurf");
            deportes.Add("Paddlesurf");
            deportes.Add("Vela");
            ViewBag.Deportes = deportes;
            return View(modeloform);
        }

        // POST: Profesor/Create
        [HttpPost]
        public ActionResult Create(ProfesorFormModel formulario, string deporte)
        {
            var deporteDEF = WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf;
            try
            {
                ProfesorCEN creator = new ProfesorCEN();

                switch (deporte)
                {
                    case "0": deporteDEF = WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf; break;
                    case "1": deporteDEF = WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf; break;
                    case "2": deporteDEF = WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.sup; break;
                    case "4": deporteDEF = WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.vela; break;

                }

                creator.New_(formulario.NIF, formulario.Disponibilidad, Session["proxprof"].ToString(),deporteDEF);
                return RedirectToAction("CambiarRol", "Admin", new { user = Session["proxprof"], arol = "User_registrado", nrol = "Profesor" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profesor/Edit/5
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

        // GET: Profesor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profesor/Delete/5
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
