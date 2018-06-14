
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


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_Mensaje_enviarMensaje) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class MensajeCEN
{
public void EnviarMensaje (string usuario_1, string usuario2, string mensaje)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_Mensaje_enviarMensaje) ENABLED START*/

        // Write here your custom code...

        MensajeCEN bandeha = new MensajeCEN ();
        DateTime hoy = DateTime.Now;

        bandeha.New_ (mensaje, hoy, usuario_1, usuario2, false);

        /*PROTECTED REGION END*/
}
}
}
