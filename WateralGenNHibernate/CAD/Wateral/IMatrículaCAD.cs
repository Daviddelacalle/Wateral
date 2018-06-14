
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IMatrículaCAD
{
MatrículaEN ReadOIDDefault (int id
                            );

void ModifyDefault (MatrículaEN matrícula);



int New_ (MatrículaEN matrícula);

void Modify (MatrículaEN matrícula);


void Destroy (int id
              );


MatrículaEN ReadOID (int id
                     );


System.Collections.Generic.IList<MatrículaEN> ReadAll (int first, int size);
}
}
