
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


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_Administrador_validar_cambio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class AdministradorCEN
{
public void Validar_cambio (int solicitud_cambio)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_Administrador_validar_cambio) ENABLED START*/

        // Write here your custom code...

        Solicitud_cambioCEN solicitud = new Solicitud_cambioCEN ();

        solicitud.Modify (solicitud_cambio, true);
        System.Console.WriteLine ("Solicitud de cambio validada por el admin");

        /*PROTECTED REGION END*/
}
}
}
