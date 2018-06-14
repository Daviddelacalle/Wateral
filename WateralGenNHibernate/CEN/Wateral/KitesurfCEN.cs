

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
 *      Definition of the class KitesurfCEN
 *
 */
public partial class KitesurfCEN
{
private IKitesurfCAD _IKitesurfCAD;

public KitesurfCEN()
{
        this._IKitesurfCAD = new KitesurfCAD ();
}

public KitesurfCEN(IKitesurfCAD _IKitesurfCAD)
{
        this._IKitesurfCAD = _IKitesurfCAD;
}

public IKitesurfCAD get_IKitesurfCAD ()
{
        return this._IKitesurfCAD;
}

public int New_ (int p_precio, int p_duracion)
{
        KitesurfEN kitesurfEN = null;
        int oid;

        //Initialized KitesurfEN
        kitesurfEN = new KitesurfEN ();
        kitesurfEN.Precio = p_precio;

        kitesurfEN.Duracion = p_duracion;

        //Call to KitesurfCAD

        oid = _IKitesurfCAD.New_ (kitesurfEN);
        return oid;
}

public void Modify (int p_Kitesurf_OID, int p_precio, int p_duracion)
{
        KitesurfEN kitesurfEN = null;

        //Initialized KitesurfEN
        kitesurfEN = new KitesurfEN ();
        kitesurfEN.Id = p_Kitesurf_OID;
        kitesurfEN.Precio = p_precio;
        kitesurfEN.Duracion = p_duracion;
        //Call to KitesurfCAD

        _IKitesurfCAD.Modify (kitesurfEN);
}

public void Destroy (int id
                     )
{
        _IKitesurfCAD.Destroy (id);
}
}
}
