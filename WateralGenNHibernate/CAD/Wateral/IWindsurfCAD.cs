
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IWindsurfCAD
{
WindsurfEN ReadOIDDefault (int id
                           );

void ModifyDefault (WindsurfEN windsurf);



int New_ (WindsurfEN windsurf);

void Modify (WindsurfEN windsurf);


void Destroy (int id
              );
}
}
