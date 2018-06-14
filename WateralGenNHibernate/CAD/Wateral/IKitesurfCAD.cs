
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IKitesurfCAD
{
KitesurfEN ReadOIDDefault (int id
                           );

void ModifyDefault (KitesurfEN kitesurf);



int New_ (KitesurfEN kitesurf);

void Modify (KitesurfEN kitesurf);


void Destroy (int id
              );
}
}
