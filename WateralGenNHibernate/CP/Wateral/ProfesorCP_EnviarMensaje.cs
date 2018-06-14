
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Profesor_enviarMensaje) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class ProfesorCP : BasicCP
{
public void EnviarMensaje (string p_oid, int p_alumno, string mensaje)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Profesor_enviarMensaje) ENABLED START*/

        IProfesorCAD profesorCAD = null;
        ProfesorCEN profesorCEN = null;
        IMensajeCAD mensajeCAD = null;
        MensajeCEN message = null;


        try
        {
                SessionInitializeTransaction ();
                profesorCAD = new ProfesorCAD (session);
                profesorCEN = new ProfesorCEN (profesorCAD);
                mensajeCAD = new MensajeCAD (session);
                message = new MensajeCEN (mensajeCAD);
                int m = message.New_ (p_alumno, p_oid, mensaje, System.DateTime.Now);
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
