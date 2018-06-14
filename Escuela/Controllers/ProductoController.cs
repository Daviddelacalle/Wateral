using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.EN.Wateral;
using Escuela.Models;
using System.IO;

using Escuela.Controllers;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Escuela.Controllers
{
    public class ProductoController : BasicController
    {
        //
        // GET: /Producto/
        [HttpPost]
        public ActionResult Index(string param)
        {
            ProductoCEN cen = new ProductoCEN();
            IList<ProductoEN> resultado = cen.FiltrarProductos(param);
            IEnumerable<Producto> productos = new AssemblerProducto().ConvertListENToModel(resultado);
            return View(productos);
        }

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


            ProductoCEN cen = new ProductoCEN();
            IList<ProductoEN> productos = cen.ReadAll(0, -1);
            IList<ProductoEN> seleccionados = new List<ProductoEN>();
            foreach (ProductoEN prod in productos)
            {
                if (prod.Stock > 0)
                {
                    seleccionados.Add(prod);
                }
            }
            IEnumerable<Producto> listDef = new AssemblerProducto().ConvertListENToModel(seleccionados);
            return View(listDef);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AIndex()
        {
            ProductoCEN cen = new ProductoCEN();
            IList<ProductoEN> productos = cen.ReadAll(0, -1);
            IEnumerable<Producto> listDef = new AssemblerProducto().ConvertListENToModel(productos);
            return View(listDef);
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id)
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
            ProductoCEN cen = new ProductoCEN();
            ProductoEN producto = cen.ReadOID(id);
            Producto display = new AssemblerProducto().ConvertENToModelUI(producto);
            return View(display);
        }

        public ActionResult DetalleProducto(int id)
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
            ProductoCEN cen = new ProductoCEN();
            ProductoEN producto = cen.ReadOID(id);
            Producto display = new AssemblerProducto().ConvertENToModelUI(producto);
            ValoracionProductoCEN vcen = new ValoracionProductoCEN();
            IList<ValoracionProductoEN> en = vcen.ReadAll(0, -1);
            IList<ValoracionProductoEN> list = new List<ValoracionProductoEN>();
            int cont = 0;
            int total = 0;
            int cont2 = 0;
            IEnumerable<ValoracionProductoEN> inverso = en.Reverse();
            foreach(var v in inverso)
            {
                
                    if(v.Producto.Id==id)
                    {
                        if (cont < 3)
                        {
                            list.Add(v);
                            cont++;
                            cont2++;
                            total+=v.Nota;
                        }
                        else
                        {
                            cont2++;
                            total += v.Nota;
                        }

                    }
            }
            ViewBag.ban_val = false;
            try
            {
                SessionInitialize();
            
            PedidoCAD pedidoCAD = new PedidoCAD(session);
            IList<PedidoEN> pedidos = pedidoCAD.ReadAll(0, -1);
            foreach (PedidoEN p in pedidos)
            {
                if (p.UserRegistrado != null && Session["UserName"] != null && p.UserRegistrado.Email.Equals(Session["UserName"].ToString()))
                {
                    foreach (LineaPedidoEN lin in p.LineasPedido)
                    {
                        if (lin.Producto.Equals(producto.Nombre) && lin.Imagen.Equals(producto.Imagen))
                        {
                            ViewBag.ban_val = true;
                        }
                    }
                }
            }
            }
            catch (Exception e)
            {

            }
            finally
            {
                SessionClose();
            }
            IList<ValoracionProducto> valoracion = new AssemblerValoracionProducto().ConvertListENToModel(list);
            ViewData["Producto"] = display;
            ViewData["Valoracion"] = valoracion;
            if (cont2 != 0)
            {
                ViewData["Media"] = total / cont2;
            }
            else
            {
                ViewData["Media"] = 0;
            }
            return View();
        }   


        //
        // GET: /Producto/Create

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ProductoNewForm nuevo = new ProductoNewForm();
            return View(nuevo);
        }

        //
        // POST: /Producto/Create

        [HttpPost]
        public ActionResult Create(ProductoNewForm modelo, HttpPostedFileBase file)
        {
            string ruta = "default";
            try
            {
                // TODO: Add insert logic here
                ProductoCEN cen = new ProductoCEN();
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Productos/"), fileName);
                    ruta = fileName;
                    file.SaveAs(path);
                }
                cen.New_(modelo.stock, modelo.Nombre, ruta, modelo.Descripcion, modelo.Precio_compra, modelo.Precio_alquiler);
                return Redirect("/Producto/AIndex");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Producto/Edit/5
        [Authorize(Roles = "Admin")] 
        public ActionResult Edit(int id)
        {
            ProductoCEN cen = new ProductoCEN();
            ProductoEN en = cen.ReadOID(id);
            Producto edit = new AssemblerProducto().ConvertENToModelUI(en);
            return View(edit);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        public ActionResult Edit(Producto prod, HttpPostedFileBase file)
        {
            string ruta = prod.Imagen;
            try
            {
                // TODO: Add insert logic here
                ProductoCEN cen = new ProductoCEN();
                if (file != null && file.ContentLength > 0)
                {
                    string fullPath = Request.MapPath("~/Images/Productos/" + ruta);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Productos/"), fileName);
                    ruta = fileName;
                    file.SaveAs(path);
                }
                cen.Modify(prod.id, prod.stock, prod.Nombre, ruta, prod.Descripcion, prod.Precio_compra, prod.Precio_alquiler);
                return Redirect("/Producto/AIndex");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Producto/Delete/5

        public ActionResult Delete(int id)
        {
            //Proceso de borrado superloco
            IList<LineaCestaEN> lineas = null;
            ProductoEN prod = null;
            ProductoCEN product = new ProductoCEN();
            LineaCestaCEN lcest = new LineaCestaCEN();
            ValoracionProductoCEN valu = new ValoracionProductoCEN();
            try
            {
                SessionInitialize();
                LineaCestaCAD cad2 = new LineaCestaCAD(session);
                ValoracionProductoCAD cad3 = new ValoracionProductoCAD(session);
                ProductoCAD cad1 = new ProductoCAD(session);
                
                lineas = cad2.ReadAll(0, -1);
                prod = cad1.ReadOID(id);
                foreach (LineaCestaEN c in lineas)
                {
                    if (c.Producto.Id == id)
                    {
                        lcest.Destroy(c.Linea);
                        //He borrado las lineas de cesta relacionadas
                    }
                }

                //Borramos las valoraciones del producto
                foreach(ValoracionProductoEN val in prod.ValoracionesProducto)
                {
                    valu.Destroy(val.Id_valoracion);
                }

                product.Destroy(id);
                Session["ProdEliminado"] = "true";
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SessionClose();
            }
            return Redirect("/Producto/AIndex");
        }

        //
        // POST: /Producto/Delete/5

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