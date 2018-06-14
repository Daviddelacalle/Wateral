

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
 *      Definition of the class ValoracionProductoCEN
 *
 */
public partial class ValoracionProductoCEN
{
private IValoracionProductoCAD _IValoracionProductoCAD;

public ValoracionProductoCEN()
{
        this._IValoracionProductoCAD = new ValoracionProductoCAD ();
}

public ValoracionProductoCEN(IValoracionProductoCAD _IValoracionProductoCAD)
{
        this._IValoracionProductoCAD = _IValoracionProductoCAD;
}

public IValoracionProductoCAD get_IValoracionProductoCAD ()
{
        return this._IValoracionProductoCAD;
}

public int New_ (int p_nota, string p_userRegistrado, int p_producto)
{
        ValoracionProductoEN valoracionProductoEN = null;
        int oid;

        //Initialized ValoracionProductoEN
        valoracionProductoEN = new ValoracionProductoEN ();
        valoracionProductoEN.Nota = p_nota;


        if (p_userRegistrado != null) {
                // El argumento p_userRegistrado -> Property userRegistrado es oid = false
                // Lista de oids id_valoracion
                valoracionProductoEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                valoracionProductoEN.UserRegistrado.Email = p_userRegistrado;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id_valoracion
                valoracionProductoEN.Producto = new WateralGenNHibernate.EN.Wateral.ProductoEN ();
                valoracionProductoEN.Producto.Id = p_producto;
        }

        //Call to ValoracionProductoCAD

        oid = _IValoracionProductoCAD.New_ (valoracionProductoEN);
        return oid;
}

public void Modify (int p_ValoracionProducto_OID, int p_nota)
{
        ValoracionProductoEN valoracionProductoEN = null;

        //Initialized ValoracionProductoEN
        valoracionProductoEN = new ValoracionProductoEN ();
        valoracionProductoEN.Id_valoracion = p_ValoracionProducto_OID;
        valoracionProductoEN.Nota = p_nota;
        //Call to ValoracionProductoCAD

        _IValoracionProductoCAD.Modify (valoracionProductoEN);
}

public void Destroy (int id_valoracion
                     )
{
        _IValoracionProductoCAD.Destroy (id_valoracion);
}

public ValoracionProductoEN ReadOID (int id_valoracion
                                     )
{
        ValoracionProductoEN valoracionProductoEN = null;

        valoracionProductoEN = _IValoracionProductoCAD.ReadOID (id_valoracion);
        return valoracionProductoEN;
}

public System.Collections.Generic.IList<ValoracionProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionProductoEN> list = null;

        list = _IValoracionProductoCAD.ReadAll (first, size);
        return list;
}
}
}
