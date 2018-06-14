
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string email
                                );

void ModifyDefault (AdministradorEN administrador);



string New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (string email
              );


AdministradorEN ReadOID (string email
                         );


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);
}
}
