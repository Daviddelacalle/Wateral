
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ICestaCAD
{
CestaEN ReadOIDDefault (int id
                        );

void ModifyDefault (CestaEN cesta);



int New_ (CestaEN cesta);

void Modify (CestaEN cesta);


void Destroy (int id
              );




CestaEN ReadOID (int id
                 );


System.Collections.Generic.IList<CestaEN> ReadAll (int first, int size);
}
}
