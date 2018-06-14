
using System;
// Definición clase ProductoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class ProductoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo valoracionesProducto
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto;



/**
 *	Atributo precio_compra
 */
private double precio_compra;



/**
 *	Atributo precio_alquiler
 */
private double precio_alquiler;



/**
 *	Atributo lineasCesta
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> lineasCesta;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> ValoracionesProducto {
        get { return valoracionesProducto; } set { valoracionesProducto = value;  }
}



public virtual double Precio_compra {
        get { return precio_compra; } set { precio_compra = value;  }
}



public virtual double Precio_alquiler {
        get { return precio_alquiler; } set { precio_alquiler = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> LineasCesta {
        get { return lineasCesta; } set { lineasCesta = value;  }
}





public ProductoEN()
{
        valoracionesProducto = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN>();
        lineasCesta = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.LineaCestaEN>();
}



public ProductoEN(int id, int stock, string nombre, string imagen, string descripcion, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto, double precio_compra, double precio_alquiler, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> lineasCesta
                  )
{
        this.init (Id, stock, nombre, imagen, descripcion, valoracionesProducto, precio_compra, precio_alquiler, lineasCesta);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Stock, producto.Nombre, producto.Imagen, producto.Descripcion, producto.ValoracionesProducto, producto.Precio_compra, producto.Precio_alquiler, producto.LineasCesta);
}

private void init (int id
                   , int stock, string nombre, string imagen, string descripcion, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto, double precio_compra, double precio_alquiler, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> lineasCesta)
{
        this.Id = id;


        this.Stock = stock;

        this.Nombre = nombre;

        this.Imagen = imagen;

        this.Descripcion = descripcion;

        this.ValoracionesProducto = valoracionesProducto;

        this.Precio_compra = precio_compra;

        this.Precio_alquiler = precio_alquiler;

        this.LineasCesta = lineasCesta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
