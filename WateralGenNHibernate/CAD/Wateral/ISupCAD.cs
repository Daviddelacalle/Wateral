
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface ISupCAD
{
SupEN ReadOIDDefault (int id
                      );

void ModifyDefault (SupEN sup);



int New_ (SupEN sup);

void Modify (SupEN sup);


void Destroy (int id
              );
}
}
