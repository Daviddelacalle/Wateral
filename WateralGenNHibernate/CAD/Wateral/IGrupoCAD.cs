
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IGrupoCAD
{
GrupoEN ReadOIDDefault (int id
                        );

void ModifyDefault (GrupoEN grupo);



int New_ (GrupoEN grupo);

void Modify (GrupoEN grupo);


void Destroy (int id
              );


GrupoEN ReadOID (int id
                 );


System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size);
}
}
