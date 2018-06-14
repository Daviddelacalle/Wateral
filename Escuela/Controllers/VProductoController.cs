using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.EN.Wateral;
using Escuela.Models;


namespace Escuela.Controllers
{
    public class VProductoController : Controller
    {
        // GET: VProducto
        public ActionResult Index()
        {
            return View();
        }

        // GET: VProducto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VProducto/Create
        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        public ActionResult Create()
        {
            ValoracionProductoCEN cen = new ValoracionProductoCEN();
            IList<ValoracionProductoEN> en = cen.ReadAll(0, -1);
            foreach (ValoracionProductoEN prod in en)
            {
                if (prod.UserRegistrado.Email.Equals(Session["UserName"].ToString()) && prod.Producto.Id == (int)Session["Alquiler"])
                {
                    return Redirect("/Producto");
                }
            }
            ValoracionProdForm modelo = new ValoracionProdForm();
            return View(modelo);
        }

        // POST: VProducto/Create
        [HttpPost]
        public ActionResult Create(ValoracionProdForm modelo)
        {
            try
            {   // TODO: Add insert logic here
                WateralGenNHibernate.CP.Wateral.ValoracionProductoCP cp = new WateralGenNHibernate.CP.Wateral.ValoracionProductoCP();
                cp.ValorarProducto(modelo.nota, Session["UserName"].ToString(), (int)Session["Alquiler"],modelo.comentario);
                return Redirect("../../producto/DetalleProducto/" + (int)Session["Alquiler"]);
            }
            catch(Exception e)
            {
                throw e;
            }
        }



        [HttpPost]
        public ActionResult Valorar(int nota, String comentario)
        {
            try
            {   // TODO: Add insert logic here
                ValoracionProductoCEN cen = new ValoracionProductoCEN();
                IList<ValoracionProductoEN> en = cen.ReadAll(0, -1);
                foreach (ValoracionProductoEN prod in en)
                {
                    if (prod.UserRegistrado.Email.Equals(Session["UserName"].ToString()) && prod.Producto.Id == (int)Session["Alquiler"])
                    {
                        return Redirect("../producto/DetalleProducto/" + (int)Session["Alquiler"]);
                    }
                }

                if (comentario != "")
                {
                    WateralGenNHibernate.CP.Wateral.ValoracionProductoCP cp = new WateralGenNHibernate.CP.Wateral.ValoracionProductoCP();
                    cp.ValorarProducto(nota, Session["UserName"].ToString(), (int)Session["Alquiler"], comentario);
                    
                }
                return Redirect("../producto/DetalleProducto/" + (int)Session["Alquiler"]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }





        // GET: VProducto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VProducto/Edit/5
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

        // GET: VProducto/Delete/5
        public ActionResult Delete(int val)
        {
            ValoracionProductoCEN valoracionProductoCEN = new ValoracionProductoCEN();
            valoracionProductoCEN.Destroy(val);
            return Redirect("../producto/DetalleProducto/" + (int)Session["Alquiler"]);
        }


        // POST: VProducto/Delete/5
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
