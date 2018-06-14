

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
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionCAD _IValoracionCAD;

public ValoracionCEN()
{
        this._IValoracionCAD = new ValoracionCAD ();
}

public ValoracionCEN(IValoracionCAD _IValoracionCAD)
{
        this._IValoracionCAD = _IValoracionCAD;
}

public IValoracionCAD get_IValoracionCAD ()
{
        return this._IValoracionCAD;
}

public int New_ (int p_nota)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Nota = p_nota;

        //Call to ValoracionCAD

        oid = _IValoracionCAD.New_ (valoracionEN);
        return oid;
}

public void Modify (int p_Valoracion_OID, int p_nota)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id_valoracion = p_Valoracion_OID;
        valoracionEN.Nota = p_nota;
        //Call to ValoracionCAD

        _IValoracionCAD.Modify (valoracionEN);
}

public void Destroy (int id_valoracion
                     )
{
        _IValoracionCAD.Destroy (id_valoracion);
}

public ValoracionEN ReadOID (int id_valoracion
                             )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionCAD.ReadOID (id_valoracion);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionCAD.ReadAll (first, size);
        return list;
}
}
}
