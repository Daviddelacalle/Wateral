

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
 *      Definition of the class SupCEN
 *
 */
public partial class SupCEN
{
private ISupCAD _ISupCAD;

public SupCEN()
{
        this._ISupCAD = new SupCAD ();
}

public SupCEN(ISupCAD _ISupCAD)
{
        this._ISupCAD = _ISupCAD;
}

public ISupCAD get_ISupCAD ()
{
        return this._ISupCAD;
}

public int New_ (int p_precio, int p_duracion)
{
        SupEN supEN = null;
        int oid;

        //Initialized SupEN
        supEN = new SupEN ();
        supEN.Precio = p_precio;

        supEN.Duracion = p_duracion;

        //Call to SupCAD

        oid = _ISupCAD.New_ (supEN);
        return oid;
}

public void Modify (int p_Sup_OID, int p_precio, int p_duracion)
{
        SupEN supEN = null;

        //Initialized SupEN
        supEN = new SupEN ();
        supEN.Id = p_Sup_OID;
        supEN.Precio = p_precio;
        supEN.Duracion = p_duracion;
        //Call to SupCAD

        _ISupCAD.Modify (supEN);
}

public void Destroy (int id
                     )
{
        _ISupCAD.Destroy (id);
}
}
}
