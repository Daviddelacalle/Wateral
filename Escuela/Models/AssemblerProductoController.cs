using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerProducto
    {
        public Producto ConvertENToModelUI(ProductoEN en)
        {
            Producto producto = new Producto();
            producto.id = en.Id;
            producto.Nombre = en.Nombre;
            producto.Descripcion = en.Descripcion;
            producto.Imagen = en.Imagen;
            producto.Precio_compra = en.Precio_compra;
            producto.Precio_alquiler = en.Precio_alquiler;
            producto.stock = en.Stock;
            
            return producto;

        }
        public IList<Producto> ConvertListENToModel(IList<ProductoEN> ens)
        {
            IList<Producto> productos = new List<Producto>();
            foreach (ProductoEN en in ens)
            {
                productos.Add(ConvertENToModelUI(en));
            }
            return productos;
        }

    }
}