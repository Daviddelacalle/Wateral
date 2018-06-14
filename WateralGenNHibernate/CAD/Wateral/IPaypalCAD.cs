
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IPaypalCAD
{
PaypalEN ReadOIDDefault (int id
                         );

void ModifyDefault (PaypalEN paypal);



int New_ (PaypalEN paypal);

void Modify (PaypalEN paypal);


void Destroy (int id
              );
}
}
