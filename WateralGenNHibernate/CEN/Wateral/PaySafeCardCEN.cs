

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
 *      Definition of the class PaySafeCardCEN
 *
 */
public partial class PaySafeCardCEN
{
private IPaySafeCardCAD _IPaySafeCardCAD;

public PaySafeCardCEN()
{
        this._IPaySafeCardCAD = new PaySafeCardCAD ();
}

public PaySafeCardCEN(IPaySafeCardCAD _IPaySafeCardCAD)
{
        this._IPaySafeCardCAD = _IPaySafeCardCAD;
}

public IPaySafeCardCAD get_IPaySafeCardCAD ()
{
        return this._IPaySafeCardCAD;
}

public int New_ (int p_pedido, string p_codigo)
{
        PaySafeCardEN paySafeCardEN = null;
        int oid;

        //Initialized PaySafeCardEN
        paySafeCardEN = new PaySafeCardEN ();

        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                paySafeCardEN.Pedido = new WateralGenNHibernate.EN.Wateral.PedidoEN ();
                paySafeCardEN.Pedido.Id = p_pedido;
        }

        paySafeCardEN.Codigo = p_codigo;

        //Call to PaySafeCardCAD

        oid = _IPaySafeCardCAD.New_ (paySafeCardEN);
        return oid;
}

public void Modify (int p_PaySafeCard_OID, string p_codigo)
{
        PaySafeCardEN paySafeCardEN = null;

        //Initialized PaySafeCardEN
        paySafeCardEN = new PaySafeCardEN ();
        paySafeCardEN.Id = p_PaySafeCard_OID;
        paySafeCardEN.Codigo = p_codigo;
        //Call to PaySafeCardCAD

        _IPaySafeCardCAD.Modify (paySafeCardEN);
}

public void Destroy (int id
                     )
{
        _IPaySafeCardCAD.Destroy (id);
}
}
}
