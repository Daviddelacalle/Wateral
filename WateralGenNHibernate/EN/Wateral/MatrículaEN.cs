
using System;
// Definición clase MatrículaEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class MatrículaEN
{
/**
 *	Atributo alumno
 */
private WateralGenNHibernate.EN.Wateral.AlumnoEN alumno;



/**
 *	Atributo curso
 */
private WateralGenNHibernate.EN.Wateral.CursoEN curso;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pagos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> pagos;






public virtual WateralGenNHibernate.EN.Wateral.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.CursoEN Curso {
        get { return curso; } set { curso = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> Pagos {
        get { return pagos; } set { pagos = value;  }
}





public MatrículaEN()
{
        pagos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.PagoEN>();
}



public MatrículaEN(int id, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, WateralGenNHibernate.EN.Wateral.CursoEN curso, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> pagos
                   )
{
        this.init (Id, alumno, curso, pagos);
}


public MatrículaEN(MatrículaEN matrícula)
{
        this.init (Id, matrícula.Alumno, matrícula.Curso, matrícula.Pagos);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, WateralGenNHibernate.EN.Wateral.CursoEN curso, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> pagos)
{
        this.Id = id;


        this.Alumno = alumno;

        this.Curso = curso;

        this.Pagos = pagos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MatrículaEN t = obj as MatrículaEN;
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
