using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerUserRegistrado
    {
        public UserRegistrado ConvertENToModelUI(UserRegistradoEN en)
        {
            UserRegistrado user = new UserRegistrado();
            user.Email = en.Email;
            user.Nombre = en.Nombre;
            user.Fotoperfil = en.Imagen;
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.Email);
                user.Rol = s[0];
            }
            catch (Exception e)
            {
                user.Rol = "Tocapelotas";
            }
            return user;
        }
        public IList<UserRegistrado> ConvertListENToModel(IList<UserRegistradoEN> ens)
        {
            IList<UserRegistrado> users = new List<UserRegistrado>();
            foreach (UserRegistradoEN en in ens)
            {
                users.Add(ConvertENToModelUI(en));
            }
            return users;
        }

    }
}