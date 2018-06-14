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
    public class CursoController : BasicController
    {
        //
        // GET: /Curso/

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
            CursoCEN cen = new CursoCEN();
            IList<CursoEN> list = cen.ReadAll(0, -1);
            IEnumerable<Curso> listDef = new AssemblerCurso().ConvertListENToModel(list);

            return View(listDef);
        }
        public ActionResult Kitesurf()
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
            CursoCEN cen = new CursoCEN();
            IList<CursoEN> list = cen.ReadAll(0, -1);
            IEnumerable<Curso> listDef = new AssemblerCurso().ConvertListENToModel(list);

            return View(listDef);
        }
        public ActionResult Windsurf()
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
            CursoCEN cen = new CursoCEN();
            IList<CursoEN> list = cen.ReadAll(0, -1);
            IEnumerable<Curso> listDef = new AssemblerCurso().ConvertListENToModel(list);

            return View(listDef);
        }

        public ActionResult Sup()
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
            CursoCEN cen = new CursoCEN();
            IList<CursoEN> list = cen.ReadAll(0, -1);
            IEnumerable<Curso> listDef = new AssemblerCurso().ConvertListENToModel(list);

            return View(listDef);
        }

        public ActionResult Vela()
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
            CursoCEN cen = new CursoCEN();
            IList<CursoEN> list = cen.ReadAll(0, -1);
            IEnumerable<Curso> listDef = new AssemblerCurso().ConvertListENToModel(list);

            return View(listDef);
        }

        public ActionResult Contratar(int id)
        {

            if (Session["UserName"] != null)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Alumno")
                {
                    ViewBag.Alumno = true;
                    return RedirectToAction("Index", "Alumno");
                }
                else
                {
                    Session["contratado"] = id;
                    Curso detalles = new Curso();
                    try
                    {
                        SessionInitialize();
                        CursoCAD micurso = new CursoCAD(session);
                        CursoEN data = micurso.ReadOID(id);
                        detalles = new AssemblerCurso().ConvertENToModelUI(data);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        SessionClose();
                    }

                    return View(detalles);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //
        // GET: /Curso/Details/5
        
        public ActionResult Details(int id)
        {/*
            Curso curso = null;
            SessionInitialize();
            CursoEN cursoEN = new CursoCAD(session).ReadOIDDefault(id);
            curso = new AssemblerCurso().ConvertENToModelUI(cursoEN);
            SessionClose();*/
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
            CursoCEN cen = new CursoCEN();
            CursoEN curso = cen.ReadOID(id);
            Curso display = new AssemblerCurso().ConvertENToModelUI(curso);

            return View(display);
        }

        //
        // GET: /Curso/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Curso/Create

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
        // GET: /Curso/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Curso/Edit/5

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
        // GET: /Curso/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Curso/Delete/5

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
