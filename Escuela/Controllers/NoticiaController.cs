using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WateralGenNHibernate.CEN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.EN.Wateral;
using Escuela.Models;
using System.IO;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Escuela.Controllers
{
    public class NoticiaController : BasicController
    {
        // GET: Noticia
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
            IEnumerable<Noticia> not = null;
            try
            {
                SessionInitialize();
                NoticiaCAD cad = new NoticiaCAD(session);
                IList<NoticiaEN> noticias = cad.ReadAll(0, -1);
                not = new AssemblerNoticia().ConvertListENToModel(noticias);
                
            }
            catch (Exception e)
            {
            }
            finally {
                SessionClose();
            }
            return View(not);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AIndex()
        {
            IEnumerable<Noticia> not = null;
            try
            {
                SessionInitialize();
                NoticiaCAD cad = new NoticiaCAD(session);
                IList<NoticiaEN> noticias = cad.ReadAll(0, -1);
                not = new AssemblerNoticia().ConvertListENToModel(noticias);
                
            }
            catch (Exception e) { }
            finally { SessionClose(); }
            return View(not);
        }

        // GET: Noticia/Details/5
        public ActionResult Details(int id)
        {
            Noticia display = null;
            try
            {
                SessionInitialize();
                INoticiaCAD cad = new NoticiaCAD(session);
                NoticiaCEN cen = new NoticiaCEN(cad);
                NoticiaEN en = cen.ReadOID(id);
                display = new AssemblerNoticia().ConvertENToModelUI(en);
                ViewData["Noticia"] = display;
            }
            catch (Exception e) { }
            finally { SessionClose(); }
            return View(display);
        }

        // GET: Noticia/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            Noticia noticia = new Noticia();
            return View(noticia);
        }

        // POST: Noticia/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Noticia not,FormCollection collection, HttpPostedFileBase file)
        {
            string ruta = "default";
            if (ModelState.IsValidField("Texto") && ModelState.IsValidField("Titulo"))
            {
                try
                {
                    // TODO: Add insert logic here
                    NoticiaCEN cen = new NoticiaCEN();
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Noticias/"), fileName);
                        ruta = fileName;
                        file.SaveAs(path);
                    }
                    var admin = "admin@admin.com";

                    if (Session["UserName"] != null)
                        admin = Session["UserName"].ToString();

                    cen.New_(admin, not.Texto, ruta, DateTime.Now, not.Titulo);
                    return Redirect("/Noticia/AIndex");
                }
                catch (Exception e)
                {
                    throw e;
                    
                }
            }
            return View();
        }

        // GET: Noticia/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Noticia edit = null;
            if (ModelState.IsValidField("Texto") && ModelState.IsValidField("Titulo"))
            {
                try
                {
                    SessionInitialize();
                    INoticiaCAD cad = new NoticiaCAD(session);
                    NoticiaCEN cen = new NoticiaCEN(cad);
                    NoticiaEN en = cen.ReadOID(id);
                    edit = new AssemblerNoticia().ConvertENToModelUI(en);
                }
                catch (Exception e) { throw e; }
                finally { SessionClose(); }
            }
            return View(edit);
        }

        // POST: Noticia/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Noticia not, FormCollection collection, HttpPostedFileBase file)
        {

            string ruta = not.Imagen;
            try
            {
                // TODO: Add insert logic here 
                NoticiaCEN cen = new NoticiaCEN();
                if (file != null && file.ContentLength > 0)
                {
                    string fullPath = Request.MapPath("~/Images/Noticias/" + ruta);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Noticias/"), fileName);
                    ruta = fileName;
                    file.SaveAs(path);
                }
                var admin = "admin@admin.com";

                if (Session["UserName"] != null)
                    admin = Session["UserName"].ToString();

                cen.Modify(not.id, not.Texto, ruta, not.Fecha, not.Titulo);
                return Redirect("/Noticia/AIndex");
            }
            catch (Exception e)
            {
                throw e;
                //return View();
            }
        }

        // GET: Noticia/Delete/5
        public ActionResult Delete(int id)
        {
            NoticiaCEN cen = new NoticiaCEN();
            cen.Destroy(id);
            return Redirect("/Noticia/AIndex");
        }

        // POST: Noticia/Delete/5
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
