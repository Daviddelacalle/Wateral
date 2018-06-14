
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Administrador_validar_cambio) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class AdministradorCP : BasicCP
{
public void Validar_cambio (int solicitud_cambio)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Administrador_validar_cambio) ENABLED START*/

        IAdministradorCAD administradorCAD = null;
        AdministradorCEN administradorCEN = null;
        IAlumnoCAD alumnoCAD = null;
        AlumnoCEN alumnoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                administradorCAD = new AdministradorCAD (session);
                administradorCEN = new  AdministradorCEN (administradorCAD);
                alumnoCAD = new AlumnoCAD(session);
                alumnoCEN = new AlumnoCEN(alumnoCAD);

                Solicitud_cambioCEN solicitud = new Solicitud_cambioCEN();
                Solicitud_cambioEN solici = solicitud.ReadOID(solicitud_cambio);

                AlumnoEN alumnocambio = solici.Alumno;

                alumnoCEN.Destroy(alumnocambio.Idalumno);

                IList<int> nuevogrupo = new List<int>();

                foreach (GrupoEN x in alumnocambio.Grupo)
                {
                    if(alumnocambio.Grupo.)
                }

                solicitud.Modify(solicitud_cambio, true);
                System.Console.WriteLine("Solicitud de cambio validada por el admin");



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Validar_cambio() not yet implemented.");



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


        /*PROTECTED REGION END*/
}
}
}
