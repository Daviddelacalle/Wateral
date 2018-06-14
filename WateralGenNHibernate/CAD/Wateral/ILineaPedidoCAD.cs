
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ILineaPedidoCAD
{
LineaPedidoEN ReadOIDDefault (int id
                              );

void ModifyDefault (LineaPedidoEN lineaPedido);



int New_ (LineaPedidoEN lineaPedido);

void Modify (LineaPedidoEN lineaPedido);


void Destroy (int id
              );


LineaPedidoEN ReadOID (int id
                       );


System.Collections.Generic.IList<LineaPedidoEN> ReadAll (int first, int size);


void CrearPedido (int p_LineaPedido_OID, int p_lineaCesta_OID);

void EliminarCesta (int p_LineaPedido_OID, int p_lineaCesta_OID);
}
}
