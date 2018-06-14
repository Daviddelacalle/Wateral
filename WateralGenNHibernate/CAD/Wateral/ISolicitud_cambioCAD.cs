
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ISolicitud_cambioCAD
{
Solicitud_cambioEN ReadOIDDefault (int id
                                   );

void ModifyDefault (Solicitud_cambioEN solicitud_cambio);



int New_ (Solicitud_cambioEN solicitud_cambio);

void Modify (Solicitud_cambioEN solicitud_cambio);


void Destroy (int id
              );


Solicitud_cambioEN ReadOID (int id
                            );


System.Collections.Generic.IList<Solicitud_cambioEN> ReadAll (int first, int size);
}
}
