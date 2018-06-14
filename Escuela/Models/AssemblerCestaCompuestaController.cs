using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerCestaCompuestaController
    {
        public CestaCompuesta ConvertENToModelUI(LineaCestaEN linea)
        {
            CestaCompuesta resultado = new CestaCompuesta();
            resultado.Id = linea.Producto.Id;
            resultado.IdMain = linea.Linea;
            resultado.Nombre = linea.Producto.Nombre;
            resultado.Cantidad = linea.Cantidad;
            resultado.Dias = linea.Dias;
            resultado.Imagen = linea.Producto.Imagen;
            resultado.Precio = linea.Precio;

            return resultado;



        }
        public IList<CestaCompuesta> ConvertListENToModel(IList<LineaCestaEN> ens)
        {
            IList<CestaCompuesta> info = new List<CestaCompuesta>();
            foreach (LineaCestaEN en in ens)
            {
                info.Add(ConvertENToModelUI(en));
            }
            return info;
        }
    }
}