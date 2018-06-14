
using System;
// Definición clase MatriculaEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class MatriculaEN
{
/**
 *	Atributo curso
 */
private WateralGenNHibernate.EN.Wateral.CursoEN curso;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pago
 */
private WateralGenNHibernate.EN.Wateral.PagoEN pago;



/**
 *	Atributo alumno
 */
private WateralGenNHibernate.EN.Wateral.AlumnoEN alumno;






public virtual WateralGenNHibernate.EN.Wateral.CursoEN Curso {
        get { return curso; } set { curso = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.PagoEN Pago {
        get { return pago; } set { pago = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}





public MatriculaEN()
{
}



public MatriculaEN(int id, WateralGenNHibernate.EN.Wateral.CursoEN curso, WateralGenNHibernate.EN.Wateral.PagoEN pago, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno
                   )
{
        this.init (Id, curso, pago, alumno);
}


public MatriculaEN(MatriculaEN matricula)
{
        this.init (Id, matricula.Curso, matricula.Pago, matricula.Alumno);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.CursoEN curso, WateralGenNHibernate.EN.Wateral.PagoEN pago, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno)
{
        this.Id = id;


        this.Curso = curso;

        this.Pago = pago;

        this.Alumno = alumno;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MatriculaEN t = obj as MatriculaEN;
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
