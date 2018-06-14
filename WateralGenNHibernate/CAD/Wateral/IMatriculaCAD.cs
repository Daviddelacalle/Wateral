
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IMatriculaCAD
{
MatriculaEN ReadOIDDefault (int id
                            );

void ModifyDefault (MatriculaEN matricula);



int New_ (MatriculaEN matricula);

void Modify (MatriculaEN matricula);


void Destroy (int id
              );


MatriculaEN ReadOID (int id
                     );


System.Collections.Generic.IList<MatriculaEN> ReadAll (int first, int size);
}
}
