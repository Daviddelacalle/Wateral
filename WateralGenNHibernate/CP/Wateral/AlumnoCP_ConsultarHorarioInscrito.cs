
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Alumno_consultarHorarioInscrito) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class AlumnoCP : BasicCP
{
public System.Collections.Generic.IList<string> ConsultarHorarioInscrito (int p_oid)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Alumno_consultarHorarioInscrito) ENABLED START*/

        IAlumnoCAD alumnoCAD = null;
        AlumnoCEN alumnoCEN = null;

        IList<string> listahorarios = new List<string>();

        try
        {
                SessionInitializeTransaction ();
                alumnoCAD = new AlumnoCAD (session);
                alumnoCEN = new  AlumnoCEN (alumnoCAD);
                AlumnoEN yo = alumnoCEN.ReadOID (p_oid);
                System.Console.WriteLine ("Tu horario es: ");
                foreach (GrupoEN x in yo.Grupo) {
                        System.Console.WriteLine ("Grupo de: " + x.Curso.Nombre + "-->" + x.Horario);
                        string auxiliar = x.Horario;
                        listahorarios.Add (auxiliar);
                }

                // Write here your custom transaction ...

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }

        return listahorarios;

        /*PROTECTED REGION END*/
}
}
}
