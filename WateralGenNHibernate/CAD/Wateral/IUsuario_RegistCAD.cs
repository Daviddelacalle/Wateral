
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IUsuario_RegistCAD
{
Usuario_RegistEN ReadOIDDefault (string email
                                 );

void ModifyDefault (Usuario_RegistEN usuario_Regist);



string New_ (Usuario_RegistEN usuario_Regist);

void Modify (Usuario_RegistEN usuario_Regist);


void Destroy (string email
              );




Usuario_RegistEN ReadOID (string email
                          );


System.Collections.Generic.IList<Usuario_RegistEN> ReadAll (int first, int size);
}
}
