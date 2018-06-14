using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.EN.Wateral;
using Escuela.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Escuela.Controllers
{
    public class UserRegistradoController : BasicController
    {
        //
        // GET: /UserRegistrado/

        public ActionResult Index()
        {
            ViewBag.Alumno = false;
            ViewBag.Profesor = false;

            if (Session["UserName"] != null)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Alumno")
                {
                    ViewBag.Alumno = true;
                }
                else
                {
                    if (s[0].ToString() == "Profesor")
                    {
                        ViewBag.Profesor = true;
                    }
                }
            }
            UserRegistradoCEN cen = new UserRegistradoCEN();
            IList<UserRegistradoEN> list = cen.ReadAll(0, -1);
            IEnumerable<UserRegistrado> listDef = new AssemblerUserRegistrado().ConvertListENToModel(list);

            return View(listDef);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AIndex()
        {
            UserRegistradoCEN cen = new UserRegistradoCEN();
            IList<UserRegistradoEN> list = cen.ReadAll(0, -1);
            IEnumerable<UserRegistrado> listDef = new AssemblerUserRegistrado().ConvertListENToModel(list);

            return View(listDef);
        }

        //
        // GET: /UserRegistrado/Details/5

        public ActionResult Perfil(string id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                UserRegistrado user = null;
                SessionInitialize();
                UserRegistradoEN userEN = new UserRegistradoCAD(session).ReadOID(Session["UserName"].ToString());
                user = new AssemblerUserRegistrado().ConvertENToModelUI(userEN);
                SessionClose();

                return View(user);
            }
        }

        //
        // GET: /UserRegistrado/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserRegistrado/Create

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

        //
        // GET: /UserRegistrado/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UserRegistrado/Edit/5

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

        //
        // GET: /UserRegistrado/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UserRegistrado/Delete/5

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
