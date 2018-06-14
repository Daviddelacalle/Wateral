
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using WateralGenNHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;


namespace WateralGenNHibernate.CP.Wateral
{
public partial class UserRegistradoCP : BasicCP
{
public UserRegistradoCP() : base ()
{
}

public UserRegistradoCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
