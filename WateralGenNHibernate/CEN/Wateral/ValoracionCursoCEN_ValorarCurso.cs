
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_ValoracionCurso_valorarCurso) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class ValoracionCursoCEN
{
public void ValorarCurso (int alumno, string curso, int nota, string comentario)
{
            /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_ValoracionCurso_valorarCurso) ENABLED START*/

            // Write here your custom code...

            ValoracionCursoCEN valoracion = new ValoracionCursoCEN();
            valoracion.New_(nota, alumno, curso);

        /*PROTECTED REGION END*/
}
}
}
