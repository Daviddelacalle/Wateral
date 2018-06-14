using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Escuela.Models;
using WateralGenNHibernate.CEN.Wateral;
using Microsoft.AspNet.Identity.EntityFramework;
using WateralGenNHibernate.CAD.Wateral;
using System.Collections.Generic;
using WateralGenNHibernate.EN.Wateral;
using System.IO;

namespace Escuela.Controllers
{
    [Authorize]
    public class AccountController : BasicController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
            // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    Session["UserName"] = model.Email;
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View(model);
            }
        }

        public ActionResult Banear(string user)
        {
            try
            {
                SessionInitialize();

                AlumnoCAD alumno_cad = new AlumnoCAD(session);
                LineaCestaCAD lcesta_cad = new LineaCestaCAD(session);
                LineaPedidoCAD lpedido_cad = new LineaPedidoCAD(session);
                CestaCAD cesta_cad = new CestaCAD(session);
                ValoracionProductoCAD vprod_cad = new ValoracionProductoCAD(session);
                ValoracionCursoCAD valoracionCurso_cad = new ValoracionCursoCAD(session);
                ValoracionProfesorCAD valoracionProfesor_cad = new ValoracionProfesorCAD(session);
                PedidoCAD pedido_cad = new PedidoCAD(session);
                MensajeCAD mensaje_cad = new MensajeCAD(session);
                Solicitud_cambioCAD solicitud_Cambio_cad = new Solicitud_cambioCAD(session);
                NoticiaCAD noticia_cad = new NoticiaCAD(session);
                AdministradorCAD administradorCAD = new AdministradorCAD(session);
                GrupoCAD grupo_cad = new GrupoCAD(session);
                ProfesorCAD profesorCAD = new ProfesorCAD(session);


                UserRegistradoCEN cen = new UserRegistradoCEN();
                AlumnoCEN alumno_cen = new AlumnoCEN();
                LineaCestaCEN lcesta_cen = new LineaCestaCEN();
                LineaPedidoCEN lpedido_cen = new LineaPedidoCEN();
                CestaCEN cesta_cen = new CestaCEN();
                ValoracionProductoCEN vprod_cen = new ValoracionProductoCEN();
                ValoracionCursoCEN valoracionCurso_cen = new ValoracionCursoCEN();
                ValoracionProfesorCEN valoracionProfesor_cen = new ValoracionProfesorCEN();
                PedidoCEN pedido_cen = new PedidoCEN();
                MensajeCEN mensaje_cen = new MensajeCEN();
                Solicitud_cambioCEN solicitud_Cambio_cen = new Solicitud_cambioCEN();
                NoticiaCEN noticia_cen = new NoticiaCEN();
                AdministradorCEN administradorCEN = new AdministradorCEN();
                GrupoCEN grupo_cen = new GrupoCEN();
                ProfesorCEN profesorCEN = new ProfesorCEN();

                IList<CestaEN> cestas = cesta_cad.ReadAll(0, -1);
                IList<AlumnoEN> esalumno = alumno_cad.ReadAll(0, -1);
                IList<ValoracionProductoEN> valoraciones = vprod_cad.ReadAll(0, -1);
                IList<ValoracionProfesorEN> valprof = valoracionProfesor_cad.ReadAll(0, -1);
                IList<ValoracionCursoEN> valcurs = valoracionCurso_cad.ReadAll(0, -1);
                IList<GrupoEN> grupos = grupo_cad.ReadAll(0, -1);
                IList<PedidoEN> pedidos = pedido_cad.ReadAll(0, -1);
                IList<MensajeEN> mensajes = mensaje_cad.ReadAll(0, -1);
                IList<NoticiaEN> noticias = noticia_cad.ReadAll(0, -1);
                IList<Solicitud_cambioEN> solicitudes = solicitud_Cambio_cad.ReadAll(0, -1);
                IList<ProfesorEN> profesores = profesorCAD.ReadAll(0, -1);

                var usu = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user);
                if (s[0].ToString() == "Admin")
                {
                    foreach (NoticiaEN n in noticias)
                    {
                        if (n.Administrador.Equals(user))
                        {
                            noticia_cen.Destroy(n.Id);
                        }
                    }
                    cen.Destroy(user);
                    var based = new IdentityDbContext();
                    var usuario = UserManager.FindById(user);
                    UserManager.DeleteAsync(usuario);
                    //administradorCEN.Destroy(user);
                }
                else
                {


                    foreach (ValoracionProductoEN v in valoraciones)
                    {
                        if (v.UserRegistrado.Email.Equals(user))
                        {
                            vprod_cen.Destroy(v.Id_valoracion);
                        }
                    }


                    foreach (MensajeEN mensajito in mensajes)
                    {
                        if (mensajito.UserRegistrado.Email.Equals(user) || mensajito.UserRegistrado_0.Email.Equals(user))
                        {
                            mensaje_cen.Destroy(mensajito.Id);
                        }
                    }

                    foreach (PedidoEN p in pedidos)
                    {
                        if (p.UserRegistrado.Email.Equals(user))
                        {
                            foreach (LineaPedidoEN l in p.LineasPedido)
                            {
                                lpedido_cen.Destroy(l.Id);
                            }
                            pedido_cen.Destroy(p.Id);
                        }
                    }

                    foreach (CestaEN c in cestas)
                    {
                        if (c.Usuario_Regist != null && c.Usuario_Regist.Email.Equals(user))
                        {
                            foreach (LineaCestaEN l in c.LineasCesta)
                            {
                                lcesta_cen.Destroy(l.Linea);
                            }
                            cesta_cad.Destroy(c.Id);
                        }
                    }

                    if (s[0].ToString() == "Alumno")
                    {
                        foreach (ValoracionCursoEN c in valcurs)
                        {
                            if (c.Alumno.UserRegistrado.Email.Equals(user))
                            {
                                valoracionCurso_cen.Destroy(c.Id_valoracion);
                            }
                        }
                        foreach (ValoracionProfesorEN p in valprof)
                        {
                            if (p.Alumno_0.UserRegistrado.Email.Equals(user))
                            {
                                valoracionProfesor_cen.Destroy(p.Id_valoracion);
                            }
                        }
                        foreach (Solicitud_cambioEN ss in solicitudes)
                        {
                            if (ss.Alumno.UserRegistrado.Email.Equals(user))
                            {
                                solicitud_Cambio_cen.Destroy(ss.Id);
                            }
                        }
                        foreach (AlumnoEN a in esalumno)
                        {
                            if (a.UserRegistrado.Email.Equals(user))
                            {
                                foreach (GrupoEN g in grupos)
                                {
                                    IList<AlumnoEN> lista = g.Alumnos;
                                    lista.Remove(a);
                                    g.Alumnos = lista;
                                    grupo_cad.ModifyDefault(g);
                                }
                                alumno_cen.Destroy(a.Idalumno);
                            }
                        }
                    }
                    if (s[0].ToString() == "Profesor")
                    {
                        foreach (ValoracionProfesorEN p in valprof)
                        {
                            if (p.Profesor.UserRegistrado.Email.Equals(user))
                            {
                                valoracionProfesor_cen.Destroy(p.Id_valoracion);
                            }
                        }
                        foreach (GrupoEN g in grupos)
                        {
                            if (g.Profesor.UserRegistrado.Email.Equals(user))
                            {
                                foreach (Solicitud_cambioEN ss in solicitudes)
                                {
                                    if (ss.Grupo.Id == g.Id)
                                    {
                                        solicitud_Cambio_cen.Destroy(ss.Id);
                                    }
                                }
                                grupo_cen.Destroy(g.Id);
                            }
                        }
                        foreach (ProfesorEN pss in profesores)
                        {
                            if (pss.UserRegistrado.Email.Equals(user))
                            {
                                profesorCEN.Destroy(pss.Id);
                            }
                        }
                    }
                    cen.Destroy(user);
                    var based = new IdentityDbContext();
                    var usuario = UserManager.FindById(user);
                    UserManager.DeleteAsync(usuario);
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
            /*
            UserRegistradoCEN cen = new UserRegistradoCEN();
            cen.Destroy(user);
            */
            return Redirect("../UserRegistrado/AIndex");
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Requerir que el usuario haya iniciado sesión con nombre de usuario y contraseña o inicio de sesión externo
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // El código siguiente protege de los ataques por fuerza bruta a los códigos de dos factores. 
            // Si un usuario introduce códigos incorrectos durante un intervalo especificado de tiempo, la cuenta del usuario 
            // se bloqueará durante un período de tiempo especificado. 
            // Puede configurar el bloqueo de la cuenta en IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Código no válido.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {                
                return View();
            }

        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new ApplicationUser { Id = model.Email, UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Enviar correo electrónico con este vínculo
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                        //Aqui he de crear el focking usuario en la bd

                        string ruta = "usuario.png";
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/Perfiles/"), fileName);
                            ruta = fileName;
                            file.SaveAs(path);
                        }

                        UserRegistradoCEN creador = new UserRegistradoCEN();
                        creador.New_(model.Email, model.Username, model.Nombre, model.Apellidos, model.Password, model.Nacimiento, ruta);

                        //Asignamos el rol de usuario mierdecilla
                        var result1 = UserManager.AddToRole(user.Id, "User_registrado");

                        /*var jej = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: false);
                        switch (jej)
                        {
                            case SignInStatus.Success:
                                Session["UserName"] = model.Email;
                                return Redirect("/Account/Login/");
                            case SignInStatus.Failure:
                            default:
                                ModelState.AddModelError("", "No ocurrido un problema");
                                return View(model);
                        }*/



                        return Redirect("../Account/Login");
                        //return RedirectToAction("Index", "Home");
                        //return RedirectToAction("Login", new { id = 99 });
                    }
                    AddErrors(result);
                }
                catch (Exception e)
                {
                    ViewData["Repetido"] = "Repetido";
                    return View(model);
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);

        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // No revelar que el usuario no existe o que no está confirmado
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Enviar correo electrónico con este vínculo
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Restablecer contraseña", "Para restablecer la contraseña, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistroAlumno(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar correo electrónico con este vínculo
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // No revelar que el usuario no existe
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Solicitar redireccionamiento al proveedor de inicio de sesión externo
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generar el token y enviarlo
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Si el usuario ya tiene un inicio de sesión, iniciar sesión del usuario con este proveedor de inicio de sesión externo
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    Session["UserName"] = loginInfo.Email;
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // Si el usuario no tiene ninguna cuenta, solicitar que cree una
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
                Session["UserName"] = model.Email;
            }

            if (ModelState.IsValid)
            {
                // Obtener datos del usuario del proveedor de inicio de sesión externo
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { Id = model.Email, UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        DateTime nacimiento = new DateTime(2000, 01, 01);
                        UserRegistradoCEN creador = new UserRegistradoCEN();
                        creador.New_(model.Email, model.Email, "", "", "", nacimiento, "usuario.png");
                        //Asignamos el rol de usuario
                        UserManager.AddToRole(user.Id, "User_registrado");

                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");  
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}