
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IPagoCAD
{
PagoEN ReadOIDDefault (int id
                       );

void ModifyDefault (PagoEN pago);



int New_ (PagoEN pago);

void Modify (PagoEN pago);


void Destroy (int id
              );


int CrearPagoCesta (PagoEN pago);

void AsignarPagoPedido (int p_Pago_OID, int p_pedido_OID);

PagoEN ReadOID (int id
                );


System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size);


int CrearPagoMatricula (PagoEN pago);

void AsignarPagoMatricula (int p_Pago_OID, int p_matricula_OID);
}
}
