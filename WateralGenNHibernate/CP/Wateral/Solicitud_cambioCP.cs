
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
public partial class Solicitud_cambioCP : BasicCP
{
public Solicitud_cambioCP() : base ()
{
}

public Solicitud_cambioCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
