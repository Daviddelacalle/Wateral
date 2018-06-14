using System;


using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;


using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.EN.Wateral;

using System.IO;
using Escuela.Controllers;
using Escuela.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Escuela.Controllers
{
    public class LineaCestaController : BasicController
    {
        //
        // GET: /LineaCesta/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        public ActionResult miLinCesta()
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
            ILineaCestaCAD LineaCestacad;
            IList<LineaCestaEN> list;
            ICestaCAD cestaCAD;
            IProductoCAD productoCAD;
            IEnumerable<CestaCompuesta> compuesta;
            try
            {
                SessionInitialize();
                LineaCestacad = new LineaCestaCAD(session);
                cestaCAD = new CestaCAD(session);
                productoCAD = new ProductoCAD(session);
                list = new List<LineaCestaEN>();
                IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);
                double canttot = 0.0;

                foreach (CestaEN ces in cestas)
                {
                    if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                    {

                        Session["Cesta"] = ces.Id;
                        foreach (LineaCestaEN lin in ces.LineasCesta)
                        {
                            list.Add(lin);
                            canttot += lin.Precio;
                        }


                    }
                }
                compuesta = new AssemblerCestaCompuestaController().ConvertListENToModel(list);
                ViewBag.Precio = canttot;
            }
            catch (System.NullReferenceException nologin)
            {
                return Redirect("../Account/Login");
            }
            catch (Exception ex)
            {
                //SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

            return View(compuesta);
        }

        //
        // GET: /LineaCesta/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /LineaCesta/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LineaCesta/Create

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
        // GET: /LineaCesta/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /LineaCesta/Edit/5

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
        // GET: /LineaCesta/Delete/5

        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        public ActionResult Delete(int id)
        {
            ILineaCestaCAD lineaCestaCAD = new LineaCestaCAD();
            lineaCestaCAD.Destroy(id);
            /*try
            {
                SessionInitialize();
                lineaCestaCAD
            }
            catch (Exception ex)
            {
                //SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }*/

            //return View();
            return Redirect("../miLinCesta");
        }

        //
        // POST: /LineaCesta/Delete/5

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
