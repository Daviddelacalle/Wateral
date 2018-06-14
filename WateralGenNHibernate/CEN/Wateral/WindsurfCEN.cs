

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
 *      Definition of the class WindsurfCEN
 *
 */
public partial class WindsurfCEN
{
private IWindsurfCAD _IWindsurfCAD;

public WindsurfCEN()
{
        this._IWindsurfCAD = new WindsurfCAD ();
}

public WindsurfCEN(IWindsurfCAD _IWindsurfCAD)
{
        this._IWindsurfCAD = _IWindsurfCAD;
}

public IWindsurfCAD get_IWindsurfCAD ()
{
        return this._IWindsurfCAD;
}

public int New_ (int p_precio, int p_duracion)
{
        WindsurfEN windsurfEN = null;
        int oid;

        //Initialized WindsurfEN
        windsurfEN = new WindsurfEN ();
        windsurfEN.Precio = p_precio;

        windsurfEN.Duracion = p_duracion;

        //Call to WindsurfCAD

        oid = _IWindsurfCAD.New_ (windsurfEN);
        return oid;
}

public void Modify (int p_Windsurf_OID, int p_precio, int p_duracion)
{
        WindsurfEN windsurfEN = null;

        //Initialized WindsurfEN
        windsurfEN = new WindsurfEN ();
        windsurfEN.Id = p_Windsurf_OID;
        windsurfEN.Precio = p_precio;
        windsurfEN.Duracion = p_duracion;
        //Call to WindsurfCAD

        _IWindsurfCAD.Modify (windsurfEN);
}

public void Destroy (int id
                     )
{
        _IWindsurfCAD.Destroy (id);
}
}
}
