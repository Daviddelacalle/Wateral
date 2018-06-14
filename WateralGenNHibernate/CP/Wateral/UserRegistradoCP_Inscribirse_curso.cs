
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_UserRegistrado_inscribirse_curso) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class UserRegistradoCP : BasicCP
{
public int Inscribirse_curso (string p_oid, string disponibilidad, int peso, WateralGenNHibernate.Enumerated.Wateral.TallaEnum talla, int numPie, string dNI, System.Collections.Generic.IList<int> grupos, string salud)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_UserRegistrado_inscribirse_curso) ENABLED START*/

        IUserRegistradoCAD userRegistradoCAD = null;
        UserRegistradoCEN userRegistradoCEN = null;

        int result = -1;


        try
        {
                SessionInitializeTransaction ();
                userRegistradoCAD = new UserRegistradoCAD (session);
                userRegistradoCEN = new  UserRegistradoCEN (userRegistradoCAD);



                // Write here your custom transaction ...

                //ATENCION, HEMOS DE VERIFICAR SI EL GRUPO DONDE SE INSCRIBE EL ALUMNO NO ESTA LLENO
                //Registramos al alumno
                AlumnoCEN inscripcion = new AlumnoCEN ();

                UserRegistradoEN usuario = userRegistradoCEN.ReadOID (p_oid);

                result = inscripcion.New_ (disponibilidad, salud, peso, talla, numPie, dNI, grupos, p_oid);

                System.Console.WriteLine ("Alumno registrado con exito: ");

                //Consultamos los datos desde la propia base de datos
                IAlumnoCAD consultor = new AlumnoCAD (session);
                AlumnoCEN consulta = new AlumnoCEN (consultor);
                AlumnoEN resultado = consulta.ReadOID (result);
                System.Console.WriteLine ("Correo del nuevo alumno: " + resultado.UserRegistrado.Email);
                System.Console.WriteLine ("Disponibilidad del nuevo alumno: " + resultado.Disponibilidad);
                System.Console.WriteLine ("El alumno esta inscrito en los grupos de: ");
                foreach (GrupoEN x in resultado.Grupo) {
                        System.Console.WriteLine (x.Id);
                        System.Console.WriteLine (x.Curso.Nombre);
                }


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
