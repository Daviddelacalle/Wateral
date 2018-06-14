

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
 *      Definition of the class VelaCEN
 *
 */
public partial class VelaCEN
{
private IVelaCAD _IVelaCAD;

public VelaCEN()
{
        this._IVelaCAD = new VelaCAD ();
}

public VelaCEN(IVelaCAD _IVelaCAD)
{
        this._IVelaCAD = _IVelaCAD;
}

public IVelaCAD get_IVelaCAD ()
{
        return this._IVelaCAD;
}

public int New_ (int p_precio, int p_duracion)
{
        VelaEN velaEN = null;
        int oid;

        //Initialized VelaEN
        velaEN = new VelaEN ();
        velaEN.Precio = p_precio;

        velaEN.Duracion = p_duracion;

        //Call to VelaCAD

        oid = _IVelaCAD.New_ (velaEN);
        return oid;
}

public void Modify (int p_Vela_OID, int p_precio, int p_duracion)
{
        VelaEN velaEN = null;

        //Initialized VelaEN
        velaEN = new VelaEN ();
        velaEN.Id = p_Vela_OID;
        velaEN.Precio = p_precio;
        velaEN.Duracion = p_duracion;
        //Call to VelaCAD

        _IVelaCAD.Modify (velaEN);
}

public void Destroy (int id
                     )
{
        _IVelaCAD.Destroy (id);
}
}
}
