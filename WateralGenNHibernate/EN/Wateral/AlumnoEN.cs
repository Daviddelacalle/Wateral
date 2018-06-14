
using System;
// Definición clase AlumnoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class AlumnoEN
{
/**
 *	Atributo disponibilidad
 */
private string disponibilidad;



/**
 *	Atributo salud
 */
private string salud;



/**
 *	Atributo peso
 */
private int peso;



/**
 *	Atributo talla
 */
private WateralGenNHibernate.Enumerated.Wateral.TallaEnum talla;



/**
 *	Atributo numPie
 */
private int numPie;



/**
 *	Atributo dNI
 */
private string dNI;



/**
 *	Atributo valoracionesCurso
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> valoracionesCurso;



/**
 *	Atributo valoracionesProfesor
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> valoracionesProfesor;



/**
 *	Atributo solicitudes_cambio
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio;



/**
 *	Atributo grupos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos;



/**
 *	Atributo userRegistrado
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado;



/**
 *	Atributo idalumno
 */
private int idalumno;



/**
 *	Atributo matriculas
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> matriculas;






public virtual string Disponibilidad {
        get { return disponibilidad; } set { disponibilidad = value;  }
}



public virtual string Salud {
        get { return salud; } set { salud = value;  }
}



public virtual int Peso {
        get { return peso; } set { peso = value;  }
}



public virtual WateralGenNHibernate.Enumerated.Wateral.TallaEnum Talla {
        get { return talla; } set { talla = value;  }
}



public virtual int NumPie {
        get { return numPie; } set { numPie = value;  }
}



public virtual string DNI {
        get { return dNI; } set { dNI = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> ValoracionesCurso {
        get { return valoracionesCurso; } set { valoracionesCurso = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> ValoracionesProfesor {
        get { return valoracionesProfesor; } set { valoracionesProfesor = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> Solicitudes_cambio {
        get { return solicitudes_cambio; } set { solicitudes_cambio = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> Grupos {
        get { return grupos; } set { grupos = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN UserRegistrado {
        get { return userRegistrado; } set { userRegistrado = value;  }
}



public virtual int Idalumno {
        get { return idalumno; } set { idalumno = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> Matriculas {
        get { return matriculas; } set { matriculas = value;  }
}





public AlumnoEN()
{
        valoracionesCurso = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN>();
        valoracionesProfesor = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN>();
        solicitudes_cambio = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN>();
        grupos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
        matriculas = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.MatriculaEN>();
}



public AlumnoEN(int idalumno, string disponibilidad, string salud, int peso, WateralGenNHibernate.Enumerated.Wateral.TallaEnum talla, int numPie, string dNI, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> valoracionesCurso, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> valoracionesProfesor, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> matriculas
                )
{
        this.init (Idalumno, disponibilidad, salud, peso, talla, numPie, dNI, valoracionesCurso, valoracionesProfesor, solicitudes_cambio, grupos, userRegistrado, matriculas);
}


public AlumnoEN(AlumnoEN alumno)
{
        this.init (Idalumno, alumno.Disponibilidad, alumno.Salud, alumno.Peso, alumno.Talla, alumno.NumPie, alumno.DNI, alumno.ValoracionesCurso, alumno.ValoracionesProfesor, alumno.Solicitudes_cambio, alumno.Grupos, alumno.UserRegistrado, alumno.Matriculas);
}

private void init (int idalumno
                   , string disponibilidad, string salud, int peso, WateralGenNHibernate.Enumerated.Wateral.TallaEnum talla, int numPie, string dNI, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionCursoEN> valoracionesCurso, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> valoracionesProfesor, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MatriculaEN> matriculas)
{
        this.Idalumno = idalumno;


        this.Disponibilidad = disponibilidad;

        this.Salud = salud;

        this.Peso = peso;

        this.Talla = talla;

        this.NumPie = numPie;

        this.DNI = dNI;

        this.ValoracionesCurso = valoracionesCurso;

        this.ValoracionesProfesor = valoracionesProfesor;

        this.Solicitudes_cambio = solicitudes_cambio;

        this.Grupos = grupos;

        this.UserRegistrado = userRegistrado;

        this.Matriculas = matriculas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AlumnoEN t = obj as AlumnoEN;
        if (t == null)
                return false;
        if (Idalumno.Equals (t.Idalumno))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Idalumno.GetHashCode ();
        return hash;
}
}
}
