
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ITarjetaCAD
{
TarjetaEN ReadOIDDefault (string numero
                          );

void ModifyDefault (TarjetaEN tarjeta);



string New_ (TarjetaEN tarjeta);

void Modify (TarjetaEN tarjeta);


void Destroy (string numero
              );


TarjetaEN ReadOID (string numero
                   );


System.Collections.Generic.IList<TarjetaEN> ReadAll (int first, int size);
}
}
