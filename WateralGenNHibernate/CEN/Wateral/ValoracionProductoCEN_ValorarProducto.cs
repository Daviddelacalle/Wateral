
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


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_ValoracionProducto_valorarProducto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class ValoracionProductoCEN
{
public void ValorarProducto (string usuario, int producto, int nota, string comentario)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_ValoracionProducto_valorarProducto) ENABLED START*/

        // Write here your custom code...

        ValoracionProductoCEN valoracion = new ValoracionProductoCEN ();

        valoracion.New_ (nota, usuario, producto);

        /*PROTECTED REGION END*/
}
}
}
