
using System;
// Definición clase NoticiaEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class NoticiaEN
{
/**
 *	Atributo administrador
 */
private WateralGenNHibernate.EN.Wateral.AdministradorEN administrador;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo noticia
 */
private string noticia;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo titulo
 */
private string titulo;






public virtual WateralGenNHibernate.EN.Wateral.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Noticia {
        get { return noticia; } set { noticia = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}





public NoticiaEN()
{
}



public NoticiaEN(int id, WateralGenNHibernate.EN.Wateral.AdministradorEN administrador, string noticia, string imagen, Nullable<DateTime> fecha, string titulo
                 )
{
        this.init (Id, administrador, noticia, imagen, fecha, titulo);
}


public NoticiaEN(NoticiaEN noticia)
{
        this.init (Id, noticia.Administrador, noticia.Noticia, noticia.Imagen, noticia.Fecha, noticia.Titulo);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.AdministradorEN administrador, string noticia, string imagen, Nullable<DateTime> fecha, string titulo)
{
        this.Id = id;


        this.Administrador = administrador;

        this.Noticia = noticia;

        this.Imagen = imagen;

        this.Fecha = fecha;

        this.Titulo = titulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NoticiaEN t = obj as NoticiaEN;
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
