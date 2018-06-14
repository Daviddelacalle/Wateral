
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Solicitud_cambio_realizarCambio) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class Solicitud_cambioCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN RealizarCambio (int p_alumno, int p_grupo, int p_grupo_0, Nullable<DateTime> p_Fecha_cambio)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Solicitud_cambio_realizarCambio) ENABLED START*/

        ISolicitud_cambioCAD solicitud_cambioCAD = null;
        Solicitud_cambioCEN solicitud_cambioCEN = null;
        IAlumnoCAD alumnoCAD = null;
        AlumnoCEN alumnoCEN = null;
        IGrupoCAD grupoCAD = null;
        GrupoCEN grupoCEN = null;
        WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN result = null;


        try
        {
                SessionInitializeTransaction ();
                solicitud_cambioCAD = new Solicitud_cambioCAD (session);
                solicitud_cambioCEN = new  Solicitud_cambioCEN (solicitud_cambioCAD);
                alumnoCAD = new AlumnoCAD(session);
                alumnoCEN = new AlumnoCEN(alumnoCAD);
                alumnoCAD = new AlumnoCAD(session);
                alumnoCEN = new AlumnoCEN(alumnoCAD);
                grupoCAD = new GrupoCAD(session);
                grupoCEN = new GrupoCEN(grupoCAD);
                long actuales = alumnoCEN.CuentaAlumnos(p_grupo_0);
                GrupoEN grupaso = grupoCEN.ReadOID(p_grupo_0);
                IList<int> listagrupos = new List<int>();
                if (actuales < grupaso.Maxalumnos)
                {
                    listagrupos.Add(p_grupo_0);
                }
                AlumnoEN alumnocambiador = alumnoCEN.ReadOID(p_alumno);

                alumnoCEN.New_(alumnocambiador.Disponibilidad, alumnocambiador.Salud, alumnocambiador.Peso, alumnocambiador.Talla, alumnocambiador.NumPie, alumnocambiador.DNI,);


                int oid;
                //Initialized Solicitud_cambioEN
                Solicitud_cambioEN solicitud_cambioEN;
                solicitud_cambioEN = new Solicitud_cambioEN ();

                if (p_alumno != -1) {
                        solicitud_cambioEN.Alumno = new WateralGenNHibernate.EN.Wateral.AlumnoEN ();
                        solicitud_cambioEN.Alumno.Idalumno = p_alumno;
                }


                if (p_grupo != -1) {
                        solicitud_cambioEN.Grupo = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                        solicitud_cambioEN.Grupo.Id = p_grupo;
                }


                if (p_grupo_0 != -1) {
                        solicitud_cambioEN.Grupo_0 = new WateralGenNHibernate.EN.Wateral.GrupoEN ();
                        solicitud_cambioEN.Grupo_0.Id = p_grupo_0;
                }

                solicitud_cambioEN.Fecha_cambio = p_Fecha_cambio;

                //Call to Solicitud_cambioCAD

                oid = solicitud_cambioCAD.RealizarCambio (solicitud_cambioEN);
                result = solicitud_cambioCAD.ReadOIDDefault (oid);



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
