using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerPedidoController
    {
        public Pedido ConvertENToModelUI(LineaPedidoEN linea)
        {
            Pedido resultado = new Pedido();

            resultado.Cantidad = linea.Cantidad;
            resultado.Nombre = linea.Producto;
            resultado.Precio = linea.Precio;
            resultado.Dias = linea.Dias;
            resultado.Imagen = linea.Imagen;


            return resultado;



        }
        public IList<Pedido> ConvertListENToModel(IList<LineaPedidoEN> ens)
        {
            IList<Pedido> info = new List<Pedido>();
            foreach (LineaPedidoEN en in ens)
            {
                info.Add(ConvertENToModelUI(en));
            }
            return info;
        }
    }
}