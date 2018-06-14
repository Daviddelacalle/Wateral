
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


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_Solicitud_cambio_solicitarCambio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class Solicitud_cambioCEN
{
public int SolicitarCambio (int alumno, int grupo, int grupo_cambio)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_Solicitud_cambio_solicitarCambio) ENABLED START*/

        // Write here your custom code...

        Solicitud_cambioCEN solicitudnueva = new Solicitud_cambioCEN ();
        int id = solicitudnueva.New_ (false, alumno, grupo, grupo_cambio);

        System.Console.WriteLine ("La solicitud del alumno: " + alumno + " para cambiar al grupo " + grupo_cambio + "ha sido registrada con exito");
        return id;



        /*PROTECTED REGION END*/
}
}
}
