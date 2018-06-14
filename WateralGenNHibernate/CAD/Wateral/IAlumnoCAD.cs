
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IAlumnoCAD
{
AlumnoEN ReadOIDDefault (int idalumno
                         );

void ModifyDefault (AlumnoEN alumno);



int New_ (AlumnoEN alumno);

void Modify (AlumnoEN alumno);


void Destroy (int idalumno
              );


AlumnoEN ReadOID (int idalumno
                  );


System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size);


long CuentaAlumnos (int grupo);


int Inscribirse_curso (AlumnoEN alumno);
}
}
