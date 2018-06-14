
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Alumno_enviarMensaje) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class AlumnoCP : BasicCP
{
public void EnviarMensaje (int p_oid, string p_profesor, string mensaje)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Alumno_enviarMensaje) ENABLED START*/

        IAlumnoCAD alumnoCAD = null;
        AlumnoCEN alumnoCEN = null;
        IMensajeCAD mensajeCAD = null;
        MensajeCEN message = null;



        try
        {
                SessionInitializeTransaction ();
                alumnoCAD = new AlumnoCAD (session);
                alumnoCEN = new  AlumnoCEN (alumnoCAD);
                mensajeCAD = new MensajeCAD (session);
                message = new MensajeCEN (mensajeCAD);
                int m = message.New_ (p_oid, p_profesor, mensaje, System.DateTime.Now);
                System.Console.WriteLine ("Mensaje enviado correctamente");

                MensajeEN enviado = message.ReadOID (m);

                System.Console.WriteLine ("Enviado por: " + enviado.Alumno.UserRegistrado.Email);
                System.Console.WriteLine ("Recibido por: " + enviado.Profesor.Email);
                System.Console.WriteLine ("Mensaje: " + enviado.Mensaje);


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


        /*PROTECTED REGION END*/
}
}
}
