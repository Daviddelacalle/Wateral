

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.Exceptions;

using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;


namespace WateralGenNHibernate.CEN.Wateral
{
/*
 *      Definition of the class NoticiaCEN
 *
 */
public partial class NoticiaCEN
{
private INoticiaCAD _INoticiaCAD;

public NoticiaCEN()
{
        this._INoticiaCAD = new NoticiaCAD ();
}

public NoticiaCEN(INoticiaCAD _INoticiaCAD)
{
        this._INoticiaCAD = _INoticiaCAD;
}

public INoticiaCAD get_INoticiaCAD ()
{
        return this._INoticiaCAD;
}

public int New_ (string p_administrador, string p_noticia, string p_imagen, Nullable<DateTime> p_fecha, string p_titulo)
{
        NoticiaEN noticiaEN = null;
        int oid;

        //Initialized NoticiaEN
        noticiaEN = new NoticiaEN ();

        if (p_administrador != null) {
                // El argumento p_administrador -> Property administrador es oid = false
                // Lista de oids id
                noticiaEN.Administrador = new WateralGenNHibernate.EN.Wateral.AdministradorEN ();
                noticiaEN.Administrador.Email = p_administrador;
        }

        noticiaEN.Noticia = p_noticia;

        noticiaEN.Imagen = p_imagen;

        noticiaEN.Fecha = p_fecha;

        noticiaEN.Titulo = p_titulo;

        //Call to NoticiaCAD

        oid = _INoticiaCAD.New_ (noticiaEN);
        return oid;
}

public void Modify (int p_Noticia_OID, string p_noticia, string p_imagen, Nullable<DateTime> p_fecha, string p_titulo)
{
        NoticiaEN noticiaEN = null;

        //Initialized NoticiaEN
        noticiaEN = new NoticiaEN ();
        noticiaEN.Id = p_Noticia_OID;
        noticiaEN.Noticia = p_noticia;
        noticiaEN.Imagen = p_imagen;
        noticiaEN.Fecha = p_fecha;
        noticiaEN.Titulo = p_titulo;
        //Call to NoticiaCAD

        _INoticiaCAD.Modify (noticiaEN);
}

public void Destroy (int id
                     )
{
        _INoticiaCAD.Destroy (id);
}

public NoticiaEN ReadOID (int id
                          )
{
        NoticiaEN noticiaEN = null;

        noticiaEN = _INoticiaCAD.ReadOID (id);
        return noticiaEN;
}

public System.Collections.Generic.IList<NoticiaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NoticiaEN> list = null;

        list = _INoticiaCAD.ReadAll (first, size);
        return list;
}
}
}
