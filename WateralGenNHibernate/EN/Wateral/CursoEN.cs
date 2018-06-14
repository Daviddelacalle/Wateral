
using System;
// Definición clase CursoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class CursoEN
{
/**
 *	Atributo grupos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos;



/**
 *	Atributo precio
 */
private int precio;



/**
 *	Atributo duracion
 */
private int duracion;



/**
 *	Atributo tipo
 */
private WateralGenNHibernate.Enumerated.Wateral.DeportesEnum tipo;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo valoraciones_curso
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> valoraciones_curso;



/**
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;



/**
 *	Atributo matriculas
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> matriculas;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo id
 */
private int id;






public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> Grupos {
        get { return grupos; } set { grupos = value;  }
}



public virtual int Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Duracion {
        get { return duracion; } set { duracion = value;  }
}



public virtual WateralGenNHibernate.Enumerated.Wateral.DeportesEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> Valoraciones_curso {
        get { return valoraciones_curso; } set { valoraciones_curso = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> Matriculas {
        get { return matriculas; } set { matriculas = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public CursoEN()
{
        grupos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
        valoraciones_curso = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN>();
        matriculas = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.MatriculaEN>();
}



public CursoEN(int id, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, int precio, int duracion, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum tipo, string nombre, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> valoraciones_curso, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> matriculas, string imagen
               )
{
        this.init (Id, grupos, precio, duracion, tipo, nombre, valoraciones_curso, fechaInicio, fechaFin, matriculas, imagen);
}


public CursoEN(CursoEN curso)
{
        this.init (Id, curso.Grupos, curso.Precio, curso.Duracion, curso.Tipo, curso.Nombre, curso.Valoraciones_curso, curso.FechaInicio, curso.FechaFin, curso.Matriculas, curso.Imagen);
}

private void init (int id
                   , System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, int precio, int duracion, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum tipo, string nombre, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> valoraciones_curso, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> matriculas, string imagen)
{
        this.Id = id;


        this.Grupos = grupos;

        this.Precio = precio;

        this.Duracion = duracion;

        this.Tipo = tipo;

        this.Nombre = nombre;

        this.Valoraciones_curso = valoraciones_curso;

        this.FechaInicio = fechaInicio;

        this.FechaFin = fechaFin;

        this.Matriculas = matriculas;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CursoEN t = obj as CursoEN;
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
