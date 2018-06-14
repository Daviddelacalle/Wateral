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

using Escuela.Controllers;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Escuela.Controllers
{
    public class MensajeController : BasicController
    {

        // GET: Mensaje
        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
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
            IList<MensajeEN> mensajotes = new List<MensajeEN>();

            try
            {
                SessionInitialize();
                MensajeCAD cad = new MensajeCAD(session);
                IList<MensajeEN> mensajes = cad.ReadAll(0, -1);
                foreach (MensajeEN mensajito in mensajes)
                {
                    if (mensajito.UserRegistrado.Email.Equals(Session["UserName"].ToString()) || mensajito.UserRegistrado_0.Email.Equals(Session["UserName"].ToString()))
                    {
                        if (mensajito.UserRegistrado_0.Email.Equals(Session["UserName"].ToString()))
                        {
                            MensajeCEN cen = new MensajeCEN();
                            cen.Modify(mensajito.Id,mensajito.Mensaje,mensajito.Fecha,true);
                        }

                        mensajotes.Insert(0, mensajito);
                    }
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SessionClose();
            }
           
            IEnumerable<Mensaje> paravista = new AssemblerMensaje().ConvertListENToModel(mensajotes);
            return View(paravista);
        }



        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        public JsonResult Check()
        {
            
            int no_leidos = 0;

            try
            {
                SessionInitialize();
                MensajeCAD cad = new MensajeCAD(session);
                IList<MensajeEN> mensajes = cad.ReadAll(0, -1);
                foreach (MensajeEN mensajito in mensajes)
                {
                    if (Session["UserName"]!=null && mensajito.UserRegistrado_0.Email.Equals(Session["UserName"].ToString()))
                    {
                        if (mensajito.Leido == false)
                        {
                            no_leidos++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SessionClose();
            }

            var result = new { num = no_leidos};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Mensaje/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mensaje/Responder/destinatario
        [Authorize(Roles = "User_registrado, Profesor, Alumno")]
        public ActionResult Responder(string destinatario)
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
            Mensaje mensaje = new Mensaje();
            ViewData["Receptor"] = destinatario + "." + Session["UserName"].ToString().Split('.')[1];
            return View(mensaje);
        }

        // POST: Mensaje/Create
        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        [HttpPost]
        public ActionResult Responder(Mensaje men)
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
            try
            {
                // TODO: Add insert logic here
                MensajeCEN cen = new MensajeCEN();
                cen.New_(men.Texto, DateTime.Now, Session["UserName"].ToString(), men.Receptor,false);
                return Redirect("/Mensaje/Index");
            }
            catch(Exception e)
            {
                throw e;
                //return View();
            }
        }

        // GET: Mensaje/Create
        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        public ActionResult Create()
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
            Mensaje mensaje = new Mensaje();
            return View(mensaje);
        }

        // POST: Mensaje/Create
        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        [HttpPost]
        public ActionResult Create(Mensaje men, FormCollection collection)
        {
            try
            {
                UserRegistradoCEN us_cen = new UserRegistradoCEN();
                UserRegistradoEN res = us_cen.ReadOID(men.Receptor);
                MensajeCEN cen = new MensajeCEN();
                cen.New_(men.Texto, DateTime.Now, Session["UserName"].ToString(), men.Receptor,false);
                return Redirect("/Mensaje/Index");
            }
            catch
            {
                ViewData["Error"] = "true";
                return View();
            }
        }

        // GET: Mensaje/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mensaje/Edit/5
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

        // GET: Mensaje/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mensaje/Delete/5
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
