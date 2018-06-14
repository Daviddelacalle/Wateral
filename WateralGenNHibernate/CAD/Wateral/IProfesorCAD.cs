
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IProfesorCAD
{
ProfesorEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProfesorEN profesor);



int New_ (ProfesorEN profesor);

void Modify (ProfesorEN profesor);


void Destroy (int id
              );


ProfesorEN ReadOID (int id
                    );


System.Collections.Generic.IList<ProfesorEN> ReadAll (int first, int size);
}
}
