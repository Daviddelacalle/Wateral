
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_UserRegistrado_especifica) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class UserRegistradoCP : BasicCP
{
public System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.UserRegistradoEN> Especifica ()
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_UserRegistrado_especifica) ENABLED START*/

        IUserRegistradoCAD userRegistradoCAD = null;
        UserRegistradoCEN userRegistradoCEN = null;

        System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.UserRegistradoEN>  result = null;


        try
        {
                SessionInitializeTransaction ();
                userRegistradoCAD = new UserRegistradoCAD (session);
                userRegistradoCEN = new  UserRegistradoCEN (userRegistradoCAD);




                return userRegistradoCAD.Especifica ();


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
