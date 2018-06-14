
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_UserRegistrado_identificarse) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class UserRegistradoCEN
{
public bool Identificarse (string p_usuario, string p_contrasenya)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_UserRegistrado_identificarse) ENABLED START*/
        bool result = false;
        UserRegistradoEN en = _IUserRegistradoCAD.ReadOIDDefault (p_usuario);

        if (en.Contrasenya.Equals (Utils.Util.GetEncondeMD5 (p_contrasenya)))
                result = true;

        return result;

        /*PROTECTED REGION END*/
}
}
}
