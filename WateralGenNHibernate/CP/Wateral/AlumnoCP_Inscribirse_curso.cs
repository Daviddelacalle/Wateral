
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Alumno_inscribirse_curso) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class AlumnoCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.AlumnoEN Inscribirse_curso (string p_disponibilidad, string p_salud, int p_peso, WateralGenNHibernate.Enumerated.Wateral.TallaEnum p_talla, int p_numPie, string p_DNI, System.Collections.Generic.IList<int> p_grupos, string p_userRegistrado)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Alumno_inscribirse_curso) ENABLED START*/

        IAlumnoCAD alumnoCAD = null;
        AlumnoCEN alumnoCEN = null;
        IGrupoCAD grupoCAD = null;
        GrupoCEN grupoCEN = null;

        WateralGenNHibernate.EN.Wateral.AlumnoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                alumnoCAD = new AlumnoCAD (session);
                alumnoCEN = new  AlumnoCEN (alumnoCAD);
                grupoCAD = new GrupoCAD (session);
                grupoCEN = new GrupoCEN (grupoCAD);

                IList<long> maxalumnosgrupo = new List<long>();

                GrupoEN posiblefallo = null;
                foreach (int y in p_grupos) {
                        GrupoEN grupoActual = grupoCEN.ReadOID (y);
                        posiblefallo = grupoActual;
                        long maxalu = grupoActual.Maxalumnos;
                        long actuales = alumnoCEN.CuentaAlumnos (y);
                        System.Console.WriteLine ("Maximo -> " + maxalu);
                        System.Console.WriteLine ("Actuales -> " + actuales);
                        if (actuales == maxalu) {
                                throw new Exception ("No cabes en el grupo: " + posiblefallo.Id);
                        }
                }

                MatriculaCEN matricula = new MatriculaCEN ();

                //Initialized AlumnoEN
                AlumnoEN alumnoEN;

                alumnoEN = new AlumnoEN ();
                alumnoEN.Disponibilidad = p_disponibilidad;

                alumnoEN.Salud = p_salud;

                alumnoEN.Peso = p_peso;

                alumnoEN.Talla = p_talla;

                alumnoEN.NumPie = p_numPie;

                alumnoEN.DNI = p_DNI;


                alumnoEN.Grupos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
                if (p_grupos != null) {
                        foreach (int item in p_grupos) {
                                WateralGenNHibernate.EN.Wateral.GrupoEN en = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                                en.Id = item;
                                alumnoEN.Grupos.Add (en);
                        }
                }

                else{
                        alumnoEN.Grupos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
                }


                if (p_userRegistrado != null) {
                        alumnoEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                        alumnoEN.UserRegistrado.Email = p_userRegistrado;
                }

                //Call to AlumnoCAD
                int oid;

                oid = alumnoCAD.Inscribirse_curso (alumnoEN);

                result = alumnoCAD.ReadOIDDefault (oid);
                SessionCommit ();
                System.Console.WriteLine ("El alumno: " + alumnoEN.UserRegistrado.Email + " se ha inscrito con exito en el grupo que deseaba");
                foreach (int x in p_grupos) {
                        GrupoEN grupaso = grupoCEN.ReadOID (x);
                        matricula.New_ (grupaso.Curso.Id, oid);
                }
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
