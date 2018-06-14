
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_ValoracionProfesor_valorarProfesor) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class ValoracionProfesorCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN ValorarProfesor (int p_nota, int p_alumno_0, int p_profesor)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_ValoracionProfesor_valorarProfesor) ENABLED START*/

        IValoracionProfesorCAD valoracionProfesorCAD = null;
        ValoracionProfesorCEN valoracionProfesorCEN = null;

        WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN result = null;


        try
        {
                SessionInitializeTransaction ();
                valoracionProfesorCAD = new ValoracionProfesorCAD (session);
                valoracionProfesorCEN = new  ValoracionProfesorCEN (valoracionProfesorCAD);




                int oid;
                //Initialized ValoracionProfesorEN
                ValoracionProfesorEN valoracionProfesorEN;
                valoracionProfesorEN = new ValoracionProfesorEN ();
                valoracionProfesorEN.Nota = p_nota;


                if (p_alumno_0 != -1) {
                        valoracionProfesorEN.Alumno_0 = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                        valoracionProfesorEN.Alumno_0.Idalumno = p_alumno_0;
                }


                if (p_profesor != null) {
                        valoracionProfesorEN.Profesor = new WateralGenNHibernate.EN.Wateral.ProfesorEN ();
                        valoracionProfesorEN.Profesor.Id = p_profesor;
                }

                //Call to ValoracionProfesorCAD

                oid = valoracionProfesorCAD.ValorarProfesor (valoracionProfesorEN);
                result = valoracionProfesorCAD.ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
