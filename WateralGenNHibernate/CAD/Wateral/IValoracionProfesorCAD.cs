
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IValoracionProfesorCAD
{
ValoracionProfesorEN ReadOIDDefault (int id_valoracion
                                     );

void ModifyDefault (ValoracionProfesorEN valoracionProfesor);



int New_ (ValoracionProfesorEN valoracionProfesor);

void Modify (ValoracionProfesorEN valoracionProfesor);


void Destroy (int id_valoracion
              );


int ValorarProfesor (ValoracionProfesorEN valoracionProfesor);

ValoracionProfesorEN ReadOID (int id_valoracion
                              );


System.Collections.Generic.IList<ValoracionProfesorEN> ReadAll (int first, int size);
}
}
