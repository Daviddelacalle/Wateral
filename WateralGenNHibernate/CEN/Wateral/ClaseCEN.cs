

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
 *      Definition of the class ClaseCEN
 *
 */
public partial class ClaseCEN
{
private IClaseCAD _IClaseCAD;

public ClaseCEN()
{
        this._IClaseCAD = new ClaseCAD ();
}

public ClaseCEN(IClaseCAD _IClaseCAD)
{
        this._IClaseCAD = _IClaseCAD;
}

public IClaseCAD get_IClaseCAD ()
{
        return this._IClaseCAD;
}

public int New_ (int p_grupo, Nullable<DateTime> p_fecha, Nullable<DateTime> p_hInicio, Nullable<DateTime> p_hFin)
{
        ClaseEN claseEN = null;
        int oid;

        //Initialized ClaseEN
        claseEN = new ClaseEN ();

        if (p_grupo != -1) {
                // El argumento p_grupo -> Property grupo es oid = false
                // Lista de oids id
                claseEN.Grupo = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                claseEN.Grupo.Id = p_grupo;
        }

        claseEN.Fecha = p_fecha;

        claseEN.HInicio = p_hInicio;

        claseEN.HFin = p_hFin;

        //Call to ClaseCAD

        oid = _IClaseCAD.New_ (claseEN);
        return oid;
}

public void Modify (int p_Clase_OID, Nullable<DateTime> p_fecha, Nullable<DateTime> p_hInicio, Nullable<DateTime> p_hFin)
{
        ClaseEN claseEN = null;

        //Initialized ClaseEN
        claseEN = new ClaseEN ();
        claseEN.Id = p_Clase_OID;
        claseEN.Fecha = p_fecha;
        claseEN.HInicio = p_hInicio;
        claseEN.HFin = p_hFin;
        //Call to ClaseCAD

        _IClaseCAD.Modify (claseEN);
}

public void Destroy (int id
                     )
{
        _IClaseCAD.Destroy (id);
}

public ClaseEN ReadOID (int id
                        )
{
        ClaseEN claseEN = null;

        claseEN = _IClaseCAD.ReadOID (id);
        return claseEN;
}

public System.Collections.Generic.IList<ClaseEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClaseEN> list = null;

        list = _IClaseCAD.ReadAll (first, size);
        return list;
}
}
}
