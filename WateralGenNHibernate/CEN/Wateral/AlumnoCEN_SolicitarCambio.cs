
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


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_Alumno_solicitarCambio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class AlumnoCEN
{
public int SolicitarCambio (int p_oid, int grupo_actual, int grupo_destino)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_Alumno_solicitarCambio) ENABLED START*/

        // Write here your custom code...
        Solicitud_cambioCEN solicitud = new Solicitud_cambioCEN ();
        int idcambio = solicitud.New_ (false, p_oid, grupo_actual, grupo_destino);

        System.Console.WriteLine ("Solicitud realizada con exito");
        System.Console.WriteLine ("Se ha registrado en la BD con un id: " + idcambio);
        return idcambio;

        /*PROTECTED REGION END*/
}
}
}
