
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_ValoracionCurso_valorarCurso) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class ValoracionCursoCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.ValoracionCursoEN ValorarCurso (int p_nota, int p_alumno, int p_curso)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_ValoracionCurso_valorarCurso) ENABLED START*/

        IValoracionCursoCAD valoracionCursoCAD = null;
        ValoracionCursoCEN valoracionCursoCEN = null;

        WateralGenNHibernate.EN.Wateral.ValoracionCursoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                valoracionCursoCAD = new ValoracionCursoCAD (session);
                valoracionCursoCEN = new  ValoracionCursoCEN (valoracionCursoCAD);




                int oid;
                //Initialized ValoracionCursoEN
                ValoracionCursoEN valoracionCursoEN;
                valoracionCursoEN = new ValoracionCursoEN ();
                valoracionCursoEN.Nota = p_nota;


                if (p_alumno != -1) {
                        valoracionCursoEN.Alumno = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                        valoracionCursoEN.Alumno.Idalumno = p_alumno;
                }


                if (p_curso != -1) {
                        valoracionCursoEN.Curso = new WateralGenNHibernate.EN.Wateral.CursoEN ();
                        valoracionCursoEN.Curso.Id = p_curso;
                }





                //Call to ValoracionCursoCAD

                oid = valoracionCursoCAD.ValorarCurso (valoracionCursoEN);
                result = valoracionCursoCAD.ReadOIDDefault (oid);



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
