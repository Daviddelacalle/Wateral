using Escuela.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using WateralGenNHibernate.CEN.Wateral;

[assembly: OwinStartupAttribute(typeof(Escuela.Startup))]
namespace Escuela
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // Creamos el rol de Admin  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.Id = "administrator@gmail.com";
                user.UserName = "administrator@gmail.com";
                user.Email = "administrator@gmail.com";

                DateTime fecha = new DateTime(1990, 1, 1);
                AdministradorCEN cen = new AdministradorCEN();
                //cen.New_("administrator@gmail.com", "Administradorcillo", "Administradorcillo", "Administradorcillo", "Administradorcillo", DateTime.Now,"imagen");
                cen.New_("administrator@gmail.com", "admin2", "Administrator", "Apellidos", "Admin123.", fecha, "imagen");

                string userPWD = "Admin123.";

                var chkUser = UserManager.Create(user, userPWD);

                //Metemos a nuestro admin a tope  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("User_registrado"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User_registrado";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Alumno"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Alumno";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Profesor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Profesor";
                roleManager.Create(role);
                //Creamos el staff de profesores
                createStaff();
            }
        }

        private void createStaff()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            DateTime nacimiento = new DateTime(1997, 10, 1);
            DateTime fechafin = new DateTime(2018, 01, 10);
            DateTime manana = new DateTime(2018, 01, 12);
            DateTime domingo = new DateTime(2018, 01, 14);
            DateTime lunes = new DateTime(2018, 01, 15);
            DateTime hora = new DateTime(2008, 01, 13, 11, 00, 0);
            DateTime fin1 = new DateTime(2008, 01, 13, 11, 00, 0);
            DateTime hora2 = new DateTime(2008, 4, 13, 15, 00, 0);
            DateTime fin2 = new DateTime(2008, 4, 13, 18, 00, 0);
            DateTime hora3 = new DateTime(2008, 4, 14, 12, 00, 0);
            DateTime fin3 = new DateTime(2008, 4, 14, 15, 00, 0);
            DateTime hora4 = new DateTime(2008, 4, 14, 10, 00, 0);

            ProfesorCEN profesor = new ProfesorCEN();
            UserRegistradoCEN user_gen = new UserRegistradoCEN();

            /////Profe1//////
            string profe = user_gen.New_("carlosaldaravi@gmail.com", "Bart", "Bartolomé", "Patriarka", "PutabidaXD", nacimiento, "imagen1.jpg");
            int profesor1 = profesor.New_("esdfsdsdf", "EveryDay", profe, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf);
            var profemvc1 = new ApplicationUser();
            profemvc1.Id = "carlosaldaravi@gmail.com";
            profemvc1.UserName = "carlosaldaravi@gmail.com";
            profemvc1.Email = "carlosaldaravi@gmail.com";
            string profePWD = "Profe123.";
            var chkUser1 = UserManager.Create(profemvc1, profePWD);
            if (chkUser1.Succeeded)
            {
                var result1 = UserManager.AddToRole(profemvc1.Id, "Profesor");
            }

            /////Profe2//////
            string profe1 = user_gen.New_("federostia@pati.es", "Fede", "Federico", "iuytfds", "1234", nacimiento, "imagen1.jpg");
            int profesor2 = profesor.New_("34tswrdfdf", "Verano", profe1, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf);
            var profemvc2 = new ApplicationUser();
            profemvc2.Id = "federostia@pati.es";
            profemvc2.UserName = "federostia@pati.es";
            profemvc2.Email = "federostia@pati.es";
            var chkUser2 = UserManager.Create(profemvc2, profePWD);
            var result2 = UserManager.AddToRole(profemvc2.Id, "Profesor");

            /////Profe3//////
            string profe2 = user_gen.New_("gust@vo.com", "Gus", "Gush", "juy2ujf", "1234", nacimiento, "imagen");
            int profesor3 = profesor.New_("4yh4wtrwsg", "Agosto", profe2, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf);
            var profemvc3 = new ApplicationUser();
            profemvc3.Id = "gust@vo.com";
            profemvc3.UserName = "gust@vo.com";
            profemvc3.Email = "gust@vo.com";
            var chkUser3 = UserManager.Create(profemvc3, profePWD);
            var result3 = UserManager.AddToRole(profemvc3.Id, "Profesor");

            /////Profe4/////
            string profe3 = user_gen.New_("heisenberg@eeuu.com", "Heis", "Heisenberg", "2354rte", "1234", nacimiento, "imagen");
            int profesor4 = profesor.New_("sw4gsgstww", "Agosto", profe3, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf);
            var profemvc4 = new ApplicationUser();
            profemvc4.Id = "heisenberg@eeuu.com";
            profemvc4.UserName = "heisenberg@eeuu.com";
            profemvc4.Email = "heisenberg@eeuu.com";
            var chkUser4 = UserManager.Create(profemvc4, profePWD);
            var result4 = UserManager.AddToRole(profemvc4.Id, "Profesor");

            /////Profe5//////
            string profe4 = user_gen.New_("ladea@dea.com", "DEA", "LaDea", "2ed45v3x", "1234", nacimiento, "imagen");
            int profesor5 = profesor.New_("wet4wtvgcs", "Agosto", profe4, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.sup);
            var profemvc5 = new ApplicationUser();
            profemvc5.Id = "ladea@dea.com";
            profemvc5.UserName = "ladea@dea.com";
            profemvc5.Email = "ladea@dea.com";
            var chkUser5 = UserManager.Create(profemvc5, profePWD);
            var result5 = UserManager.AddToRole(profemvc5.Id, "Profesor");


            /////Profe6//////
            string profe5 = user_gen.New_("batman@gotham.com", "Bat", "Batman", "45tv4y3w4", "1234", nacimiento, "imagen");
            int profesor6 = profesor.New_("w4tsw4twst", "Agosto", profe5, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.vela);
            var profemvc6 = new ApplicationUser();
            profemvc6.Id = "batman@gotham.com";
            profemvc6.UserName = "batman@gotham.com";
            profemvc6.Email = "batman@gotham.com";
            var chkUser6 = UserManager.Create(profemvc6, profePWD);
            var result6 = UserManager.AddToRole(profemvc6.Id, "Profesor");

            //Creación de cursos 
            CursoCEN cursoCEN = new CursoCEN();

            int kitesurf = cursoCEN.New_(200, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf, "Iniciación", DateTime.Today, fechafin, "kitesurf.jpg");
            int kitesurfP = cursoCEN.New_(200, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf, "Perfeccionamiento", DateTime.Today, fechafin, "kitesurf2.jpg");
            int kitesurfA = cursoCEN.New_(60, 1, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.kitesurf, "Freestyle", DateTime.Today, fechafin, "kitesurf3.jpg");

            int windsurf = cursoCEN.New_(150, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf, "Iniciación", DateTime.Today, fechafin, "windsurf.jpg");
            int windsurfA = cursoCEN.New_(150, 6, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.windsurf, "Avanzado", DateTime.Today, fechafin, "windsurfA.jpg");

            int paddlesurf = cursoCEN.New_(100, 2, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.sup, "Iniciación", DateTime.Today, fechafin, "sup.jpg");
            int paddlesurfOlas = cursoCEN.New_(240, 10, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.sup, "Olas", DateTime.Today, fechafin, "supOlas.jpg");

            int vela = cursoCEN.New_(200, 10, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum.vela, "Básico", DateTime.Today, fechafin, "vela.jpg");


            GrupoCEN grupoCEN = new GrupoCEN();
            int grupo1 = grupoCEN.New_(kitesurf, profesor1, 4, "Sabado y Domingo de 11:00 a 14:00");
            int grupo2 = grupoCEN.New_(kitesurf, profesor2, 4, "Sabado y Domingo de 11:00 a 14:00");
            int grupo3 = grupoCEN.New_(kitesurfP, profesor2, 2, "Sabado y Domingo de 15:00 a 18:00");
            int grupo4 = grupoCEN.New_(kitesurfA, profesor1, 1, "Lunes y miércoles de 12:00 a 15:00");
            int grupoWind1 = grupoCEN.New_(windsurf, profesor3, 6, "Domingos de 09:00 a 12:00");
            int grupoWind2 = grupoCEN.New_(windsurfA, profesor3, 6, "Domingos de 09:00 a 12:00");
            int grupoWind3 = grupoCEN.New_(windsurfA, profesor4, 6, "Domingos de 12:00 a 15:00");
            int grupoSup1 = grupoCEN.New_(paddlesurf, profesor5, 10, "Domingos de 10:00 a 12:00");
            int grupoVela1 = grupoCEN.New_(vela, profesor6, 6, "Domingos de 10:00 a 12:00");

            ClaseCEN creadorclases = new ClaseCEN();

            int claseKite1 = creadorclases.New_(grupo1, manana, hora, fin1);
            int claseKite2 = creadorclases.New_(grupo2, manana, hora, fin1);
            int claseKite3 = creadorclases.New_(grupo3, lunes, hora2, fin2);
            int claseKite4 = creadorclases.New_(grupo3, lunes, hora3, fin3);
            int claseKite5 = creadorclases.New_(grupo3, lunes, hora3, fin3);
            int claseWind1 = creadorclases.New_(grupoWind1, domingo, hora, fin1);
            int claseWind2 = creadorclases.New_(grupoWind2, domingo, hora, fin1);
            int claseWind3 = creadorclases.New_(grupoWind3, domingo, hora3, fin3);
            int claseSup1 = creadorclases.New_(grupoSup1, domingo, hora4, fin3);
            int claseVela1 = creadorclases.New_(grupoVela1, domingo, hora4, fin3);

        }
    }
}