
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IValoracionCAD
{
ValoracionEN ReadOIDDefault (int id_valoracion
                             );

void ModifyDefault (ValoracionEN valoracion);



int New_ (ValoracionEN valoracion);

void Modify (ValoracionEN valoracion);


void Destroy (int id_valoracion
              );


ValoracionEN ReadOID (int id_valoracion
                      );


System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size);
}
}
