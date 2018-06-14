
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IPaySafeCardCAD
{
PaySafeCardEN ReadOIDDefault (int id
                              );

void ModifyDefault (PaySafeCardEN paySafeCard);



int New_ (PaySafeCardEN paySafeCard);

void Modify (PaySafeCardEN paySafeCard);


void Destroy (int id
              );
}
}
