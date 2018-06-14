

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.Exceptions;

using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;


namespace WateralGenNHibernate.CEN.Wateral
{
/*
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public int New_ (int p_stock, string p_nombre, string p_imagen, string p_descripcion, double p_precio_compra, double p_precio_alquiler)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Stock = p_stock;

        productoEN.Nombre = p_nombre;

        productoEN.Imagen = p_imagen;

        productoEN.Descripcion = p_descripcion;

        productoEN.Precio_compra = p_precio_compra;

        productoEN.Precio_alquiler = p_precio_alquiler;

        //Call to ProductoCAD

        oid = _IProductoCAD.New_ (productoEN);
        return oid;
}

public void Modify (int p_Producto_OID, int p_stock, string p_nombre, string p_imagen, string p_descripcion, double p_precio_compra, double p_precio_alquiler)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Id = p_Producto_OID;
        productoEN.Stock = p_stock;
        productoEN.Nombre = p_nombre;
        productoEN.Imagen = p_imagen;
        productoEN.Descripcion = p_descripcion;
        productoEN.Precio_compra = p_precio_compra;
        productoEN.Precio_alquiler = p_precio_alquiler;
        //Call to ProductoCAD

        _IProductoCAD.Modify (productoEN);
}

public void Destroy (int id
                     )
{
        _IProductoCAD.Destroy (id);
}

public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoCAD.ReadOID (id);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ProductoEN> FiltrarProductos (string nombre)
{
        return _IProductoCAD.FiltrarProductos (nombre);
}
}
}
