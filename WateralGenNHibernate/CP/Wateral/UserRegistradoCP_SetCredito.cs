
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_UserRegistrado_setCredito) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class UserRegistradoCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.UserRegistradoEN SetCredito (string p_email, string p_usuario, string p_nombre, string p_apellidos, String p_contrasenya, Nullable<DateTime> p_nacimiento, string credito)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_UserRegistrado_setCredito) ENABLED START*/

        IUserRegistradoCAD userRegistradoCAD = null;
        UserRegistradoCEN userRegistradoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                userRegistradoCAD = new UserRegistradoCAD (session);
                userRegistradoCEN = new  UserRegistradoCEN (userRegistradoCAD);

                userRegistradoCEN.Destroy(p_email);
                userRegistradoCEN.New_(p_email,)


                // Write here your custom transaction ...
                

                throw new NotImplementedException ("Method SetCredito() not yet implemented.");



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
