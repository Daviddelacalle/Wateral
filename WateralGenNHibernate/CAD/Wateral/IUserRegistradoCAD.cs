
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IUserRegistradoCAD
{
UserRegistradoEN ReadOIDDefault (string email
                                 );

void ModifyDefault (UserRegistradoEN userRegistrado);



string New_ (UserRegistradoEN userRegistrado);

void Modify (UserRegistradoEN userRegistrado);


void Destroy (string email
              );



UserRegistradoEN ReadOID (string email
                          );


System.Collections.Generic.IList<UserRegistradoEN> ReadAll (int first, int size);
}
}
