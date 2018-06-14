

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
 *      Definition of the class CursoCEN
 *
 */
public partial class CursoCEN
{
private ICursoCAD _ICursoCAD;

public CursoCEN()
{
        this._ICursoCAD = new CursoCAD ();
}

public CursoCEN(ICursoCAD _ICursoCAD)
{
        this._ICursoCAD = _ICursoCAD;
}

public ICursoCAD get_ICursoCAD ()
{
        return this._ICursoCAD;
}

public int New_ (int p_precio, int p_duracion, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum p_tipo, string p_nombre, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, string p_imagen)
{
        CursoEN cursoEN = null;
        int oid;

        //Initialized CursoEN
        cursoEN = new CursoEN ();
        cursoEN.Precio = p_precio;

        cursoEN.Duracion = p_duracion;

        cursoEN.Tipo = p_tipo;

        cursoEN.Nombre = p_nombre;

        cursoEN.FechaInicio = p_fechaInicio;

        cursoEN.FechaFin = p_fechaFin;

        cursoEN.Imagen = p_imagen;

        //Call to CursoCAD

        oid = _ICursoCAD.New_ (cursoEN);
        return oid;
}

public void Modify (int p_Curso_OID, int p_precio, int p_duracion, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum p_tipo, string p_nombre, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, string p_imagen)
{
        CursoEN cursoEN = null;

        //Initialized CursoEN
        cursoEN = new CursoEN ();
        cursoEN.Id = p_Curso_OID;
        cursoEN.Precio = p_precio;
        cursoEN.Duracion = p_duracion;
        cursoEN.Tipo = p_tipo;
        cursoEN.Nombre = p_nombre;
        cursoEN.FechaInicio = p_fechaInicio;
        cursoEN.FechaFin = p_fechaFin;
        cursoEN.Imagen = p_imagen;
        //Call to CursoCAD

        _ICursoCAD.Modify (cursoEN);
}

public void Destroy (int id
                     )
{
        _ICursoCAD.Destroy (id);
}

public CursoEN ReadOID (int id
                        )
{
        CursoEN cursoEN = null;

        cursoEN = _ICursoCAD.ReadOID (id);
        return cursoEN;
}

public System.Collections.Generic.IList<CursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CursoEN> list = null;

        list = _ICursoCAD.ReadAll (first, size);
        return list;
}
}
}
