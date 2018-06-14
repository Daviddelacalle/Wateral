
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IValoracionProductoCAD
{
ValoracionProductoEN ReadOIDDefault (int id_valoracion
                                     );

void ModifyDefault (ValoracionProductoEN valoracionProducto);



int New_ (ValoracionProductoEN valoracionProducto);

void Modify (ValoracionProductoEN valoracionProducto);


void Destroy (int id_valoracion
              );


int ValorarProducto (ValoracionProductoEN valoracionProducto);

ValoracionProductoEN ReadOID (int id_valoracion
                              );


System.Collections.Generic.IList<ValoracionProductoEN> ReadAll (int first, int size);
}
}
