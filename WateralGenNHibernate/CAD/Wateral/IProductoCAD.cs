
using System;
using WateralGenNHibernate.EN.Wateral;

namespace WateralGenNHibernate.CAD.Wateral
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProductoEN producto);



int New_ (ProductoEN producto);

void Modify (ProductoEN producto);


void Destroy (int id
              );




ProductoEN ReadOID (int id
                    );


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ProductoEN> FiltrarProductos (string nombre);
}
}
