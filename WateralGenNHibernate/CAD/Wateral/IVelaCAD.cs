
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IVelaCAD
{
VelaEN ReadOIDDefault (int id
                       );

void ModifyDefault (VelaEN vela);



int New_ (VelaEN vela);

void Modify (VelaEN vela);


void Destroy (int id
              );
}
}
