using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerMensaje
    {
        public Mensaje ConvertENToModelUI(MensajeEN en)
        {
            Mensaje mensaje = new Mensaje();
            mensaje.id = en.Id;
            mensaje.Texto = en.Mensaje;
            mensaje.Fecha = en.Fecha;
            mensaje.Emisor = en.UserRegistrado.Email;
            mensaje.Receptor = en.UserRegistrado_0.Email;

            return mensaje;

        }
        public IList<Mensaje> ConvertListENToModel(IList<MensajeEN> ens)
        {
            IList<Mensaje> info = new List<Mensaje>();
            foreach (MensajeEN en in ens)
            {
                info.Add(ConvertENToModelUI(en));
            }
            return info;
        }
    }
}