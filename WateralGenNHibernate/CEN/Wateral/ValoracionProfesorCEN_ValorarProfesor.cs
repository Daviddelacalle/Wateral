
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


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_ValoracionProfesor_valorarProfesor) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class ValoracionProfesorCEN
{
public void ValorarProfesor (int alumno, string profesor, int nota, string comentario)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_ValoracionProfesor_valorarProfesor) ENABLED START*/

        // Write here your custom code...

        ValoracionProfesorCEN valoracion = new ValoracionProfesorCEN ();

        valoracion.New_ (nota, alumno, profesor);

        /*PROTECTED REGION END*/
}
}
}
