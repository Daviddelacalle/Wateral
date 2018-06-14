using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.EN.Wateral;
using Escuela.Models;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Escuela.Controllers
{
    public class PedidoController : BasicController
    {
        // GET: Pedido
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Pedido/Details/5
        public ActionResult misPedidos()
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
            IPedidoCAD pedidoCAD;
            IList<LineaPedidoEN> list = new List<LineaPedidoEN>();
            IList<PedidoEN> pedidos = new List<PedidoEN>();
            try
            {
                SessionInitialize();
                pedidoCAD = new PedidoCAD(session);
                pedidos=pedidoCAD.ReadAll(0,-1);
                foreach (PedidoEN p in pedidos)
                {
                    if (p.UserRegistrado!=null && Session["UserName"]!=null && p.UserRegistrado.Email.Equals(Session["UserName"].ToString()))
                    {
                        foreach(LineaPedidoEN lp in p.LineasPedido)
                        {
                            list.Add(lp);
                        }
                    }
                }
                IEnumerable<Pedido> prods = new AssemblerPedidoController().ConvertListENToModel(list);
                return View(prods);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                SessionClose();
            }
            
        }
        public ActionResult misPedidosCompletos()
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
            IPedidoCAD pedidoCAD;
            IList<LineaPedidoEN> list = new List<LineaPedidoEN>();
            IList<PedidoEN> pedidos = new List<PedidoEN>();
            IList<PedidoEN> pedido = new List<PedidoEN>();
            try
            {
                SessionInitialize();
                pedidoCAD = new PedidoCAD(session);
                pedidos = pedidoCAD.ReadAll(0, -1);
                foreach (PedidoEN p in pedidos)
                {
                    if (p.UserRegistrado != null && Session["UserName"] != null && p.UserRegistrado.Email.Equals(Session["UserName"].ToString()))
                    {
                        
                        foreach (LineaPedidoEN lin in p.LineasPedido)
                        {
                            list.Add(lin);
                        }
                        IList<Pedido> lineas = new AssemblerPedidoController().ConvertListENToModel(list);
                        ViewData[p.Id.ToString()] = lineas;
                        list.Clear();
                        pedido.Add(p);
                    }
                }
                //IEnumerable<Pedido> prods = new AssemblerPedidoController().ConvertListENToModel(list);
                IList<PedidoCompleto> prods = new AssemblerPedidoCompleto().ConvertListENToModel(pedido);
                ViewData["Pedidos"] = prods;
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SessionClose();
            }

        }
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            try
            {
                SessionInitialize();
                WateralGenNHibernate.CP.Wateral.CestaCP cp = new WateralGenNHibernate.CP.Wateral.CestaCP();
                int actual = cp.Realizar_pago(((int)Session["Cesta"]), 3);
                PedidoCAD cen = new PedidoCAD(session);
                PedidoEN realizado = cen.ReadOID(actual);
                IList<LineaPedidoEN> lineas = new List<LineaPedidoEN>();
                string pedido = null;
                foreach (LineaPedidoEN l in realizado.LineasPedido)
                {
                    
                    lineas.Add(l);

                    pedido = pedido + "<tr><td>" + l.Producto;
                    if (l.Dias != -1)
                    {
                        pedido += " [Alquiler / Días: " + l.Dias + "]";
                    }
                    String ped = "</td><td>" + l.Cantidad.ToString() + "</td><td>" + l.Precio.ToString() + "€ </td></tr>";
                    pedido += pedido;
                }
                IEnumerable<Pedido> vrealizado = new AssemblerPedidoController().ConvertListENToModel(lineas);
                double total = 0.0;
                foreach (Pedido v in vrealizado)
                {
                    total += v.Precio;
                    break;
                }
                PedidoCompleto ppp = new AssemblerPedidoCompleto().ConvertENToModelUI(realizado);
                ViewData[ppp.Id.ToString()] = vrealizado;
                ViewData["Pedidos"] = ppp;
                //Mandamos el correo con la factura (A LO MEJOR TOCA CAMBIARLO CUANDO CREEMOS EL OBJETO DE TIPO PAGO, estaria guay)
                SmtpClient client = new SmtpClient("in-v3.mailjet.com");
                client.Credentials = new NetworkCredential("2495a83e93a7dd773fc956829efabded", "73210e5fe02094273075f60d2f51c4c3");
                client.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sistemasmultimedia2017@gmail.com");
                mailMessage.To.Add(Session["UserName"].ToString());
                mailMessage.Subject = "Su pedido ha sido confirmado";
                mailMessage.IsBodyHtml = true;
                //mailMessage.Body = "<h1>Enhorabuena, su pedido ha sido realizado con éxito.</h1>" + 
                //"<h2>Usted ha compardo: </h2>" + "<table>"
                //+
                //pedido 
                //+
                // "<tr><td>Total: " + total + "€ </td></tr></table>"
                //+"<p>Para cualquier duda o reclamación, contacte con nuestro servicio de soprote o acuda a la escuela para que podamos atenderle.</p>"
                //+ "<p> Un coordial saludo. </p>"
                //+"<p>El equipo de Wateral</p>";
                //Path.Combine(Directory.GetCurrentDirectory(), "\\HTMLAux\\Correos\\primero.html");
                //Application.StartupPath +
                //System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @""\\HTMLAux\\Correos\\primero.html"");
                string HTML = System.IO.File.ReadAllText(Server.MapPath("..\\HTMLAux\\Correos\\primero.html"));
                
                string correocomp = HTML + pedido;
                correocomp = correocomp + System.IO.File.ReadAllText(Server.MapPath("..\\HTMLAux\\Correos\\ending.html"));
                mailMessage.Body = correocomp;
                client.Send(mailMessage);
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SessionClose();
            }
            
        }

        // POST: Pedido/Create
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

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedido/Edit/5
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

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
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
