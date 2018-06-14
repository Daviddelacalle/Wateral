
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int id
                         );

void ModifyDefault (PedidoEN pedido);



int New_ (PedidoEN pedido);

void Modify (PedidoEN pedido);


void Destroy (int id
              );


PedidoEN ReadOID (int id
                  );


System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size);
}
}
