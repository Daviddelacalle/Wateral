
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


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_UserRegistrado_inscribirse_curso) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class UserRegistradoCEN
{
public int Inscribirse_curso (string p_oid, string disponibilidad, int peso, WateralGenNHibernate.Enumerated.Wateral.TallaEnum talla, int numPie, string dNI, System.Collections.Generic.IList<int> grupos, string salud)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_UserRegistrado_inscribirse_curso) ENABLED START*/
        /*
         * // Write here your custom code...
         * int alumnonuevo = 0;
         * AlumnoCEN procesoAlumno = new AlumnoCEN ();
         *
         * alumnonuevo = procesoAlumno.New_ (disponibilidad, salud, peso, talla, numPie, dNI, grupos, p_oid);
         * System.Console.WriteLine ("Alumno inscrito correctamente");
         * return alumnonuevo;*/
        return 0;
        /*PROTECTED REGION END*/
}
}
}
