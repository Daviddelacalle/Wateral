
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface INoticiaCAD
{
NoticiaEN ReadOIDDefault (int id
                          );

void ModifyDefault (NoticiaEN noticia);



int New_ (NoticiaEN noticia);

void Modify (NoticiaEN noticia);


void Destroy (int id
              );


NoticiaEN ReadOID (int id
                   );


System.Collections.Generic.IList<NoticiaEN> ReadAll (int first, int size);
}
}
