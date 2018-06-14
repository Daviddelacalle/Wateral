
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ILineaCestaCAD
{
LineaCestaEN ReadOIDDefault (int linea
                             );

void ModifyDefault (LineaCestaEN lineaCesta);



int New_ (LineaCestaEN lineaCesta);

void Modify (LineaCestaEN lineaCesta);


void Destroy (int linea
              );


LineaCestaEN ReadOID (int linea
                      );


System.Collections.Generic.IList<LineaCestaEN> ReadAll (int first, int size);
}
}
