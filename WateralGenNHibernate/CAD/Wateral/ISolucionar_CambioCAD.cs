
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ISolucionar_CambioCAD
{
Solucionar_CambioEN ReadOIDDefault (int id
                                    );

void ModifyDefault (Solucionar_CambioEN solucionar_Cambio);



int New_ (Solucionar_CambioEN solucionar_Cambio);

void Modify (Solucionar_CambioEN solucionar_Cambio);


void Destroy (int id
              );
}
}
