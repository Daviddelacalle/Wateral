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

namespace Escuela.Controllers
{
    public class CestaController : BasicController
    {
        //
        // GET: /Cesta/

        public ActionResult Index()
        {

            ICestaCAD cestaCAD = null;
            //CestaCEN cestaCEN = null;
            IList<ProductoEN> prod = new List<ProductoEN>();
            IList<LineaCestaEN> cets = new List<LineaCestaEN>();
            try
            {
                SessionInitialize();
                cestaCAD = new CestaCAD(session);

                IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);

                double canttot = 0;

                foreach (CestaEN ces in cestas)
                {
                    if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                    {/*

                        ILineaCestaCAD icest = new LineaCestaCAD();
                        IList<LineaCestaEN> lins = icest.ReadAll(0, -1);
                        foreach (LineaCestaEN lin in lins)
                        {
                            prod.Add(lin.Producto);
                        }*/


                        foreach (LineaCestaEN lin in ces.LineasCesta)
                        {
                            prod.Add(lin.Producto);
                            cets.Add(lin);
                            canttot += lin.Precio;
                        }


                    }
                }
                ViewBag.Precio = canttot;
                IEnumerable<Producto> prods = new AssemblerProducto().ConvertListENToModel(prod);
                //SessionCommit();
                return View(prods);
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


        }

        //
        // GET: /Cesta/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Badge()
        {

            ICestaCAD cestaCAD = null;
            int num = 0;
            try
            {
                SessionInitialize();
                cestaCAD = new CestaCAD(session);
                IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);
                foreach (CestaEN ces in cestas)
                {
                    if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                    {
                        foreach (LineaCestaEN l in ces.LineasCesta)
                        {
                            num += l.Cantidad;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SessionClose();
            }
            ViewBag.num = num;
            return Content(num.ToString());
        }

        //
        // GET: /Cesta/Create
        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        [HttpPost]
        public ActionResult Create(int id, int cantidad)
        {
            //ya tengo el producto, ahora operamos con la cesta

            //CestaCEN cen = new CestaCEN();


            /*
            WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
            anyadidor.Anyadir(,,1,-1);
            */
            //int ids=cen.New_("email@Masteryi.com", compras);
            //Creamos el model del producto que nos hemos comprado jeje
            //ProductoCEN cenp = new ProductoCEN();
            //ProductoEN producto = cenp.ReadOID(id);
            //Producto prod = new AssemblerProducto().ConvertENToModelUI(producto);
            Producto prod = null;




            ICestaCAD cestaCAD = null;
            IProductoCAD productoCAD = null;
            //CestaCEN cestaCEN = null;
            IList<LineaCestaEN> lins = null;
            Boolean tiene_cesta = false;
            int num = 0;
            try
            {
                SessionInitialize();
                cestaCAD = new CestaCAD(session);
                productoCAD = new ProductoCAD(session);
                LineaCestaCAD lineaCestaCAD = new LineaCestaCAD(session);

                IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);
                int ids = 0;
                foreach (CestaEN ces in cestas)
                {
                    if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                    {
                        ids = ces.Id;
                        WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                        int p = anyadidor.Anyadir(ids, id, cantidad, -1);
                        ProductoEN pro = productoCAD.ReadOID(id);
                        prod = new AssemblerProducto().ConvertENToModelUI(pro);
                        tiene_cesta = true;
                        foreach (LineaCestaEN l in ces.LineasCesta)
                        {
                            num += l.Cantidad;
                        }
                    }
                }
                if (!tiene_cesta)
                {
                    CestaCEN cen = new CestaCEN();
                    ids = cen.New_(Session["UserName"].ToString());
                    WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                    int p = anyadidor.Anyadir(ids, id, cantidad, -1);
                    ProductoEN pro = productoCAD.ReadOID(id);
                    prod = new AssemblerProducto().ConvertENToModelUI(pro);
                }
                Session["Cesta"] = ids;
                ViewBag.nopuedeser = Session["UserName"].ToString();
                
                //SessionCommit();
                //return View(prod);
                return Redirect("/LineaCesta/miLinCesta");
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
        }

        public JsonResult Incrementar(int id,int dias)
        {
            ICestaCAD cestaCAD = null;
            IProductoCAD productoCAD = null;
            //CestaCEN cestaCEN = null;
            IList<LineaCestaEN> lins = null;
            LineaCestaEN lc = null;
            try
            {
                SessionInitialize();
                cestaCAD = new CestaCAD(session);
                productoCAD = new ProductoCAD(session);
                LineaCestaCAD lineaCestaCAD = new LineaCestaCAD(session);

                IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);
                int ids = 0;
                foreach (CestaEN ces in cestas)
                {
                    if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                    {
                        ids = ces.Id;
                        WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                        int p = anyadidor.Anyadir(ids, id, 1, dias);
                        lc = lineaCestaCAD.ReadOID(p);
                    }
                }

                Session["Cesta"] = ids;

                //SessionCommit();
                //return View(prod);
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

            var result = new { qty = lc.Cantidad, price = lc.Precio};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Decrementar(int id, int dias)
        {
            ICestaCAD cestaCAD = null;
            IProductoCAD productoCAD = null;
            //CestaCEN cestaCEN = null;
            IList<LineaCestaEN> lins = null;
            LineaCestaEN lc = null;
            try
            {
                SessionInitialize();
                cestaCAD = new CestaCAD(session);
                productoCAD = new ProductoCAD(session);
                LineaCestaCAD lineaCestaCAD = new LineaCestaCAD(session);

                IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);
                int ids = 0;
                foreach (CestaEN ces in cestas)
                {
                    if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                    {
                        ids = ces.Id;
                        WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                       
                        int p = anyadidor.Anyadir(ids, id, -1, dias);
                        lc = lineaCestaCAD.ReadOID(p);
                   
                        
                    }
                }

                Session["Cesta"] = ids;

                //SessionCommit();
                //return View(prod);
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

            var result = new { qty = lc.Cantidad, price = lc.Precio };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User_registrado, Alumno, Profesor")]
        [HttpPost]
        public ActionResult Alquilar(int dias,int cantidad)
        {
            Producto prod = null;
            ICestaCAD cestaCAD = null;
            IProductoCAD productoCAD = null;
            //CestaCEN cestaCEN = null;
            IList<LineaCestaEN> lins = null;
            Boolean tiene_cesta = false;
            try
            {
                SessionInitialize();
                cestaCAD = new CestaCAD(session);
                productoCAD = new ProductoCAD(session);
                LineaCestaCAD lineaCestaCAD = new LineaCestaCAD(session);

                IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);
                int ids = 0;
                foreach (CestaEN ces in cestas)
                {
                    if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                    {
                        ids = ces.Id;
                        WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                        int p = anyadidor.Anyadir(ids, (int)Session["Alquiler"], cantidad, dias);
                        ProductoEN pro = productoCAD.ReadOID((int)Session["Alquiler"]);
                        prod = new AssemblerProducto().ConvertENToModelUI(pro);
                        tiene_cesta = true;
                    }
                }
                if (!tiene_cesta)
                {
                    CestaCEN cen = new CestaCEN(); 
                    ids = cen.New_(Session["UserName"].ToString());
                    WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                    int p = anyadidor.Anyadir(ids, (int)Session["Alquiler"], cantidad, dias);
                    ProductoEN pro = productoCAD.ReadOID((int)Session["Alquiler"]);
                    prod = new AssemblerProducto().ConvertENToModelUI(pro);
                }
                Session["Cesta"] = ids;

                //SessionCommit();
                return Redirect("../LineaCesta/miLinCesta");
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
        }

        /* public ActionResult IniAlquiler(int product)
         {
             Session["Alquiler"] = product;
             CestaCompuesta form = new CestaCompuesta();
             return View(form);
         }

         [HttpPost]
         public ActionResult IniAlquiler(CestaCompuesta dias)
         {

             Producto prod = null;
             ICestaCAD cestaCAD = null;
             IProductoCAD productoCAD = null;
             //CestaCEN cestaCEN = null;
             IList<LineaCestaEN> lins = null;
             Boolean tiene_cesta = false;
             try
             {
                 SessionInitialize();
                 cestaCAD = new CestaCAD(session);
                 productoCAD = new ProductoCAD(session);
                 LineaCestaCAD lineaCestaCAD = new LineaCestaCAD(session);

                 IList<CestaEN> cestas = cestaCAD.ReadAll(0, -1);
                 int ids = 0;
                 foreach (CestaEN ces in cestas)
                 {
                     if (ces.Usuario_Regist != null && ces.Usuario_Regist.Email.Equals(Session["UserName"].ToString()))
                     {
                         ids = ces.Id;
                         WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                         int p = anyadidor.Anyadir(ids, (int)Session["Alquiler"], 1, dias.Dias);
                         ProductoEN pro = productoCAD.ReadOID((int)Session["Alquiler"]);
                         prod = new AssemblerProducto().ConvertENToModelUI(pro);
                         tiene_cesta = true;
                     }
                 }
                 if (!tiene_cesta)
                 {
                     CestaCEN cen = new CestaCEN();
                     IList<int> compras = new List<int>();
                     ids = cen.New_(Session["UserName"].ToString(), compras);
                     WateralGenNHibernate.CP.Wateral.CestaCP anyadidor = new WateralGenNHibernate.CP.Wateral.CestaCP();
                     int p = anyadidor.Anyadir(ids, (int)Session["Alquiler"], 1, dias.Dias);
                     ProductoEN pro = productoCAD.ReadOID((int)Session["Alquiler"]);
                     prod = new AssemblerProducto().ConvertENToModelUI(pro);
                 }
                 Session["Cesta"] = ids;

                 //SessionCommit();
                 return Redirect("../LineaCesta/miLinCesta");
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
         }
         */
        //

        //
        // GET: /Cesta/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cesta/Edit/5

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
        // GET: /Cesta/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cesta/Delete/5

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
