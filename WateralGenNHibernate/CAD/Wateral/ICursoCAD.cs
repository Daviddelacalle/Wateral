
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ICursoCAD
{
CursoEN ReadOIDDefault (int id
                        );

void ModifyDefault (CursoEN curso);



int New_ (CursoEN curso);

void Modify (CursoEN curso);


void Destroy (int id
              );


CursoEN ReadOID (int id
                 );


System.Collections.Generic.IList<CursoEN> ReadAll (int first, int size);
}
}
