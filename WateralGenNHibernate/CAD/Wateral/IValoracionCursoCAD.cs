
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IValoracionCursoCAD
{
ValoracionCursoEN ReadOIDDefault (int id_valoracion
                                  );

void ModifyDefault (ValoracionCursoEN valoracionCurso);



int New_ (ValoracionCursoEN valoracionCurso);

void Modify (ValoracionCursoEN valoracionCurso);


void Destroy (int id_valoracion
              );


int ValorarCurso (ValoracionCursoEN valoracionCurso);

ValoracionCursoEN ReadOID (int id_valoracion
                           );


System.Collections.Generic.IList<ValoracionCursoEN> ReadAll (int first, int size);
}
}
