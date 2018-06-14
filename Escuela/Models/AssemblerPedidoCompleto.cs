using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;


namespace Escuela.Models
{
    public class AssemblerPedidoCompleto
    {
        public PedidoCompleto ConvertENToModelUI(PedidoEN linea)
        {

            PedidoCompleto resultado = new PedidoCompleto();
            resultado.Fecha = (DateTime)linea.Fecha;
            resultado.Precio = linea.Precio_total;
            resultado.Id = linea.Id;

            return resultado;



        }
        public IList<PedidoCompleto> ConvertListENToModel(IList<PedidoEN> ens)
        {
            IList<PedidoCompleto> info = new List<PedidoCompleto>();
            foreach (PedidoEN en in ens)
            {
                info.Add(ConvertENToModelUI(en));
            }
            return info;
        }
    }
}