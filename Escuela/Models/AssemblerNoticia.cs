using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerNoticia
    {
        public Noticia ConvertENToModelUI(NoticiaEN linea)
        {

            Noticia resultado = new Noticia();
            resultado.id = linea.Id;
            resultado.Autor = linea.Administrador.Nombre;
            resultado.Fecha = linea.Fecha;
            resultado.Imagen = linea.Imagen;
            resultado.Texto = linea.Noticia;
            resultado.Titulo = linea.Titulo;

            return resultado;



        }
        public IList<Noticia> ConvertListENToModel(IList<NoticiaEN> ens)
        {
            IList<Noticia> info = new List<Noticia>();
            foreach (NoticiaEN en in ens)
            {
                info.Add(ConvertENToModelUI(en));
            }
            return info;
        }
    }
}