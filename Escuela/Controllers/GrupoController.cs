using Escuela.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Controllers
{
    public class GrupoController : BasicController
    {
        // GET: Grupo
        public ActionResult Index()
        {
            IEnumerable<GrupoModel> vista = null;
            try
            {
                SessionInitialize();
                GrupoCAD cad = new GrupoCAD(session);
                IList<GrupoEN> grupos = cad.ReadAll(0, -1);
                vista = new AssemblerGrupo().ConvertListENToModel(grupos);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SessionClose();
            }
            return View(vista);
        }

        public ActionResult Finalizar(int id)
        {
            try
            {
                SessionInitialize();
                GrupoCAD g_cad = new GrupoCAD(session);
                GrupoCEN g_cen = new GrupoCEN();
                IList<int> alumnos = new List<int>();
                GrupoEN grupo = g_cad.ReadOID(id);
                AlumnoCEN a_cen = new AlumnoCEN();
                AlumnoCAD a_cad = new AlumnoCAD();
                string curso = grupo.Curso.Tipo.ToString();
                string nivel = grupo.Curso.Nombre;
                string extension = "pdf";
                string ruta = curso + nivel + "." + extension;

                foreach (AlumnoEN alu in grupo.Alumnos)
                {
                    alumnos.Add(alu.Idalumno);
                }

                //ya tengo todos los alumnos perfes, ahora mato el grupo
                g_cen.Destroy(id);

                //Ahora procedo a mandar los correos (seviene la locura)
                foreach (int ident in alumnos)
                {
                    AlumnoEN este = a_cad.ReadOID(ident);
                    string email = este.UserRegistrado.Email;
                    SmtpClient client = new SmtpClient("in-v3.mailjet.com");
                    client.Credentials = new NetworkCredential("2495a83e93a7dd773fc956829efabded", "73210e5fe02094273075f60d2f51c4c3");
                    client.EnableSsl = true;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("sistemasmultimedia2017@gmail.com");
                    mailMessage.To.Add(email);
                    mailMessage.Subject = "Enhorabuena, ha terminado el curso";
                    mailMessage.IsBodyHtml = true;
                    string HTML = System.IO.File.ReadAllText(Server.MapPath("\\HTMLAux\\Correos\\primero.html"));
                    string correocomp = HTML + "Has finalizado el curso";
                    correocomp = correocomp + System.IO.File.ReadAllText(Server.MapPath("\\HTMLAux\\Correos\\ending.html"));
                    mailMessage.Body = correocomp;
                    System.Net.Mail.Attachment attachment;
                    var path = Path.Combine(Server.MapPath("~/Diplomas/"), ruta);
                    attachment = new Attachment(path, MediaTypeNames.Application.Pdf);
                    mailMessage.Attachments.Add(attachment);
                    client.Send(mailMessage);
                    a_cen.Destroy(ident);

                    //ahora vamos a quitarle permisos de alumno

                    var _context = new ApplicationDbContext();
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                    UserManager.RemoveFromRole(email, "Alumno");
                    UserManager.AddToRole(email, "User_registrado");
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

            return RedirectToAction("Index", "Grupo");
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SessionInitialize();
                ProfesorCAD cad = new ProfesorCAD(session);
                IList<ProfesorEN> listaP = cad.ReadAll(0, -1);

                IList<String> nombres = new List<String>();


                foreach (ProfesorEN item in listaP)
                {
                    nombres.Add(item.UserRegistrado.Email);
                }

                ViewBag.Nombres= nombres;


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                SessionClose();
            }
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Grupo/Edit/5
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

        // GET: Grupo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Grupo/Delete/5
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
