
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IClaseCAD
{
ClaseEN ReadOIDDefault (int id
                        );

void ModifyDefault (ClaseEN clase);



int New_ (ClaseEN clase);

void Modify (ClaseEN clase);


void Destroy (int id
              );


ClaseEN ReadOID (int id
                 );


System.Collections.Generic.IList<ClaseEN> ReadAll (int first, int size);
}
}
