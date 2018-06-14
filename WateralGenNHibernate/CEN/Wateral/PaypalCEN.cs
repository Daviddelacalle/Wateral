

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
 *      Definition of the class PaypalCEN
 *
 */
public partial class PaypalCEN
{
private IPaypalCAD _IPaypalCAD;

public PaypalCEN()
{
        this._IPaypalCAD = new PaypalCAD ();
}

public PaypalCEN(IPaypalCAD _IPaypalCAD)
{
        this._IPaypalCAD = _IPaypalCAD;
}

public IPaypalCAD get_IPaypalCAD ()
{
        return this._IPaypalCAD;
}

public int New_ (int p_pedido, string p_usuario, string p_password)
{
        PaypalEN paypalEN = null;
        int oid;

        //Initialized PaypalEN
        paypalEN = new PaypalEN ();

        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                paypalEN.Pedido = new WateralGenNHibernate.EN.Wateral.PedidoEN ();
                paypalEN.Pedido.Id = p_pedido;
        }

        paypalEN.Usuario = p_usuario;

        paypalEN.Password = p_password;

        //Call to PaypalCAD

        oid = _IPaypalCAD.New_ (paypalEN);
        return oid;
}

public void Modify (int p_Paypal_OID, string p_usuario, string p_password)
{
        PaypalEN paypalEN = null;

        //Initialized PaypalEN
        paypalEN = new PaypalEN ();
        paypalEN.Id = p_Paypal_OID;
        paypalEN.Usuario = p_usuario;
        paypalEN.Password = p_password;
        //Call to PaypalCAD

        _IPaypalCAD.Modify (paypalEN);
}

public void Destroy (int id
                     )
{
        _IPaypalCAD.Destroy (id);
}
}
}
