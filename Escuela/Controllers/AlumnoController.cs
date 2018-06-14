using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.EN.Wateral;
using Escuela.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Escuela.Controllers;
using System.Net.Mail;
using System.Net;

namespace MvcApplication1.Controllers
{
    public class AlumnoController : BasicController
    {
        //
        // GET: /Alumno/
        [Authorize(Roles = "Alumno")]
        public ActionResult Index()
        {
            UserRegistradoCEN cen = new UserRegistradoCEN();
            UserRegistradoEN en = cen.ReadOID(Session["UserName"].ToString());
            DatosAlumno datos = null;
            string nombre_usuario = en.Nombre;
            IList<DatosAlumno> mostrar = new List<DatosAlumno>();
            try
            {
                SessionInitialize();
                GrupoCAD gru = new GrupoCAD(session);
                IList<GrupoEN> grupillos = gru.ReadAll(0, -1);
                foreach (GrupoEN g in grupillos)
                {
                    foreach (AlumnoEN a in g.Alumnos)
                    {
                        if (a.UserRegistrado.Email.Equals(Session["UserName"].ToString()))
                        {
                            //El alumno está en el grupo
                            datos = new AssemblerDatosAlumnoController().ConvertDatatoModel(g, nombre_usuario);

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


            return View(datos);
        }

        //
        // GET: /Alumno/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Alumno/Create    

        public ActionResult Create()
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
                    Alumno model = new Alumno();
                    GrupoCEN grupoCEN = new GrupoCEN();
                    GrupoCAD cad = new GrupoCAD();
                    IList<GrupoEN> grupos = cad.ReadAll(0, -1);
                    IList<GrupoEN> gruposc = new List<GrupoEN>();
                    foreach (GrupoEN g in grupos)
                    {
                        if (g.Curso.Id == (int)Session["contratado"])
                        {
                            gruposc.Add(g);
                        }
                    }
                    IList<String> tallas = new List<String>();
                    tallas.Add("xs");
                    tallas.Add("small");
                    tallas.Add("m");
                    tallas.Add("l");
                    tallas.Add("xl");

                    ViewBag.Talla = tallas;
                    ViewBag.Grupos = gruposc;

                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }

        //
        // POST: /Alumno/Create

        [HttpPost]
        public ActionResult Create(Alumno alu, string selector, string talla)
        {

            var tallaDEF = WateralGenNHibernate.Enumerated.Wateral.TallaEnum.xl;
            WateralGenNHibernate.CP.Wateral.AlumnoCP alumnoCP = new WateralGenNHibernate.CP.Wateral.AlumnoCP();

            try
            {
                //Asignamos el grupo elegido

                IList<int> grupo = new List<int>();
                grupo.Add(Int32.Parse(selector));

                //Asignamos la talla

                switch (talla)
                {
                    case "0": tallaDEF = WateralGenNHibernate.Enumerated.Wateral.TallaEnum.xs; break;
                    case "1": tallaDEF = WateralGenNHibernate.Enumerated.Wateral.TallaEnum.small; break;
                    case "2": tallaDEF = WateralGenNHibernate.Enumerated.Wateral.TallaEnum.m; break;
                    case "3": tallaDEF = WateralGenNHibernate.Enumerated.Wateral.TallaEnum.l; break;
                    case "4": tallaDEF = WateralGenNHibernate.Enumerated.Wateral.TallaEnum.xl; break;
                }

                //Creamos el alumno

                AlumnoEN alumno = alumnoCP.Inscribirse_curso(alu.Disponibilidad, alu.Salud, alu.Peso, tallaDEF, alu.NumPie, alu.DNI, grupo, Session["UserName"].ToString());

                var user = User.Identity;
                var _context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

                //Le borramos cualquier rol anterior

                UserManager.RemoveFromRole(user.GetUserId(), "User_registrado");

                //Le asignamos el rol de Alumno

                UserManager.AddToRole(user.GetUserId(), "Alumno");
                //Mandamos el correo con la factura (A LO MEJOR TOCA CAMBIARLO CUANDO CREEMOS EL OBJETO DE TIPO PAGO, estaria guay)
                SmtpClient client = new SmtpClient("in-v3.mailjet.com");
                client.Credentials = new NetworkCredential("2495a83e93a7dd773fc956829efabded", "73210e5fe02094273075f60d2f51c4c3");
                client.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sistemasmultimedia2017@gmail.com");
                mailMessage.To.Add(Session["UserName"].ToString());
                mailMessage.Subject = "Se ha matriculado como alumno de Wateral";
                mailMessage.IsBodyHtml = true;
                
                string HTML = System.IO.File.ReadAllText(Server.MapPath("..\\HTMLAux\\Correos\\primero_registro.html"));

                string mensaje = "Enahorabuena, ahora es usted alumno de la escuela Wateral. Le recordamos que debe debe asistir a la hora y el día indicados en su perfil de alumno. Le aconsejamos que traiga crema solar y gafas de sol para el desarrollo de su clase.";

                string correocomp = HTML + mensaje;
                correocomp = correocomp + System.IO.File.ReadAllText(Server.MapPath("..\\HTMLAux\\Correos\\ending.html"));
                mailMessage.Body = correocomp;
                client.Send(mailMessage);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("ErrCreate", "Alumno", new { msg = e.Message.ToString() });
            }
        }
        //
        // GET: /Alumno/ErrCreate
        public ActionResult ErrCreate(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }

        //
        // GET: /Alumno/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Alumno/Edit/5

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
        // GET: /Alumno/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Alumno/Delete/5

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
