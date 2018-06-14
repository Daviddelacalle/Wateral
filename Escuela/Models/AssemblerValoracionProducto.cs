using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;


namespace Escuela.Models
{
    public class AssemblerValoracionProducto
    {
        public ValoracionProducto ConvertENToModelUI(ValoracionProductoEN en)
        {
            ValoracionProducto producto = new ValoracionProducto();
            producto.comentario = en.Comentario;
            producto.nota = en.Nota;
            producto.producto = en.Producto.Id;
            producto.usuario = en.UserRegistrado.Email;
            producto.id = en.Id_valoracion;

            return producto;

        }
        public IList<ValoracionProducto> ConvertListENToModel(IList<ValoracionProductoEN> ens)
        {
            IList<ValoracionProducto> productos = new List<ValoracionProducto>();
            foreach (ValoracionProductoEN en in ens)
            {
                productos.Add(ConvertENToModelUI(en));
            }
            return productos;
        }
    }
}