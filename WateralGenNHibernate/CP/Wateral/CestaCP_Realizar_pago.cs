
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Cesta_realizar_pago) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class CestaCP : BasicCP
{
public int Realizar_pago (int p_oid, int tipo)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Cesta_realizar_pago) ENABLED START*/


        ICestaCAD cestaCAD = null;
        CestaCEN cestaCEN = null;
        ILineaCestaCAD lineaCestaCAD = null;
        LineaCestaCEN lineaCestaCEN = null;
        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;
        IPagoCAD pagoCAD = null;
        PagoCEN pagoCEN = null;
        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;
        IProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;
        int pedido = 0;

        try
        {
                SessionInitializeTransaction ();
                cestaCAD = new CestaCAD (session);
                cestaCEN = new CestaCEN (cestaCAD);
                lineaCestaCAD = new LineaCestaCAD (session);
                lineaCestaCEN = new LineaCestaCEN (lineaCestaCAD);
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new LineaPedidoCEN (lineaPedidoCAD);
                pagoCAD = new PagoCAD (session);
                pagoCEN = new PagoCEN (pagoCAD);
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new PedidoCEN (pedidoCAD);
                productoCAD = new ProductoCAD (session);
                productoCEN = new ProductoCEN (productoCAD);

                if (tipo == 3) {
                        CestaEN cestaza = cestaCEN.ReadOID (p_oid);
                        WateralGenNHibernate.CP.Wateral.LineaCestaCP cp_lincesta = new WateralGenNHibernate.CP.Wateral.LineaCestaCP ();
                        LineaCestaEN linaconsultar = lineaCestaCEN.ReadOID (tipo);

                        IList<LineaPedidoEN> lista = new List<LineaPedidoEN>();
                        IList<LineaCestaEN> listacest = new List<LineaCestaEN>();
                        int aux = 0;
                        double precio = 0;
                        foreach (LineaCestaEN x in cestaza.LineasCesta) {
                                aux = cp_lincesta.Create_LinPed (x.Linea);
                                precio += lineaPedidoCEN.ReadOID (aux).Precio;
                                lista.Add (lineaPedidoCEN.ReadOID (aux));
                                listacest.Add (x);
                                productoCEN.ModificarStock (x.Producto.Id, -x.Cantidad);
                        }



                        DateTime creacion = DateTime.Now;
                        pedido = pedidoCEN.New_ (creacion, lista, cestaCEN.ReadOID (p_oid).Usuario_Regist.Email, precio);
                        /*
                         * WateralGenNHibernate.CP.Wateral.PagoCP pagocustom = new WateralGenNHibernate.CP.Wateral.PagoCP (session);
                         * pagocustom.CrearPagoCesta (WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum.tarjeta, pedido);
                         *
                         * foreach (LineaCestaEN x in cestaza.LineasCesta) {
                         *      lineaPedidoCAD.EliminarCesta (x.LineaPedido.Id, x.Linea);
                         *      lineaCestaCEN.Destroy (x.Linea);
                         * }
                         */
                        for (int i = 0; i < lista.Count; i++) {
                                lineaPedidoCAD.EliminarCesta (lista [i].Id, listacest [i].Linea);
                                lineaCestaCEN.Destroy (listacest [i].Linea);
                        }
                }

                SessionCommit ();
                return pedido;
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
